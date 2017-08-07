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
              //  int check =  Page.Session.Timeout;
                lblChao.Text = "Xin Chào: " + Session["TenDangNhap"].ToString();
                ASPxLabel2.Text = DateTime.Now.Year + Server.HtmlDecode(" &copy; Copyright by GPM");


            }
            
        }

        
        
    }
}