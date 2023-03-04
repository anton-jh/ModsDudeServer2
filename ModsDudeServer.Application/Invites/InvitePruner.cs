using Microsoft.EntityFrameworkCore;
using ModsDudeServer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Invites;
public class InvitePruner
{
    private readonly ApplicationDbContext _dbContext;


    public InvitePruner(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Prune()
    {
        _dbContext.Invites.Where(invite => invite.Expires <= DateTimeOffset.UtcNow).ExecuteDelete();
    }
}
