var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//register to know related controllers and views
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/me", () => "mr kyaing");
//app.MapGet("/now", () => DateTime.Now);
//app.MapGet("/friends", () => "Mg Mg");
//app.MapGet("/makepay", () => "Payment Successfully");

//register the routing pattern
//localhost:home/index
app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
app.Run();
