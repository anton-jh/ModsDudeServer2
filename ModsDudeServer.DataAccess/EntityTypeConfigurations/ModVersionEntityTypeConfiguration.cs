using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class ModVersionEntityTypeConfiguration : IEntityTypeConfiguration<ModVersion>
{
    public void Configure(EntityTypeBuilder<ModVersion> builder)
    {
        builder.HasKey(version => new { version.ModId, version.VersionString });
        // ModId is configured in ModEntityTypeConfiguration
        builder.Property(version => version.CreatedOn);
        builder.OwnsOne(version => version.File);
    }
}
