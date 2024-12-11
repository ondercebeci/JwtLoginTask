using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Services
{
    public static class ServiceRegistiration
    {

        //public static  IServiceCollection AddApplicationss(this IServiceCollection services)
        //{
        //    services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));

        //    return services;

        //}


        //public static void AddApplicationService(this IServiceCollection services)
        //{
        //    //services.AddMediatR(Assembly.GetExecutingAssembly());
        //    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        //}

        //public static void AddApplicationService(IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        //}

        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
