using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Week5Project.Data;
using Week5Project.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<SchoolDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapGet("/", async context =>
{
    if (!context.User.Identity?.IsAuthenticated ?? true)
    {
        context.Response.Redirect("/Identity/Account/Login");
    }
    else
    {
        context.Response.Redirect("/Index");
    }
    await Task.CompletedTask;
});



app.MapRazorPages();
app.Run();