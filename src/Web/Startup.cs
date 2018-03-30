using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using yyyeee.CustomerCatalog.Services;
using yyyeee.CustomerCatalog.Services.CustomerRead;
using yyyeee.CustomerCatalog.Services.CustomerWrite;
using yyyeee.CustomerCatalog.Services.DataLayer;

namespace yyyeee.CustomerCatalog
{
    public class Startup
    {
        private readonly IHostingEnvironment _currentEnvironment;
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
        {
            _configuration = configuration;
            _currentEnvironment = currentEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddMvc();
            services.AddSingleton(_configuration);
            services.AddTransient<ICustomerProvider, CustomerProvider>();
            services.AddSingleton<LiteDatabaseFactory>();
            services.AddTransient<ICommandHandler<AddCustomerCommand>, AddCustomerCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });

            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
