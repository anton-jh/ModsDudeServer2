using ModsDudeServer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Users;
public class UserName : ValueOf<string, UserName>
{
    protected override void Validate()
    {
        Value.MustBe().AtLeastThisLong(4);
    }
}
