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
    public partial class DanhSachPhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
        protected void Page_Load(object sender, EventArgs e)
        {
             LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtPhieuXuatKhac();
            gridPhieuXuatKhac.DataSource = data.DanhSachPhieuXuatKhac();
            gridPhieuXuatKhac.DataBind();
        }

        protected void gridPhieuXuatKhac_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //int ID = Int32.Parse(e.Keys[0].ToString());
            //data = new dtPhieuXuatKhac();
            //DataTable da = data.LayDanhSachChiTietPhieuXuatKhac_ID(ID);
            //if (da.Rows.Count != 0)
            //{
            //    DataRow dr = da.Rows[0];
            //    int SoLuong = Int32.Parse(dr["SoLuong"].ToString());
            //    //dtLichSuKho.ThemLichSu(ID, Int32.Parse(Session["IDNhanVien"].ToString()), SoLuong * (-1), "Xóa danh sách phiếu xuất khác");
            //}
            //data.XoaPhieuXuatKhac_ID(ID);
            //e.Cancel = true;
            //gridPhieuXuatKhac.CancelEdit();
            //LoadGrid();

            //dtLichSuTruyCap dt1 = new dtLichSuTruyCap();
            //dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Phiếu Xuất Khác: " + ID,Session["IDKho"].ToString(), "Nhập xuất tồn", "Xóa"); ;   
        }
    }
}