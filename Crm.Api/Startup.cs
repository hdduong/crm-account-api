using System.IO;
using AutoMapper;
using Crm.Account.Api.Repository.Configuration;
using Crm.Account.Api.Repository.Interfaces;
using Crm.Account.Api.Repository.Repositories;
using Crm.Account.Api.Service.Interfaces.Services;
using Crm.Account.Api.Service.Interfaces.Validators;
using Crm.Account.Api.Service.Models.Configuration;
using Crm.Account.Api.Service.Services;
using Crm.Account.Api.Service.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Crm.Account.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {         
            Configuration = configuration;
        }      

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddOptions();
            services.Configure<RepositoryConfiguration>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<AppConfigurations>(Configuration.GetSection("AppConfigurations"));

            // repository
            services.AddScoped<IRepositoryConfiguration, RepositoryConfiguration>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecordTypeRepository, RecordTypeRepository>();
            services.AddScoped<ILosRepository, LosRepository>();

            // validator layer
            services.AddTransient<IAccountRequestDsOValidator, AccountRequestDsOValidator>();
            services.AddTransient<IUserRequestDsOValidator, UserRequestDsOValidator>();
            services.AddTransient<IAccountUserRequestDsoValidator, AccountUserRequestDsoValidator>();
            services.AddTransient<IRecordTypeRequestDsOValidator, RecordTypeRequestDsOValidator>();
            services.AddTransient<IAccountRecordTypeDsOValidator, AccountRecordTypeDsOValidator>();

            // service layer
            services.AddTransient<IEllieJwtService, EllieJwtService>();
            services.AddTransient<IShareService, ShareService>();
            services.AddTransient<IRecordTypeService, RecordTypeService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc()
                .AddFluentValidation()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "header", Description = "Please insert JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });

                c.SwaggerDoc("v1", new Info { Title = "CRM API", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Crm.Api.xml");
                c.IncludeXmlComments(xmlPath);

                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseMiddleware(typeof(GlobalExceptionMiddleware));
            app.UseMiddleware(typeof(GlobalCorrelationIdMiddleware));
            app.UseMiddleware(typeof(GlobalJwtValidationMiddleware));

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Mvc controller could not route the request");
            });
        }
    }
}
