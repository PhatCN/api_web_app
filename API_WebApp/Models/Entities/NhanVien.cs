using System;
using System.Collections.Generic;

namespace API_WebApp.Models.Entities;

public partial class NhanVien
{
	public int MaNhanVien { get; set; }

	public string HoTen { get; set; } = null!;

	public DateOnly? NgaySinh { get; set; }

	public string? GioiTinh { get; set; }

	public string? DiaChi { get; set; }

	public string? SoDienThoai { get; set; }

	public virtual ICollection<TaiKhoanDangNhap> TaiKhoanDangNhaps { get; set; } = new List<TaiKhoanDangNhap>();
}
