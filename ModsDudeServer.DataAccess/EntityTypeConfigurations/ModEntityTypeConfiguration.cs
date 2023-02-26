using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.DataAccess.ValueConverters;
using ModsDudeServer.Domain.Mods;
using ModsDudeServer.Domain.Repos;
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
        builder.HasOne<Repo>().WithMany().HasForeignKey(mod => mod.RepoId);
        builder.Property(mod => mod.Name);
        builder.Property(mod => mod.Description);
        builder.HasMany(mod => mod.Categories).WithMany();
        builder.HasMany(mod => mod.Versions).WithOne().HasForeignKey(modVersion => modVersion.ModId);
    }
}
