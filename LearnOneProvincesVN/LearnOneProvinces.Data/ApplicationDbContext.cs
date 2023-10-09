using LearnOneProvincesVN.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOneProvincesVN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Wards> Wards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.ToTable("Provinces");
                entity.HasKey(p => p.ID);
                entity.Property(p => p.ID).HasColumnName("ID");
                entity.Property(p => p.Provinces_Name).HasColumnName("Provinces_Name").HasMaxLength(255);
            });
            modelBuilder.Entity<Districts>(entity =>
            {
                entity.ToTable("Districts");
                entity.HasKey(p => p.ID);
                entity.Property(p => p.Districs_Name).HasColumnName("Districs_Name").HasMaxLength(255);
                entity.Property(p => p.Provinces_ID).HasColumnName("Provinces_ID").IsRequired(false);
                entity.HasOne(p => p.Provinces).WithMany(p => p.Districts).HasForeignKey(p => p.Provinces_ID);
            });
            modelBuilder.Entity<Wards>(entity =>
            {
                entity.ToTable("Wards");
                entity.HasKey(p => p.ID);
                entity.Property(p => p.ID).HasColumnName("ID");
                entity.Property(p => p.Wards_Name).HasColumnName("Wards_Name").HasMaxLength(255);
                entity.Property(p => p.Districts_ID).HasColumnName("Districs_ID").IsRequired(false);
                entity.HasOne(p => p.Districts).WithMany(p => p.Wards).HasForeignKey(p => p.Districts_ID);
            });
        }
    }
}
