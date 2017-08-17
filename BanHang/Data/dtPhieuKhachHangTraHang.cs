using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtPhieuKhachHangTraHang
    {
        public DataTable DanhSachPhieuKhachHangTraHang()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM GPM_KhachHangTraHang";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable ChiTietPhieuKhachHangTraHang_Temp(string IDPhhieuTraHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_HangHoa.MaHang,GPM_HangHoa.TenHangHoa,GPM_DonViTinh.TenDonViTinh,GPM_KhachHangTraHang_ChiTiet_Temp.* FROM GPM_KhachHangTraHang_ChiTiet_Temp, GPM_HangHoa, GPM_DonViTinh WHERE GPM_HangHoa.IDDonViTinh = GPM_DonViTinh.ID AND GPM_HangHoa.ID = GPM_KhachHangTraHang_ChiTiet_Temp.IDHangHoa AND GPM_KhachHangTraHang_ChiTiet_Temp.IDKhachHangTraHang = '" + IDPhhieuTraHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable ChiTietPhieuKhachHangTraHang(string IDPhhieuTraHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_HangHoa.MaHang,GPM_HangHoa.TenHangHoa,GPM_DonViTinh.TenDonViTinh,GPM_KhachHangTraHang_ChiTiet.* FROM GPM_KhachHangTraHang_ChiTiet,GPM_DonViTinh, GPM_HangHoa WHERE GPM_HangHoa.ID = GPM_KhachHangTraHang_ChiTiet.IDHangHoa AND GPM_HangHoa.IDDonViTinh = GPM_DonViTinh.ID AND GPM_KhachHangTraHang_ChiTiet.IDKhachHangTraHang = '" + IDPhhieuTraHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable HoaDon_ID(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_HoaDon where ID = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable DanhSachHangHoa_HoaDon(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.TenHangHoa, GPM_HangHoa.MaHang, GPM_DonViTinh.TenDonViTinh, GPM_ChiTietHoaDon.* from GPM_DonViTinh,GPM_HangHoa,GPM_ChiTietHoaDon where GPM_HangHoa.TraHang = 0 and GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh and GPM_ChiTietHoaDon.IDHangHoa = GPM_HangHoa.ID and GPM_ChiTietHoaDon.IDHoaDon = '" + IDHoaDon + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void XoaPhieu_Temp(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_KhachHangTraHang where ID = '" + IDPhieu + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void XoaPhieu_Null()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_KhachHangTraHang where MaHoaDon is null and IDKhachHang is null and SoLuongHang is null";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void XoaChiTiet_Temp(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_KhachHangTraHang_ChiTiet_Temp where IDKhachHangTraHang = '" + IDPhieu + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void XoaChiTiet_TempID(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_KhachHangTraHang_ChiTiet_Temp where ID = '" + ID + "'";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public DataTable ChiTietHangHoa_ID(string IDHangHoa, string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_KhachHangTraHang_ChiTiet_Temp where IDHangHoa = '" + IDHangHoa + "' and IDKhachHangTraHang = '" + IDPhieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable ChiTietTongSoLuongHangHoa(string IDPhieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select IDKhachHangTraHang, SUM(SoLuong) as SoLuong, SUM(ThanhTien) as ThanhTien from GPM_KhachHangTraHang_ChiTiet_Temp where IDKhachHangTraHang = '" + IDPhieu + "' group by IDKhachHangTraHang";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable ChiTietHangHoa(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.IDDonViTinh, GPM_ChiTietHoaDon.* from GPM_HangHoa,GPM_ChiTietHoaDon where GPM_ChiTietHoaDon.IDHangHoa = GPM_HangHoa.ID and GPM_ChiTietHoaDon.ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public object ThemPhieuKhachHangTraHang()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object ID = null;
                    string cmdText = "INSERT INTO [GPM_KhachHangTraHang] ([NgayLap]) OUTPUT INSERTED.ID VALUES (getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        ID = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return ID;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public object ThemChiTietPhieuKhachHangTraHang_Temp(string IDKhachHangTraHang, string IDHangHoa, string DonGia, string SoLuong, string ThanhTien, string LyDoTra)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuChuyenKho = null;
                    string cmdText = "INSERT INTO [GPM_KhachHangTraHang_ChiTiet_Temp] ([IDKhachHangTraHang],[IDHangHoa],[DonGia],[SoLuong],[ThanhTien],[LyDoTra]) OUTPUT INSERTED.ID VALUES ('" + IDKhachHangTraHang + "','" + IDHangHoa + "','" + DonGia + "','" + SoLuong + "','" + ThanhTien + "',N'" + LyDoTra + "')";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuChuyenKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuChuyenKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public object ThemChiTietPhieuKhachHangTraHang(string IDKhachHangTraHang, string IDHangHoa, string DonGia, string SoLuong, string ThanhTien, string LyDoTra)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuChuyenKho = null;
                    string cmdText = "INSERT INTO [GPM_KhachHangTraHang_ChiTiet] ([IDKhachHangTraHang],[IDHangHoa],[DonGia],[SoLuong],[ThanhTien],[LyDoTra]) OUTPUT INSERTED.ID VALUES ('" + IDKhachHangTraHang + "','" + IDHangHoa + "','" + DonGia + "','" + SoLuong + "','" + ThanhTien + "',N'" + LyDoTra + "')";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuChuyenKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuChuyenKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public void CapNhatChiTietPhieuKhachHangTraHang_Temp(string IDKhachHangTraHang, string IDHangHoa, string DonGia, string SoLuong, string ThanhTien, string LyDoTra)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "update GPM_KhachHangTraHang_ChiTiet_Temp set DonGia = '" + DonGia + "', SoLuong = '" + SoLuong + "', ThanhTien = '" + ThanhTien + "', LyDoTra = '" + LyDoTra + "' where IDKhachHangTraHang = '" + IDKhachHangTraHang + "' and IDHangHoa = '" + IDHangHoa + "'";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public void CapNhatPhieuKhachHangTraHang(string ID, string MaHoaDon, string IDNhanVien, string IDKhachHang, string SoLuongHang, string TongTien, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "update GPM_KhachHangTraHang set MaHoaDon = '" + MaHoaDon + "', IDNhanVien = '" + IDNhanVien + "', IDKhachHang = '" + IDKhachHang + "', SoLuongHang = '" + SoLuongHang + "', TongTien = '" + TongTien + "', GhiChu = '" + GhiChu + "' where ID = '" + ID + "'";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
    }
}