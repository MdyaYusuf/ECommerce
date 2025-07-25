using ECommerce.DataAccess.Contexts;
using ECommerce.DataAccess.Extensions;
using ECommerce.Models.Entities;
using ECommerce.Service.Extensions;
using ECommerce.WebApi.Middlewares;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromHours(24);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
  opt.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
  opt.User.RequireUniqueEmail = true;
  opt.Password.RequireNonAlphanumeric = false;
  opt.Password.RequireDigit = true;
  opt.Password.RequireLowercase = true;
  opt.Password.RequireUppercase = true;
  opt.Password.RequiredLength = 6;

  opt.Lockout.MaxFailedAccessAttempts = 5;
  opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
  opt.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<BaseDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
