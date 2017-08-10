using BanHang.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPrinting;
using System.Data.SqlClient;
using BanHang.Data;

namespace BanHang
{
    public partial class InHoaDonBanLe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            using (MemoryStream ms = new MemoryStream())
            {
                rpHoaDonBanHangLe r = new rpHoaDonBanHangLe();
                r.Parameters["IDHoaDon"].Value = Request.QueryString["IDHoaDon"];
                r.Parameters["IDHoaDon"].Visible = false;
                viewerReport.Report = r;
            }      
        }
    }
}