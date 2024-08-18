using System;
using System.Text.RegularExpressions;
using ExpiredFood.Data;
using ExpiredFood.Mapping;
using ExpiredFood.DTO;
using ExpiredFood.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Endpoints;

public static class FoodEndpoints
{
    const string GetFood = "GetFoodById";

    public static RouteGroupBuilder MapFoodsEndpoints(this WebApplication app){

        var group = app.MapGroup("/foods").WithParameterValidation();

        //Endpoint to list all the Transactions
        group.MapGet("", (ExpiredFoodContext dbcontext) =>  
            dbcontext.Foods.Include(f => f.Category)
            .Select(f => f.ToDTO())
            .AsNoTracking()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", (ExpiredFoodContext dbcontext, int id)=>{

            Food? food = dbcontext.Foods.Include(t => t.Category)
            .SingleOrDefault(t => t.FoodId == id);
            return food == null ? Results.NotFound() : Results.Ok(food.ToDTO());
            }
        ).WithName("GetFoodById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", (ExpiredFoodContext dbcontext, CreateFoodDTO newfood) => {

           Food foodEntity = newfood.ToEntity();    
           dbcontext.Foods.Add(foodEntity);
           dbcontext.SaveChanges();

           return Results.CreatedAtRoute(GetFood, new { id = foodEntity.FoodId }, 
           foodEntity.ToResumeDTO());
        });

        //Endpoint to update a specific Transaction
        group.MapPut("/{id}", (ExpiredFoodContext dbcontext, int id, UpdateFoodDTO updatefood) => {
            var existingfood = dbcontext.Foods.Find(id);
            if (existingfood == null) return Results.NotFound();

            dbcontext.Entry(existingfood).CurrentValues.SetValues(updatefood);
            dbcontext.SaveChanges();
            return Results.CreatedAtRoute(GetFood, new { id = existingfood.FoodId }, 
           existingfood.ToResumeDTO());
        });

        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", (ExpiredFoodContext dbcontext, int id) => {
            dbcontext.Foods.Where(t => t.FoodId == id).ExecuteDelete();
            
            return Results.NoContent();
        });

        return group;
    }

}
