using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleToDoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<ToDoAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ToDoAppDbContext>();

builder.Services.AddRazorPages();   

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Important for Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDoList}/{action=Index}/{id?}");

app.MapRazorPages();  // If using Razor Pages

app.Run();
