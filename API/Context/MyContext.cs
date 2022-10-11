using API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=desktop-3eq7s2p;Initial Catalog=DTSMiniProject;Integrated Security=True");
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GK9TR5F;Initial Catalog=DTSMiniProject;User ID=mccdts1;Password=mccdts;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

          
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Role>().HasData(
               new Role { id = 1, name = "Kepala Bagian Produksi" },
               new Role { id = 2, name = "Manager" },
               new Role { id = 3, name = "Mankeu" }
           );
           // OnModelCreatingPartial(modelBuilder);
        }

    }
}
