using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_WebApp.Models.Entities;

public partial class QuanLyNhanVienContext : DbContext
{
	public QuanLyNhanVienContext()
	{
	}

	public QuanLyNhanVienContext(DbContextOptions<QuanLyNhanVienContext> options)
		: base(options)
	{
	}

	public virtual DbSet<NhanVien> NhanViens { get; set; }

	public virtual DbSet<QuyenDangNhap> QuyenDangNhaps { get; set; }

	public virtual DbSet<TaiKhoanDangNhap> TaiKhoanDangNhaps { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Name=DefaultConnection");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<NhanVien>(entity =>
		{
			entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA479FDEB086");

			entity.ToTable("NhanVien");

			entity.Property(e => e.DiaChi).HasMaxLength(255);
			entity.Property(e => e.GioiTinh).HasMaxLength(10);
			entity.Property(e => e.HoTen).HasMaxLength(100);
			entity.Property(e => e.SoDienThoai).HasMaxLength(15);
		});

		modelBuilder.Entity<QuyenDangNhap>(entity =>
		{
			entity.HasKey(e => e.MaQuyen).HasName("PK__QuyenDan__1D4B7ED4105655F9");

			entity.ToTable("QuyenDangNhap");

			entity.HasIndex(e => e.TenQuyen, "UQ__QuyenDan__5637EE79AE04D403").IsUnique();

			entity.Property(e => e.TenQuyen).HasMaxLength(50);
		});

		modelBuilder.Entity<TaiKhoanDangNhap>(entity =>
		{
			entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C65298AA827C1");

			entity.ToTable("TaiKhoanDangNhap");

			entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC09BE77D77").IsUnique();

			entity.Property(e => e.MatKhau).HasMaxLength(100);
			entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
			entity.Property(e => e.TenDangNhap).HasMaxLength(50);

			entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.TaiKhoanDangNhaps)
				.HasForeignKey(d => d.MaNhanVien)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_TaiKhoan_NhanVien");

			entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.TaiKhoanDangNhaps)
				.HasForeignKey(d => d.MaQuyen)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_TaiKhoan_Quyen");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
