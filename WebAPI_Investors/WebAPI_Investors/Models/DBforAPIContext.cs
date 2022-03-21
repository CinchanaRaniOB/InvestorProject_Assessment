using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_Investors.Models
{
    public partial class DBforAPIContext : DbContext
    {
        public DBforAPIContext()
        {
        }

        public DBforAPIContext(DbContextOptions<DBforAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Investor> Investor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DBforAPI;Integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investor>(entity =>
            {
                entity.Property(e => e.Contact).HasColumnType("numeric(12,0)");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProfilePictureUrl)
                    .HasColumnName("ProfilePictureURL")
                    .HasMaxLength(200);

                entity.Property(e => e.TotalInvestment)
                    .HasColumnName("Total_Investment")
                    .HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
