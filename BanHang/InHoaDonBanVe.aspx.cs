using BanHang.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class InHoaDonBanVe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDVe = Request.QueryString["IDVe"];

            rpInVe rp = new rpInVe();
            rp.Parameters["IDVe"].Value = IDVe;
            rp.Parameters["IDVe"].Visible = false;
            viewerReport.Report = rp;
        }
    }
}