using TaskFour.Models;
using TaskFour;

internal class Program
{
    private static void Main(string[] args)
    {
        var _builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        _builder.Services.AddControllersWithViews();
        _builder.Services.AddScoped<IRepository<PizzaModel>, Repository>();

        _builder.Logging.ClearProviders();
        _builder.Logging.AddConsole();
        _builder.Logging.AddFile("C:/Temp/TestProject/app.log");

        var app = _builder.Build();

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

        app.UseAuthorization();



        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}