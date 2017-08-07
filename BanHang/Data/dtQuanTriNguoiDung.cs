using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtQuanTriNguoiDung
    {
        public static int KT_Tendangnhap_CapNhat(string TenDangNhap, string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenDangNhap FROM [GPM_NGUOIDUNG] WHERE [TenDangNhap] = '" + TenDangNhap + "' AND ID = " + ID;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return 1;
                    }
                    else return -1;
                }
            }
        }
        public DataTable LayDanhSachNguoiDung()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT *  FROM [GPM_NGUOIDUNG] WHERE DAXOA = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public static int KiemTraNguoiDung(string TenDangNhap)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenDangNhap FROM [GPM_NGUOIDUNG] WHERE [TenDangNhap] = '" + TenDangNhap + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return 1;
                    }
                    else return -1;
                }
            }
        }


        public void ThemNguoiDung(string TenNguoiDung, string TenDangNhap, int IDNhomNguoiDung, string SDT, string MatKhau, string Email)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_NGUOIDUNG] ([TenNguoiDung],[TenDangNhap], [IDNhomNguoiDung], [SDT], [MatKhau], [NgayCapNhat],[Email]) VALUES (@TenNguoiDung,@TenDangNhap, @IDNhomNguoiDung, @SDT, @MatKhau, getdate(),@Email)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                        myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
                        myCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        myCommand.Parameters.AddWithValue("@SDT", SDT);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@MatKhau", MatKhau);
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
        public void XoaNguoiDung(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_NGUOIDUNG] SET [DaXoa] = 1 WHERE ID = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void SuaNguoiDung(int ID, string TenNguoiDung, string TenDangNhap, int IDNhomNguoiDung, string SDT, string MatKhau, string Email)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_NGUOIDUNG] SET [IDNhomNguoiDung] = @IDNhomNguoiDung,[TenDangNhap] = @TenDangNhap,[TenNguoiDung] = @TenNguoiDung,[SDT] = @SDT, [NgayCapNhat] = getdate(), [MatKhau] = @MatKhau,[Email] = @Email WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
                        myCommand.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        myCommand.Parameters.AddWithValue("@TenNguoiDung", TenNguoiDung);
                        myCommand.Parameters.AddWithValue("@SDT", SDT);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@MatKhau", MatKhau);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
    }
}