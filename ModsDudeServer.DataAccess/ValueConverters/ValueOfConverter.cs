using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.DataAccess.ValueConverters;
internal class ValueOfConverter<TValue, T> : ValueConverter<T, TValue>
    where T : ValueOf<TValue, T>, new()
{
    public ValueOfConverter()
        : base(fromModel => fromModel.Value, fromProvider => ValueOf<TValue, T>.From(fromProvider))
    {
    }
}
