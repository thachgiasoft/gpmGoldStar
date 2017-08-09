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
    public partial class ChiTietPhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDPhieuXuatKhac = Request.QueryString["IDPhieuXuatKhac"];
            if (IDPhieuXuatKhac != null)
            {

                LoadGrid(IDPhieuXuatKhac.ToString());
            }
        }
        private void LoadGrid(string IDPhieuXuatKhac)
        {
            data = new dtPhieuXuatKhac();
            gridChiTietPhieuXuatKhac.DataSource = data.DanhSachChiTietPhieuXuatKhac_ID(IDPhieuXuatKhac);
            gridChiTietPhieuXuatKhac.DataBind();
        }
    }
}