using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.DataAccess.ValueConverters;
using ModsDudeServer.Domain.Games;
using ModsDudeServer.Domain.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class ModEntityTypeConfiguration : IEntityTypeConfiguration<Mod>
{
    public void Configure(EntityTypeBuilder<Mod> builder)
    {
        builder.HasKey(mod => mod.Id);
        builder.HasOne<Game>().WithMany().HasForeignKey(mod => mod.GameId);
        builder.Property(mod => mod.Name);
        builder.Property(mod => mod.Description);
        builder.HasMany(mod => mod.Categories);
        builder.HasMany(mod => mod.Versions).WithOne().HasForeignKey(modVersion => modVersion.ModId);
    }
}
