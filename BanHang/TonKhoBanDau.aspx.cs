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
          LoadGrid();  
        }
        private void LoadGrid()
        {
            data = new dtKhoHang();
            gridTonKhoBanDau.DataSource = data.LayDanhSachHangTrongKho();
            gridTonKhoBanDau.DataBind();
        }
    }
}