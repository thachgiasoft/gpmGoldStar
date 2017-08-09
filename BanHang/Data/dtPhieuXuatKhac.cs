using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtPhieuXuatKhac
    {
        public object ThemPhieuXuatKhac_Temp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuNhapSi = null;
                    string cmdText = "INSERT INTO [GPM_PhieuXuatKhac] ([NgayCapNhat]) OUTPUT INSERTED.ID VALUES (getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuNhapSi = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuNhapSi;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public void XoaPhieuXuatKhac_Temp(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_PhieuXuatKhac] WHERE [ID] = '" + ID + "'";
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
        public void XoaChiTietPhieuXuatKhac_Temp(string IDPhieuXuatKhac)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_ChiTietPhieuXuatKhac_Temp] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
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
        public DataTable KTChiTietPhieuXuatKhac_Temp(string IDHangHoa, string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_ChiTietPhieuXuatKhac_Temp] WHERE [IDHangHoa]= '" + IDHangHoa + "' AND [IDPhieuXuatKhac] = " + IDPhieuXuatKhac;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void ThemPhieuXuatKhac_Temp1(string IDPhieuXuatKhac, string IDHangHoa, int SoLuong, string IDDonViTinh, string MaHang, string SoLuongCon)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_ChiTietPhieuXuatKhac_Temp] ([IDPhieuXuatKhac],[IDHangHoa],[SoLuong],[IDDonViTinh],[MaHang],[SoLuongCon]) VALUES (@IDPhieuXuatKhac,@IDHangHoa,@SoLuong,@IDDonViTinh,@MaHang,@SoLuongCon)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuongCon);
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
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
        public void UpdatePhieuXuatKhac_temp(string IDPhieuXuatKhac, string IDHangHoa, int SoLuong)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_ChiTietPhieuXuatKhac_Temp] SET [IDPhieuXuatKhac] = @IDPhieuXuatKhac,[SoLuong] = @SoLuong WHERE [IDHangHoa] = @IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi");
                }
            }
        }
        public DataTable LayDanhSachPhieuXuatKhac_Temp(string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_ChiTietPhieuXuatKhac_Temp] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void CapNhatPhieuXuatKhac_ID(string ID, string IDNhanVien, string IDLyDoXuat, DateTime NgayLapPhieu, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_PhieuXuatKhac] SET [IDNhanVien] = @IDNhanVien, [IDLyDoXuat] = @IDLyDoXuat,[NgayLapPhieu] = @NgayLapPhieu,[GhiChu] = @GhiChu,[NgayCapNhat] = getdate() WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
          
                        myCommand.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        myCommand.Parameters.AddWithValue("@NgayLapPhieu", NgayLapPhieu);
                        myCommand.Parameters.AddWithValue("@IDLyDoXuat", IDLyDoXuat);
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi");
                }
            }
        }
        public void ThemChiTietPhieuXuatKhac(object IDPhieuXuatKhac, string IDHangHoa, string SoLuong, string MaHang, string IDDonViTinh, string SoLuongCon)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_ChiTietPhieuXuatKhac] ([IDPhieuXuatKhac],[IDHangHoa],[SoLuong],[MaHang],[IDDonViTinh],[SoLuongCon]) VALUES (@IDPhieuXuatKhac,@IDHangHoa,@SoLuong,@MaHang,@IDDonViTinh,@SoLuongCon)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuongCon);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDPhieuXuatKhac", IDPhieuXuatKhac);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
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

        public void XoaChiTietPhieuXuatKhac_Temp_ID(int ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_ChiTietPhieuXuatKhac_Temp] WHERE ID = @ID";
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
        public DataTable DanhSachPhieuXuatKhac()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT * FROM [GPM_PhieuXuatKhac] WHERE IDLyDoXuat is not null  ORDER BY [ID] DESC";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachChiTietPhieuXuatKhac_ID(string IDPhieuXuatKhac)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_ChiTietPhieuXuatKhac] WHERE [IDPhieuXuatKhac] = '" + IDPhieuXuatKhac + "'";
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