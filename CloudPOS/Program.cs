using CloudPOS.DAO;
using CloudPOS.Reports.Common;
using CloudPOS.Services;
using CloudPOS.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();//for storing data AddToCart
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//register the Unit Of Work for all repositories for it.
builder.Services.AddTransient<IItemService, ItemService>();//register the Item domain for curd process
builder.Services.AddTransient<ICategoryService, CategoryService>();//register the category domain for curd process
builder.Services.AddTransient<IBrandService, BrandService>();//register the brand for curd transactions
builder.Services.AddTransient<IStockInComeService, StockInComeService>();//register the StockInCome for curd transactions
builder.Services.AddTransient<ISaleProcessService, SaleProcessService>();//register the SaleProcessService for curd operation of SaleEntity and SaleOrderEntity
builder.Services.AddTransient<IReporting, Reporting>();
var config = builder.Configuration;//create a config object to get the connectionSetting from appSetting.json
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(config.GetConnectionString("DefaultConnectionString")));//getting the connection
//for enable identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();
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
app.UseSession();//for storing addToCart function
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=IndexPublic}/{id?}");
app.MapRazorPages();
app.Run();
