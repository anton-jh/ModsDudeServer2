using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Games;
using ModsDudeServer.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasKey(profile => profile.Id);
        builder.HasOne<Game>().WithMany().HasForeignKey(profile => profile.GameId);
        builder.Property(profile => profile.Name);
        builder.OwnsMany(profile => profile.Mods);
        builder.OwnsOne(profile => profile.Savegame, savegameBuilder =>
        {
            savegameBuilder.Property(savegame => savegame.FileName);
            savegameBuilder.OwnsOne(savegame => savegame.Status, checkOutInfo =>
            {
                checkOutInfo.Property(status => status.UserId);
                checkOutInfo.Property(status => status.Time);
                checkOutInfo.Property(status => status.IsCheckedOut);
            });
        });
    }
}
