﻿// <auto-generated />
using System;
using Eticaret.Magaza.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eticaret.Magaza.Migrations
{
    [DbContext(typeof(MainDatabaseContext))]
    partial class MainDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eticaret.Model.Kategori", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier rowguidcol")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Kategori");
                });

            modelBuilder.Entity("Eticaret.Model.Satis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier rowguidcol")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("FaturaNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Satis");
                });

            modelBuilder.Entity("Eticaret.Model.SatisDetay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier rowguidcol")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<Guid>("SatisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UrunId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SatisDetay");
                });

            modelBuilder.Entity("Eticaret.Model.Urun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier rowguidcol")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<string>("GorselAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KategoriId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.ToTable("Urun");
                });

            modelBuilder.Entity("Eticaret.Model.Urun", b =>
                {
                    b.HasOne("Eticaret.Model.Kategori", "Kategori")
                        .WithMany()
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });
#pragma warning restore 612, 618
        }
    }
}