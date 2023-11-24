using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClimeiMvc.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<climei_mvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("climei_mvcContext") ?? throw new InvalidOperationException("Connection string 'climei_mvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
