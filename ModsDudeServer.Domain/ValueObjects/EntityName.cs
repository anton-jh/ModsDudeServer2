using ModsDudeServer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.ValueObjects;
public class EntityName : ValueOf<string, EntityName>
{
    protected override void Validate()
    {
        Value.MustBe().NotEmptyOrWhitespace();
    }
}
