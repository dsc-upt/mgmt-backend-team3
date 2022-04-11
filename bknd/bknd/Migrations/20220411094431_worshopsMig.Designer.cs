﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bknd.DataBase;

#nullable disable

namespace bknd.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220411094431_worshopsMig")]
    partial class worshopsMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bknd.Team.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("GithubLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamLeadId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamLeadId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("bknd.UserProfile.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("fbLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teamId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("teamId");

                    b.HasIndex("userId");

                    b.ToTable("userprofiles");
                });

            modelBuilder.Entity("bknd.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("bknd.Workshops.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("coverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("presentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seats")
                        .HasColumnType("int");

                    b.Property<string>("topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trainerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("trainerId");

                    b.ToTable("workshops");
                });

            modelBuilder.Entity("bknd.Team.Team", b =>
                {
                    b.HasOne("bknd.Users.User", "TeamLead")
                        .WithMany()
                        .HasForeignKey("TeamLeadId");

                    b.Navigation("TeamLead");
                });

            modelBuilder.Entity("bknd.UserProfile.UserProfile", b =>
                {
                    b.HasOne("bknd.Team.Team", "team")
                        .WithMany()
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bknd.Users.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("team");

                    b.Navigation("user");
                });

            modelBuilder.Entity("bknd.Users.User", b =>
                {
                    b.HasOne("bknd.Workshops.Workshop", null)
                        .WithMany("participants")
                        .HasForeignKey("WorkshopId");
                });

            modelBuilder.Entity("bknd.Workshops.Workshop", b =>
                {
                    b.HasOne("bknd.Users.User", "trainer")
                        .WithMany()
                        .HasForeignKey("trainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trainer");
                });

            modelBuilder.Entity("bknd.Workshops.Workshop", b =>
                {
                    b.Navigation("participants");
                });
#pragma warning restore 612, 618
        }
    }
}