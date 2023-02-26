using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class PluginEntityTypeConfiguration : IEntityTypeConfiguration<Adapter>
{
    public void Configure(EntityTypeBuilder<Adapter> builder)
    {
        builder.HasKey(plugin => plugin.Id);
        builder.Property(plugin => plugin.Name);
        builder.Property(plugin => plugin.Description);
        builder.OwnsOne(plugin => plugin.File, fileInfo =>
        {
            fileInfo.Property(f => f.FileName);
            fileInfo.Property(f => f.Checksum);
        });
    }
}
