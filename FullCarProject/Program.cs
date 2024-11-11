using Entity.EntityContext;
using EntityContext.DataSettings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using Repository.IGenericRepository;

namespace FullCarProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            IConfiguration configuration = builder.Configuration;
            configuration.DataSettingClassLocalHostConnection();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(m =>
            {
                m.LoginPath = "/Home/Index";
            });

            builder.Services.AddDbContext<DbEntityContext>(
                dbContextOptions => dbContextOptions
                  .UseNpgsql(Settings.ConnectionString));
            
            builder.Services.AddScoped(typeof(IFullRepository<>), typeof(FullRepository<>));

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
