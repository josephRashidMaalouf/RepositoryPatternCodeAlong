using Application.Interfaces;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPeopleService, PeoplePeopleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/people", async (IPeopleService service) => await service.GetAllAsync());
app.MapPost("/people", async (IPeopleService service, AddPersonModel model) => await service.AddAsync(model));

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();



app.Run();

