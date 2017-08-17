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
    public partial class DanhMucCombo : System.Web.UI.Page
    {
        dtHangCombo data = new dtHangCombo();
        protected void Page_Load(object sender, EventArgs e)
        {
             LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtHangCombo();
            gridDanhMucCombo.DataSource = data.DanhSachHangHoaCombo();
            gridDanhMucCombo.DataBind();
        }

        protected void gridDanhMucCombo_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtHangCombo();
            data.XoaHangCombo(ID);
            e.Cancel = true;
            gridDanhMucCombo.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Hàng hóa combo", "Xóa hàng hóa ID: " + ID);
        }

        protected void gridDanhMucCombo_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            string TenHangHoa = e.NewValues["TenHangHoa"] == null ? "" : e.NewValues["TenHangHoa"].ToString();
            if (TenHangHoa != "")
            {
                string TrangThaiHang = e.NewValues["TrangThaiHang"].ToString();
                string TongTien = e.NewValues["GiaBan1"].ToString();
                data = new dtHangCombo();
                data.CapNhatHangHoa_Combo(ID, TrangThaiHang,TongTien, TenHangHoa);
            }
            else
            {
                throw new Exception("Lỗi: Vui lòng nhập Tên hàng hóa");
            }
            e.Cancel = true;
            gridDanhMucCombo.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Hàng hóa combo", "Cập nhật hàng hóa ID: " + ID);
        }
    }
}