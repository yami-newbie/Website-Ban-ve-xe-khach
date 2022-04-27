using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BVXK.Domain.Models
{
    public partial class BVXKContext : DbContext
    {
        public BVXKContext()
        {
        }

        public BVXKContext(DbContextOptions<BVXKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<LichTrinh> LichTrinhs { get; set; } = null!;
        public virtual DbSet<VeXe> VeXes { get; set; } = null!;
        public virtual DbSet<Xe> Xes { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("WebsiteBVXKContext"));

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("Account");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .HasColumnType("image")
                    .HasColumnName("avatar");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .HasColumnName("displayName");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength();

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.IdDonHang);

                entity.ToTable("DonHang");

                entity.Property(e => e.IdDonHang).HasColumnName("idDonHang");

                entity.Property(e => e.DiemDon)
                    .HasMaxLength(50)
                    .HasColumnName("diemDon");

                entity.Property(e => e.DiemTra)
                    .HasMaxLength(50)
                    .HasColumnName("diemTra");

                entity.Property(e => e.IdLichTrinh).HasColumnName("idLichTrinh");

                entity.Property(e => e.IdVeXe).HasColumnName("idVeXe");

                entity.Property(e => e.IdXe).HasColumnName("idXe");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .HasColumnName("soDienThoai")
                    .IsFixedLength();

                entity.Property(e => e.TenKhachHang)
                    .HasMaxLength(50)
                    .HasColumnName("tenKhachHang");

                entity.Property(e => e.ThoiGianDon)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("thoiGianDon");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.Property(e => e.TongTien)
                    .HasColumnType("money")
                    .HasColumnName("tongTien");

                entity.HasOne(d => d.IdLichTrinhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdLichTrinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_LichTrinh");

                entity.HasOne(d => d.IdVeXeNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdVeXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_VeXe");

                entity.HasOne(d => d.IdXeNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_Xe");
            });

            modelBuilder.Entity<LichTrinh>(entity =>
            {
                entity.HasKey(e => e.IdLichTrinh)
                    .HasName("PK_TTLichTrinh");

                entity.ToTable("LichTrinh");

                entity.Property(e => e.IdLichTrinh).HasColumnName("idLichTrinh");

                entity.Property(e => e.IdXe).HasColumnName("idXe");

                entity.Property(e => e.NgayDen)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ngayDen");

                entity.Property(e => e.NgayDi)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ngayDi");

                entity.Property(e => e.NoiDen)
                    .HasMaxLength(50)
                    .HasColumnName("noiDen");

                entity.Property(e => e.NoiXuatPhat)
                    .HasMaxLength(50)
                    .HasColumnName("noiXuatPhat");

                entity.HasOne(d => d.IdXeNavigation)
                    .WithMany(p => p.LichTrinhs)
                    .HasForeignKey(d => d.IdXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LichTrinh_Xe");
            });

            modelBuilder.Entity<VeXe>(entity =>
            {
                entity.HasKey(e => e.IdVe);

                entity.ToTable("VeXe");

                entity.Property(e => e.IdVe).HasColumnName("idVe");

                entity.Property(e => e.GiaVe).HasColumnType("money");

                entity.Property(e => e.IdLichTrinh).HasColumnName("idLichTrinh");

                entity.Property(e => e.IdXe).HasColumnName("idXe");

                entity.Property(e => e.LoaiVe).HasColumnName("loaiVe");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.HasOne(d => d.IdXeNavigation)
                    .WithMany(p => p.VeXes)
                    .HasForeignKey(d => d.IdXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeXe_Xe");
            });

            modelBuilder.Entity<Xe>(entity =>
            {
                entity.HasKey(e => e.IdXe);

                entity.ToTable("Xe");

                entity.Property(e => e.IdXe).HasColumnName("idXe");

                entity.Property(e => e.BienSo)
                    .HasMaxLength(10)
                    .HasColumnName("bienSo")
                    .IsFixedLength();

                entity.Property(e => e.LoaiXe).HasColumnName("loaiXe");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .HasColumnName("soDienThoai")
                    .IsFixedLength();

                entity.Property(e => e.SoLuongGhe).HasColumnName("soLuongGhe");

                entity.Property(e => e.TenTaiXe)
                    .HasMaxLength(50)
                    .HasColumnName("tenTaiXe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
