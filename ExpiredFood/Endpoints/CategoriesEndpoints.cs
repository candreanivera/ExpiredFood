using System;
using ExpiredFood.DTO;

namespace ExpiredFood.Endpoints;

public static class CategoriesEndpoints
{
    static List<CategoryDTO> categories = [
        new(1, "Fruits"),
        new(2, "Bread"),
        new(3, "Vegetables")
    ];
    
//This methods extends from WebApplication and returns RouteGroupBuilder
public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
{
    var group = app.MapGroup("/categories");

    //Endpoint to list all the Categories
    group.MapGet("", () => categories);

    //Endpoint to list an specific Category
    group.MapGet("/{id}", (int id) => categories.Find(x => x.Category_Id == id)).
    WithName("GetCategoryById");

    //Endpoint to insert a new Category
    group.MapPost("", (CreateCategoryDTO newcategory) => {
        CategoryDTO category = new(
            categories.Count + 1,
            newcategory.Name
        );
        categories.Add(category);

        return Results.CreatedAtRoute("GetCategoryById", new { id = category.Category_Id }, category);
    });


    group.MapPut("/{id}", (int id, UpdateCategoryDTO category) => {
        var index = categories.FindIndex(x => x.Category_Id == id);
        if (index == -1) {
            return Results.NotFound();
        }

        categories[index] = new CategoryDTO(
            id, 
            category.Name);

        return Results.NoContent();
    });

    group.MapDelete("/{id}", (int id) => 
    {
    categories.RemoveAll(x => x.Category_Id == id);
    return Results.NoContent();
        
    });

    return group;

}
};