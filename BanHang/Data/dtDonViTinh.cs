using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BanHang.Data
{
    public class dtDonViTinh
    {
        public DataTable LayDanhSachDonViTinh()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_DONVITINH] WHERE [DAXOA] = 0 and ID != 1";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public int layID_DonViTinh_Ten(string ten)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_DONVITINH] WHERE [TenDonViTinh] = '" + ten + "'";
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

        public static int KiemTra(string TenDonViTinh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_DONVITINH] WHERE [TenDonViTinh] = N'" + TenDonViTinh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                    {

                        return 1;
                    }
                    else return -1;
                }
            }
        }
        //public DataTable LayDanhSachDonViTinh_Full()
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = " SELECT * FROM [GPM_DONVITINH]";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb;
        //        }
        //    }
        //}

        //public DataTable LayDanhSachDonViTinh_Ten(string Ten)
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = " SELECT * FROM [GPM_DONVITINH] WHERE [DAXOA] = 0 AND TenDonViTinh ='"+Ten+"'";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb;
        //        }
        //    }
        //}

        //public int LayDonViTinh_GetID(string Ten)
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = " SELECT ID FROM [GPM_DONVITINH] WHERE [DAXOA] = 0 AND TenDonViTinh ='" + Ten + "'";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            string s = "43";
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            if (tb.Rows.Count != 0)
        //            {
        //                DataRow dr = tb.Rows[0];
        //                s = dr["ID"].ToString();
        //            }
        //            return Int32.Parse(s);
        //        }
        //    }
        //}

        public void ThemDonViTinh(string TenDonViTinh, string MoTa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_DONVITINH] ([TenDonViTinh],[MoTa], [NgayCapNhat]) VALUES (@TenDonViTinh,@MoTa, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@MoTa", MoTa);

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

        public void XoaDonViTinh(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_DONVITINH] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

        public void SuaThongTinDonViTinh(int ID, string TenDonViTinh, string MoTa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_DONVITINH] SET [TenDonViTinh] = @TenDonViTinh,[MoTa] = @MoTa, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenDonViTinh", TenDonViTinh);
                        myCommand.Parameters.AddWithValue("@MoTa", MoTa);
                      
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