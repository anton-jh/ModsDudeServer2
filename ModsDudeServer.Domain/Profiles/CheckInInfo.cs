using ModsDudeServer.Domain.Exceptions;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Profiles;
public class CheckInInfo : ValueOf<(UserName UserName, DateTime Time), CheckInInfo>
{
    public UserName UserName => Value.UserName;
    public DateTime Time => Value.Time;


    protected override void Validate()
    {
        if (Time > DateTime.Now)
        {
            throw new DomainValidationException("Savegame check-in time cannot be in the future.");
        }
    }
}
