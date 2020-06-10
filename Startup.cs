using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HosteliteAPI.Controllers_Repository;
using HosteliteAPI.Data;
using HosteliteAPI.Dtos;
using HosteliteAPI.Helpers;
using HosteliteAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace HosteliteAPI
{
    /// <summary>
    /// The bootstrapped class for building and starting up our webapp
    /// </summary>
    /// <returns></returns>
    public class Startup
    {
        /// <summary>
        /// The bootstrapped class constructor
        /// </summary>
        /// <returns></returns>
        public Startup(IConfiguration configuration)

        {
            Configuration = configuration;
        }

        /// <summary>
        /// The bootstrapped class property
        /// </summary>
        /// <returns></returns>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// This method is where we register our services for dependency injection into our webapp
        /// </summary>
        /// <returns></returns>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<Seed>();
           
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                    {
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                    }
                })
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            //Auto mapper configuration
            var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new Info { Title = "Hostelite API", Version = "v1" });
                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"HosteliteAPI.xml";
                options.IncludeXmlComments(xmlPath);
            });
                
            services.AddCors();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHostelRepository, HostelRepository>();
        }


        /// <summary>
        /// This method is the pipeline for our requests into our webapp
        /// </summary>
        /// <returns></returns>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seed)

        {
            if (env.IsDevelopment())
            {
              //app.UseDeveloperExceptionPage();
              app.UseExceptionHandler(builder =>
              {
                builder.Run(async context =>
                {
                  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                  var error = context.Features.Get<IExceptionHandlerFeature>();
                  if (error != null)
                  {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message);
                  }
                });
              });
            }
            else
            {
              app.UseExceptionHandler(builder =>
              {
                builder.Run(async context =>
                {
                  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                  var error = context.Features.Get<IExceptionHandlerFeature>();
                  if (error != null)
                  {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message);
                  }
                });
              });
            }
        
            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hostelite API v1")
            );
            //seed.SeedUsers();
            //seed.SeedHostels();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseAuthentication();
            app.UseMvc();

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }
    }
}
