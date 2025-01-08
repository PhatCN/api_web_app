 using System;
using System.Collections.Generic;

namespace API_WebApp.Models.Entities;

public partial class TaiKhoanDangNhap
{
	public int MaTaiKhoan { get; set; }

	public string TenDangNhap { get; set; } = null!;

	public string MatKhau { get; set; } = null!;

	public int? MaNhanVien { get; set; }

	public int? MaQuyen { get; set; }

	public DateOnly? NgayTao { get; set; }

	public virtual NhanVien? MaNhanVienNavigation { get; set; }

	public virtual QuyenDangNhap? MaQuyenNavigation { get; set; }
}
