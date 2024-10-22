using BookStore.BusinessLogic.Books.Commands;
using BookStore.BusinessLogic.Tags.Commands;
using BookStore.DAL.DbContexts;
using BookStore.DAL.Frameworks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("book")).AddInterceptors(new AddAuditInterceptor()));

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateTagHandler).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateBookHandler).Assembly));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
