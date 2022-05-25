
using DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

string connectionString;
#if DEBUG
connectionString = builder.Configuration.GetConnectionString("LocalConnection");
#endif
builder.Services.AddSqlite<WebStoreContext>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", () => "Hello World!");

app.Run();
