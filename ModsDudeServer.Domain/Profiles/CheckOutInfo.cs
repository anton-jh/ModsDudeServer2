using ModsDudeServer.Domain.Exceptions;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Profiles;
public class CheckOutInfo : ValueOf<(UserName UserName, DateTime Time), CheckOutInfo>
{
    public UserName UserName => Value.UserName;
    public DateTime Time => Value.Time;


    protected override void Validate()
    {
        if (Time > DateTime.Now)
        {
            throw new DomainValidationException("Savegame check-out time cannot be in the future.");
        }
    }
}
