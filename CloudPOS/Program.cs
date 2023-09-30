using CloudPOS.DAO;
using CloudPOS.Services;
using CloudPOS.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//register the Unit Of Work
builder.Services.AddTransient<IItemService, ItemService>();//register the Item domain for curd process
builder.Services.AddTransient<ICategoryService, CategoryService>();//register the category domain for curd process
builder.Services.AddTransient<IBrandService, BrandService>();//register the brand for curd transactions
var config = builder.Configuration;//create a config object to get the connectionSetting from appSetting.json
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(config.GetConnectionString("DefaultConnectionString")));//getting the connection
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
