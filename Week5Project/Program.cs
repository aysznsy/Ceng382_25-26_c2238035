using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Week5Project.Data; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbConnection")));

var app = builder.Build();


app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

// Razor Pages yönlendirmesini ekleyin
app.MapRazorPages();

// Uygulamayı başlatın
app.Run();
