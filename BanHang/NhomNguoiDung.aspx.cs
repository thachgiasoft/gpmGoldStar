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
    public partial class NhomNguoiDung : System.Web.UI.Page
    {
        dtNhomNguoiDung data = new dtNhomNguoiDung();
        protected void Page_Load(object sender, EventArgs e)
        {
           
             LoadGrid();
        }
        public void LoadGrid()
        {
            data = new dtNhomNguoiDung();
            gridNhomNguoiDung.DataSource = data.LayDanhSachNhomNguoiDung();
            gridNhomNguoiDung.DataBind();
        }

        protected void gridNhomNguoiDung_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtNhomNguoiDung();
           // data.XoaMenu_IDNhomNguoiDung(ID);
            data.XoaNhomNguoiDung(ID);
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Nhóm người dùng", "Xóa nhóm người dùng ID: " + ID);
        }

        protected void gridNhomNguoiDung_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtNhomNguoiDung();
            string TenNhom = e.NewValues["TenNhom"].ToString();
            object IDNhomNguoiDung = data.ThemNhomNguoiDung(TenNhom);
            //if (IDNhomNguoiDung != null)
            //{
            //    DataTable db = data.DanhSachMenu();
            //    foreach (DataRow dr in db.Rows)
            //    {
            //        int IDMenu = Int32.Parse(dr["ID"].ToString());
            //        data = new dtNhomNguoiDung();
            //        data.ThemMenu_IDNhomNguoiDung(IDNhomNguoiDung, IDMenu);
            //    }
            //}
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Nhóm người dùng", "Thêm nhóm người dùng");
         
        }

        protected void gridNhomNguoiDung_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string TenNhom = e.NewValues["TenNhom"].ToString();
            data.SuaThongTinNhomNguoiDung(Int32.Parse(ID), TenNhom);
            e.Cancel = true;
            gridNhomNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Nhóm người dùng", "Cập nhật nhóm người dùng");
        }
    }
}