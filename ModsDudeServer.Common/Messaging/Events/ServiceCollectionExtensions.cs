using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Common.Messaging.Events;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventHandlers(this IServiceCollection services, params Assembly[] assemblies)
    {
        IEnumerable<Type> allTypes = assemblies.SelectMany(assembly => assembly.GetTypes());
        IEnumerable<Type> eventTypes = allTypes.Where(t => typeof(IEvent).IsAssignableFrom(t));

        foreach (Type eventType in eventTypes)
        {
            Type handlerInterface = typeof(IEventHandler<>).MakeGenericType(eventType);
            IEnumerable<Type> handlerTypes = allTypes.Where(handlerInterface.IsAssignableFrom);

            foreach (Type handlerType in handlerTypes)
            {
                services.AddScoped(handlerInterface, handlerType);
            }
        }

        return services;
    }
}
