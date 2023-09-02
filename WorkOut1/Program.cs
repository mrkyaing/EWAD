var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//register to know related controllers and views
var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
