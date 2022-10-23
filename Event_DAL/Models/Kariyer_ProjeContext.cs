using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Event_DAL.Models
{
    public partial class Kariyer_ProjeContext : DbContext
    {
        public Kariyer_ProjeContext()
        {
        }

        public Kariyer_ProjeContext(DbContextOptions<Kariyer_ProjeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Attendee> Attendees { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyEvent> CompanyEvents { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventOwner> EventOwners { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.JoinedEventName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UpcomingJoinEventName).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendees_Events1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendees_AspNetUsers");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoriyName).HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName).HasMaxLength(30);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Domain).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<CompanyEvent>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.PaidEventId });

                entity.ToTable("CompanyEvent");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.PaidEventId).HasColumnName("PaidEventID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyEvents)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyEvent_Companies");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.EventAddress).HasMaxLength(50);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventLastApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(50);

                entity.Property(e => e.TicketFee).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Events_Categories");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Events_Cities");
            });

            modelBuilder.Entity<EventOwner>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(450)
                    .HasColumnName("OwnerID");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventOwners_Events");

                entity.HasOne(d => d.Owner)
                    .WithMany()
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventOwners_AspNetUsers");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasIndex(e => e.TicketId, "IX_Tickets")
                    .IsUnique();

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.AttendeeId).HasColumnName("AttendeeID");

                entity.Property(e => e.PaidEventId).HasColumnName("PaidEventID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
