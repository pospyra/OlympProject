using Contracts.Animal;
using Microsoft.OpenApi.Models;
using Registrar;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Olymp Project Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
});

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
