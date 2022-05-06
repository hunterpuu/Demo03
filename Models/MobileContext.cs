using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Demo03.Models
{
    public partial class MobileContext : DbContext
    {
        public MobileContext()
        {
        }

        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mobile> Mobiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Mobile;User Id=sa;Password=password@1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.ToTable("Mobile");

                entity.Property(e => e.Brands)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Devices)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("OS")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
