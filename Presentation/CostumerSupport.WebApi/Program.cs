using CostummerSupport.Application.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using CostummerSupport.Application.Feature;
using CostummerSupport.Application.Interfaces;
using System.Text;
using MediatR;
using CostumerSupport.WebApi;
using CostummerSupport.Application.Services;
using CostumerSupport.WebApi.Controllers;
using CostumerSupport.Persistence.Context;
using CostumerSupport.Persistence.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddApplicationService(builder.Configuration); 

builder.Services.AddScoped<CostumerSupportContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience=JwtTokenDefaults.ValidAudience,
        ValidIssuer=JwtTokenDefaults.ValidIssuer,
        ClockSkew=TimeSpan.Zero,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true
    };
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
{
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
