using System;
using System.Text.RegularExpressions;
using ExpiredFood_BackEnd.Data;
using ExpiredFood.Mapping;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Endpoints;

public static class TransactionsEndpoints
{
    const string GetTransaction = "GetTransactionById";

    public static RouteGroupBuilder MapTransactionsEndpoints(this WebApplication app){

        var group = app.MapGroup("/transactions").WithParameterValidation();
     
        //Endpoint to list all the Transactions
        group.MapGet("", async (ExpiredFood_BackEndContext dbcontext) => await
         dbcontext.Transactions.Include(transaction => transaction.User)
        .Include(transaction => transaction.Category)
        .Select(Transaction => Transaction.ToDTO())
        .AsNoTracking()
        .ToListAsync()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id) => {
            Transaction? transaction = await dbcontext.Transactions.Include(t => t.User)
            .Include(t => t.Category)
            .SingleOrDefaultAsync(t => t.TransactionId == id);

            return transaction == null ? Results.NotFound() : Results.Ok(transaction.ToDTO());
            }
        ).WithName("GetTransactionById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", async (ExpiredFood_BackEndContext dbcontext, CreateTransactionDTO newtransaction) => {

           Transaction transactionentity = newtransaction.ToEntity();    
           dbcontext.Transactions.Add(transactionentity);
           try{
           await dbcontext.SaveChangesAsync();

           return Results.CreatedAtRoute(GetTransaction, new { id = transactionentity.TransactionId }, 
           transactionentity.ToResumeDTO());
           }
           catch (Exception){
               return Results.BadRequest("Errorrrrrr");
           }
        });

        //Endpoint to update a specific Transaction
        group.MapPut("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id, UpdateTransactionDTO updatetransaction) => {
            var existingTransaction = await dbcontext.Transactions.FindAsync(id);
            if (existingTransaction == null) return Results.NotFound();

            dbcontext.Entry(existingTransaction).CurrentValues.SetValues(updatetransaction);
            await dbcontext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetTransaction, new { id = existingTransaction.TransactionId }, 
           existingTransaction.ToResumeDTO());
        });


        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id) => {
            await dbcontext.Transactions.Where(t => t.TransactionId == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });

        return group;
    }

}
