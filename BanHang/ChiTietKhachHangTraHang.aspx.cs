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
    public partial class ChiTietKhachHangTraHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] == "GPM")
            {
                string IDPhieuKhachHangTraHang = Request.QueryString["IDPhieuKhachHangTraHang"];
                if (IDPhieuKhachHangTraHang != null)
                {
                    dtPhieuKhachHangTraHang data = new dtPhieuKhachHangTraHang();
                    DataTable da = data.ChiTietPhieuKhachHangTraHang(IDPhieuKhachHangTraHang);
                    gridDanhSachHangHoa.DataSource = da;
                    gridDanhSachHangHoa.DataBind();
                }
            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }
    }
}