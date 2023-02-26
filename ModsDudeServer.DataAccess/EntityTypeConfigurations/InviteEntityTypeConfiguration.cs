using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Invites;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class InviteEntityTypeConfiguration : IEntityTypeConfiguration<Invite>
{
    public void Configure(EntityTypeBuilder<Invite> builder)
    {
        builder.HasKey(invite => invite.Id);
        builder.HasOne<Repo>().WithMany().HasForeignKey(invite => invite.RepoId);
        builder.Property(invite => invite.MembershipLevel);
        builder.Property(invite => invite.Expires);
        builder.Property(invite => invite.MultiUse);
    }
}
