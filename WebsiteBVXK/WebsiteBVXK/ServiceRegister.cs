using BVXK.Application;
using BVXK.Database;
using BVXK.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace WebsiteBVXK
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);
            foreach (var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddTransient<IXeManager, XeManager>();
            @this.AddTransient<ILichTrinhManager, LichTrinhManager>();
            @this.AddTransient<IThongKeManager, ThongKeManager>();

            return @this;
        }
    }
}
