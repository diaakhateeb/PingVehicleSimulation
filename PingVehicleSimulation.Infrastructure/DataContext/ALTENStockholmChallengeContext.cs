using Microsoft.EntityFrameworkCore;
using PingVehicleSimulation.Core.Entities;

#nullable disable

namespace PingVehicleSimulation.Infrastructure.DataContext
{
    public partial class ALTENStockholmChallengeContext : DbContext
    {
        public ALTENStockholmChallengeContext()
        {
        }

        public ALTENStockholmChallengeContext(DbContextOptions<ALTENStockholmChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleStatusTran> VehicleStatusTrans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ALTEN-Stockholm-Challenge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.RegNumber).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Vehicle_Customer");
            });

            modelBuilder.Entity<VehicleStatusTran>(entity =>
            {
                entity.Property(e => e.PingTime).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(3);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleStatusTrans)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_VehStatusTrans_Vehicle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
