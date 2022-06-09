using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiProyectoSmart.Models
{
    public partial class IF4101_ParkingLotContext : DbContext
    {
        public IF4101_ParkingLotContext()
        {
        }

        public IF4101_ParkingLotContext(DbContextOptions<IF4101_ParkingLotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParkingLot> ParkingLots { get; set; } = null!;
        public virtual DbSet<Rate> Rates { get; set; } = null!;
        public virtual DbSet<RateType> RateTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Spot> Spots { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=IF4101_ParkingLot;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.HasKey(e => e.IdParkingLot);

                entity.ToTable("ParkingLot");

                entity.Property(e => e.IdParkingLot).HasColumnName("Id_ParkingLot");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.District).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(15);

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.ParkingLots)
                    .UsingEntity<Dictionary<string, object>>(
                        "ParkingLotOperator",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ParkingLot_Operator_User"),
                        r => r.HasOne<ParkingLot>().WithMany().HasForeignKey("ParkingLotId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ParkingLot_Operator_ParkingLot"),
                        j =>
                        {
                            j.HasKey("ParkingLotId", "UserId");

                            j.ToTable("ParkingLot_Operator");
                        });
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => e.IdRate);

                entity.ToTable("Rate");

                entity.Property(e => e.IdRate).HasColumnName("Id_Rate");

                entity.HasOne(d => d.RateType)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.RateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Rate_Type");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rate_Vehicle_Type");
            });

            modelBuilder.Entity<RateType>(entity =>
            {
                entity.HasKey(e => e.IdRateType);

                entity.ToTable("Rate_Type");

                entity.Property(e => e.IdRateType).HasColumnName("Id_RateType");

                entity.Property(e => e.BookingTime)
                    .HasMaxLength(20)
                    .HasColumnName("Booking_Time");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("Id_Role");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Spot>(entity =>
            {
                entity.HasKey(e => e.IdSpot);

                entity.ToTable("Spot");

                entity.Property(e => e.IdSpot).HasColumnName("Id_Spot");

                entity.Property(e => e.Status).HasMaxLength(15);

                entity.Property(e => e.Type).HasMaxLength(15);

                entity.Property(e => e.VehicleId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ParkingLot)
                    .WithMany(p => p.Spots)
                    .HasForeignKey(d => d.ParkingLotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spot_ParkingLot");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Spots)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_Spot_Vehicle");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK_Ticket_1");

                entity.ToTable("Ticket");

                entity.HasIndex(e => new { e.SpotId, e.StarDay }, "uq_spot_starday")
                    .IsUnique();

                entity.Property(e => e.IdTicket).HasColumnName("Id_Ticket");

                entity.Property(e => e.EndDay).HasColumnType("datetime");

                entity.Property(e => e.StarDay).HasColumnType("datetime");

                entity.HasOne(d => d.ParkingLot)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ParkingLotId)
                    .HasConstraintName("FK_Ticket_ParkingLot");

                entity.HasOne(d => d.RateType)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RateTypeId)
                    .HasConstraintName("FK_Ticket_Rate_Type");

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SpotId)
                    .HasConstraintName("FK_Ticket_Spot");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Ticket_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.Identification).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(15);

                entity.Property(e => e.TelNumber)
                    .HasMaxLength(15)
                    .HasColumnName("Tel_Number");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.IdVehicle);

                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.LicensePlate, "UQ__Vehicle__026BC15C1839DBF3")
                    .IsUnique();

                entity.Property(e => e.IdVehicle).HasColumnName("Id_Vehicle");

                entity.Property(e => e.Brand).HasMaxLength(25);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.LicensePlate).HasMaxLength(10);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Vehicle_Type");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Vehicles)
                    .UsingEntity<Dictionary<string, object>>(
                        "VehicleUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Vehicle_User_User1"),
                        r => r.HasOne<Vehicle>().WithMany().HasForeignKey("VehicleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Vehicle_User_Vehicle1"),
                        j =>
                        {
                            j.HasKey("VehicleId", "UserId");

                            j.ToTable("Vehicle_User");
                        });
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.IdType);

                entity.ToTable("Vehicle_Type");

                entity.Property(e => e.IdType).HasColumnName("Id_Type");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
