using CustomerCRUDApp.DAL;
using CustomerCRUDApp.Infrastructure.Middlewares;
using CustomerCRUDApp.Infrastructure.Repositories.Impl;
using CustomerCRUDApp_BAL.Contracts.Interfaces;
using CustomerCRUDApp_BAL.Services;
using CustomerCRUDApp_BAL.Services.Impl;
using CustomerCRUDApp_BAL.UnitofWork;
using CustomerCRUDApp_DAL.AppDbContext;
using CustomerCRUDApp_DAL.Entities;
using CustomerCRUDApp_DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<CustProdRepository>();
builder.Services.AddScoped<ICustProdService, CustProdService>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();

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

app.UseSaveChanges();

app.Run();
