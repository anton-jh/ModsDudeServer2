using ModsDudeServer.Domain.Adapters;
using ModsDudeServer.Domain.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Repos;
public class Repo
{
    public Repo(DisplayName name, AdapterId adapterId)
    {
        Id = RepoId.NewId();
        Name = name;
        AdapterId = adapterId;
    }


    public RepoId Id { get; init; }
    public DisplayName Name { get; set; }
    public AdapterId AdapterId { get; init; }
}
