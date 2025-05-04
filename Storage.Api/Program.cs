using FluentValidation;
using Storage.Core.Models;
using Storage.Database.Extensions;
using Storage.Api.Validators;
using Storage.Api.HostedServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IProductsBatchesService, ProductsBatchesService>(); // for launch without database
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IValidator<ProductsBatch>, ProductsBatchesValidator>();

builder.Services.AddHostedService<DailyReportBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();