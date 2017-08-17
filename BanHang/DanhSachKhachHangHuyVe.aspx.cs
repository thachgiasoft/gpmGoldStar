using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class DanhSachKhachHangHuyVe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dtKhachHangHuyVe dt = new dtKhachHangHuyVe();
            dt.XoaPhieu_Null();

            LoadGrid();
        }

        private void LoadGrid()
        {
            dtKhachHangHuyVe data = new dtKhachHangHuyVe();
            gridPhieuKhachHangTraHang.DataSource = data.DanhSachPhieuKhachHangHuyVe();
            gridPhieuKhachHangTraHang.DataBind();
        }
    }
}