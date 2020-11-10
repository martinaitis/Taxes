using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxesLog;
using TaxesData;
using System;

namespace TaxesAPI
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
            services.AddTransient<FileLogger>();
            services.AddTransient<ConsoleLogger>();

            services.AddTransient<LoggerResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "File":
                        return serviceProvider.GetService<FileLogger>();
                    case "Console":
                        return serviceProvider.GetService<ConsoleLogger>();
                    default:
                        throw new ArgumentException($"Logger '{key}' does not exist.");
                }
            });

            services.AddTransient<SQLiteSourceProvider>();
            services.AddTransient<MongoDBSourceProvider>();
            services.AddTransient<SourceProviderResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "SQLite":
                        return serviceProvider.GetService<SQLiteSourceProvider>();
                    case "MongoDB":
                        return serviceProvider.GetService<MongoDBSourceProvider>();
                    default:
                        throw new ArgumentException($"Source provider '{key}' does not exist.");
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
