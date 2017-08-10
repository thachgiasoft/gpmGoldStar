using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BanHang.Data
{
    public class dtHangHoa
    {
        public static bool KiemTraMaHang(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT MaHang FROM [GPM_HangHoa] WHERE [MaHang] = '" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
        public void CapNhatBarCode(int ID, object IDHangHoa, string BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoa_Barcode] SET [IDHangHoa] = @IDHangHoa, [BarCode] = @BarCode,[NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@BarCode", BarCode);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public DataTable kiemTraBarcode(string IDHangHoa, string Barcode)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM GPM_HangHoa_Barcode WHERE IDHangHoa = '" + IDHangHoa + "' AND Barcode = '" + Barcode + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable LayDanhSachHangHoa()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_HangHoa where MaHang is not null and DaXoa = 0 and TrangThaiHang <3";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public string LayIDHangHoa_MaHang(string MaHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select ID from GPM_HangHoa where MaHang = '" + MaHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb.Rows[0]["ID"].ToString();
                }
            }
        }

        public DataTable LayDanhSachHangHoa_FullBarcode()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.GiaMua, GPM_HangHoa.GiaBan1, GPM_HangHoa.GiaBan2, GPM_HangHoa.GiaBan3, GPM_HangHoa.GiaBan4, GPM_HangHoa.GiaBan5 ,GPM_HangHoa.TrangThai, GPM_HangHoa_Barcode.Barcode, GPM_DonViTinh.TenDonViTinh, GPM_TrangThaiHang.TenTrangThai as TrangThaiHang from GPM_HangHoa,GPM_HangHoa_Barcode,GPM_DonViTinh, GPM_TrangThaiHang where GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh and GPM_HangHoa.ID = GPM_HangHoa_Barcode.IDHangHoa and GPM_TrangThaiHang.ID = GPM_HangHoa.TrangThaiHang";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public object ThemHangHoa(string MaHang, string TenHangHoa, string IDDonViTinh, float GiaMua, float GiaBan1, float GiaBan2, float GiaBan3, float GiaBan4, float GiaBan5, string TrangThaiHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object IDHangHoa = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HANGHOA] ([MaHang],[TenHangHoa],[IDDonViTinh],[GiaMua],[GiaBan1],[GiaBan2],[GiaBan3],[GiaBan4],[GiaBan5],[TrangThaiHang],[GhiChu],[NgayCapNhat])" +
                                     " OUTPUT INSERTED.ID" +
                                     " VALUES (@MaHang, @TenHangHoa, @IDDonViTinh, @GiaMua, @GiaBan1, @GiaBan2, @GiaBan3, @GiaBan4, @GiaBan5, @TrangThaiHang, @GhiChu, getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@TrangThaiHang", TrangThaiHang);
                        myCommand.Parameters.AddWithValue("@GiaMua", GiaMua);
                        myCommand.Parameters.AddWithValue("@GiaBan1", GiaBan1);
                        myCommand.Parameters.AddWithValue("@GiaBan2", GiaBan2);
                        myCommand.Parameters.AddWithValue("@GiaBan3", GiaBan3);
                        myCommand.Parameters.AddWithValue("@GiaBan4", GiaBan4);
                        myCommand.Parameters.AddWithValue("@GiaBan5", GiaBan5);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
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

      
        public void XoaHangHoa(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_HANGHOA] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

      
        public void SuaThongTinHangHoa(int ID, string MaHang, string TenHangHoa, string IDDonViTinh, float GiaMua, float GiaBan1, float GiaBan2, float GiaBan3, float GiaBan4, float GiaBan5, string TrangThaiHang, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_HANGHOA] SET [TrangThaiHang] = @TrangThaiHang,[GhiChu] = @GhiChu,[TenHangHoa] = @TenHangHoa, [IDDonViTinh] = @IDDonViTinh, [MaHang] = @MaHang, [GiaMua] = @GiaMua, [GiaBan1] = @GiaBan1, [GiaBan2] = @GiaBan2, [GiaBan3] = @GiaBan3, [GiaBan4] = @GiaBan4, [GiaBan5] = @GiaBan5,  [NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
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

     
        public void ThemDanhSachBarCode(object IDHangHoa, List<string> ListBarCode)
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
                        myCommand.Parameters.AddWithValue("@BarCode", "");
                        foreach (string barCode in ListBarCode)
                        {
                            myCommand.Parameters["@BarCode"].Value = barCode;
                            myCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public void ThemBarCode(object IDHangHoa, string BarCode)
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
        
        public DataTable GetListBarCode(object ID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [ID], [Barcode], [NgayCapNhat] FROM [GPM_HangHoa_Barcode] WHERE [IDHangHoa] = @IDHangHoa";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    command.Parameters.AddWithValue("@IDHangHoa", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public void SuaDanhSachBarCode(object ID, List<string> ListBarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE FROM [GPM_HangHoa_Barcode] WHERE [IDHangHoa] = @IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    ThemDanhSachBarCode(ID, ListBarCode);
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaBarCode(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE FROM [GPM_HangHoa_Barcode] WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
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

        public void ThemHangVaoTonKho(int IDHangHoa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HangHoaTonKho] ([IDHangHoa],[SoLuongCon],[NgayCapNhat]) VALUES (@IDHangHoa,0,getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaHangVaoTonKho(int IDHangHoa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE  FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = '" + IDHangHoa + "'";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public static bool KiemTraTonKho(int IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDHangHoa FROM [GPM_HangHoaTonKho] WHERE [IDHangHoa] = " + IDHangHoa;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}