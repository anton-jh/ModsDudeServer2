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
    public Savegame(FileName fileName, CheckInInfo checkInInfo)
    {
        FileName = fileName;
        CheckInInfo = checkInInfo;
    }


    public FileName FileName { get; }
    public CheckOutInfo? CheckOutInfo { get; private set; }
    public CheckInInfo CheckInInfo { get; private set; }


    public void CheckOut(UserName userName)
    {
        CheckOutInfo = new()
        {
            UserName = userName,
            Time = DateTime.Now
        };
    }

    public void CheckIn(UserName userName)
    {
        CheckInInfo = new()
        {
            UserName = userName,
            Time = DateTime.Now
        };
        CheckOutInfo = null;
    }
}
