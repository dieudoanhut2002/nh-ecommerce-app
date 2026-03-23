using Ecommerce.API.ExceptionHandlers;
using Ecommerce.Application;
using Ecommerce.Application.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddApplication();

builder.Services.AddExceptionHandler<FluentValidationExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();

app.Run();
