using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class NhomKhachHang : System.Web.UI.Page
    {
        dtNhomKhachHang data = new dtNhomKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            data = new dtNhomKhachHang();
            gridNhomKhachHang.DataSource = data.LayDanhNhomKhachHang();
            gridNhomKhachHang.DataBind();
        }

        protected void gridNhomKhachHang_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string TenNhomKhachHang = e.NewValues["TenNhomKhachHang"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data = new dtNhomKhachHang();
            data.ThemNhomNhomHangMoi(TenNhomKhachHang, GhiChu);
            e.Cancel = true;
            gridNhomKhachHang.CancelEdit();
            LoadGrid();
        }

        protected void gridNhomKhachHang_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string TenNhomKhachHang = e.NewValues["TenNhomKhachHang"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();
            data.SuaThongTinNhomKhachHang(Int32.Parse(ID), TenNhomKhachHang, GhiChu);
            e.Cancel = true;
            gridNhomKhachHang.CancelEdit();
            LoadGrid();
        }

        protected void gridNhomKhachHang_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtNhomKhachHang();
            data.XoaNhomKhachHang(Int32.Parse(ID));
            e.Cancel = true;
            gridNhomKhachHang.CancelEdit();
            LoadGrid();
        }
    }
}