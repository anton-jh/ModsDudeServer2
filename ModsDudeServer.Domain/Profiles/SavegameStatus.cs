using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Profiles;
public class SavegameStatus
{
    public required UserId UserId { get; init; }
    public required DateTime Time { get; init; }
    public required bool IsCheckedOut { get; init; }
}
