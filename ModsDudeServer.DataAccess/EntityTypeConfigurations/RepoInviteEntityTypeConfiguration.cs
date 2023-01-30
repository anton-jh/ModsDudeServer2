using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Repo;
using ModsDudeServer.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class RepoInviteEntityTypeConfiguration : IEntityTypeConfiguration<RepoInvite>
{
    public void Configure(EntityTypeBuilder<RepoInvite> builder)
    {
        builder.HasKey(invite => invite.Id);
        builder.HasOne<Repo>().WithMany().HasForeignKey(invite => invite.RepoId);
        builder.Property(invite => invite.MembershipLevel);
        builder.Property(invite => invite.Expires);
        builder.Property(invite => invite.MultiUse);
    }
}
