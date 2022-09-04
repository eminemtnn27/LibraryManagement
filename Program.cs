
using BilgiKutuphanesiWebApp.Data;
using BilgiKutuphanesiWebApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

 
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BilgiContext>(options=>options.UseSqlServer(connectionString));
 
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<DbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("BilgiKutuphanesiWebApp"));
    
//});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=List}");///*/{id?}*/
});

app.MapRazorPages();

app.Run();
