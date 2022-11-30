using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using proyecto_aula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace proyecto_aula
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", Configuration =>
            {
                Configuration.Cookie.Name = "proyecto_aula";
                Configuration.LoginPath = "/Home/LoginBiblio";
                Configuration.LoginPath = "/Home/Login";
                Configuration.AccessDeniedPath = "/Home/AccesoDenegado";

            });
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddDbContext<ContextoBasededatos>(opt =>
            {
            opt.UseSqlServer("Data Source = SQL8003.site4now.net; Initial Catalog = db_a8e91d_myeasybook; User Id = db_a8e91d_myeasybook_admin; Password = _Mcd1cyt13");
                // "Data Source=.;Initial Catalog=Nueva4;Integrated Security=True"
                //Data Source=.;Initial Catalog=NuevaBase3;Integrated Security=True
                //Data Source=GAEL-IVAN740\\SQLEXPRESS01;Initial Catalog=NuevaBase4;Integrated Security=True
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
                    endpoints.MapHub<ChatHub>("/Home");
            });
        }
    }
}
