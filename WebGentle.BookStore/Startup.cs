using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Data;
using WebGentle.BookStore.Repository;

namespace WebGentle.BookStore
{
    public class Startup
    {
        public readonly IConfiguration configuration = null;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=GGKU4DELL1375" + @"\" + "SQLEXPRESS; Database=BookStore; Integrated Security=True;"));
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(options => {

                options.HtmlHelperOptions.ClientValidationEnabled = false;
            });
#endif

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();



            // Folder other than wwwroot for static files
            /*app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            });*/



            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
                /*endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");*/

                /*endpoints.MapControllerRoute(
                    name: "AboutUs",
                    pattern: "about-us",
                    defaults: new { controller="home", action="index"});*/

            });


            /*app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
            });*/
        }
    }
}
