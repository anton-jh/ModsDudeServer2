using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Common.Messaging.Commands;
public interface ICommandHandler<T>
    where T : class
{
    void Handle(T command);
}
