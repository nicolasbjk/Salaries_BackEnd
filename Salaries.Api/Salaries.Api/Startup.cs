using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Salaries.Api.Swagger;
using Salaries.Core.ApplicationProviders.CalculateAnnualSalaryServices;
using Salaries.Core.ApplicationProviders.EmployeeServices;
using Salaries.Core.ApplicationServices.CalculateAnnualSalaryServices;
using Salaries.Core.ApplicationServices.EmployeeServices;
using Salaries.Core.Repositories;
using Salaries.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace Salaries.Api2
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConfiguration.DocNameV1, new Info { Title = SwaggerConfiguration.DocInfoTitle, Version = SwaggerConfiguration.DocInfoVersion });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureCors(services);
            ConfigureDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureCors(IServiceCollection services)
        {
            var policy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", policy);
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            #region Services Settings
            services.AddTransient<IGetAllEmployeeService, GetAllEmployeeService>();
            services.AddTransient<IGetEmployeeByIdService, GetEmployeeByIdService>();
            services.AddTransient<ICalculateAnnualSalaryFactory, CalculateAnnualSalaryFactory>();
            #endregion

            #region Repository Settings
            services.AddHttpClient<IEmployeeRepository, EmployeeRepository>(client => {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            #endregion
        }
    }
}
