global using AspDotNetCoreEmpty.ViewModels;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Microsoft.AspNetCore.Razor.TagHelpers;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using System;
global using System.Collections.Generic;
global using System.Linq;
using AspDotNetCoreEmpty.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace AspDotNetCoreEmpty;

public class Program
{
    const string conStr = "ConnectionStrings:BethanysPieShopDbContextConnection";

    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        string connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");
        
        builder.Services
            .AddDbContext<BethanysPieShopDbContext>(
                options => options.UseSqlServer(connectionString))
            .AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<BethanysPieShopDbContext>();

        builder.Services.AddRazorPages();
        builder.Services.AddRazorComponents(options => options.DetailedErrors = builder.Environment.IsDevelopment());
        builder.Services
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IPieRepository, PieRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp))
            .AddSession()
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            .AddHttpContextAccessor()
            .AddDbContext<BethanysPieShopDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration[conStr]);
            })
            .AddDatabaseDeveloperPageExceptionFilter()
            .AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        WebApplication app = builder.Build();
        app
            .UseStaticFiles()
            .UseSession()
            .UseAuthentication()
            .UseAntiforgery()
            .UseHttpsRedirection()
            .UseAuthorization();
        
        if(app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
            app.UseExceptionHandler("/Error");
        }
        
        app.MapDefaultControllerRoute();
        app.MapRazorPages();

        //app.MapControllerRoute("default1", "{controller=Homet}/{action=Index}/{id?}");
        //DbInitializer.Seed(app);
        app.Run();
    }

    /*/// <summary>
    /// Debug attempt
    /// </summary>
    /// <param name="text">text to print out</param>
    [Conditional("debug")]
    public static void WriteColorLine(string text)
    {
        var currentBgColor = Console.BackgroundColor;
        var currentTextColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(text);
        Console.ForegroundColor = currentTextColor;
        Console.BackgroundColor = currentBgColor;
    }*/
}