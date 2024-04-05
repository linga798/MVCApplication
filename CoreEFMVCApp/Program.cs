using CoreEFMVCApp.Data;
using CoreEFMVCApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreEFMVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Register DbContext
            var connectionString = builder.Configuration.GetConnectionString("EmpMngtConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //Register employee service
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Register department service
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

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
            app.MapControllerRoute(
        name: "catch-all",
        pattern: "{*url}",
        defaults: new { controller = "Employee", action = "Add" } // This will route unmatched URLs to the Add action in the Employee controller
    );

                

            app.Run();
        }
    }
}
