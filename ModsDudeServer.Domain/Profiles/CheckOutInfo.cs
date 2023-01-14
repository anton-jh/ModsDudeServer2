using ModsDudeServer.Domain.Exceptions;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Profiles;
public class CheckOutInfo
{
    public required UserName UserName { get; set; }

    private DateTime _time;
    public required DateTime Time
    {
        get => _time;
        set => _time = value <= DateTime.Now ? value : throw new DomainValidationException("Savegame check-out time cannot be in the future.");
    }
}
