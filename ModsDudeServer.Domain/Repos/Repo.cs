using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Repo;
public class Repo
{
    public Repo(DisplayName name)
    {
        Id = RepoId.NewId();
        Name = name;
    }


    public RepoId Id { get; init; }
    public DisplayName Name { get; set; }
}
