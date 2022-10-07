using Microsoft.AspNetCore.Mvc.Razor;
using mvc.Services;

var builder = WebApplication.CreateBuilder(args);
//

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>{
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // options.ViewLocationFormats.Add("/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
    // {0} -> ten Action
    // {1} -> ten COntroller
    // {2} -> ten Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" +  RazorViewEngine.ViewExtension);
   
});
//builder.Services.AddSingleton<ProductService>();
//builder.Services.AddSingleton<ProductService, ProductService>();
//builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
//builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    // Xac dinh danh tinh
app.UseAuthorization();     // Xac thuc quyen truy cap

//URL: {controller}/{action}/{id}
//Abc/Xyz => Controller = Abc, goi method Xyz
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();



app.Run();
