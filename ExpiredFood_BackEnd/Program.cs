using ExpiredFood.Data;
using ExpiredFood.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//Connection String
var connectionString = builder.Configuration.GetConnectionString("ExpiredFood");
builder.Services.AddSqlite<ExpiredFoodContext>(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapCategoriesEndpoints();
app.MapTransactionsEndpoints();
app.MapFoodsEndpoints();
app.MapUsersEndpoints();

app.Run();
