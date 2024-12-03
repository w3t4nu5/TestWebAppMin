using TestWebAppMin.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddBusinessLogic();
builder.Services.AddDataAccess();

var app = builder.Build();
app.MapControllers();

app.Run();
