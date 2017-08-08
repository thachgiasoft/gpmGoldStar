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
    public partial class BaoCaoTonKho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            dtBaoCao d = new dtBaoCao();
            DataTable dx = d.LayDanhSach_LoaiHangHoa();
            dx.Rows.Add(-1, "Tất cả loại hàng");
            cmbLoaiHangHoa.DataSource = dx;
            cmbLoaiHangHoa.TextField = "TenTrangThai";
            cmbLoaiHangHoa.ValueField = "ID";
            cmbLoaiHangHoa.DataBind();
            cmbLoaiHangHoa.SelectedIndex = cmbLoaiHangHoa.Items.Count;
        }

        public void LoadGrid()
        {
            dtBaoCao data = new dtBaoCao();
            gridBaoCaoTonKho.DataSource = data.LayDanhSach_HangHoaTonKho();
            gridBaoCaoTonKho.DataBind();
        }

        protected void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string idLoai = cmbLoaiHangHoa.Value + "";
            popup.ContentUrl = "~/InBaoCaoTonKho.aspx?idloai=" + idLoai;
            popup.ShowOnPageLoad = true;
        }
    }
}