﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Common.Messaging.Events;
public interface IEventHandler<T> where T : IEvent
{
    void Handle(T e);
}
