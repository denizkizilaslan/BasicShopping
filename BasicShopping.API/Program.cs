using BasicShopping.API.Utilities.Extensions;
using BasicShopping.Business.Abstract;
using BasicShopping.Business.Concrete;
using BasicShopping.DataAccess.MongoDB.Abstract;
using BasicShopping.DataAccess.MongoDB.Concrete;
using BasicShopping.DataAccess.Redis.Abstract;
using BasicShopping.DataAccess.Redis.Concrete;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration;
Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, ProductMongoDbDal>();

builder.Services.AddTransient<IBasketRepository, RedisBasketRepository>();

builder.Services.AddMongoDbSettings(Configuration);
builder.Services.AddSingleton(sp => sp.ConfigureRedis(Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
