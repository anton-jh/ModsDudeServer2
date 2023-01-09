using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Repo;
public class Repo
{
    public Repo(RepoId id, DisplayName name)
    {
        Id = id;
        Name = name;
    }


    public RepoId Id { get; }
    public DisplayName Name { get; set; }

    public static Repo NewServer(DisplayName name)
        => new(RepoId.NewId(), name);
}
