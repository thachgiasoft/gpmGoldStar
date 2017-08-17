using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BanHang.Data
{
    public class dtBanHangLe
    {
        public DataTable LayThongHoaDon()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select TOP 10 GPM_HoaDon.ID,GPM_HoaDon.TongTien,GPM_KhachHang.TenKhachHang,GPM_HoaDon.NgayBan from GPM_HoaDon,GPM_KhachHang WHERE GPM_HoaDon.IDKhachHang = GPM_KhachHang.ID ORDER BY GPM_HoaDon.ID DESC";
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

        public string LayMaHoaDon_ID(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select MaHoaDon from GPM_HoaDon where ID = '" + ID + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tb = new DataTable();
                        tb.Load(reader);
                        return tb.Rows[0]["MaHoaDon"].ToString();
                    }
                }
            }
        }

        public DataTable LayThongHoaDon_BaoCao(string NgayBD, string NgayKT, string IDKho)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_ChiTietHoaDon.GiaMua,GPM_ChiTietHoaDon.GiaBan,GPM_ChiTietHoaDon.SoLuong from GPM_ChiTietHoaDon,GPM_HoaDon where GPM_ChiTietHoaDon.IDHangHoa = GPM_HoaDon.ID and GPM_HoaDon.IDKho = '" + IDKho + "' and GPM_HoaDon.NgayBan >= '" + NgayBD + "' and GPM_HoaDon.NgayBan <= '" + NgayKT + "'";
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

        public DataTable LayThongChiTietHoaDon_ID(string IDHoaDon)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_ChiTietHoaDon.DonGia as GiaBan,GPM_ChiTietHoaDon.SoLuong,GPM_ChiTietHoaDon.TongTien as ThanhTien,GPM_HangHoa.TenHangHoa,GPM_HangHoa.MaHang,GPM_DonViTinh.TenDonViTinh from GPM_ChiTietHoaDon,GPM_HangHoa,GPM_DonViTinh WHERE GPM_HangHoa.ID = GPM_ChiTietHoaDon.IDHangHoa AND GPM_HangHoa.IDDonViTinh = GPM_DonViTinh.ID AND GPM_ChiTietHoaDon.IDHoaDon = " + IDHoaDon;
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
        public DataTable LayThongTinHangHoa(string Barcode)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.ID, GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.IDDonViTinh, GPM_HangHoa.GiaBan1, GPM_DonViTinh.TenDonViTinh, GPM_HangHoa_Barcode.Barcode from GPM_HangHoa, GPM_DonViTinh, GPM_HangHoa_Barcode where GPM_HangHoa.ID = GPM_HangHoa_Barcode.IDHangHoa and GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh and GPM_HangHoa_Barcode.Barcode = @Barcode";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                {
                    command.Parameters.AddWithValue("@Barcode", Barcode);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tb = new DataTable();
                        tb.Load(reader);
                        return tb;
                    }
                }
            }
        }
        
        public object InsertHoaDon(string IDNhanVien, string IDKhachHang, HoaDon hoaDon)
        {
            object IDHoaDon = null;
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                SqlTransaction trans = null;
                try
                {
                    con.Open();
                    trans = con.BeginTransaction();
                    string InsertHoaDon = "INSERT INTO [GPM_HoaDon] ([IDKhachHang],[IDNhanVien],[NgayBan],[TongTien],[HinhThucGiamGia],[GiamGia],[KhachCanTra],[KhachThanhToan],[TienThua]) " +
                                          "OUTPUT INSERTED.ID " +
                                          "VALUES (@IDKhachHang, @IDNhanVien, getdate(), @TongTien, @HinhThucGiamGia, @GiamGia, @KhachCanTra, @KhachThanhToan, @TienThua)";

                    using (SqlCommand cmd = new SqlCommand(InsertHoaDon, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        cmd.Parameters.AddWithValue("@IDNhanVien", IDNhanVien);
                        cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                        cmd.Parameters.AddWithValue("@HinhThucGiamGia", hoaDon.HinhThucGiamGia);
                        cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                        cmd.Parameters.AddWithValue("@KhachCanTra", hoaDon.KhachCanTra);
                        cmd.Parameters.AddWithValue("@KhachThanhToan", hoaDon.KhachThanhToan);
                        cmd.Parameters.AddWithValue("@TienThua", hoaDon.TienThua);
                        IDHoaDon = cmd.ExecuteScalar();
                    }

                    DateTime date = DateTime.Now;
                    string strDate = date.ToString("ddMMyyyy") + "-";
                    string MaHD = strDate + ((int)IDHoaDon * 0.0001).ToString().Replace(".","");

                    string strUpdateMaHoaDon = "update GPM_HoaDon set MaHoaDon = @MaHoaDon where ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(strUpdateMaHoaDon, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", MaHD);
                        cmd.Parameters.AddWithValue("@ID", IDHoaDon);
                        cmd.ExecuteNonQuery();
                    }

                    string strUpdateDiemKH = "update GPM_KhachHang set DiemTichLuy = DiemTichLuy - @dTL where ID = @IDKhachHang and ID != 1";
                    using (SqlCommand cmd = new SqlCommand(strUpdateDiemKH, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@dTL", hoaDon.SoDiemGiam);
                        cmd.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        cmd.ExecuteNonQuery();
                    }

                    string strUpdateDiemKHTang = "update GPM_KhachHang set DiemTichLuy = DiemTichLuy + @dTLTang where ID = @IDKhachHang and ID != 1";
                    using (SqlCommand cmd = new SqlCommand(strUpdateDiemKHTang, con, trans))
                    {
                        cmd.Parameters.AddWithValue("@dTLTang", hoaDon.SoDiemTang);
                        cmd.Parameters.AddWithValue("@IDKhachHang", IDKhachHang);
                        cmd.ExecuteNonQuery();
                    }

                    if (IDHoaDon != null)
                    {
                        foreach (ChiTietHoaDon cthd in hoaDon.ListChiTietHoaDon)
                        {
                            dtHangHoa dtHH = new dtHangHoa();
                            dtLichSuHeThong.ThemLichSuBanHang(IDNhanVien + "", IDKhachHang + "", "Bán hàng", cthd.MaHang + "", cthd.SoLuong + "", cthd.DonGia + "", "Bán hàng");
                            
                            string InsertChiTietHoaDon = "INSERT INTO [GPM_ChiTietHoaDon] ([IDHoaDon],[IDHangHoa] ,[SoLuong],[DonGia],[TongTien]) " +
                                                         "VALUES (@IDHoaDon, @IDHangHoa, @SoLuong, @DonGia, @TongTien)";
                            using (SqlCommand cmd = new SqlCommand(InsertChiTietHoaDon, con, trans))
                            {
                                cmd.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                                cmd.Parameters.AddWithValue("@IDHangHoa", dtHH.LayIDHangHoa_MaHang(cthd.MaHang + ""));
                                cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                                cmd.Parameters.AddWithValue("@DonGia", cthd.DonGia);
                                cmd.Parameters.AddWithValue("@TongTien", cthd.ThanhTien);
                                cmd.ExecuteNonQuery();
                            }

                            string UpdateLichSuBanHang = "update GPM_HangHoaTonKho set SoLuongCon = SoLuongCon - @SL where IDHangHoa = (select ID from GPM_HangHoa where TrangThaiHang != 2 and ID = @IDHangHoa)";
                            using (SqlCommand cmd = new SqlCommand(UpdateLichSuBanHang, con, trans))
                            {
                                cmd.Parameters.AddWithValue("@SL", cthd.SoLuong);
                                cmd.Parameters.AddWithValue("@IDHangHoa", dtHH.LayIDHangHoa_MaHang(cthd.MaHang + ""));
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
        
    }
}