using ExpiredFood.DTO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<CategoryDTO> categories = [
new(1, "Fruits"),
new(2, "Bread"),
new(3, "Vegetables")
];

app.MapGet("/", () => "Hello World!");

//Endpoint tto list all the Categories
app.MapGet("/categories", () => categories);

app.Run();
