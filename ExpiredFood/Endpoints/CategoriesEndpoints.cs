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
    group.MapGet("", (ExpiredFoodContext dbcontext) => 
        dbcontext.Categories.Select(category => category.ToDTO()).AsNoTracking()
    );

    //Endpoint to list an specific Category
    group.MapGet("/{id}", (int id, ExpiredFoodContext DbContext) => {
        Category? category = DbContext.Categories.Find(id);
        return category == null ? Results.NotFound() : Results.Ok(category);
        }
    ).WithName("GetCategoryById");

    //Endpoint to insert a new Category
    group.MapPost("", (CreateCategoryDTO newcategory, ExpiredFoodContext DbContext) => {

    Category categoryEntity = newcategory.toEntity();

    DbContext.Categories.Add(categoryEntity);
    DbContext.SaveChanges();
    

    return Results.CreatedAtRoute(GetCategory, new { id = categoryEntity.CategoryId }, categoryEntity);
  
    });


    //Endpoint to update an existing Category
    group.MapPut("/{id}", (int id, UpdateCategoryDTO updatedcategory, ExpiredFoodContext DbContext) => {
        
        var existingCategory = DbContext.Categories.Find(id);
        if (existingCategory is null) {
            return Results.NotFound();
        }
       
        DbContext.Entry(existingCategory).CurrentValues.SetValues(updatedcategory);
        DbContext.SaveChanges();

        return Results.NoContent();
    });

    //Endpoint to delete an existing Category
    group.MapDelete("/{id}", (int id, ExpiredFoodContext DbContext) => 
    {
    DbContext.Categories.Where(Category => Category.CategoryId == id).ExecuteDelete();
    return Results.NoContent();
        
    });

    return group;

}
};