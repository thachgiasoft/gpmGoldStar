using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class KyHieuGiaVe : System.Web.UI.Page
    {
        dtKyHieuGiaVe data = new dtKyHieuGiaVe();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtKyHieuGiaVe();
            gridDanhSach.DataSource = data.LayDanhSach();
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string MaKyHieu = e.NewValues["MaKyHieu"].ToString();
            string TenKyHieu = e.NewValues["TenKyHieu"].ToString();
            float GiaVe = float.Parse(e.NewValues["GiaVe"].ToString());
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtKyHieuGiaVe();
            data.Them(MaKyHieu, TenKyHieu, GiaVe, GhiChu);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Ký hiệu vé", "Thêm ký hiệu vé.");
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string MaKyHieu = e.NewValues["MaKyHieu"].ToString();
            string TenKyHieu = e.NewValues["TenKyHieu"].ToString();
            float GiaVe = float.Parse(e.NewValues["GiaVe"].ToString());
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtKyHieuGiaVe();
            data.SuaThongTin(ID,MaKyHieu, TenKyHieu, GiaVe, GhiChu);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Ký hiệu vé", "Cập nhật ký hiệu vé ID: " + ID);
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtKyHieuGiaVe();
            data.Xoa(ID);
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Ký hiệu vé", "Xóa ký hiệu vé ID: " + ID);
        }
    }
}