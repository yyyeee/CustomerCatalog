using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddMvc();

            if (_currentEnvironment.IsEnvironment("Testing"))
            {
//                services.AddDbContext<ApplicationDbContext>(options =>
//                    options.UseInMemoryDatabase("TestingDB"));
            }
            else
            {
//                services.AddDbContext<ApplicationDbContext>(options =>
//                    options.UseSqlServer(_configuration.GetConnectionString("CustomerDatabase")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
