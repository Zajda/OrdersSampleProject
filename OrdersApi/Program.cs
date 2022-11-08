using ApiSampleProject.DbContexts;
using ApiSampleProject.Extensions;
using ApiSampleProject.Repositories;
using ApiSampleProject.Repositories.Interfaces;
using ApiSampleProject.Services;
using ApiSampleProject.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register repositories and DbContext
builder.Services.AddDbContext<OrdersSampleDbContext>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

// Register services
builder.Services.AddScoped<IItemsService, ItemsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "SampleApi", Version = "v1"}); });

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