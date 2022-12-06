using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. //Order doesn;t matter up here

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Configure the HTTP request pipeline.
// Middleware Section
// app.UseHttpsRedirection();

//Order very important below!!

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseAuthentication(); //Asks do you have a valid token?

app.UseAuthorization(); //What are you allowed to do?

app.MapControllers();

app.Run();
