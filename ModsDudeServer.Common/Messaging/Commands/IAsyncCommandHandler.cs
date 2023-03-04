using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Common.Messaging.Commands;
public interface IAsyncCommandHandler<T>
{
    Task Handle(T command);
}
