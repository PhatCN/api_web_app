using System;
using System.Collections.Generic;

namespace API_WebApp.Models.Entities;

public partial class QuyenDangNhap
{
    public int MaQuyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<TaiKhoanDangNhap> TaiKhoanDangNhaps { get; set; } = new List<TaiKhoanDangNhap>();
}
