using System;
using System.Text.RegularExpressions;
using ExpiredFood_BackEnd.Data;
using ExpiredFood.Mapping;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Endpoints;

public static class FoodEndpoints
{
    const string GetFood = "GetFoodById";

    public static RouteGroupBuilder MapFoodsEndpoints(this WebApplication app){

        var group = app.MapGroup("/foods").WithParameterValidation();

        //Endpoint to list all the Transactions
        group.MapGet("", async (ExpiredFood_BackEndContext dbcontext) => await 
            dbcontext.Foods.Include(f => f.Category)
            .Select(f => f.ToDTO())
            .AsNoTracking()
            .ToListAsync()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id) =>  {

            Food? food = await dbcontext.Foods.Include(t => t.Category)
            .SingleOrDefaultAsync(t => t.FoodId == id);
            return food == null ? Results.NotFound() : Results.Ok(food.ToDTO());
            }
        ).WithName("GetFoodById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", async (ExpiredFood_BackEndContext dbcontext, CreateFoodDTO newfood) => {

           Food foodEntity = newfood.ToEntity();    
           dbcontext.Foods.Add(foodEntity);
           await dbcontext.SaveChangesAsync();

           return Results.CreatedAtRoute(GetFood, new { id = foodEntity.FoodId }, 
           foodEntity.ToResumeDTO());
        });

        //Endpoint to update a specific Transaction
        group.MapPut("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id, UpdateFoodDTO updatefood) => {
            var existingfood = await dbcontext.Foods.FindAsync(id);
            if (existingfood == null) return Results.NotFound();

            dbcontext.Entry(existingfood).CurrentValues.SetValues(updatefood);
            await dbcontext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetFood, new { id = existingfood.FoodId }, existingfood.ToResumeDTO());
        });

        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", async (ExpiredFood_BackEndContext dbcontext, int id) => {
            await dbcontext.Foods.Where(t => t.FoodId == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });

        return group;
    }

}
