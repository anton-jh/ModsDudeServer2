// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModsDudeServer.DataAccess;

#nullable disable

namespace ModsDudeServer.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230226202632_6 - Domain v2")]
    partial class _6Domainv2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryMod", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoriesId", "ModId");

                    b.HasIndex("ModId");

                    b.ToTable("CategoryMod");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Adapters.Adapter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plugins");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Invites.Invite", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Expires")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MembershipLevel")
                        .HasColumnType("int");

                    b.Property<bool>("MultiUse")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.Mod", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RepoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RepoId");

                    b.ToTable("Mods");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.ModVersion", b =>
                {
                    b.Property<string>("ModId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VersionString")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ModId", "VersionString");

                    b.ToTable("ModVersions");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Profiles.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RepoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RepoId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Repos.Repo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdapterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdapterId")
                        .IsUnique();

                    b.ToTable("Repos");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategoryMod", b =>
                {
                    b.HasOne("ModsDudeServer.Domain.Mods.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModsDudeServer.Domain.Mods.Mod", null)
                        .WithMany()
                        .HasForeignKey("ModId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Adapters.Adapter", b =>
                {
                    b.OwnsOne("ModsDudeServer.Domain.Adapters.AdapterFileInfo", "File", b1 =>
                        {
                            b1.Property<string>("AdapterId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<byte[]>("Checksum")
                                .IsRequired()
                                .HasColumnType("varbinary(max)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AdapterId");

                            b1.ToTable("Plugins");

                            b1.WithOwner()
                                .HasForeignKey("AdapterId");
                        });

                    b.Navigation("File")
                        .IsRequired();
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Invites.Invite", b =>
                {
                    b.OwnsMany("ModsDudeServer.Domain.Invites.RepoInvite", "RepoInvites", b1 =>
                        {
                            b1.Property<Guid>("InviteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("RepoId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("InviteId", "Id");

                            b1.ToTable("RepoInvite");

                            b1.WithOwner()
                                .HasForeignKey("InviteId");
                        });

                    b.Navigation("RepoInvites");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.Mod", b =>
                {
                    b.HasOne("ModsDudeServer.Domain.Repos.Repo", null)
                        .WithMany()
                        .HasForeignKey("RepoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.ModVersion", b =>
                {
                    b.HasOne("ModsDudeServer.Domain.Mods.Mod", null)
                        .WithMany("Versions")
                        .HasForeignKey("ModId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ModsDudeServer.Domain.Mods.ModFileInfo", "File", b1 =>
                        {
                            b1.Property<string>("ModVersionModId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("ModVersionVersionString")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("FileSize")
                                .HasColumnType("bigint");

                            b1.HasKey("ModVersionModId", "ModVersionVersionString");

                            b1.ToTable("ModVersions");

                            b1.WithOwner()
                                .HasForeignKey("ModVersionModId", "ModVersionVersionString");
                        });

                    b.Navigation("File");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Profiles.Profile", b =>
                {
                    b.HasOne("ModsDudeServer.Domain.Repos.Repo", null)
                        .WithMany()
                        .HasForeignKey("RepoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ModsDudeServer.Domain.Profiles.ModDependency", "Mods", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<bool>("IsProtected")
                                .HasColumnType("bit");

                            b1.Property<string>("ModId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ModVersion")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfileId", "Id");

                            b1.ToTable("ModDependency");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("ModsDudeServer.Domain.Profiles.Savegame", "Savegame", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FileName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfileId");

                            b1.ToTable("Profiles");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");

                            b1.OwnsOne("ModsDudeServer.Domain.Profiles.SavegameStatus", "Status", b2 =>
                                {
                                    b2.Property<Guid>("SavegameProfileId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<bool>("IsCheckedOut")
                                        .HasColumnType("bit");

                                    b2.Property<DateTime>("Time")
                                        .HasColumnType("datetime2");

                                    b2.Property<Guid>("UserId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("SavegameProfileId");

                                    b2.ToTable("Profiles");

                                    b2.WithOwner()
                                        .HasForeignKey("SavegameProfileId");
                                });

                            b1.Navigation("Status")
                                .IsRequired();
                        });

                    b.Navigation("Mods");

                    b.Navigation("Savegame");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Repos.Repo", b =>
                {
                    b.HasOne("ModsDudeServer.Domain.Adapters.Adapter", null)
                        .WithOne()
                        .HasForeignKey("ModsDudeServer.Domain.Repos.Repo", "AdapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Users.User", b =>
                {
                    b.OwnsMany("ModsDudeServer.Domain.Users.RepoMembership", "RepoMemberships", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<int>("Level")
                                .HasColumnType("int");

                            b1.Property<Guid>("RepoId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("RepoMembership");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RepoMemberships");
                });

            modelBuilder.Entity("ModsDudeServer.Domain.Mods.Mod", b =>
                {
                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
