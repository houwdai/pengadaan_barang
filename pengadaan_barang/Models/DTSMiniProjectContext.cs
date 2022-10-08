using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class DTSMiniProjectContext : DbContext
    {
        public DTSMiniProjectContext()
        {
        }

        public DTSMiniProjectContext(DbContextOptions<DTSMiniProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Divisi> Divisi { get; set; }
        public virtual DbSet<Pengadaan> Pengadaan { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Satuan> Satuan { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=desktop-3eq7s2p;Initial Catalog=DTSMiniProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Divisi>(entity =>
            {
                entity.ToTable("divisi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pengadaan>(entity =>
            {
                entity.ToTable("pengadaan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBarang).HasColumnName("idBarang");

                entity.Property(e => e.IdDivisi).HasColumnName("idDivisi");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.Kuantitas).HasColumnName("kuantitas");

                entity.Property(e => e.PengaadanGuid)
                    .HasColumnName("pengaadan_GUID")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('SPB-'+right(replicate('0',(8))+CONVERT([varchar],[id]),(5)))");

                entity.Property(e => e.Totals).HasColumnName("totals");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Pengadaan)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK__pengadaan__idBar__3C69FB99");

                entity.HasOne(d => d.IdDivisiNavigation)
                    .WithMany(p => p.Pengadaan)
                    .HasForeignKey(d => d.IdDivisi)
                    .HasConstraintName("FK__pengadaan__idDiv__3B75D760");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Pengadaan)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__pengadaan__idSta__3E52440B");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Pengadaan)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK__pengadaan__idSup__3D5E1FD2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HargaProduct).HasColumnName("hargaProduct");

                entity.Property(e => e.IdSatuan).HasColumnName("idSatuan");

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.NamaProduk)
                    .HasColumnName("namaProduk")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StockProduct).HasColumnName("stockProduct");

                entity.HasOne(d => d.IdSatuanNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdSatuan)
                    .HasConstraintName("FK__Product__idSatua__37A5467C");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK__Product__idSuppl__38996AB5");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Satuan>(entity =>
            {
                entity.ToTable("satuan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kota)
                    .HasColumnName("kota")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasColumnName("nama")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
