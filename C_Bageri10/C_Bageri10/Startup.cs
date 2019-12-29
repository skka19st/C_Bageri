using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using C_Bageri_10.Models;

namespace C_Bageri_10
{
    // konfigurerar applikationen inför körning
    public class Startup
    {
        // service collection
        // registrera de tjänster som ska användas
        // instanser av de olika klasserna skapas här
        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            // ska nås från alla ställen i applikationen
            // skapar ny instans för varje request, försvinner när 
            // "request" är färdigbehandlad
            // interface, databaskoppling
            services.AddScoped<IProdukt, MockProduktRepository>();

            // skapar ny instans varje gång
            //services.AddTransient

            // skapar en enda instans för hela applikationen
            // instansen återanvändes
            //services.AddSingleton()

            // registrera support för MVC
            services.AddControllersWithViews();
        }

        // S.k. middleware-komponenter
        // sätter upp request pipeline
        // komponenter som vill fånga upp och hantera http-request och producera http-respons
        // komponenterna jobbar i en kedja efter varandra
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // exeption-info, endast för utvecklingsmiljö 
                app.UseDeveloperExceptionPage();
            }

            // http.request omdirigeras
            app.UseHttpsRedirection();

            // statiska filer, tex bilder
            // letar under mappen wwwroot
            app.UseStaticFiles();

            // förmedla request till rätt slutstation
            // inkommande request ska dirigeras till en controller
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    // för att hitta rätt sida direkt
                    pattern: "{controller=CProdukt}/{action=List}/{id?}");
            });

            // info-medd för vanligt förekommande fel
            //app.UseStatusCodePages();
        }
    }
}
