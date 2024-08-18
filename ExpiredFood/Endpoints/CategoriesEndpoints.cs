using System;
using ExpiredFood.Data;
using ExpiredFood.DTO;
using ExpiredFood.Entities;
using ExpiredFood.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ExpiredFood.Endpoints;

public static class CategoriesEndpoints
{
    
//Definition of a constant
const string GetCategory = "GetCategoryById";

//This methods extends from WebApplication and returns RouteGroupBuilder
public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
{
    var group = app.MapGroup("/categories").WithParameterValidation();

    //Endpoint to list all the Categories
    group.MapGet("", async (ExpiredFoodContext dbcontext) => await
        dbcontext.Categories.Select(category => category.ToDTO()).AsNoTracking().ToListAsync());

    //Endpoint to list an specific Category
    group.MapGet("/{id}", async (int id, ExpiredFoodContext DbContext) => {
        Category? category = await DbContext.Categories.FindAsync(id);
        return category is null ? Results.NotFound() : Results.Ok(category);
        }
    ).WithName("GetCategoryById");


    //Endpoint to insert a new Category
    group.MapPost("", async (CreateCategoryDTO newcategory, ExpiredFoodContext DbContext) => {
    Category categoryEntity = newcategory.toEntity();
    DbContext.Categories.Add(categoryEntity);
    await DbContext.SaveChangesAsync();
    return Results.CreatedAtRoute(GetCategory, new { id = categoryEntity.CategoryId }, categoryEntity);
  
    });


    //Endpoint to update an existing Category
    group.MapPut("/{id}", async (int id, UpdateCategoryDTO updatedcategory, ExpiredFoodContext DbContext) => {
        
        var existingCategory = await DbContext.Categories.FindAsync(id);
        if (existingCategory is null) {
            return Results.NotFound();
        }
       
        DbContext.Entry(existingCategory).CurrentValues.SetValues(updatedcategory);
        await DbContext.SaveChangesAsync();

        return Results.NoContent();
    });

    //Endpoint to delete an existing Category
    group.MapDelete("/{id}", async (int id, ExpiredFoodContext DbContext) => 
    {
    await DbContext.Categories.Where(Category => Category.CategoryId == id).ExecuteDeleteAsync();
    return Results.NoContent();
        
    });

    return group;

}
};