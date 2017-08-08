using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtImportHangHoa
    {
        public void XoaDuLieuTemp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_HangHoa_Import]";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaDuLieuTemp_ID(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_HangHoa_Import] WHERE [ID] = " + ID;
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public DataTable DanhSachHangHoa_Import_Temp()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_HangHoa_Import]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable KiemTraHangHoa_Import_Temp(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_HangHoa_Import] WHERE MaHang ='" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public object insertHangHoa_temp(string MaHang, string TenHangHoa, int IDDonViTinh, float GiaMua, float GiaBan1, float GiaBan2, float GiaBan3, float GiaBan4, float GiaBan5, int TrangThaiHang, int TrangThai, string Barcode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object IDHangHoa = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HangHoa_Import] ([MaHang], [TenHangHoa], [IDDonViTinh], [GiaMua], [GiaBan1], [GiaBan2], [GiaBan3], [GiaBan4], [GiaBan5], [TrangThaiHang], [TrangThai], [Barcode])" +
                                     " OUTPUT INSERTED.ID" +
                                     " VALUES (@MaHang, @TenHangHoa,@IDDonViTinh, @GiaMua, @GiaBan1, @GiaBan2, @GiaBan3, @GiaBan4, @GiaBan5, @TrangThaiHang, @TrangThai, @Barcode)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan1", GiaBan1);
                        myCommand.Parameters.AddWithValue("@GiaBan2", GiaBan2);
                        myCommand.Parameters.AddWithValue("@GiaBan3", GiaBan3);
                        myCommand.Parameters.AddWithValue("@GiaBan4", GiaBan4);
                        myCommand.Parameters.AddWithValue("@GiaBan5", GiaBan5);
                        myCommand.Parameters.AddWithValue("@TrangThaiHang", TrangThaiHang);
                        myCommand.Parameters.AddWithValue("@TrangThai", TrangThai);
                        myCommand.Parameters.AddWithValue("@Barcode", Barcode);
                        IDHangHoa = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();

                    return IDHangHoa;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public void ThemhBarCode(object IDHangHoa, string BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HangHoa_Barcode] ([IDHangHoa],[Barcode],[NgayCapNhat])" +
                             " VALUES(@IDHangHoa, @BarCode, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@BarCode", BarCode);
                        myCommand.ExecuteNonQuery();
                     
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public DataTable KiemTraHangHoa(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_HangHoa] WHERE [MaHang] = '" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void ThemHangHoa_Temp(int IDNhaCungCap, int IDMaHang, string TenHang, int IDDonViTinh, float GiaMua, float GiaBan, string Barcode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HangHoa_Import] ([IDNhaCungCap], [IDMaHang], [TenHang], [IDDonViTinh], [GiaMua], [GiaBan],[Barcode]) VALUES (@IDNhaCungCap, @IDMaHang, @TenHang, @IDDonViTinh, @GiaMua, @GiaBan,@Barcode)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNhaCungCap", IDNhaCungCap);
                        myCommand.Parameters.AddWithValue("@IDMaHang", IDMaHang);
                        myCommand.Parameters.AddWithValue("@TenHang", TenHang);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@Barcode", Barcode);
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
        public static int Lay_IDNhaCungCap(string TenNhaCungCap)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_NhaCungCap] WHERE [TenNhaCungCap] = N'" + TenNhaCungCap + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["ID"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static int Lay_IDMaHang(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_MaHang] WHERE [MaHang] = N'" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["ID"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static int Lay_IDDVT(string TenDonViTinh)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT ID FROM [GPM_DonViTinh] WHERE [TenDonViTinh] = N'" + TenDonViTinh + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["ID"].ToString());
                    }
                    else return -1;
                }
            }
        }
    }
}