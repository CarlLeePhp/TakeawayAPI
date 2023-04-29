using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeawayAPI.Data.Models;
using TakeawayAPI.Data;
using TakeawayAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TakeawayAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add Indentity Support
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add Authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
            GetBytes(builder.Configuration["JwtSettings:SecurityKey"]))
        };
    });

builder.Services.AddAuthorization();

// for cors
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// App Services
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
        .WithOrigins("http://localhost:3000");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
