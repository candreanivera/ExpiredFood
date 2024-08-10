using ExpiredFood.DTO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<CategoryDTO> categories = [
new(1, "Fruits"),
new(2, "Bread"),
new(3, "Vegetables")
];

app.MapGet("/", () => "Hello World!");

//Endpoint to list all the Categories
app.MapGet("/categories", () => categories);

//Endpoint to list an specific Category
app.MapGet("/categories/{id}", (int id) => categories.Find(x => x.Id_Category == id)).WithName("GetCategoryById");

//Endpoint to insert a new Category
app.MapPost("/categories", (CreateCategoryDTO newcategory) => {
    CategoryDTO category = new(
        categories.Count + 1,
        newcategory.Name
    );
    categories.Add(category);

    return Results.CreatedAtRoute("GetCategoryById", new { id = category.Id_Category }, category);
});


app.MapPut("/categories/{id}", (int id, UpdateCategoryDTO category) => {
    var index = categories.FindIndex(x => x.Id_Category == id);
    if (index == -1) {
        return Results.NotFound();
    }

    categories[index] = new CategoryDTO(
        id, 
        category.Name);

    return Results.NoContent();
});

app.MapDelete("/categories/{id}", (int id) => 
{
  categories.RemoveAll(x => x.Id_Category == id);
  return Results.NoContent();
    
});

app.Run();
