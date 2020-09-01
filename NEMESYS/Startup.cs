using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEMESYS.Models;

//This class contains the middleware of the application

namespace NEMESYS {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) { //Inside this collection parameter we can insert any services that we want to inject into the application.
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //This is what makes this application from ASP.NET Core into ASP.NET Core MVC

            //Adding the dependency injections for the different services needed to the services Collection
            //With these dependency injections, the services collection will provide an instance of the service we need whenever we need.

            //This will create an instance of the NemesysContext class(by calling its constructor and passing the DB provider and connection string as a parameter to it).
            services.AddDbContext<NemesysContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            //The following adds a dependency injection to connect to Google Authentication
            services.AddAuthentication(options =>
            {
                //Once google has autenticated the user, the user will be signed in using a cookie
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle("Google", options => {
                options.ClientId = Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                /*
                options.Events = new OAuthEvents {
                    //The OnRedirectToAuthorizationEndpoint event simply shows only the accounts with a um.edu.mt domain when
                    //the user gets to the Google account selection page. If the user clicks other account, then the domain 
                    //part of the email address will be prefilled with 'um.edu.mt'.An important thing to note here is that 
                    //if you are already logged into Google with a um.edu.mt account, then the Google login prompt does not 
                    //display. In this case clicking on the login button will log you in immediately with that account.
                    OnRedirectToAuthorizationEndpoint = context =>
                    {
                        context.Response.Redirect(context.RedirectUri + "&hd=" + System.Net.WebUtility.UrlEncode("um.edu.mt"));

                        return Task.CompletedTask;
                    },
                    //After the user has authenticated with Google, a JSON object with the user's details is returned
                    //After this, the OnCreatingTicket event handler is called. The context instance will give us 
                    //access to the JSON payload returned from Google. One of the values in this JSON object is the domain.
                    //Thus we fetch that, and check if it is um.edu.mt. If it isn't we throw an exception.
                    OnCreatingTicket = context =>
                    {
                        string domain = context.User.Value<string>("hd");
                        if (domain != "um.edu.mt") {
                            throw new Exception("You must sign in with a um.edu.mt email address");
                        } 
                        return Task.CompletedTask;                       
                    }
                };
                */
            });            
        }

        //Here we decide how we want to process an HTTP request
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //Adding the authentication middleware
            app.UseAuthentication();
            app.UseStatusCodePages(); //When an exception happens, send out the error code


            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    //We want the Index view from the views corrsponding to the HomeController to be initially loaded
                    template: "{controller=Home}/{action=Index}/{id?}"); 
            });
        }
    }
}
