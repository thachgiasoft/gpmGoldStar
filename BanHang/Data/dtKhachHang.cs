using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtKhachHang
    {
        public DataTable LayDanhSachKhachHang()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] where TenKhachHang != N'Khách lẻ' and DaXoa = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public string layDiemTichLuy(string IDKH)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT DiemTichLuy FROM [GPM_KHACHHANG] WHERE ID = " + IDKH;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb.Rows[0]["DiemTichLuy"].ToString();
                }
            }
        }

        public DataTable DanhSachQuan_IDThanhPho(string IDThanhPho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_district] WHERE [provinceid] = " + IDThanhPho;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayDanhSachKhachHang_ID(int ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] WHERE [GPM_KHACHHANG].DaXoa = 0 AND ID='" +ID +"'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public object ThemKhachHang(int IDNhomKhachHang, string MaKhachHang, string TenKhachHang, DateTime NgaySinh, string CMND, string DiaChi, string DienThoai, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object ID = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KHACHHANG] ([IDNhomKhachHang],[MaKhachHang], [TenKhachHang], [NgaySinh], [CMND], [DiaChi], [DienThoai], [GhiChu])  OUTPUT INSERTED.ID VALUES (@IDNhomKhachHang,@MaKhachHang, @TenKhachHang, @NgaySinh, @CMND, @DiaChi, @DienThoai, @GhiChu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDNhomKhachHang", IDNhomKhachHang);
                        myCommand.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                        myCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                        myCommand.Parameters.AddWithValue("@CMND", CMND);
                        myCommand.Parameters.AddWithValue("@DiaChi", DiaChi); 
                        myCommand.Parameters.AddWithValue("@DienThoai", DienThoai);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
                       // myCommand.ExecuteNonQuery();
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
        public object ThemKhachHang_Temp(int IDNhomKhachHang, string MaKhachHang, string TenKhachHang, DateTime NgaySinh, string CMND, string DiaChi, string DienThoai, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    object ID = null;
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KHACHHANG_IMPORT] ([IDNhomKhachHang],[MaKhachHang], [TenKhachHang], [NgaySinh], [CMND], [DiaChi], [DienThoai], [GhiChu])  OUTPUT INSERTED.ID VALUES (@IDNhomKhachHang,@MaKhachHang, @TenKhachHang, @NgaySinh, @CMND, @DiaChi, @DienThoai, @GhiChu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDNhomKhachHang", IDNhomKhachHang);
                        myCommand.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                        myCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                        myCommand.Parameters.AddWithValue("@CMND", CMND);
                        myCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                        myCommand.Parameters.AddWithValue("@DienThoai", DienThoai);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
                        // myCommand.ExecuteNonQuery();
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
        public void CapNhatMaKhachHang(object ID, string MaKhachHang, string Barcode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_KHACHHANG] SET [MaKhachHang] = @MaKhachHang,[Barcode] = @Barcode WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaKhachHang", MaKhachHang);
                        myCommand.Parameters.AddWithValue("@Barcode", Barcode);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }
        public void XoaKhachHang(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_KHACHHANG] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

        public void XoaKhachHang_NganhHang(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_KHACHHANG] SET [DAXOA] = 1 WHERE [IDNhomKhachHang] = @ID";
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

        public void SuaThongTinKhachHang(int ID, int IDNhomKhachHang, string TenKhachHang, DateTime NgaySinh, string CMND, string DiaChi, string DienThoai, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_KHACHHANG] SET [IDNhomKhachHang] = @IDNhomKhachHang,[TenKhachHang] = @TenKhachHang, [NgaySinh] = @NgaySinh, [CMND] = @CMND, [DiaChi] = @DiaChi, [DienThoai] = @DienThoai, [GhiChu] = @GhiChu WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDNhomKhachHang", IDNhomKhachHang);
                        myCommand.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                        myCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                        myCommand.Parameters.AddWithValue("@CMND", CMND);
                        myCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                        myCommand.Parameters.AddWithValue("@DienThoai", DienThoai);
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
        public DataTable KiemTraKhachHang_Ten(string TenKhachHang, string DienThoai)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] WHERE [GPM_KHACHHANG].DaXoa = 0 AND [GPM_KHACHHANG].TenKhachHang ='" + TenKhachHang + "' AND [GPM_KHACHHANG].DienThoai ='" + DienThoai + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public int KiemTraMaKhachHang(string MaKhachHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] WHERE MaKhachHang = " + MaKhachHang;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                        return 0;
                    return 1;
                }
            }
        }

        public int KiemTraSDTKhachHang(string SDT)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] WHERE DienThoai = '" + SDT + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                        return 0;
                    return 1;
                }
            }
        }

        public int KiemTraSDTKhachHang_KhacID(string ID, string SDT)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KHACHHANG] WHERE DienThoai = '" + SDT + "' AND ID != '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count == 0)
                        return 0;
                    return 1;
                }
            }
        }

        // import 
        public DataTable DanhSachKhachHang_Import_Temp()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_KhachHang_Import]";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void XoaDuLieuTemp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_KhachHang_Import]";
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

        public DataTable KiemTraKhachHang_Import_Temp(string TenKhachHang, string CMND, string DienThoai)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_KhachHang_Import] WHERE [GPM_KhachHang_Import].TenKhachHang = N'" + TenKhachHang + "' AND  [GPM_KhachHang_Import].CMND = N'" + CMND + "' AND [GPM_KhachHang_Import].DienThoai = N'" + DienThoai + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable KiemTraKhachHang_Import(string TenKhachHang, string CMND, string DienThoai)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_KhachHang] WHERE [GPM_KhachHang].TenKhachHang = N'" + TenKhachHang + "' AND  [GPM_KhachHang].CMND = N'" + CMND + "' AND [GPM_KhachHang].DienThoai = N'" + DienThoai + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void ThemKhachHang_Temp(int IDNhomKhachHang, string TenKhachHang, DateTime NgaySinh, string CMND, string DiaChi, int IDThanhPho, int IDQuan, string DienThoai, string Email, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KhachHang_Import] ([IDNhomKhachHang], [TenKhachHang], [NgaySinh], [CMND], [DiaChi], [IDThanhPho], [IDQuan], [DienThoai], [Email], [GhiChu]) " +
                    "VALUES (@IDNhomKhachHang, @TenKhachHang, @NgaySinh, @CMND, @DiaChi, @IDThanhPho, @IDQuan, @DienThoai, @Email, @GhiChu)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {

                        myCommand.Parameters.AddWithValue("@IDNhomKhachHang", IDNhomKhachHang);
                        myCommand.Parameters.AddWithValue("@TenKhachHang", TenKhachHang);
                        myCommand.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                        myCommand.Parameters.AddWithValue("@CMND", CMND);
                        myCommand.Parameters.AddWithValue("@DiaChi", DiaChi);
                        myCommand.Parameters.AddWithValue("@IDThanhPho", IDThanhPho);
                        myCommand.Parameters.AddWithValue("@IDQuan", IDQuan);
                        myCommand.Parameters.AddWithValue("@DienThoai", DienThoai);
                        myCommand.Parameters.AddWithValue("@Email", Email);
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


        public void XoaDuLieuTemp_ID(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_KhachHang_Import] WHERE [ID] = '" + ID + "'";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
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
        public DataTable Lay_IDNhomHang(string TenNhomHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_NhomKhachHang] WHERE [TenNhomKhachHang] = N'" + TenNhomHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable Lay_IDQuan(string name)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_district] WHERE name = N'" + name + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public DataTable Lay_IDThanhPho(string name)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_province] WHERE name = N'" + name + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
    }
}