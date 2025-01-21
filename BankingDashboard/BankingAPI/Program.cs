using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using BankingAPI.Helper;
using BankingAPI.Contracts.BusinessLogic;
using BankingAPI.Contracts.Database;
using BankingAPI.Database;
using BankingAPI.BusinessLogic;
using BankingAPI.BusinessLogic.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

#region DataControllers
builder.Services.AddScoped<ILoginDAL, LoginDAL>();
builder.Services.AddScoped<IFundTransferDAL, FundTransferDAL>();
builder.Services.AddScoped<IBankingDashboardDAL, BankingDashboardDAL>();
#endregion

#region BlControllers
builder.Services.AddScoped<ILoginBL, LoginBL>();
builder.Services.AddScoped<IFundTransferBL, FundTransferBL>();
builder.Services.AddScoped<IBankingDashboardBL, BankingDashboardBL>();
#endregion

builder.Services.AddSwaggerGen();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication("Jwt")
    .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>("Jwt", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
