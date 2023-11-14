using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Services;
using Microsoft.EntityFrameworkCore;
using BeverlyHillsZoo.Web.Data.Services;

namespace BeverlyHillsZoo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services
            builder.Services.AddScoped<HabitatAirService>();
            builder.Services.AddScoped<HabitatLandService>();
            builder.Services.AddScoped<HabitatWaterService>();
            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddScoped<VisitService>();
            builder.Services.AddScoped<AnimalService>();
            builder.Services.AddScoped<GuideService>();


            builder.Services.AddControllersWithViews();



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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}