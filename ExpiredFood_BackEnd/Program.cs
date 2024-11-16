using ExpiredFood_BackEnd.Data;
using ExpiredFood.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Connection String
var connectionString = builder.Configuration.GetConnectionString("ExpiredFoodContext");
builder.Services.AddSqlServer<ExpiredFood_BackEndContext>(connectionString);

var app = builder.Build();

app.Services.InitializeDb();

app.MapGet("/", () => "Weeeena po!");
app.MapCategoriesEndpoints();
app.MapTransactionsEndpoints();
app.MapFoodsEndpoints();
app.MapUsersEndpoints();

app.Run();
