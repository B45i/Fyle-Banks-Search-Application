using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace fyle_backend.Models
{
    public partial class postgresContext : DbContext
    {
        private IConfiguration _configuration;

        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<BankBranches> BankBranches { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<BankBranches>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bank_branches");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(195);

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.BankName)
                    .HasColumnName("bank_name")
                    .HasMaxLength(49);

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(74);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(50);

                entity.Property(e => e.Ifsc)
                    .HasColumnName("ifsc")
                    .HasMaxLength(11);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(26);
            });

            modelBuilder.Entity<Banks>(entity =>
            {
                entity.ToTable("banks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(49);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(e => e.Ifsc)
                    .HasName("branches_ifsc_pkey");

                entity.ToTable("branches");

                entity.Property(e => e.Ifsc)
                    .HasColumnName("ifsc")
                    .HasMaxLength(11);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(195);

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(74);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(26);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("branches_banks_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
