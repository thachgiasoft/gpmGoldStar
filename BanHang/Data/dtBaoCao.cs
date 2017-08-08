using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BanHang.Data
{
    public class dtBaoCao
    {
        public DataTable LayDanhSach_HangHoaTonKho()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.IDDonViTinh, GPM_HangHoa.TrangThaiHang, GPM_HangHoaTonKho.SoLuongCon, GPM_HangHoaTonKho.NgayCapNhat from GPM_HangHoa, GPM_HangHoaTonKho where GPM_HangHoa.ID = GPM_HangHoaTonKho.IDHangHoa";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public DataTable LayDanhSach_LoaiHangHoa()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_TrangThaiHang";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
        public string layTen_LoaiHangHoa_ID(string ID)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select * from GPM_TrangThaiHang where ID = " + ID;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return tb.Rows[0]["TenTrangThai"].ToString();
                    }
                    return "";
                }
            }
        }
        public int layID_LoaiHangHoa_Ten(string ten)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "select ID from GPM_TrangThaiHang where TenTrangThai = '" + ten + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        return Int32.Parse(tb.Rows[0]["ID"].ToString());
                    }
                    return 0;
                }
            }
        }
    }
}