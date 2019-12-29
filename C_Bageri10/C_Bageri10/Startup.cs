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
    // konfigurerar applikationen inf�r k�rning
    public class Startup
    {
        // service collection
        // registrera de tj�nster som ska anv�ndas
        // instanser av de olika klasserna skapas h�r
        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            // ska n�s fr�n alla st�llen i applikationen
            // skapar ny instans f�r varje request, f�rsvinner n�r 
            // "request" �r f�rdigbehandlad
            // interface, databaskoppling
            services.AddScoped<IProdukt, MockProduktRepository>();

            // skapar ny instans varje g�ng
            //services.AddTransient

            // skapar en enda instans f�r hela applikationen
            // instansen �teranv�ndes
            //services.AddSingleton()

            // registrera support f�r MVC
            services.AddControllersWithViews();
        }

        // S.k. middleware-komponenter
        // s�tter upp request pipeline
        // komponenter som vill f�nga upp och hantera http-request och producera http-respons
        // komponenterna jobbar i en kedja efter varandra
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // exeption-info, endast f�r utvecklingsmilj� 
                app.UseDeveloperExceptionPage();
            }

            // http.request omdirigeras
            app.UseHttpsRedirection();

            // statiska filer, tex bilder
            // letar under mappen wwwroot
            app.UseStaticFiles();

            // f�rmedla request till r�tt slutstation
            // inkommande request ska dirigeras till en controller
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
                    // f�r att hitta r�tt sida direkt
                    pattern: "{controller=CProdukt}/{action=List}/{id?}");
            });

            // info-medd f�r vanligt f�rekommande fel
            //app.UseStatusCodePages();
        }
    }
}
