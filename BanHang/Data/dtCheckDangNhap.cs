using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtCheckDangNhap
    {
        public DataTable KiemTraQuanLy(string TenDangNhap, string MatKhau )
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_NguoiDung] WHERE [TenDangNhap] = N'" + TenDangNhap + "' AND [DAXOA] = 0 AND [MatKhau] =N'" + MatKhau + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable KiemTraBanHang(string TenDangNhap, string MatKhau)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_NguoiDung] WHERE [TenDangNhap] = N'" + TenDangNhap + "' AND [DAXOA] = 0  AND [MatKhau] = N'" + MatKhau + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayDanhSachMenu_IDNhomNguoiDung(int IDNhomNguoiDung)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_PhanQuyen] WHERE [IDNhomNguoiDung] = " + IDNhomNguoiDung;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable KiemTraNguoiDung(string TenDangNhap, string MatKhau)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_NguoiDung] WHERE [TenDangNhap] = N'" + TenDangNhap + "' AND [MatKhau] = N'" + MatKhau + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void DoiMatKhau(int ID, string MatKhau)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_NguoiDung] SET [MatKhau] = @MatKhau WHERE [ID] = " + ID;
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
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
    }
}