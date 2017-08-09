using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachKiemKho : System.Web.UI.Page
    {
        dtKiemKho data = new dtKiemKho();
        protected void Page_Load(object sender, EventArgs e)
        {
              LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtKiemKho();
            gridDanhSachKiemKho.DataSource = data.DanhSachKiemKho();
            gridDanhSachKiemKho.DataBind();
        }
    }
}