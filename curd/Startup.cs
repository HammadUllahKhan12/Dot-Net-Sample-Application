using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Context;
using Services;
using Context.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace curd
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

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Api", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "test@text.com",
                    ValidAudience = "test@text.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm"))
                };
            });


            /* services.AddDefaultIdentity<IdentityUser>(options =>
                  options.SignIn.RequireConfirmedAccount = true)
                  .AddEntityFrameworkStores<DataBaseContext>();
             services.AddRazorPages();*/

            /*  
               services.AddAuthentication().AddGoogle(options =>
           {
               IConfigurationSection googleAuthNSection =
                   Configuration.GetSection("Authentication:Google");

               options.ClientId = googleAuthNSection["656733915265-hrdosla5vc67g82g1sj7htptinu9ppp9.apps.googleusercontent.com"];
               options.ClientSecret = googleAuthNSection["qXV66qWAFOSam00u2ZiB4yUl"];
           });*/





            //MultipleActiveResultSet = True
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-B23IUM2;Integrated Security=True;Initial Catalog=DemoDB3");
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped (typeof( IGenericRepositry< >),typeof( GenericRepositry<> ));

        }

      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           /* var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.EnsureInitialized();

            UseWebApi(httpConfig);*/

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseSwagger();
            app.UseAuthentication();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}



