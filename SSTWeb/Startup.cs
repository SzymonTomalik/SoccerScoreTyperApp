using EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSTDataAccessLibrary.DataAccess;
using SSTDataAccessLibrary.Models;
using SSTWeb.CustomTokenProviders;
using SSTWeb.CustomValidators;
using SSTWeb.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSTWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddDbContext<SSTContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SSTDB")));

            services.AddIdentity<Typer, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            })
                .AddEntityFrameworkStores<SSTContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<EmailConfirmationTokenProvider<Typer>>("emailconfirmation")
                .AddPasswordValidator<CustomPasswordValidator<Typer>>();

            services.AddAuthentication()
                .AddGoogle("Google", opt=>
                {
                    var googleAuth = Configuration.GetSection("Authentication:Google");
                    opt.ClientId = googleAuth["ClientId"];
                    opt.ClientSecret = googleAuth["ClientSecret"];
                    opt.SignInScheme = IdentityConstants.ExternalScheme;
                    
                })
                .AddFacebook(opt =>
                {
                    var facebookAuth = Configuration.GetSection("Authentication:Facebook");
                    opt.AppId = facebookAuth["AppId"];
                    opt.AppSecret = facebookAuth["AppSecret"];
                    opt.SignInScheme = IdentityConstants.ExternalScheme;
                });


            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromMinutes(30));
            services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromDays(3));

            services.AddScoped<IUserClaimsPrincipalFactory<Typer>, CustomClaimsFactory>();


            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
