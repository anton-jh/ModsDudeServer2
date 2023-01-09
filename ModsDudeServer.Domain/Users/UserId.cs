using ModsDudeServer.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Users;
public class UserId : ValueOf<Guid, UserId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new DomainValidationException("An empty Guid is not a valid UserId.");
        }
    }


    public static UserId NewUserId() => From(Guid.NewGuid());
}
