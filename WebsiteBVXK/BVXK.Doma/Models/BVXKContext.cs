using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<CtDonHang> CtDonHangs { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<LichTrinh> LichTrinhs { get; set; } = null!;
        public virtual DbSet<ThongKe> ThongKes { get; set; } = null!;
        public virtual DbSet<VeXe> VeXes { get; set; } = null!;
        public virtual DbSet<Xe> Xes { get; set; } = null!;
        //Scaffold-DbContext "Data Source=DESKTOP-R3JFTAQ;Initial Catalog=BVXK;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Models
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3JFTAQ;Initial Catalog=BVXK;Integrated Security=True");
        //            }
        //        }

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

            modelBuilder.Entity<CtDonHang>(entity =>
            {
                entity.HasKey(e => e.IdCtdonHang);

                entity.ToTable("CT_DonHang");

                entity.Property(e => e.IdCtdonHang).HasColumnName("idCTDonHang");

                entity.Property(e => e.IdDonHang).HasColumnName("idDonHang");

                entity.Property(e => e.SoGhe).HasColumnName("soGhe");

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.CtDonHangs)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DonHang_DonHang");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.IdDonHang);

                entity.ToTable("DonHang");

                entity.Property(e => e.IdDonHang).HasColumnName("idDonHang");

                entity.Property(e => e.Cmnd)
                    .HasColumnType("text")
                    .HasColumnName("cmnd");

                entity.Property(e => e.DiemDon)
                    .HasMaxLength(50)
                    .HasColumnName("diemDon");

                entity.Property(e => e.DiemTra)
                    .HasMaxLength(50)
                    .HasColumnName("diemTra");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.GhiChu)
                    .HasColumnType("text")
                    .HasColumnName("ghiChu");

                entity.Property(e => e.IdVeXe).HasColumnName("idVeXe");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .HasColumnName("soDienThoai")
                    .IsFixedLength();

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenKhachHang)
                    .HasMaxLength(50)
                    .HasColumnName("tenKhachHang");

                entity.Property(e => e.ThoiGianDon)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("thoiGianDon");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.HasOne(d => d.IdVeXeNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdVeXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_VeXe");
            });

            modelBuilder.Entity<LichTrinh>(entity =>
            {
                entity.HasKey(e => e.IdLichTrinh)
                    .HasName("PK_TTLichTrinh");

                entity.ToTable("LichTrinh");

                entity.Property(e => e.IdLichTrinh).HasColumnName("idLichTrinh");

                entity.Property(e => e.Hinh1)
                    .HasColumnType("image")
                    .HasColumnName("hinh1");

                entity.Property(e => e.Hinh2)
                    .HasColumnType("image")
                    .HasColumnName("hinh2");

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

            modelBuilder.Entity<ThongKe>(entity =>
            {
                entity.HasKey(e => e.IdThongKe);

                entity.ToTable("ThongKe");

                entity.Property(e => e.IdThongKe).HasColumnName("idThongKe");

                entity.Property(e => e.GiaVe)
                    .HasColumnType("money")
                    .HasColumnName("giaVe");

                entity.Property(e => e.IdVe).HasColumnName("idVe");

                entity.Property(e => e.LoaiVe).HasColumnName("loaiVe");

                entity.Property(e => e.NgayDat)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("ngayDat");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            });

            modelBuilder.Entity<VeXe>(entity =>
            {
                entity.HasKey(e => e.IdVe);

                entity.ToTable("VeXe");

                entity.Property(e => e.IdVe).HasColumnName("idVe");

                entity.Property(e => e.GiaVe).HasColumnType("money");

                entity.Property(e => e.IdLichTrinh).HasColumnName("idLichTrinh");

                entity.Property(e => e.LoaiVe).HasColumnName("loaiVe");

                entity.Property(e => e.TinhTrang).HasColumnName("tinhTrang");

                entity.HasOne(d => d.IdLichTrinhNavigation)
                    .WithMany(p => p.VeXes)
                    .HasForeignKey(d => d.IdLichTrinh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VeXe_LichTrinh");
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
