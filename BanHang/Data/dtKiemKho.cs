using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtKiemKho
    {
        public void CapNhatTrangThai(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_KiemKho] SET [TrangThai] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
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
        public static int LayTrangThaiKiemKho(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TrangThai FROM [GPM_KiemKho] WHERE [ID] = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["TrangThai"].ToString().Trim());
                    }
                    return 0;
                }
            }
        }
        //public static int LayIDKhoKiemKho(string ID)
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = "SELECT IDKho FROM [GPM_KiemKho] WHERE [ID] = " + ID;
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            if (tb.Rows.Count != 0)
        //            {
        //                DataRow dr = tb.Rows[0];
        //                return Int32.Parse(dr["IDKho"].ToString().Trim());
        //            }
        //            return 0;
        //        }
        //    }
        //}
        public DataTable DanhSachKiemKho()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KiemKho] WHERE IDNguoiDung is not null  ORDER BY [ID] DESC ";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachChiTietPhieuKiemKho_IDPhieuKiemKho(int IDPhieuKiemKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KiemKho_ChiTiet] WHERE IDPhieuKiemKho =" + IDPhieuKiemKho;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable DanhSachKiemKhoTemp_IDPhieuKiemKho(string IDPhieuKiemKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KiemKho_ChiTiet_Temp] WHERE [IDPhieuKiemKho] =" + IDPhieuKiemKho;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public object ThemPhieu_Temp()
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    object IDPhieuKiemKho = null;
                    string cmdText = "INSERT INTO [GPM_KiemKho] ([NgayCapNhat]) OUTPUT INSERTED.ID VALUES (getdate())";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        IDPhieuKiemKho = myCommand.ExecuteScalar();
                    }
                    myConnection.Close();
                    return IDPhieuKiemKho;
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
        public DataTable KTChiTietPhieuKiemKho_Temp(string IDHangHoa, string IDPhieuKiemKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KiemKho_ChiTiet_Temp] WHERE [IDHangHoa]= '" + IDHangHoa + "' AND [IDPhieuKiemKho] = " + IDPhieuKiemKho;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public void ThemPhieuKiemKho_Temp(string IDPhieuKiemKho, string IDHangHoa, int TonKho, int ChenhLech, string MaHang, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KiemKho_ChiTiet_Temp] ([IDPhieuKiemKho],[IDHangHoa],[TonKho],[ChenhLech],[MaHang],[IDDonViTinh]) VALUES (@IDPhieuKiemKho,@IDHangHoa,@TonKho,@ChenhLech,@MaHang,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                      
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDPhieuKiemKho", IDPhieuKiemKho);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@TonKho", TonKho);
                        myCommand.Parameters.AddWithValue("@ChenhLech", ChenhLech);

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
        public void CapNhatPhieuKiemKho_Temp(string ID, int ThucTe, int ChenhLech)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_KiemKho_ChiTiet_Temp] SET [ThucTe] = @ThucTe, [ChenhLech] = @ChenhLech WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);

                        myCommand.Parameters.AddWithValue("@ThucTe", ThucTe);
                        myCommand.Parameters.AddWithValue("@ChenhLech", ChenhLech);

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
        public void CapNhatPhieuKiemKho_Chinh(string ID, int ThucTe, int ChenhLech)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_KiemKho_ChiTiet] SET [ThucTe] = @ThucTe, [ChenhLech] = @ChenhLech WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);

                        myCommand.Parameters.AddWithValue("@ThucTe", ThucTe);
                        myCommand.Parameters.AddWithValue("@ChenhLech", ChenhLech);

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
        public void XoaPhieuKiemKho_Temp_ID(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE [GPM_KiemKho_ChiTiet_Temp] WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
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
        public void XoaPhieuKiemKho_Temp_IDPhieuKiemKho(string IDPhieuKiemKho)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "DELETE [GPM_KiemKho_ChiTiet_Temp] WHERE [IDPhieuKiemKho] = @IDPhieuKiemKho";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDPhieuKiemKho", IDPhieuKiemKho);
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
        public static int LayIDHangHoa_Barcode(string Barcode)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDHangHoa FROM [GPM_HangHoa_Barcode] WHERE [Barcode] = N'" + Barcode + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["IDHangHoa"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static int LayIDHangHoa_HangHoa(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID FROM [GPM_HangHoa] WHERE [ID] = '" + ID + "'";
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
        public void CapNhatPhieuKiemKho(string ID, string IDNguoiDung, DateTime NgayKiemKho, string GhiChu)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [GPM_KiemKho] SET [IDNguoiDung] = @IDNguoiDung, [NgayKiemKho] = @NgayKiemKho,[GhiChu] = @GhiChu WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);
                        myCommand.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
                        myCommand.Parameters.AddWithValue("@NgayKiemKho", NgayKiemKho);
                      
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
        public void ThemPhieuKiemKho(string IDPhieuKiemKho, string IDHangHoa, string TonKho, string ChenhLech, string ThucTe, string MaHang, string IDDonViTinh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "INSERT INTO [GPM_KiemKho_ChiTiet] ([IDPhieuKiemKho],[IDHangHoa],[TonKho],[ChenhLech],[ThucTe],[MaHang],[IDDonViTinh]) VALUES (@IDPhieuKiemKho,@IDHangHoa,@TonKho,@ChenhLech,@ThucTe,@MaHang,@IDDonViTinh)";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                     
                        myCommand.Parameters.AddWithValue("@IDDonViTinh", IDDonViTinh);
                        myCommand.Parameters.AddWithValue("@MaHang", MaHang);
                        myCommand.Parameters.AddWithValue("@IDPhieuKiemKho", IDPhieuKiemKho);
                        myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
                        myCommand.Parameters.AddWithValue("@TonKho", TonKho);
                        myCommand.Parameters.AddWithValue("@ChenhLech", ChenhLech);
                        myCommand.Parameters.AddWithValue("@ThucTe", ThucTe);
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