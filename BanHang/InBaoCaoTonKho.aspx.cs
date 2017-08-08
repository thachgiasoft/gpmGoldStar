using BanHang.Data;
using BanHang.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class InBaoCaoTonKho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idloai = Request.QueryString["idloai"];
            string strLoai = "Tất cả loại hàng hóa";

            if (Int32.Parse(idloai) != -1)
            {
                dtBaoCao d1 = new dtBaoCao();
                strLoai = d1.layTen_LoaiHangHoa_ID(idloai);
            }

            rpBaoCaoTonKho rp = new rpBaoCaoTonKho();
            rp.Parameters["strLoai"].Value = strLoai;
            rp.Parameters["idLoai"].Value = idloai;
            rp.Parameters["strLoai"].Visible = false;
            rp.Parameters["idLoai"].Visible = false;
            reportView.Report = rp;
        }
    }
}