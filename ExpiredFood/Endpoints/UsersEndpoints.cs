using System;
using System.Text.RegularExpressions;
using ExpiredFood.Data;
using ExpiredFood.Mapping;
using ExpiredFood.DTO;
using ExpiredFood.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Endpoints;

public static class UsersEndpoints
{
    const string GetUser = "GetUserById";

    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app){

        var group = app.MapGroup("/users").WithParameterValidation();

        //Endpoint to list all the Transactions
        group.MapGet("", async (ExpiredFoodContext dbcontext) => 
            await dbcontext.Users.Select(user => user.ToDTO())
            .AsNoTracking()
            .ToListAsync()
        );

        //Endpoint to show an especific transaction
        group.MapGet("/{id}", async (ExpiredFoodContext dbcontext, int id) => {

            User? user = await dbcontext.Users.FindAsync(id);
            return user == null ? Results.NotFound() : Results.Ok(user.ToDTO());
            }
        ).WithName("GetUserById");
    

        //Endpoint to insert a new Transaction
        group.MapPost("", async (ExpiredFoodContext dbcontext, CreateUserDTO newuser) => {

           User userEntity = newuser.ToEntity();    
           dbcontext.Users.Add(userEntity);
           await dbcontext.SaveChangesAsync();

           return Results.CreatedAtRoute(GetUser, new { id = userEntity.UserId }, 
           userEntity.ToDTO());
        });

        //Endpoint to update a specific Transaction
        group.MapPut("/{id}", async (ExpiredFoodContext dbcontext, int id, UpdateUserDTO updateuser) => {
            var existinguser = await dbcontext.Users.FindAsync(id);
            if (existinguser == null) return Results.NotFound();

            dbcontext.Entry(existinguser).CurrentValues.SetValues(updateuser);
            await dbcontext.SaveChangesAsync();
            return Results.CreatedAtRoute(GetUser, new { id = existinguser.UserId }, 
           existinguser.ToDTO());
        });

        //Endpoint to delete a specific Transaction
        group.MapDelete("/{id}", async (ExpiredFoodContext dbcontext, int id) => {
            await dbcontext.Users.Where(t => t.UserId == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });

        return group;
    }

}
