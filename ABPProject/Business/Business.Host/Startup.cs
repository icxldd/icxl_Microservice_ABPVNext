using Business.Host;
using Business.Host.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Business
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<BusinessHostModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IHostApplicationLifetime _host)
        {
            app.InitializeApplication();
            var settingsOptions = serviceProvider.GetService<IOptions<AppConfig>>();
            var appConfig = settingsOptions.Value;
            app.RegisterConsul(_host, appConfig);
        }
    }
}
