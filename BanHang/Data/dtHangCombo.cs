using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtHangCombo
    {

        public void XoaHangCombo(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoa] SET [DAXOA] = 1 WHERE [ID] = @ID";
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

        public void ThemBarCode(object IDHangHoa, string BarCode)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_HangHoa_Barcode] ([IDHangHoa],[Barcode],[NgayCapNhat])  VALUES(@IDHangHoa, @BarCode, getdate())";
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
        //public void ThemHangVaoTonKho(object IDKho, int IDHangHoa, int SoLuongCon, float GiaBan)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        try
        //        {
        //            myConnection.Open();
        //            string cmdText = "INSERT INTO [GPM_HangHoaTonKho] ([IDKho],[IDHangHoa],[SoLuongCon],[NgayCapNhat],[GiaBan]) VALUES (@IDKho,@IDHangHoa,@SoLuongCon,getdate(),@GiaBan)";
        //            using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@IDKho", IDKho);
        //                myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
        //                myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuongCon);
        //                myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
        //                myCommand.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw new Exception("Lỗi: Quá trình cập nhật dữ liệu gặp lỗi, hãy tải lại trang");
        //        }
        //    }
        //}
        //public DataTable LayDanhSachHangHoa_BanHangCombo()
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = "SELECT [GPM_HANGHOA].ID,[GPM_HANGHOA].MaHang,[GPM_HANGHOA].TenHangHoa,[GPM_HANGHOA].GiaBanSauThue,[GPM_DonViTinh].TenDonViTinh FROM [GPM_HANGHOA],[GPM_DonViTinh] WHERE [GPM_HANGHOA].[DAXOA] = 0 AND ([GPM_HANGHOA].[IDTrangThaiHang] =1 OR [GPM_HANGHOA].[IDTrangThaiHang] = 3) AND [GPM_HANGHOA].IDDonViTinh = [GPM_DonViTinh].ID";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb;
        //        }
        //    }
        //}
        public DataTable DanhSachHangHoaCombo()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [GPM_HANGHOA].* FROM [GPM_HANGHOA] WHERE TrangThai = 1 AND TenHangHoa is not null";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public object ThemIDHangHoa_Temp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuNhapSi = null;
                    string cmdText = "INSERT INTO [GPM_HangHoa] ([TrangThai],[NgayCapNhat]) OUTPUT INSERTED.ID VALUES (1,getdate())";
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
        public DataTable DanhSachHangHoaCombo_Temp(string IDHangHoaComBo)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "  SELECT [GPM_DonViTinh].TenDonViTinh,[GPM_HangHoa_Combo_Temp].*,[GPM_HangHoa].TenHangHoa  FROM [GPM_HangHoa_Combo_Temp],[GPM_HangHoa],[GPM_DonViTinh] WHERE  [GPM_DonViTinh].ID = [GPM_HangHoa_Combo_Temp].IDDonViTinh  AND [GPM_HangHoa].ID = [GPM_HangHoa_Combo_Temp].IDHangHoa  AND [GPM_HangHoa_Combo_Temp].[IDHangHoaCombo] =  '" + IDHangHoaComBo + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }

        public void ThemHangHoa_Temp(string IDHangHoaCombo, string IDHangHoa, int SoLuong, float GiaBan, float ThanhTien, string MaHang, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();

                    string cmdText = "INSERT INTO [GPM_HangHoa_Combo_Temp] ([MaHang],[IDDonViTinh],[IDHangHoaCombo],[IDHangHoa],[SoLuong],[GiaBan],[ThanhTien]) VALUES (@MaHang,@IDDonViTinh,@IDHangHoaCombo,@IDHangHoa,@SoLuong,@GiaBan,@ThanhTien)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                       
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDHangHoaCombo", IDHangHoaCombo);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
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

        public void ThemHangHoa(string IDHangHoaCombo, string IDHangHoa, int SoLuong, float GiaBan, float ThanhTien, string MaHang, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();

                    string cmdText = "INSERT INTO [GPM_HangHoa_Combo] ([IDHangHoaCombo],[IDHangHoa],[SoLuong],[GiaBan],[ThanhTien],[MaHang],[IDDonViTinh]) VALUES (@IDHangHoaCombo,@IDHangHoa,@SoLuong,@GiaBan,@ThanhTien,@MaHang,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                       
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDHangHoaCombo", IDHangHoaCombo);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
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
        public void XoaHangHoa_Temp_ID(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_HangHoa_Combo_Temp] WHERE [ID] = '" + ID + "'";
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

        public void XoaHangHoa_Temp_IDHangCombo(string IDHangHoaComBo)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "DELETE [GPM_HangHoa_Combo_Temp] WHERE [IDHangHoaComBo] = '" + IDHangHoaComBo + "'";
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



        public DataTable KTHangHoa_Temp(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_HangHoa_Combo_Temp] WHERE [IDHangHoa]= '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void UpdateHangHoa_temp(string IDHangHoaCombo, string IDHangHoa, int SoLuong, float GiaBan, float ThanhTien, string MaHang, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoa_Combo_Temp] SET [IDDonViTinh] = @IDDonViTinh,[MaHang] = @MaHang,[IDHangHoaCombo] = @IDHangHoaCombo,[SoLuong] = @SoLuong,[GiaBan] = @GiaBan ,[ThanhTien] = @ThanhTien  WHERE [IDHangHoa] = @IDHangHoa";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                      
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@IDHangHoaCombo", IDHangHoaCombo);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@SoLuong", SoLuong);
                        myCommand.Parameters.AddWithValue("@GiaBan", GiaBan);
                        myCommand.Parameters.AddWithValue("@ThanhTien", ThanhTien);
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

        public void CapNhatHangHoa(string ID, string MaHang, string IDDonViTinh, string TenHangHoa, float TongTien, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoa] SET [TrangThaiHang] = 3,[GhiChu] = @GhiChu,[MaHang] = @MaHang,[IDDonViTinh] = @IDDonViTinh ,[TenHangHoa] = @TenHangHoa,[GiaBan1] = @TongTien  WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@GhiChu", GhiChu);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@TongTien", TongTien);
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



        public DataTable DanhSachHangHoaCombo_IDHangHoaComBo(string IDHangHoaComBo)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from [GPM_HangHoa_Combo] where [IDHangHoaCombo] =  '" + IDHangHoaComBo + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        //public DataTable DanhSachHangHoaCombo_ID(int ID)
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = " SELECT * FROM [GPM_HangHoa_Combo] WHERE [ID] = '" + ID + "'";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb;
        //        }
        //    }
        //}

        public void CapNhatHangHoa_Combo(int ID, string TrangThaiHang, string TongTien, string TenHangHoa)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_HangHoa] SET [TenHangHoa] = @TenHangHoa,[TrangThaiHang] = @TrangThaiHang,[GiaBan1] = @TongTien WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@TenHangHoa", TenHangHoa);
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@TrangThaiHang", TrangThaiHang);
                        myCommand.Parameters.AddWithValue("@TongTien", TongTien);
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
    }
}