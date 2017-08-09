using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Collections;
using BanHang.Data;
using System.Data;

namespace BanHang {
    public partial class RootMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["KTDangNhap"] != "GPM")
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                lblChao.Text = "Xin Chào: " + Session["TenDangNhap"].ToString();
                ASPxLabel2.Text = Server.HtmlDecode("Copyrights &copy;") + DateTime.Now.Year + Server.HtmlDecode(". All Rights Reserved. Designed by GPM.VN");
            }
        }        
    }
}