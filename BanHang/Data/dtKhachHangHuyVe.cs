using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtKhachHangHuyVe
    {
        public DataTable DanhSachPhieuKhachHangHuyVe()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM GPM_KhachHangHuyVe";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void XoaPhieu_Null()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "delete from GPM_KhachHangHuyVe where IDBanVe is null and IDNhanVien is null and MaVe is null";
                using (SqlCommand myCommand = new SqlCommand(cmdText, con))
                {
                    myCommand.ExecuteNonQuery();
                }
            }
        }

        public void ThemPhieuHuyVe(string IDBanVe, string IDNhanVien, string IDKhachHang, string KyHieu, string GiaVe, string SoThuTu, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KhachHangHuyVe] ([IDBanVe],[IDNhanVien],[IDKhachHang],[MaVe],[DonGia],[MaSoVe],[GhiChu], [NgayLap]) VALUES (@IDBanVe,@IDNhanVien,@IDKhachHang,@KyHieu,@GiaVe,@SoThuTu,@GhiChu, getDATE())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDBanVe", IDBanVe);
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        myCommand.Parameters.AddWithValue("@KyHieu", KyHieu);
                        myCommand.Parameters.AddWithValue("@GiaVe", GiaVe);
                        myCommand.Parameters.AddWithValue("@SoThuTu", SoThuTu);
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

    }
}