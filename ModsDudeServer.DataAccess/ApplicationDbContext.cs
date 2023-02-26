using Microsoft.EntityFrameworkCore;
using ModsDudeServer.DataAccess.EntityTypeConfigurations;
using ModsDudeServer.DataAccess.ValueConverters;
using ModsDudeServer.Domain.Files;
using ModsDudeServer.Domain.Information;
using ModsDudeServer.Domain.Mods;
using ModsDudeServer.Domain.Adapters;
using ModsDudeServer.Domain.Profiles;
using ModsDudeServer.Domain.Repos;
using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;
using ModsDudeServer.Domain.Invites;

namespace ModsDudeServer.DataAccess;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        void ConfigureValueOfConverter<T, TValue>()
            where T : ValueOf<TValue, T>, new()
        {
            configurationBuilder.Properties<T>().HaveConversion<ValueOfConverter<TValue, T>>();
        }

        ConfigureValueOfConverter<FileChecksum, byte[]>();
        ConfigureValueOfConverter<FileName, string>();
        ConfigureValueOfConverter<FileSize, long>();
        ConfigureValueOfConverter<Description, string>();
        ConfigureValueOfConverter<DisplayName, string>();
        ConfigureValueOfConverter<CategoryId, Guid>();
        ConfigureValueOfConverter<ModId, string>();
        ConfigureValueOfConverter<ModVersionString, string>();
        ConfigureValueOfConverter<AdapterId, string>();
        ConfigureValueOfConverter<ProfileId, Guid>();
        ConfigureValueOfConverter<RepoId, Guid>();
        ConfigureValueOfConverter<InviteId, Guid>();
        ConfigureValueOfConverter<UserId, Guid>();
        ConfigureValueOfConverter<UserName, string>();
        ConfigureValueOfConverter<PasswordHash, string>();
        ConfigureValueOfConverter<RepoMembershipLevel, int>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ModEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ModVersionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PluginEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RepoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new InviteEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }


    public required DbSet<Mod> Mods { get; init; }
    public required DbSet<ModVersion> ModVersions { get; init; }
    public required DbSet<Adapter> Plugins { get; init; }
    public required DbSet<Profile> Profiles { get; init; }
    public required DbSet<Repo> Repos { get; init; }
    public required DbSet<Invite> Invites { get; init; }
    public required DbSet<User> Users { get; init; }
}
