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
    public Savegame(FileName fileName, CheckOutInfo? checkOutInfo, CheckInInfo checkInInfo)
    {
        FileName = fileName;
        CheckOutInfo = checkOutInfo;
        CheckInInfo = checkInInfo;
    }


    public FileName FileName { get; }
    public CheckOutInfo? CheckOutInfo { get; private set; }
    public CheckInInfo CheckInInfo { get; private set; }


    public void CheckOut(UserName userName)
    {
        CheckOutInfo = CheckOutInfo.From((userName, DateTime.Now));
    }

    public void CheckIn(UserName userName)
    {
        CheckInInfo = CheckInInfo.From((userName, DateTime.Now));
        CheckOutInfo = null;
    }


    public static Savegame NewSavegame(FileName fileName, UserName checkedInBy)
        => new(fileName, null, CheckInInfo.From((checkedInBy, DateTime.Now)));
}
