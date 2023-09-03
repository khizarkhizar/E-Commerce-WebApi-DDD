using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity; 
using WebApplication2.Controllers;  
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces; 
using Infrastructure.Data; 
using Infrastructure.Data.Repositories;
using Domain.Categories;
using Domain.Addresses;
using Domain.Items;
using Domain.Orders;
using Infrastructure.Database;
using WebApplication2.Application.BusinessServices;
using WebApplication2.Application.Services;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services
               .AddDbContext<EcomOrderDDDContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));

builder.Services.AddLogging((logging) =>
{
    logging.ClearProviders(); // Clear any default providers
    logging.AddConsole();     // Add the console logger
     
});
 
builder.Services.AddScoped<UnitOfWork>();
builder.Services
                .AddTransient(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
 
//Services Injection
builder.Services.AddScoped<CategoriesService>();

builder.Services.AddScoped<ItemService>();

 builder.Services.AddScoped<AddressesService>();

builder.Services.AddScoped<OrderService>();


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
 