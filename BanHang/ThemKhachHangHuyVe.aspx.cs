using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ThemKhachHangHuyVe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            dtBanVe data = new dtBanVe();

            DateTime date = DateTime.Now;
            string NgayBD = date.ToString("yyyy-MM-dd") + " 00:00:00.000";
            string NgayKT = date.ToString("yyyy-MM-dd") + " 23:59:59.999";
            
            cmbMaSoVe.DataSource = data.LayDanhSachMaSoVe(NgayBD, NgayKT);
            cmbMaSoVe.DataBind();
        }

        protected void cmbMaSoVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtBanVe data = new dtBanVe();
            DataTable da = data.LayDanhSachMaSoVe_ID(cmbMaSoVe.Value + "");
            if (da.Rows.Count != 0)
            {
                txtKyHieu.Value = da.Rows[0]["KyHieu"].ToString();
                txtGiaVe.Value = da.Rows[0]["GiaVe"].ToString();
            }

            LoadGrid();
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {

            Response.Redirect("DanhSachKhachHangHuyVe.aspx");
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            dtBanVe data = new dtBanVe();
            DataTable da = data.LayThongTinVe(cmbMaSoVe.Value + "");
            if (da.Rows.Count != 0)
            {
                string IDBanVe = da.Rows[0]["IDBanVe"].ToString();
                string IDNhanVien = da.Rows[0]["IDNhanVien"].ToString();
                string IDKhachHang = da.Rows[0]["IDKhachHang"].ToString();
                string KyHieu = da.Rows[0]["KyHieu"].ToString();
                string GiaVe = da.Rows[0]["GiaVe"].ToString();
                string SoThuTu = da.Rows[0]["SoThuTu"].ToString();
                string GhiChu = txtGhiChu.Value + "";

                dtKhachHangHuyVe dt = new dtKhachHangHuyVe();
                dt.ThemPhieuHuyVe(IDBanVe, IDNhanVien, IDKhachHang, KyHieu, GiaVe, SoThuTu, GhiChu);

                string Diem = dtSetting.LayTienQuyDoiDiem();
                data.CapNhatHuyVe(cmbMaSoVe.Value + "");
                data.CapNhatDiemKhachHang(Int32.Parse(IDKhachHang), (int)(Int32.Parse(GiaVe) / float.Parse(Diem)));
            }

            Response.Redirect("DanhSachKhachHangHuyVe.aspx");
        }
    }
}