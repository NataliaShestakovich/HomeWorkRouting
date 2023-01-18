using HomeWorkRouting.DBContext;
using HomeWorkRouting.Repository;
using HomeWorkRouting.Repository.Interfaces;
using HomeWorkRouting.Sevices;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContextFactory<PopulationContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PopulationConnectionString")));

            builder.Services.AddScoped<ObjectRepository>();

            builder.Services.AddScoped<RepositoryService>();

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

            app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "default2",
               pattern: "{country}",
               defaults: new { controller = "Home", action = "Index" });

            app.Run();
        }
    }
}