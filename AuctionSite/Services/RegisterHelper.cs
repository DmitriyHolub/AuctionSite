using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public static class RegisterHelper
    {
        public static void RegisterServices<T>(this IServiceCollection services)
        {
            var type = typeof(T);
            NiceRegister(services, type);
        }

        public static void NiceRegister(this IServiceCollection services, Type type)
        {
            services.AddScoped(type, serviceProvider =>
            {
                var constructor = type.GetConstructors()
                    .OrderByDescending(x => x.GetParameters().Length)
                    .First();

                var parametorsInfo = constructor.GetParameters();
                var parametorsValue = parametorsInfo
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

                return constructor.Invoke(parametorsValue);
            });
        }
        public static object Register(this IServiceCollection services,IServiceProvider serviceProvider, Type type)
        {
              var constructor = type.GetConstructors()
                    .OrderByDescending(x => x.GetParameters().Length)
                    .First();

                var parametorsInfo = constructor.GetParameters();
                var parametorsValue = parametorsInfo
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

                return constructor.Invoke(parametorsValue);
            
        }
    }
}
