using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtLichSuHeThong
    {
        public static void ThemLichSuBanHang(string IDNhanVien, string IDKhachHang, string NoiDung, string MaHang, string SoLuong, string DonGia, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_LICHSUBANHANG] ([IDNhanVien],[IDKhachHang], [NoiDung],[MaHang], [SoLuong],[DonGia],[GhiChu],[Ngay]) VALUES (@IDNhanVien,@IDKhachHang, @NoiDung,@MaHang, @SoLuong,@DonGia,@GhiChu, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        myCommand.Parameters.AddWithValue("@NoiDung", NoiDung);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@DonGia", DonGia);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);

                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public static void ThemLichSuTruyCap(string IDNhanVien, string ThaoTac, string HanhDong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_LICHSUTRUYCAP] ([IDNhanVien],[ThaoTac], [HanhDong],[Ngay]) VALUES (@IDNhanVien,@ThaoTac, @HanhDong, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@ThaoTac", ThaoTac);
                        myCommand.Parameters.AddWithValue("@HanhDong", HanhDong);

                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }

        public static void ThemLichSuQuyDoiDiem(string IDKhachHang, string SoDiemCu, string SoDiemMoi, string NoiDung)
        {
            if (Int32.Parse(IDKhachHang) != 1 && (float.Parse(SoDiemCu) != float.Parse(SoDiemMoi)))
            {
                using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
                {
                    try
                    {
                        myConnection.Open();
                        string cmdText = "INSERT INTO [GPM_LichSuQuyDoiDiem] ([IDKhachHang],[SoDiemCu], [SoDiemMoi],[NoiDung],[Ngay]) VALUES (@IDKhachHang,@SoDiemCu, @SoDiemMoi,@NoiDung, getdate())";
                        using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                        {
                            myCommand.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                            myCommand.Parameters.AddWithValue("@SoDiemCu", SoDiemCu);
                            myCommand.Parameters.AddWithValue("@SoDiemMoi", SoDiemMoi);
                            myCommand.Parameters.AddWithValue("@NoiDung", NoiDung);

                            myCommand.ExecuteNonQuery();
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
}