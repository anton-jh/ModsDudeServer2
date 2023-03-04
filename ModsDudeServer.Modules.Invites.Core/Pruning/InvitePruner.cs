using Microsoft.EntityFrameworkCore;
using ModsDudeServer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Modules.Invites.Core.Pruning;
public class InvitePruner : IInvitePruner
{
    private readonly ApplicationDbContext _dbContext;


    public InvitePruner(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Run()
    {
        _dbContext.Invites.Where(invite => invite.Expires <= DateTimeOffset.UtcNow).ExecuteDelete();
    }
}
