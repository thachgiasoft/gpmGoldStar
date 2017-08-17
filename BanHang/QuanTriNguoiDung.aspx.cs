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
    public partial class QuanTriNguoiDung : System.Web.UI.Page
    {
        dtQuanTriNguoiDung data = new dtQuanTriNguoiDung();
        protected void Page_Load(object sender, EventArgs e)
        {
           
             LoadGrid();
               
        }
        public void LoadGrid()
        {
            data = new dtQuanTriNguoiDung();
            gridQuanTriNguoiDung.DataSource = data.LayDanhSachNguoiDung();
            gridQuanTriNguoiDung.DataBind();
        }
        protected void gridQuanTriNguoiDung_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtQuanTriNguoiDung();
            data.XoaNguoiDung(Int32.Parse(ID));
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Quản trị người dùng", "Xóa quản trị người dùng ID: " + ID);
        }

        protected void gridQuanTriNguoiDung_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
           
            data = new dtQuanTriNguoiDung();
            string TenNguoiDung = e.NewValues["TenNguoiDung"].ToString();
            int IDNhomNguoiDung = Int32.Parse(e.NewValues["IDNhomNguoiDung"].ToString());
            string Email = e.NewValues["Email"].ToString();
            string SDT = e.NewValues["SDT"].ToString();
            string MatKhau = e.NewValues["MatKhau"].ToString();
            MatKhau = dtSetting.GetSHA1HashData(MatKhau);
            string TenDangNhap = e.NewValues["TenDangNhap"].ToString().ToUpper();

            if (dtQuanTriNguoiDung.KiemTraNguoiDung(TenDangNhap.Trim()) != -1)
            {
                throw new Exception("Lỗi: Tên đăng nhập đã tồn tại");
            }
            else
            {
                data.ThemNguoiDung(TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, MatKhau, Email);
               
            }
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Quản trị người dùng", "Thêm quản trị người dùng");
        }

        protected void gridQuanTriNguoiDung_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys["ID"].ToString();
            string TenNguoiDung = e.NewValues["TenNguoiDung"].ToString();
            int IDNhomNguoiDung = Int32.Parse(e.NewValues["IDNhomNguoiDung"].ToString());
           
            string SDT = e.NewValues["SDT"].ToString();
            string MatKhau = e.NewValues["MatKhau"].ToString();
            string Email = e.NewValues["Email"].ToString();
            MatKhau = dtSetting.GetSHA1HashData(MatKhau);
            string TenDangNhap = e.NewValues["TenDangNhap"].ToString().ToUpper();
            if (dtQuanTriNguoiDung.KT_Tendangnhap_CapNhat(TenDangNhap.Trim(), ID) == -1)
            {
                if (dtQuanTriNguoiDung.KiemTraNguoiDung(TenDangNhap.Trim()) == 1)
                {
                    throw new Exception("Lỗi: Tên đăng nhập đã tồn tại");
                }
                else
                {
                    data.SuaNguoiDung(Int32.Parse(ID), TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, MatKhau, Email);
                  
                }
            }
            else
            {
                data.SuaNguoiDung(Int32.Parse(ID), TenNguoiDung, TenDangNhap, IDNhomNguoiDung, SDT, MatKhau, Email);
               
            }
            e.Cancel = true;
            gridQuanTriNguoiDung.CancelEdit();
            LoadGrid();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Quản trị người dùng", "Cập nhật quản trị người dùng ID: " + ID);
        }
    }
}