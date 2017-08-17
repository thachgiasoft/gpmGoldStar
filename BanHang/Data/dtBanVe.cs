using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtBanVe
    {
        //public int Dem_Max(string KyHieu)
        //{
        //    using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        con.Open();
        //        string cmdText = "SELECT ID FROM [GPM_GiaVe_ChiTiet] WHERE [KyHieu] = N'" + KyHieu + "'";
        //        using (SqlCommand command = new SqlCommand(cmdText, con))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            DataTable tb = new DataTable();
        //            tb.Load(reader);
        //            return tb.Rows.Count + 1;
        //        }
        //    }
        //}

        public void CapNhatHuyVe(string ID)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_GiaVe_ChiTiet] SET [HuyVe] = 1 WHERE [ID] = @ID";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", ID);;
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public void CapNhatDiemKhachHang(int IDKhachHang, int Diem)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string strSQL = "UPDATE [GPM_KhachHang] SET [DiemTichLuy] = [DiemTichLuy] - @Diem WHERE [ID] = @ID AND ID != 1";
                    using (SqlCommand myCommand = new SqlCommand(strSQL, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@ID", IDKhachHang);
                        myCommand.Parameters.AddWithValue("@Diem", Diem);
                        myCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Lỗi: Quá trình Xóa dữ liệu gặp lỗi, hãy tải lại trang");
                }
            }
        }

        public object InsertHoaDonBanVe(string IDNhanVien,string TenNhanVien, string IDKhachHang, HoaDonBanVe hoaDon,string DiemTichLuy)
        {
            object IDHoaDon = null;
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                SqlTransaction trans = null;
                try
                {
                    con.Open();
                    trans = con.BeginTransaction();
                    string InsertHoaDon = "INSERT INTO [GPM_BanVe] ([IDKhachHang],[TenKhachHang], [IDNhanVien],[TenNhanVien],[SoLuong],[TongTien],[NgayBan],[KhachCanTra],[KhachThanhToan],[TienThua],[GiamGia],[DiemTichLuy]) " +
                                            "OUTPUT INSERTED.ID " +
                                            "VALUES (@IDKhachHang, @TenKhachHang, @IDNhanVien,@TenNhanVien, @SoLuong, @TongTien, getdate(), @KhachCanTra, @KhachThanhToan,@TienThua, @GiamGia, @DiemTichLuy)";

                        using (SqlCommand cmd = new SqlCommand(InsertHoaDon, con, trans))
                        {
                            cmd.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                            cmd.Parameters.AddWithValue("@TenKhachHang", dtBanVe.LayTenKhachHang(IDKhachHang));
                            cmd.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                            cmd.Parameters.AddWithValue("@TenNhanVien",TenNhanVien );
                            cmd.Parameters.AddWithValue("@SoLuong", hoaDon.SoLuongHang);
                            cmd.Parameters.AddWithValue("@TongTien",hoaDon.TongTien);
                            cmd.Parameters.AddWithValue("@KhachCanTra", hoaDon.KhachCanTra);
                            cmd.Parameters.AddWithValue("@KhachThanhToan", hoaDon.KhachThanhToan);
                            cmd.Parameters.AddWithValue("@GiamGia",  hoaDon.GiamGia);
                            cmd.Parameters.AddWithValue("@TienThua", hoaDon.TienThua);
                            cmd.Parameters.AddWithValue("@DiemTichLuy", DiemTichLuy);
                            IDHoaDon = cmd.ExecuteScalar();
                        }
                        if (IDHoaDon != null)
                        {
                            foreach (ChiTietBanVe cthd in hoaDon.ListChiTietBanVe)
                            {
                                int SLMua = cthd.SoLuong;
                                for (int i = 0; i < SLMua; i++)
                                {
                                    //------------------------------------------------------------------------------------
                                    int STTV = 0;
                                    string SoVe;
                                    string GPM = "0000000";
                                    string cmdText = "SELECT ID FROM [GPM_GiaVe_ChiTiet] WHERE [KyHieu] = N'" + cthd.TenKyHieu + "'";
                                    using (SqlCommand command = new SqlCommand(cmdText, con, trans))
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        DataTable tb = new DataTable();
                                        tb.Load(reader);
                                        STTV = tb.Rows.Count + 1;
                                        int DoDaiHT = STTV.ToString().Length;
                                        string DoDaiGPM = GPM.Substring(0,7-DoDaiHT);
                                        SoVe = DoDaiGPM + STTV;
                                    }

                                    //-------------------------------------------------------------------------
                                    dtBanVe bv = new dtBanVe();
                                    string InsertChiTietHoaDon = "INSERT INTO [GPM_GiaVe_ChiTiet] ([IDBanVe],[KyHieu],[GiaVe],[SoThuTu],[NgayBan]) " +
                                                            "VALUES (@IDBanVe, @KyHieu, @GiaVe, @SoThuTu,getdate())";
                                    using (SqlCommand cmd = new SqlCommand(InsertChiTietHoaDon, con, trans))
                                    {
                                        cmd.Parameters.AddWithValue("@IDBanVe", IDHoaDon);
                                        cmd.Parameters.AddWithValue("@KyHieu", cthd.TenKyHieu);
                                        cmd.Parameters.AddWithValue("@GiaVe", cthd.DonGia);
                                        cmd.Parameters.AddWithValue("@SoThuTu", SoVe);
                                        cmd.ExecuteNonQuery();
                                    }

                                    
                                }

                                dtLichSuHeThong.ThemLichSuBanHang(IDNhanVien + "", IDKhachHang + "", " Bán vé", cthd.TenKyHieu, cthd.SoLuong + "", cthd.DonGia + "", "Bán vé");
                            }
                            if (Int32.Parse(IDKhachHang) != 1)
                            {
                                string TruDiemTichLuy = "UPDATE [GPM_KhachHang] SET DiemTichLuy = DiemTichLuy -  @DiemTichLuy WHERE ID = @ID";
                                using (SqlCommand cmd = new SqlCommand(TruDiemTichLuy, con, trans))
                                {
                                    cmd.Parameters.AddWithValue("@ID", IDKhachHang);
                                    cmd.Parameters.AddWithValue("@DiemTichLuy", DiemTichLuy);
                                    cmd.ExecuteNonQuery();
                                }

                                float TongTienGiam = hoaDon.KhachCanTra / float.Parse(dtSetting.LayTienQuyDoiDiem());
                                string CongDiemTichLuy = "UPDATE [GPM_KhachHang] SET DiemTichLuy = DiemTichLuy +  @DiemTichLuy1 WHERE ID = @ID";
                                using (SqlCommand cmd = new SqlCommand(CongDiemTichLuy, con, trans))
                                {
                                    cmd.Parameters.AddWithValue("@ID", IDKhachHang);
                                    cmd.Parameters.AddWithValue("@DiemTichLuy1", TongTienGiam);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        } 
                    trans.Commit();
                    con.Close();
                }
                catch (Exception ex)
                {
                    if (trans != null) trans.Rollback();
                    throw new Exception("Quá trình lưu dữ liệu có lỗi xảy ra, vui lòng tải lại trang và thanh toán lại !!");
                }
            }
            return IDHoaDon;
        }
        public static string LayTenKhachHang(string IDKhachHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT TenKhachHang FROM [GPM_KhachHang] WHERE [ID] = '" + IDKhachHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["TenKhachHang"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }

        public float DiemTichLuy(string IDKhachHang)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT DiemTichLuy FROM [GPM_KhachHang] WHERE [ID] = '" + IDKhachHang + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return float.Parse(dr["DiemTichLuy"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public DataTable ThongTinKyHieu(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_KyHieuGiaVe] WHERE ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tb = new DataTable();
                        tb.Load(reader);
                        return tb;
                    }
                }
            }
        }

        public DataTable LayDanhSachMaSoVe(string NgayBD, string NgayKT)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_GiaVe_ChiTiet] WHERE NgayBan >= '" + NgayBD + "' AND NgayBan <= '" + NgayKT + "' AND HuyVe = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tb = new DataTable();
                        tb.Load(reader);
                        return tb;
                    }
                }
            }
        }

        public DataTable LayDanhSachMaSoVe_ID(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT * FROM [GPM_GiaVe_ChiTiet] WHERE ID = '" + ID + "' AND HuyVe = 0";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tb = new DataTable();
                        tb.Load(reader);
                        return tb;
                    }
                }
            }
        }

        public DataTable LayThongTinVe(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT GPM_BanVe.IDKhachHang,GPM_BanVe.IDNhanVien,GPM_GiaVe_ChiTiet.* FROM GPM_GiaVe_ChiTiet, GPM_BanVe WHERE GPM_GiaVe_ChiTiet.IDBanVe = GPM_BanVe.ID AND GPM_GiaVe_ChiTiet.ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
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
}