using ExpiredFood.DTO;
using ExpiredFood.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapCategoriesEndpoints();

app.Run();
