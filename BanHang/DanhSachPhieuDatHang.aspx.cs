using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachPhieuDatHang : System.Web.UI.Page
    {
        dtDatHang data = new dtDatHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtDatHang();
            gridDonDatHang.DataSource = data.DanhSachDonHang();
            gridDonDatHang.DataBind();
        }
    }
}