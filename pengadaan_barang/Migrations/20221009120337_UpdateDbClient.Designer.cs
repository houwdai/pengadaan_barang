﻿// <auto-generated />
using System;
using Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Client.Migrations
{
    [DbContext(typeof(DTSMiniProjectContext))]
    [Migration("20221009120337_UpdateDbClient")]
    partial class UpdateDbClient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Client.Models.Divisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nama")
                        .HasColumnName("nama")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("divisi");
                });

            modelBuilder.Entity("Client.Models.Pengadaan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdBarang")
                        .HasColumnName("idBarang")
                        .HasColumnType("int");

                    b.Property<int?>("IdDivisi")
                        .HasColumnName("idDivisi")
                        .HasColumnType("int");

                    b.Property<int?>("IdStatus")
                        .HasColumnName("idStatus")
                        .HasColumnType("int");

                    b.Property<int?>("IdSupplier")
                        .HasColumnName("idSupplier")
                        .HasColumnType("int");

                    b.Property<int?>("Kuantitas")
                        .HasColumnName("kuantitas")
                        .HasColumnType("int");

                    b.Property<string>("PengaadanGuid")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("pengaadan_GUID")
                        .HasColumnType("varchar(9)")
                        .HasComputedColumnSql("('SPB-'+right(replicate('0',(8))+CONVERT([varchar],[id]),(5)))")
                        .HasMaxLength(9)
                        .IsUnicode(false);

                    b.Property<int?>("Totals")
                        .HasColumnName("totals")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBarang");

                    b.HasIndex("IdDivisi");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdSupplier");

                    b.ToTable("pengadaan");
                });

            modelBuilder.Entity("Client.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HargaProduct")
                        .HasColumnName("hargaProduct")
                        .HasColumnType("int");

                    b.Property<int?>("IdSatuan")
                        .HasColumnName("idSatuan")
                        .HasColumnType("int");

                    b.Property<int?>("IdSupplier")
                        .HasColumnName("idSupplier")
                        .HasColumnType("int");

                    b.Property<string>("NamaProduk")
                        .HasColumnName("namaProduk")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("StockProduct")
                        .HasColumnName("stockProduct")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdSatuan");

                    b.HasIndex("IdSupplier");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Client.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Client.Models.Satuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nama")
                        .HasColumnName("nama")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("satuan");
                });

            modelBuilder.Entity("Client.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("status");
                });

            modelBuilder.Entity("Client.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alamat")
                        .HasColumnName("alamat")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Kota")
                        .HasColumnName("kota")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nama")
                        .HasColumnName("nama")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("supplier");
                });

            modelBuilder.Entity("Client.Models.Pengadaan", b =>
                {
                    b.HasOne("Client.Models.Product", "IdBarangNavigation")
                        .WithMany("Pengadaan")
                        .HasForeignKey("IdBarang")
                        .HasConstraintName("FK__pengadaan__idBar__3C69FB99");

                    b.HasOne("Client.Models.Divisi", "IdDivisiNavigation")
                        .WithMany("Pengadaan")
                        .HasForeignKey("IdDivisi")
                        .HasConstraintName("FK__pengadaan__idDiv__3B75D760");

                    b.HasOne("Client.Models.Status", "IdStatusNavigation")
                        .WithMany("Pengadaan")
                        .HasForeignKey("IdStatus")
                        .HasConstraintName("FK__pengadaan__idSta__3E52440B");

                    b.HasOne("Client.Models.Supplier", "IdSupplierNavigation")
                        .WithMany("Pengadaan")
                        .HasForeignKey("IdSupplier")
                        .HasConstraintName("FK__pengadaan__idSup__3D5E1FD2");
                });

            modelBuilder.Entity("Client.Models.Product", b =>
                {
                    b.HasOne("Client.Models.Satuan", "IdSatuanNavigation")
                        .WithMany("Product")
                        .HasForeignKey("IdSatuan")
                        .HasConstraintName("FK__Product__idSatua__37A5467C");

                    b.HasOne("Client.Models.Supplier", "IdSupplierNavigation")
                        .WithMany("Product")
                        .HasForeignKey("IdSupplier")
                        .HasConstraintName("FK__Product__idSuppl__38996AB5");
                });
#pragma warning restore 612, 618
        }
    }
}
