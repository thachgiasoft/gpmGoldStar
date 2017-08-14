using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BanHang.Data;

namespace BanHang
{
    public partial class ChiTietHoaDonDaIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDHoaDon = Request.QueryString["IDHoaDon"];
            dtBanHangLe dt = new dtBanHangLe();
            grdChiTietHoaDon.DataSource = dt.LayThongChiTietHoaDon_ID(IDHoaDon);
            grdChiTietHoaDon.DataBind();
        }

        protected void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string IDHoaDon = Request.QueryString["IDHoaDon"];
            chitietbuilInLai.ContentUrl = "~/InHoaDonBanLe.aspx?IDHoaDon=" + IDHoaDon;
            chitietbuilInLai.ShowOnPageLoad = true;
        }
    }
}