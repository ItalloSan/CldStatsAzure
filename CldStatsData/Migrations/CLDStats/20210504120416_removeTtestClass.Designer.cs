﻿// <auto-generated />
using System;
using CLDStatsData.CLDStatsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CLDStats.Migrations.CLDStats
{
    [DbContext(typeof(CLDStatsDbContext))]
    [Migration("20210504120416_removeTtestClass")]
    partial class removeTtestClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Acivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("PipUserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("QuarterId")
                        .HasColumnType("int");

                    b.Property<int?>("VolunteerAmount")
                        .HasColumnType("int");

                    b.Property<float?>("VolunteerHours")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("PipUserId");

                    b.HasIndex("QuarterId");

                    b.ToTable("Acivity");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActitityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Id" }, "IX_ActitityType")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "IX_ActitityType_1")
                        .IsUnique();

                    b.ToTable("ActitityType");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActivityCluster", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("ClusterId")
                        .HasColumnType("int");

                    b.HasKey("ActivityId", "ClusterId");

                    b.HasIndex("ClusterId");

                    b.ToTable("Activity_Cluster");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActivityTypeStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypeStatus");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("PipUserStatusId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("PipUserStatusId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("LoginProvider", "ProviderKey", "UserId")
                        .HasName("PK_dbo.AspNetUserLogins");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_dbo.AspNetUserRoles");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Centre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClusterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ClusterId");

                    b.ToTable("Centres");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.CentreFootfall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CentreId")
                        .HasColumnType("int");

                    b.Property<int>("QuarterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CentreId");

                    b.HasIndex("QuarterId");

                    b.ToTable("CentreFootfall");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Cluster", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cluster");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.CurrerntQuarter", b =>
                {
                    b.Property<int>("QuarterId")
                        .HasColumnType("int");

                    b.HasKey("QuarterId");

                    b.ToTable("CurrerntQuarter");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.PipUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("AuthId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PipUserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PipUser");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.PipUserStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("PipUserStatus");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Quarter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Quarter");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Acivity", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.ActitityType", "ActivityType")
                        .WithMany("Activities")
                        .HasForeignKey("ActivityTypeId")
                        .HasConstraintName("FK_Acivity_ActitityType")
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.AspNetUser", "PipUser")
                        .WithMany("Acivities")
                        .HasForeignKey("PipUserId")
                        .HasConstraintName("FK_Acivity_AspNetUsers")
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.Quarter", "Quarter")
                        .WithMany("Acivities")
                        .HasForeignKey("QuarterId")
                        .HasConstraintName("FK_Acivity_Quarter")
                        .IsRequired();

                    b.Navigation("ActivityType");

                    b.Navigation("PipUser");

                    b.Navigation("Quarter");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActitityType", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.Priority", "Priority")
                        .WithMany("ActitityTypes")
                        .HasForeignKey("PriorityId")
                        .HasConstraintName("FK_ActitityType_Priority")
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.ActivityTypeStatus", "Status")
                        .WithMany("ActitityTypes")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_ActitityType_ActivityTypeStatus")
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActivityCluster", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.Acivity", "Activity")
                        .WithMany("ActivityClusters")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Activity_Cluster_Acivity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.Cluster", "Cluster")
                        .WithMany("ActivityClusters")
                        .HasForeignKey("ClusterId")
                        .HasConstraintName("FK_Activity_Cluster_Cluster")
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Cluster");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUser", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.PipUserStatus", "PipUserStatus")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("PipUserStatusId")
                        .HasConstraintName("FK_AspNetUsers_PipUserStatus");

                    b.Navigation("PipUserStatus");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserClaim", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserLogin", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUserRole", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Centre", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.Cluster", "Cluster")
                        .WithMany("Centres")
                        .HasForeignKey("ClusterId")
                        .HasConstraintName("FK_Centres_Cluster")
                        .IsRequired();

                    b.Navigation("Cluster");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.CentreFootfall", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.Centre", "Centre")
                        .WithMany("CentreFootfalls")
                        .HasForeignKey("CentreId")
                        .HasConstraintName("FK_CentreFootfall_Centres")
                        .IsRequired();

                    b.HasOne("CLDStatsData.CLDStatsModels.Quarter", "Quarter")
                        .WithMany("CentreFootfalls")
                        .HasForeignKey("QuarterId")
                        .HasConstraintName("FK_CentreFootfall_Quarter")
                        .IsRequired();

                    b.Navigation("Centre");

                    b.Navigation("Quarter");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.CurrerntQuarter", b =>
                {
                    b.HasOne("CLDStatsData.CLDStatsModels.Quarter", "Quarter")
                        .WithOne("CurrerntQuarter")
                        .HasForeignKey("CLDStatsData.CLDStatsModels.CurrerntQuarter", "QuarterId")
                        .HasConstraintName("FK_CurrerntQuarter_Quarter")
                        .IsRequired();

                    b.Navigation("Quarter");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Acivity", b =>
                {
                    b.Navigation("ActivityClusters");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActitityType", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.ActivityTypeStatus", b =>
                {
                    b.Navigation("ActitityTypes");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetRole", b =>
                {
                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.AspNetUser", b =>
                {
                    b.Navigation("Acivities");

                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Centre", b =>
                {
                    b.Navigation("CentreFootfalls");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Cluster", b =>
                {
                    b.Navigation("ActivityClusters");

                    b.Navigation("Centres");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.PipUserStatus", b =>
                {
                    b.Navigation("AspNetUsers");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Priority", b =>
                {
                    b.Navigation("ActitityTypes");
                });

            modelBuilder.Entity("CLDStatsData.CLDStatsModels.Quarter", b =>
                {
                    b.Navigation("Acivities");

                    b.Navigation("CentreFootfalls");

                    b.Navigation("CurrerntQuarter");
                });
#pragma warning restore 612, 618
        }
    }
}
