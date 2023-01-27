using ModsDudeServer.Domain.Files;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Profiles;
public class Savegame
{
    public Savegame(FileName fileName)
    {
        FileName = fileName;
    }


    public FileName FileName { get; }
    public required SavegameStatus Status { get; set; }


    public void CheckOut(UserId userId)
    {
        Status = new()
        {
            UserId = userId,
            Time = DateTime.Now,
            IsCheckedOut = true
        };
    }

    public void CheckIn(UserId userId)
    {
        Status = new()
        {
            UserId = userId,
            Time = DateTime.Now,
            IsCheckedOut = false
        };
    }
}
