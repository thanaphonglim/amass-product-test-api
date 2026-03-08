using AmassTest.Api.Endpoints;
using AmassTest.Application.Features.Products.CreateProduct;
using AmassTest.Application.Features.Products.DeleteProduct;
using AmassTest.Application.Features.Products.GetProducts;
using AmassTest.Application.Interfaces;
using AmassTest.Infrastructure.Data.AppDbContext;
using AmassTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<GetProductsHandler>();
builder.Services.AddScoped<DeleteProductHandler>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AmassTestDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/products").MapProductEndpoints();
app.Run();
