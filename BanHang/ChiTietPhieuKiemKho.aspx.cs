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
    public partial class ChiTietPhieuKiemKho : System.Web.UI.Page
    {
        dtKiemKho data = new dtKiemKho();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDPhieuKiemKho = Request.QueryString["IDPhieuKiemKho"];
            if (IDPhieuKiemKho != null)
            {
                if (dtKiemKho.LayTrangThaiKiemKho(IDPhieuKiemKho) == 1)
                {
                    gridChiTietPhieuKiemKho.Columns["chucnang"].Visible = false;
                    btnDuyet.Enabled = false;
                }
                LoadGrid(Int32.Parse(IDPhieuKiemKho.ToString()));
            }
        }

        private void LoadGrid(int IDPhieuKiemKho)
        {
            data = new dtKiemKho();
            gridChiTietPhieuKiemKho.DataSource = data.DanhSachChiTietPhieuKiemKho_IDPhieuKiemKho(IDPhieuKiemKho);
            gridChiTietPhieuKiemKho.DataBind();
        }

        protected void gridChiTietPhieuKiemKho_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string IDPhieuKiemKho = Request.QueryString["IDPhieuKiemKho"];
            string ID = e.Keys[0].ToString();
            int ThucTe = Int32.Parse(e.NewValues["ThucTe"].ToString());
            int TonKho = Int32.Parse(e.NewValues["TonKho"].ToString());
            if (ThucTe >= 0)
            {
                data = new dtKiemKho();
                data.CapNhatPhieuKiemKho_Chinh(ID, ThucTe, ThucTe - TonKho);
                e.Cancel = true;
                gridChiTietPhieuKiemKho.CancelEdit();
                LoadGrid(Int32.Parse(IDPhieuKiemKho.ToString()));
            }
            else
            {
                throw new Exception("Lỗi: Số lượng thực tế phải  >= 0");
            }
        }

        protected void gridChiTietPhieuKiemKho_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            string IDPhieuKiemKho = Request.QueryString["IDPhieuKiemKho"];
            DataTable dt = data.DanhSachChiTietPhieuKiemKho_IDPhieuKiemKho(Int32.Parse(IDPhieuKiemKho));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ThucTe = dr["ThucTe"].ToString();
                    string IDHangHoa = dr["IDHangHoa"].ToString();
                    dtSetting.CapNhatKho(IDHangHoa, ThucTe);
                }
                data = new dtKiemKho();
                data.CapNhatTrangThai(IDPhieuKiemKho);
               // Response.Redirect("DanhSachKiemKho.aspx");
                // chưa ghi lịch sử
                btnDuyet.Enabled = false;
                gridChiTietPhieuKiemKho.Columns["chucnang"].Visible = false;
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Danh sách kiểm kho rỗng'); </script>");
            }
        }
    }
}