using ModsDudeServer.Common.Messaging.Events;

namespace ModsDudeServer.Common.Messaging.Events.Events;

public class AnotherTestEventHandler : IEventHandler<TestEvent>
{
    public void Handle(TestEvent e)
    {

    }
}
