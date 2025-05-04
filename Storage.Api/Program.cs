using FluentValidation;
using Storage.Api.Models;
using Storage.Api.Services;
using Storage.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductsBatchesService, ProductsBatchesService>();
builder.Services.AddScoped<IValidator<ProductsBatch>, ProductsBatchesValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();