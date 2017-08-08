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
    public partial class ChiTietHangHoaCombo : System.Web.UI.Page
    {
        dtHangCombo data = new dtHangCombo();
        protected void Page_Load(object sender, EventArgs e)
        {
          
                string IDHangHoaComBo = Request.QueryString["IDHangHoaComBo"];
                if (IDHangHoaComBo != null)
                {

                    LoadGrid(IDHangHoaComBo.ToString());
                }
          
        }

        private void LoadGrid(string IDHangHoaComBo)
        {

            data = new dtHangCombo();
            gridChiTietHangHoaCombo.DataSource = data.DanhSachHangHoaCombo_IDHangHoaComBo(IDHangHoaComBo);
            gridChiTietHangHoaCombo.DataBind();
        }
    }
}