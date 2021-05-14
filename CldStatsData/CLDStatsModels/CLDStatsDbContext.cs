using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;


#nullable disable

namespace CldStatsData.CldStatsModels
{
    public partial class CLDStatsDbContext : DbContext
    {
        public CLDStatsDbContext()
        {
        }

        public CLDStatsDbContext(DbContextOptions<CLDStatsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acivity> Acivities { get; set; }
        public virtual DbSet<ActitityType> ActitityTypes { get; set; }
        public virtual DbSet<ActivityCluster> ActivityClusters { get; set; }
        public virtual DbSet<ActivityTypeStatus> ActivityTypeStatuses { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<Centre> Centres { get; set; }
        public virtual DbSet<CentreFootfall> CentreFootfalls { get; set; }
        public virtual DbSet<Cluster> Clusters { get; set; }
        public virtual DbSet<CurrerntQuarter> CurrerntQuarters { get; set; }
        public virtual DbSet<PipUser> PipUsers { get; set; }
        public virtual DbSet<PipUserStatus> PipUserStatuses { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=CLDStats");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Acivity>(entity =>
            {
                entity.ToTable("Acivity");

                entity.Property(e => e.Note)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.PipUserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acivity_ActitityType");

                entity.HasOne(d => d.PipUser)
                    .WithMany(p => p.Acivities)
                    .HasForeignKey(d => d.PipUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acivity_AspNetUsers");

                entity.HasOne(d => d.Quarter)
                    .WithMany(p => p.Acivities)
                    .HasForeignKey(d => d.QuarterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acivity_Quarter");
            });

            modelBuilder.Entity<ActitityType>(entity =>
            {
                entity.ToTable("ActitityType");

                //entity.HasIndex(e => e.Id, "IX_ActitityType").IsUnique();

                //entity.HasIndex(e => e.Name, "IX_ActitityType_1").IsUnique();

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.ActitityTypes)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActitityType_Priority");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ActitityTypes)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActitityType_ActivityTypeStatus");
            });

            modelBuilder.Entity<ActivityCluster>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.ClusterId });

                entity.ToTable("Activity_Cluster");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityClusters)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Activity_Cluster_Acivity");

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.ActivityClusters)
                    .HasForeignKey(d => d.ClusterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Cluster_Cluster");
            });

            modelBuilder.Entity<ActivityTypeStatus>(entity =>
            {
                entity.ToTable("ActivityTypeStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.PipUserStatus)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.PipUserStatusId)
                    .HasConstraintName("FK_AspNetUsers_PipUserStatus");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Centre>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.Centres)
                    .HasForeignKey(d => d.ClusterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Centres_Cluster");
            });

            modelBuilder.Entity<CentreFootfall>(entity =>
            {
                entity.ToTable("CentreFootfall");

                entity.HasOne(d => d.Centre)
                    .WithMany(p => p.CentreFootfalls)
                    .HasForeignKey(d => d.CentreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CentreFootfall_Centres");

                entity.HasOne(d => d.Quarter)
                    .WithMany(p => p.CentreFootfalls)
                    .HasForeignKey(d => d.QuarterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CentreFootfall_Quarter");
            });

            modelBuilder.Entity<Cluster>(entity =>
            {
                entity.ToTable("Cluster");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CurrerntQuarter>(entity =>
            {
                entity.HasKey(e => e.QuarterId);

                entity.ToTable("CurrerntQuarter");

                entity.Property(e => e.QuarterId).ValueGeneratedNever();

                entity.HasOne(d => d.Quarter)
                    .WithOne(p => p.CurrerntQuarter)
                    .HasForeignKey<CurrerntQuarter>(d => d.QuarterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrerntQuarter_Quarter");
            });

            modelBuilder.Entity<PipUser>(entity =>
            {
                entity.ToTable("PipUser");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.AuthId).HasMaxLength(128);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PipUserStatus>(entity =>
            {
                entity.ToTable("PipUserStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.ToTable("Priority");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Quarter>(entity =>
            {
                entity.ToTable("Quarter");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
