using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebWedding.Models;
using WebWedding.Services;

namespace WebWedding
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
            services.AddDbContext<WebWeddingContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("WebWedding_Konekcija")));
            services.AddRazorPages();
            services.AddSession();

            services.AddMvc();
            services.AddTransient<IProstorRezervisaniService, ProstorRezervisaniService>();
            services.AddTransient<IProstorZakazaniService, ProstorZakazaniService>();
            services.AddTransient<IMuzikaRezervisaniService, MuzikaRezervisaniService>();
            services.AddTransient<IMuzikaZakazaniService, MuzikaZakazaniService>();
            services.AddTransient<IDekoracijaRezervisaniService, DekoracijaRezervisaniService>();
            services.AddTransient<IDekoracijaZakazaniService, DekoracijaZakazaniService>();
            services.AddTransient<IFotografRezervisaniService, FotografRezervisaniService>();
            services.AddTransient<IFotografZakazaniService, FotografZakazaniService>();
            services.AddTransient<IKorisnikService, KorisnikService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IOrganizatorService, OrganizatorService>();
            services.AddTransient<IMeniService, MeniService>();
            services.AddControllers();

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
