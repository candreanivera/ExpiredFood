using System;
using System.Text.RegularExpressions;
using ExpiredFood.Data;
using ExpiredFood.Mapping;
using ExpiredFood.DTO;
using ExpiredFood.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Endpoints;

public static class TransactionsEndpoints
{
    const string GetTransaction = "GetTransactionById";

    public static RouteGroupBuilder MapTransactionsEndpoints(this WebApplication app){

        var group = app.MapGroup("/transactions").WithParameterValidation();

        //Endpoint to list all the Transactions
        group.MapGet("", async (ExpiredFoodContext dbcontext) => await
         dbcontext.Transactions.Include(transaction => transaction.User)
        .Include(transaction => transaction.Food)
        .Select(Transaction => Transaction.ToDTO())
        .AsNoTracking()
        .ToListAsync()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", async (ExpiredFoodContext dbcontext, int id) => {
            Transaction? transaction = await dbcontext.Transactions.Include(t => t.User)
            .Include(t => t.Food)
            .SingleOrDefaultAsync(t => t.TransactionId == id);

            return transaction == null ? Results.NotFound() : Results.Ok(transaction.ToDTO());
            }
        ).WithName("GetTransactionById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", async (ExpiredFoodContext dbcontext, CreateTransactionDTO newtransaction) => {

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
        group.MapPut("/{id}", async (ExpiredFoodContext dbcontext, int id, UpdateTransactionDTO updatetransaction) => {
            var existingTransaction = await dbcontext.Transactions.FindAsync(id);
            if (existingTransaction == null) return Results.NotFound();

            dbcontext.Entry(existingTransaction).CurrentValues.SetValues(updatetransaction);
            await dbcontext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetTransaction, new { id = existingTransaction.TransactionId }, 
           existingTransaction.ToResumeDTO());
        });


        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", async (ExpiredFoodContext dbcontext, int id) => {
            await dbcontext.Transactions.Where(t => t.TransactionId == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });

        return group;
    }

}
