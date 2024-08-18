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
        group.MapGet("", (ExpiredFoodContext dbcontext) =>  
        dbcontext.Transactions.Include(transaction => transaction.User)
        .Include(transaction => transaction.Food)
        .Select(Transaction => Transaction.ToDTO())
        .AsNoTracking()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", (ExpiredFoodContext dbcontext, int id)=>{

            Transaction? transaction = dbcontext.Transactions.Include(t => t.User)
            .Include(t => t.Food)
            .SingleOrDefault(t => t.TransactionId == id);

            return transaction == null ? Results.NotFound() : Results.Ok(transaction.ToDTO());
            }
        ).WithName("GetTransactionById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", (ExpiredFoodContext dbcontext, CreateTransactionDTO newtransaction) => {

           Transaction transactionentity = newtransaction.ToEntity();    
           dbcontext.Transactions.Add(transactionentity);
           dbcontext.SaveChanges();

           return Results.CreatedAtRoute(GetTransaction, new { id = transactionentity.TransactionId }, 
           transactionentity.ToResumeDTO());
        });

        //Endpoint to update a specific Transaction
        group.MapPut("/{id}", (ExpiredFoodContext dbcontext, int id, UpdateTransactionDTO updatetransaction) => {
            var existingTransaction = dbcontext.Transactions.Find(id);
            if (existingTransaction == null) return Results.NotFound();

            dbcontext.Entry(existingTransaction).CurrentValues.SetValues(updatetransaction);
            dbcontext.SaveChanges();
            return Results.CreatedAtRoute(GetTransaction, new { id = existingTransaction.TransactionId }, 
           existingTransaction.ToResumeDTO());
        });

        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", (ExpiredFoodContext dbcontext, int id) => {
            dbcontext.Transactions.Where(t => t.TransactionId == id).ExecuteDelete();
            
            return Results.NoContent();
        });

        return group;
    }

}
