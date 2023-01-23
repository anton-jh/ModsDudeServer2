using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModsDudeServer.Domain.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.DataAccess.EntityTypeConfigurations;
internal class RepoEntityTypeConfiguration : IEntityTypeConfiguration<Repo>
{
    public void Configure(EntityTypeBuilder<Repo> builder)
    {
        builder.HasKey(repo => repo.Id);
        builder.Property(repo => repo.Name);
    }
}
