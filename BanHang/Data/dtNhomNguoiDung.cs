using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtNhomNguoiDung
    {
        public DataTable LayDanhSachNhomNguoiDung()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_NHOMNGUOIDUNG]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        //public DataTable DanhSachMenu()
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = " SELECT * FROM [GPM_MENU]";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb;
        //        }
        //    }
        //}
        //public void ThemMenu_IDNhomNguoiDung(object IDNhomNguoiDung, int IDMenu)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        try
        //        {
        //            myConnection.Open();
        //            string cmdText = "INSERT INTO [GPM_PhanQuyen] ([IDNhomNguoiDung],[IDMenu],[NgayCapNhat]) VALUES (@IDNhomNguoiDung,@IDMenu,getdate())";
        //            using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@IDNhomNguoiDung", IDNhomNguoiDung);
        //                myCommand.Parameters.AddWithValue("@IDMenu", IDMenu);
        //                myCommand.ExecuteNonQuery();
        //            }
        //            myConnection.Close();
        //        }
        //        catch
        //        {
        //            throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
        //        }
        //    }
        //}
        //public void XoaMenu_IDNhomNguoiDung(int IDNhomNguoiDung)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        try
        //        {
        //            myConnection.Open();
        //            string cmdText = "DELETE [GPM_PhanQuyen] WHERE IDNhomNguoiDung =  " + IDNhomNguoiDung;
        //            using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
        //            {
        //                myCommand.ExecuteNonQuery();
        //            }
        //            myConnection.Close();
        //        }
        //        catch
        //        {
        //            throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
        //        }
        //    }
        //}
        public object ThemNhomNguoiDung(string TenNhom)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object IDNhomNguoiDung = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_NHOMNGUOIDUNG] ([TenNhom],[NgayCapNhat])  OUTPUT INSERTED.ID VALUES (@TenNhom,getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenNhom", TenNhom);
                        IDNhomNguoiDung = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDNhomNguoiDung;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public void XoaNhomNguoiDung(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_NHOMNGUOIDUNG] WHERE [ID] = @ID";
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
        public void SuaThongTinNhomNguoiDung(int ID, string TenNhom)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_NHOMNGUOIDUNG] SET [TenNhom] = @TenNhom, [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TenNhom", TenNhom);
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