using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.SQL;
using PetShop.Infrastructure.SQL.Repositories;

namespace PetShopApp.UI.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, PetShopOwnerRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IValidateIdService, ValidateIdService>();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PetShopContext>(optionsAction: opt =>
                    opt.UseSqlite( "Data Source = PetShop.db"));
            }
            else
            {
                services.AddDbContext<PetShopContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.MaxDepth = 2;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //FakeDb.InitData();
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<PetShopContext>();
                    DbInitializer.SeedDb(context);
                }
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
