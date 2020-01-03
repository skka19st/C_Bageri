using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using C_Bageri30.Models;

namespace C_Bageri30
{
    // konfigurerar applikationen inför körning
    public class Startup
    {
        // används för databas (Entity Framework)
        public IConfiguration Configuration { get; }

        // construktor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // service collection, dependency injection
        // registrera de tjänster som ska användas
        // instanser av de olika klasserna skapas här
        public void ConfigureServices(IServiceCollection services)
        {
            // databas-konfigurering
            // registrering av databas
            // specificerar vilken databas (Entity Framework)
            // <AppDbContext> = Model-klass för databasen
            // GetConnectionString hämtar info från appsettings.json

            services.AddDbContext<AppDatabase>(options =>
                options.UseSqlServer(Configuration.GetConnectionString
                    ("DefaultConnection")));

            // funktion för identifiering
            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDatabase>();

            // ska nås från alla ställen i applikationen
            // skapar ny instans för varje request, försvinner när 
            // "request" är färdigbehandlad
            // interface, databaskoppling
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<IContact, ContactRepository>();
            services.AddScoped<ICommentary, CommentaryRepository>();
            services.AddScoped<IGrades, GradesRepository>();

            // RepositoryMock är testdata
            //services.AddScoped<IProduct, ProductRepositoryMock>();
            //services.AddScoped<IContact, ContactRepositoryMock>();

            // skapar ny instans varje gång
            //services.AddTransient

            // skapar en enda instans för hela applikationen
            // instansen återanvändes
            //services.AddSingleton()

            // registrera support för MVC
            services.AddControllersWithViews();

            // för att använda sessions
            //services.AddHttpContextAccessor();
            //services.AddSession();

            // behövs för identifieringsfunktion
            services.AddRazorPages();
        }

        // S.k. middleware-komponenter
        // sätter upp request pipeline
        // komponenter som vill fånga upp och hantera http-request  
        // och producera http-respons
        // komponenterna jobbar i en kedja efter varandra
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

            // request ska dirigeras till: controller + action-metod
            app.UseRouting();

            // identifiering, inloggning
            //app.UseAuthentication();

            // håller koll på olika behörighetsnivåer/typer
            //app.UseAuthorization();

            // Om ingen slutstation har begärts visas hemsidan
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    // 3:e parameter-namn samma som i action-metoden
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // endpoint för identifieringsfunktioner
                //endpoints.MapRazorPages();
            });

            // info-medd för vanligt förekommande fel
            //app.UseStatusCodePages();
        }
    }
}
