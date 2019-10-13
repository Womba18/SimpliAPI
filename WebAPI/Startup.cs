using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ApplicationCore.Service.Service_Interfaces;
using ApplicationCore.Service;
using ApplicationCore.Domain.Repository_Interfaces;
using Infrastructure;
using ApplicationCore.Domain.BusinessDomain;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;

namespace WebAPI
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
            // Add framework services.
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; });

            // Add application services.
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IRepository<Supplier>, SupplierRepository>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IRepository<Customer>, CustomerRepository>();

            services.AddTransient<ITrendRepository, TrendRepository>();

            services.AddSingleton<ITrendService, TrendService>();
            services.AddSingleton<IFirebaseLogin, FirebaseLogin>();
            //services.AddSingleton<>


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
