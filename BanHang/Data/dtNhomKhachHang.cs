using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtNhomKhachHang
    {
        public DataTable LayDanhNhomKhachHang()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "  SELECT * FROM [GPM_NhomKhachHang]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void ThemNhomNhomHangMoi(string TenNhomKhachHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_NHOMKHACHHANG] ([TenNhomKhachHang], [NgayCapNhat], [GhiChu]) VALUES (@TenNhomKhachHang, getDATE(), @GhiChu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenNhomKhachHang", TenNhomKhachHang);
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

        public void XoaNhomKhachHang(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {

                    myConnection.Open();
                    string strSQL = "delete GPM_NHOMKHACHHANG where ID = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public void SuaThongTinNhomKhachHang(int ID, string TenNhomKhachHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_NHOMKHACHHANG] SET [TenNhomKhachHang] = @TenNhomKhachHang, [NgayCapNhat] = getDATE(), [GhiChu] = @GhiChu WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenNhomKhachHang", TenNhomKhachHang);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public DataTable LayDanhSachNhomKhachHang_Ten(string str)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_NHOMKHACHHANG] WHERE [DAXOA] = 0 AND TenNhomKhachHang = '" + str + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public int LayIDNhomKhachHang_Ten(string str)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID FROM [GPM_NHOMKHACHHANG] WHERE TenNhomKhachHang = '" + str + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return Int32.Parse(tb.Rows[0]["ID"].ToString());
                    }
                    return 1;
                }
            }
        }
    }
}