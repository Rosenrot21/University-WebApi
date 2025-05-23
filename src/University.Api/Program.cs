using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using University.Application;
using University.Infrastructure;
using University.Persistence.UniversityDb;
using WebApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCustomExceptionHandler(app.Environment);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



