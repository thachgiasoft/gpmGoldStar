using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ThemHangHoaCombo : System.Web.UI.Page
    {
        dtHangCombo data = new dtHangCombo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data = new dtHangCombo();
                object IDHangHoaComBo = data.ThemIDHangHoa_Temp();
                IDHangHoaComBo_Temp.Value = IDHangHoaComBo.ToString();
                txtSoLuong.Text = "0";
                txtMaHang.Text = "121212";
            }
               
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            data = new dtHangCombo();

            data.XoaHangHoa_Temp_IDHangCombo(IDHangHoaComBo_Temp.Value.ToString());
            Response.Redirect("DanhMucCombo.aspx");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text != "" && cmbDonViTinh.Text != "" && txtTenHangHoa.Text != "" && txtGiaBan.Text != "")
            {
                data = new dtHangCombo();
                string IDHangHoaComBo = IDHangHoaComBo_Temp.Value.ToString();
                DataTable dt = data.DanhSachHangHoaCombo_Temp(IDHangHoaComBo);
                if (dt.Rows.Count != 0)
                {
                    string MaHang = txtMaHang.Text.Trim();
                    string txtTenHangComBo = dtSetting.convertDauSangKhongDau(txtTenHangHoa.Text.ToString());

                    string IDDonViTinh = cmbDonViTinh.Value.ToString();
                    float GiaBan = float.Parse(txtGiaBan.Text.ToString());
                    string barcode = txtBarcode.Text == null ? "" :txtBarcode.Text.ToString().Trim();
                    string GhiChu = txtGhiChu.Text == null ? "" : txtGhiChu.Text.ToString();
                    if ((dtHangHoa.KiemTraMaHang(MaHang))  ==  false)
                    {
                        data = new dtHangCombo();
                        data.CapNhatHangHoa(IDHangHoaComBo, MaHang, IDDonViTinh, txtTenHangComBo, GiaBan, GhiChu);
                        if (barcode != "")
                        {
                            data.ThemBarCode(IDHangHoaComBo, barcode);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            string IDHangHoa1 = dr["IDHangHoa"].ToString();
                            int SoLuong1 = Int32.Parse(dr["SoLuong"].ToString());
                            float GiaBan1 = float.Parse(dr["GiaBan"].ToString());
                            float ThanhTien1 = float.Parse(dr["ThanhTien"].ToString());
                            string MaHang1 = dr["MaHang"].ToString();
                            string IDDonViTinh1 = dr["IDDonViTinh"].ToString();
                            data = new dtHangCombo();
                            data.ThemHangHoa(IDHangHoaComBo, IDHangHoa1, SoLuong1, GiaBan1, ThanhTien1, MaHang1, IDDonViTinh1);
                        }
                        data.XoaHangHoa_Temp_IDHangCombo(IDHangHoaComBo);

                        string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
                        if (Session["IDThuNgan"] != null)
                            IDNhanVien1 = Session["IDThuNgan"].ToString();
                        if (Session["IDNhanVien"] != null)
                            IDNhanVien1 = Session["IDNhanVien"].ToString();
                        dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Thêm Hàng hóa Combo", "Thêm hàng hóa combo");

                        Response.Redirect("DanhMucCombo.aspx");
                    }
                    else
                    {
                        Response.Write("<script language='JavaScript'> alert('Mã hàng đã tồn tại.'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Danh sách hàng hóa combo rỗng.'); </script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng điền đầy đủ thông tin hàng hóa combo.'); </script>");
            }
        }
        public void TinhTongTien()
        {
            data = new dtHangCombo();
            DataTable db = data.DanhSachHangHoaCombo_Temp(IDHangHoaComBo_Temp.Value.ToString());
            if (db.Rows.Count != 0)
            {
                double TongTien = 0;
                foreach (DataRow dr in db.Rows)
                {
                    double ThanhTien = double.Parse(dr["ThanhTien"].ToString());
                    TongTien = TongTien + ThanhTien;
                }
                txtGiaBan.Text = (TongTien).ToString();
            }
            else
            {
                txtGiaBan.Text = "0";
            }
        }
       
        protected void btnThem_Temp_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && cmbHangHoa.Text != "")
            {
                int SL = Int32.Parse(txtSoLuong.Text);
                if (SL > 0)
                {

                    string IDHangHoaComBo = IDHangHoaComBo_Temp.Value.ToString();
                    float GiaBan = dtSetting.GiaBan1(cmbHangHoa.Value.ToString());
                    string MaHang = dtSetting.LayMaHang(cmbHangHoa.Value.ToString());
                    string IDDonViTinh = dtSetting.LayIDDonViTinh(cmbHangHoa.Value.ToString());
                  
                    data = new dtHangCombo();
                    DataTable db = data.KTHangHoa_Temp(cmbHangHoa.Value.ToString());// kiểm tra hàng hóa
                    if (db.Rows.Count == 0)
                    {
                        data = new dtHangCombo();
                        data.ThemHangHoa_Temp(IDHangHoaComBo, cmbHangHoa.Value.ToString(), SL, GiaBan, SL * GiaBan, MaHang, IDDonViTinh);
                        TinhTongTien();
                        Clear();
                    }
                    else
                    {
                        data = new dtHangCombo();
                        data.UpdateHangHoa_temp(IDHangHoaComBo, cmbHangHoa.Value.ToString(), SL, GiaBan, SL * GiaBan, MaHang, IDDonViTinh);
                        TinhTongTien();
                        Clear();
                    }
                   
                    LoadGrid(IDHangHoaComBo);
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Số lượng > 0.'); </script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Bạn chưa chọn hàng hóa hoặc số lượng.'); </script>");
            }
        }
        public void Clear()
        {
       
            cmbHangHoa.Text = "";
            txtSoLuong.Text = "0";
           
        }

       
        private void LoadGrid(string IDHangHoaComBo)
        {
            data = new dtHangCombo();
            gridDanhSachHangHoa.DataSource = data.DanhSachHangHoaCombo_Temp(IDHangHoaComBo);
            gridDanhSachHangHoa.DataBind();

        }

        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;

            dsHangHoa.SelectCommand = @"SELECT [ID], [MaHang], [TenHangHoa], [GiaBan1] , [TenDonViTinh]
                                        FROM (
	                                        select GPM_HangHoa.ID, GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa,GPM_HangHoa.GiaBan1, GPM_DonViTinh.TenDonViTinh, 
	                                        row_number()over(order by GPM_HangHoa.MaHang) as [rn] 
	                                        FROM GPM_DonViTinh INNER JOIN GPM_HangHoa ON GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh 
                                                              
	                                        WHERE ((GPM_HangHoa.TenHangHoa LIKE @TenHang) OR (GPM_HangHoa.MaHang LIKE @MaHang)) AND (GPM_HangHoa.DaXoa = 0) AND  (GPM_HangHoa.TrangThai = 0)
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex";

            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("TenHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("MaHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            dsHangHoa.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void cmbHangHoa_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsHangHoa.SelectCommand = @"SELECT GPM_HangHoa.ID, GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.GiaBan1, GPM_DonViTinh.TenDonViTinh 
                                        FROM GPM_DonViTinh INNER JOIN GPM_HangHoa ON GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh
                                        WHERE (GPM_HangHoa.ID = @ID) AND  (GPM_HangHoa.TrangThai = 0)";

            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

      
        protected void BtnXoaHang_Click(object sender, EventArgs e)
        {
            string ID = (((ASPxButton)sender).CommandArgument).ToString();
            string IDHangHoaComBo = IDHangHoaComBo_Temp.Value.ToString();
            data = new dtHangCombo();
            data.XoaHangHoa_Temp_ID(ID);
            TinhTongTien();
            LoadGrid(IDHangHoaComBo);
        }
        protected void gridDanhSachHangHoa_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            TinhTongTien();
        }

        protected void gridDanhSachHangHoa_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            TinhTongTien();
        }

      
    }
}