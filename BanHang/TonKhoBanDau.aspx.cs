using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class TonKhoBanDau : System.Web.UI.Page
    {
        dtKhoHang data = new dtKhoHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
                if (Session["IDThuNgan"] != null)
                    IDNhanVien1 = Session["IDThuNgan"].ToString();
                if (Session["IDNhanVien"] != null)
                    IDNhanVien1 = Session["IDNhanVien"].ToString();
                dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Tồn kho ban đầu", "Truy cập tồn kho ban đầu.");
            }
        }
        private void LoadGrid()
        {
            data = new dtKhoHang();
            gridTonKhoBanDau.DataSource = data.LayDanhSachHangTrongKho();
            gridTonKhoBanDau.DataBind();
        }
    }
}