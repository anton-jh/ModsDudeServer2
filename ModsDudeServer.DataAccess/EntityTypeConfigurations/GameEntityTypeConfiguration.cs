using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.DataAccess.ValueConverters;
using ModsDudeServer.Domain.Games;
using ModsDudeServer.Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityConfigurations;
internal class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(game => game.Id);
        builder.HasOne<Repo>().WithMany().HasForeignKey(game => game.RepoId);
        builder.Property(game => game.Name);
        builder.OwnsMany(game => game.Plugins, plugin =>
        {
            plugin.Property(p => p.PluginId);
            plugin.Property(p => p.Priority);
        });
    }
}
