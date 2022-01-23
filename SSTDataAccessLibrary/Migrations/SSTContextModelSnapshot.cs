﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSTDataAccessLibrary.DataAccess;

#nullable disable

namespace SSTDataAccessLibrary.Migrations
{
    [DbContext(typeof(SSTContext))]
    partial class SSTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SSTDataAccessLibrary.Models.ScoreType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("SoccerMatchId")
                        .HasColumnType("int");

                    b.Property<int>("TypedAwayTeamResult")
                        .HasColumnType("int");

                    b.Property<int>("TypedHomeTeamResult")
                        .HasColumnType("int");

                    b.Property<int>("TyperGroupAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SoccerMatchId");

                    b.HasIndex("TyperGroupAccountId");

                    b.ToTable("ScoreTypes");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.SoccerMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AwayTeam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int");

                    b.Property<string>("CompetitionGroup")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HomeTeam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MatchResult")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SoccerMatches");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.Typer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Typers");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.TyperGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TyperGroups");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.TyperGroupAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TyperGroupId")
                        .HasColumnType("int");

                    b.Property<int>("TyperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TyperGroupId");

                    b.HasIndex("TyperId");

                    b.ToTable("TyperGroupAccounts");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.ScoreType", b =>
                {
                    b.HasOne("SSTDataAccessLibrary.Models.SoccerMatch", "SoccerMatch")
                        .WithMany()
                        .HasForeignKey("SoccerMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSTDataAccessLibrary.Models.TyperGroupAccount", "TyperGroupAccount")
                        .WithMany("ScoreTypes")
                        .HasForeignKey("TyperGroupAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoccerMatch");

                    b.Navigation("TyperGroupAccount");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.TyperGroupAccount", b =>
                {
                    b.HasOne("SSTDataAccessLibrary.Models.TyperGroup", "TyperGroup")
                        .WithMany("TyperGroupAccountsList")
                        .HasForeignKey("TyperGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSTDataAccessLibrary.Models.Typer", "Typer")
                        .WithMany("UserGroupAccount")
                        .HasForeignKey("TyperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Typer");

                    b.Navigation("TyperGroup");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.Typer", b =>
                {
                    b.Navigation("UserGroupAccount");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.TyperGroup", b =>
                {
                    b.Navigation("TyperGroupAccountsList");
                });

            modelBuilder.Entity("SSTDataAccessLibrary.Models.TyperGroupAccount", b =>
                {
                    b.Navigation("ScoreTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
