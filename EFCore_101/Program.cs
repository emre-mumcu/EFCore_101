
using EFCore_101.App_Data;
using EFCore_101.App_Data.Context;
using EFCore_101.App_Lib;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        IMvcBuilder mvcBuilder = builder.Services.AddMvc();

        mvcBuilder.AddSessionStateTempDataProvider();

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            mvcBuilder.AddRazorRuntimeCompilation();
        }

        mvcBuilder.AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

        builder.Services.AddDataProtection();

        {   // DbContext:

            // In this type of service registration, connection string is NOT provided to DI.
            // It must be provided in DbContext's OnConfiguring method.
            builder.Services.AddDbContext<AppDbContext>();

            // In this type of service registration, connection string is provided to DI.
            // If DbContext is created by DI, connection string is present in the instance.
            // But if user manually creates DbContext, the connection string must also be provided in DbContext's OnConfiguring method
            // builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString: ""));

            // Manually            
            // builder.Services.AddScoped(x => { return new AppDbContext(); });
        }

        builder.Services.Configure<RazorViewEngineOptions>(options => {
            options.ViewLocationExpanders.Add(new ViewLocationExpander());
        });
    }

    var app = builder.Build();

    App.Instance.WebHostEnvironment = app.Services.GetRequiredService<IWebHostEnvironment>();

    {
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
    }

    await DataSeeder.SeedData(app.Services);

    app.Run();
}
catch (Exception ex)
{
    Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddMvc(); })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure((ctx, app) =>
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Application Error {ex?.Message} {ex.InnerException?.Message}");
            });
        });
    }).Build().Run();
}



public sealed class App
{
    // https://csharpindepth.com/articles/singleton (Sixth version)

    private static readonly Lazy<App> appInstance = new Lazy<App>(() => new App());

    public static App Instance { get { return appInstance.Value; } }

    private App() 
    {
        DataConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("data.json", true)
            .Build();
    }

    public IConfiguration DataConfiguration { get; set; }
    public IWebHostEnvironment WebHostEnvironment { get; set; }
}