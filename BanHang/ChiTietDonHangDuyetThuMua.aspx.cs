using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ChiTietDonHangDuyetThuMua : System.Web.UI.Page
    {
        dtDuyetDonHangThuMua data = new dtDuyetDonHangThuMua();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDDonHang = Request.QueryString["IDDonHang"];
            if (IDDonHang != null)
            {
                LoadGrid(IDDonHang.ToString());
            }
        }

        private void LoadGrid(string IDDonHangThuMua)
        {
            data = new dtDuyetDonHangThuMua();
            gridChiTiet.DataSource = data.DanhSachChiTiet_Duyet_ThuMua(IDDonHangThuMua);
            gridChiTiet.DataBind();
        }
    }
}