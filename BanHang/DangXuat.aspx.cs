using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DangXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Đăng Xuất", Session["IDKho"].ToString(), "Đăng Xuất", "Thoát");
            Session["KTDangNhap"] = null;
            Response.Redirect("DangNhap.aspx");
        }
    }
}