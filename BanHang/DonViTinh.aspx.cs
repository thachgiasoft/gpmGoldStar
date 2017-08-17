using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DonViTinh : System.Web.UI.Page
    {
        dtDonViTinh data = new dtDonViTinh();
        protected void Page_Load(object sender, EventArgs e)
        {
             LoadGrid();
        }
        public void LoadGrid()
        {
            data = new dtDonViTinh();
            gridDonViTinh.DataSource = data.LayDanhSachDonViTinh();
            gridDonViTinh.DataBind();
        }

        protected void gridDonViTinh_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
           
            data = new dtDonViTinh();
            string TenDonViTinh = e.NewValues["TenDonViTinh"].ToString();
            string MoTa = e.NewValues["MoTa"] == null ? "" : e.NewValues["MoTa"].ToString(); 
            if (dtDonViTinh.KiemTra(dtSetting.convertDauSangKhongDau(TenDonViTinh)) == 1)
            {
                data.ThemDonViTinh(dtSetting.convertDauSangKhongDau(TenDonViTinh), MoTa);
                e.Cancel = true;
                gridDonViTinh.CancelEdit();
                LoadGrid();
            }
            else
            {
                throw new Exception("Lỗi: Tên đơn vị tính đã tồn tại: " + dtSetting.convertDauSangKhongDau(TenDonViTinh));
            }

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Đơn vị tính", "Thêm đơn vị tính");
        }

        protected void gridDonViTinh_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtDonViTinh();
            data.XoaDonViTinh(Int32.Parse(ID));
            e.Cancel = true;
            gridDonViTinh.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Đơn vị tính", "Xóa đơn vị tính ID: " + ID);
        }

        protected void gridDonViTinh_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys["ID"].ToString());
            string TenDonViTinh = e.NewValues["TenDonViTinh"].ToString();
            string MoTa = e.NewValues["MoTa"] == null ? "" : e.NewValues["MoTa"].ToString();
            data.SuaThongTinDonViTinh(ID, dtSetting.convertDauSangKhongDau(TenDonViTinh), MoTa);
            e.Cancel = true;
            gridDonViTinh.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Đơn vị tính", "Cập nhật đơn vị tính ID: " + ID);
        }
    }
}