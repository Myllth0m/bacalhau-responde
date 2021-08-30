using System;
using BacalhauResponde.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BacalhauResponde
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(opcoes =>
            {
                opcoes.CheckConsentNeeded = contexto => true;
                opcoes.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BacalhauRespondeContexto>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<BacalhauRespondeContexto>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opcoes =>
            {
                opcoes.Cookie.HttpOnly = true;
                opcoes.ExpireTimeSpan = TimeSpan.FromDays(1);
                opcoes.LoginPath = new PathString("/Autenticacao/Entrar");
                opcoes.LogoutPath = new PathString("/Autenticacao/Sair");
                opcoes.AccessDeniedPath = new PathString("/Autenticacao/AcessoNegado");
                opcoes.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.Password.RequireDigit = true;
                opcoes.Password.RequireLowercase = false;
                opcoes.Password.RequireNonAlphanumeric = false;
                opcoes.Password.RequireUppercase = false;
                opcoes.Password.RequiredLength = 6;
            });

            services.Configure<CookieTempDataProviderOptions>(opcoes =>
            {
                opcoes.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Autenticacao}/{action=Entrar}");
            });
        }
    }
}
