using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModsDudeServer.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.DataAccess.ValueConverters;
internal class GuidIdConverter<T> : ValueConverter<T, Guid>
    where T : ValueOf<Guid, T>, new()
{
    public GuidIdConverter()
        : base(fromModel => fromModel.Value, fromProvider => GuidId<T>.From(fromProvider))
    {
    }
}
