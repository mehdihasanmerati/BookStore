using AAASecurity.Infrastructure;
using AAASecurity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AAADbContext>
       (options => options.UseSqlServer(builder.Configuration.GetConnectionString("identity")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(c =>
{
    // manage structure of password and emil
    c.Password.RequiredLength = 6;
    c.User.RequireUniqueEmail = true;

    c.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    c.Lockout.MaxFailedAccessAttempts = 3;
    c.Lockout.AllowedForNewUsers = true;

}).AddEntityFrameworkStores<AAADbContext>().AddPasswordValidator<UserNameInPasswordValidator>()
                                           .AddPasswordValidator<InvalidPassword<IdentityUser>>()
                                           .AddUserValidator<CustomUserValidator>();


builder.Services.AddAuthorization(c => c.AddPolicy("isAdmin", pb => pb.RequireRole("Admin")
                                        .RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name","hoda")));

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Account/LogIn", "");
});


var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
