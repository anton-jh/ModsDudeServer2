using ModsDudeServer.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Helpers;
public abstract class GuidId<T> : ValueOf<Guid, T>
    where T : ValueOf<Guid, T>, new()
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            string subTypeName = GetType().Name;

            throw new DomainValidationException($"An empty Guid is not a valid {subTypeName}");
        }
    }


    public static T NewId() => From(Guid.NewGuid());
}
