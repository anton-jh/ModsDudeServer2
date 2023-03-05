using Microsoft.Extensions.DependencyInjection;
using ModsDudeServer.Common.Messaging.Events.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Common.Messaging.Events;
public class EventBus
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IEnumerable<IEventHandler<TestEvent>> _eventHandlers;


    public EventBus(IServiceProvider serviceProvider, IEnumerable<IEventHandler<TestEvent>> eventHandlers)
    {
        _serviceProvider = serviceProvider;
        _eventHandlers = eventHandlers;
    }


    public void Publish(IEvent e)
    {
        Type concreteEventHandlerType = typeof(IEventHandler<>).MakeGenericType(e.GetType());
        Type listOfEventHandlersType = typeof(IEnumerable<>).MakeGenericType(concreteEventHandlerType);
        MethodInfo handleMethod = concreteEventHandlerType.GetMethod(nameof(IEventHandler<IEvent>.Handle))!;

        IEnumerable handlers = (IEnumerable)_serviceProvider.GetService(listOfEventHandlersType)!;
        object?[] args = new object?[] { e };

        foreach (object handler in handlers)
        {
            handleMethod.Invoke(handler, args);
        }
    }
}
