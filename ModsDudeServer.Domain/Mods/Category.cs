using ModsDudeServer.Domain.Information;
using ModsDudeServer.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Mods;
public class Category
{
    public Category(DisplayName name)
    {
        Id = CategoryId.NewId();
        Name = name;
    }


    public required CategoryId Id { get; init; }
    public DisplayName Name { get; set; }
}
