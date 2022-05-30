
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain.Infrastracture;
using Domain.Interfaces;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString;
#if DEBUG
connectionString = builder.Configuration.GetConnectionString("LocalConnection");
#endif

//DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddSqlite<WebStoreContext>(connectionString);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseStaticFiles();
app.UseDefaultFiles();

app.MapControllers();

app.Run();
