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
    public partial class PhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data = new dtPhieuXuatKhac();
                object IDPhieuXuatKhac = data.ThemPhieuXuatKhac_Temp();
                IDPhieuXuatKhac_Temp.Value = IDPhieuXuatKhac.ToString();
                cmbNguoiLapPhieu.Text = Session["IDNhanVien"].ToString();
               
            }
            LoadGrid(IDPhieuXuatKhac_Temp.Value.ToString());  
        }
       
        public void Clear()
        {
            cmbHangHoa.Text = "";
            txtSoLuong.Text = "";
            txtTonKho.Text = "";
            cmbDonViTinh.Text = "";
          
        }
        protected void cmbNgayLapPhieu_Init(object sender, EventArgs e)
        {
            cmbNgayLapPhieu.Date = DateTime.Today;
        }

        protected void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHangHoa.Text != "")
            {
                cmbDonViTinh.Value = dtSetting.LayIDDonViTinh(cmbHangHoa.Value.ToString());
                txtTonKho.Text = dtSetting.SoLuong_TonKho(cmbHangHoa.Value.ToString()).ToString();
                txtSoLuong.Text = "0";
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbHangHoa.Value != null && txtSoLuong.Text != "")
            {
                int SoLuong = Int32.Parse(txtSoLuong.Value.ToString());
                if (SoLuong > 0)
                {
                    string IDHangHoa = cmbHangHoa.Value.ToString();
                    string IDPhieuXuatKhac = IDPhieuXuatKhac_Temp.Value.ToString();
                    DataTable db = data.KTChiTietPhieuXuatKhac_Temp(IDHangHoa, IDPhieuXuatKhac);// kiểm tra hàng hóa
                    if (db.Rows.Count == 0)
                    {
                        data = new dtPhieuXuatKhac();
                        data.ThemPhieuXuatKhac_Temp1(IDPhieuXuatKhac, IDHangHoa, SoLuong, dtSetting.LayIDDonViTinh(IDHangHoa), dtSetting.LayMaHang(IDHangHoa), txtTonKho.Text);
                        Clear();
                    }
                    else
                    {
                        data = new dtPhieuXuatKhac();
                        data.UpdatePhieuXuatKhac_temp(IDPhieuXuatKhac, IDHangHoa, SoLuong);
                        Clear();
                    }
                    LoadGrid(IDPhieuXuatKhac);
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Số Lượng phải > 0.'); </script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Bạn chưa chọn hàng hóa.'); </script>");
            }
        }

        private void LoadGrid(string IDPhieuXuatKhac)
        {
            data = new dtPhieuXuatKhac();
            gridDanhSachHangHoa_Temp.DataSource = data.LayDanhSachPhieuXuatKhac_Temp(IDPhieuXuatKhac);
            gridDanhSachHangHoa_Temp.DataBind();

        }

        protected void btnHuyPhieuXuatKhac_Click(object sender, EventArgs e)
        {
            data = new dtPhieuXuatKhac();
            int ID = Int32.Parse(IDPhieuXuatKhac_Temp.Value.ToString());
            if (ID != null)
            {
                data.XoaPhieuXuatKhac_Temp(ID);
                data.XoaChiTietPhieuXuatKhac_Temp(IDPhieuXuatKhac_Temp.Value.ToString());
                Response.Redirect("DanhSachPhieuXuatKhac.aspx");
            }
        }

        protected void btnThemPhieuXuatKhac_Click(object sender, EventArgs e)
        {
            if (cmbLyDoXuat.Text != "")
            {
                string IDPhieuXuatKhac = IDPhieuXuatKhac_Temp.Value.ToString();
                DataTable db = data.LayDanhSachPhieuXuatKhac_Temp(IDPhieuXuatKhac);
                if (db.Rows.Count != 0)
                {
                    string IDNguoiLapPhieu = cmbNguoiLapPhieu.Value.ToString();
                    DateTime NgayLapPhieu = DateTime.Parse(cmbNgayLapPhieu.Text.ToString());
                    string IDLyDoXuat = cmbLyDoXuat.Value.ToString();
                    string GhiChu = txtGhiChu == null ? "" : txtGhiChu.Text.ToString();
                    data = new dtPhieuXuatKhac();
                    data.CapNhatPhieuXuatKhac_ID(IDPhieuXuatKhac, IDNguoiLapPhieu, IDLyDoXuat, NgayLapPhieu, GhiChu);
                    foreach (DataRow dr in db.Rows)
                    {
                        string IDHangHoa = dr["IDHangHoa"].ToString();
                        string SoLuong = dr["SoLuong"].ToString();
                        string SoLuongCon = dr["SoLuongCon"].ToString();
                        string MaHang = dr["MaHang"].ToString();
                        string IDDonViTinh = dr["IDDonViTinh"].ToString();
                        data = new dtPhieuXuatKhac();
                        data.ThemChiTietPhieuXuatKhac(IDPhieuXuatKhac, IDHangHoa, SoLuong, MaHang, IDDonViTinh, SoLuongCon);
                        dtSetting.TruTonKho(IDHangHoa, SoLuong);
                    }
                    data = new dtPhieuXuatKhac();
                    data.XoaChiTietPhieuXuatKhac_Temp(IDPhieuXuatKhac);

                    string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
                    if (Session["IDThuNgan"] != null)
                        IDNhanVien1 = Session["IDThuNgan"].ToString();
                    if (Session["IDNhanVien"] != null)
                        IDNhanVien1 = Session["IDNhanVien"].ToString();
                    dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Phiếu xuất khác", "Thêm phiếu xuất khác.");

                    Response.Redirect("DanhSachPhieuXuatKhac.aspx");
                }
                else
                {
                    Response.Write("<script language='JavaScript'> alert('Danh sách hàng hóa rỗng.'); </script>");
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng chọn lý do để xuất.'); </script>");
            }
        }

        protected void gridDanhSachHangHoa_Temp_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtPhieuXuatKhac();
            data.XoaChiTietPhieuXuatKhac_Temp_ID(ID);
            e.Cancel = true;
            gridDanhSachHangHoa_Temp.CancelEdit();
            LoadGrid(IDPhieuXuatKhac_Temp.Value.ToString());

        }

        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;

            sqlHangHoa.SelectCommand = @"SELECT [ID], [MaHang], [TenHangHoa], [GiaMua] , [TenDonViTinh]
                                        FROM (
	                                        select GPM_HangHoa.ID, GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.GiaMua, GPM_DonViTinh.TenDonViTinh, 
	                                        row_number()over(order by GPM_HangHoa.MaHang) as [rn] 
	                                        FROM GPM_DonViTinh INNER JOIN GPM_HangHoa ON GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh 
                                                               INNER JOIN GPM_HangHoaTonKho ON GPM_HangHoaTonKho.IDHangHoa = GPM_HangHoa.ID
	                                        WHERE (GPM_HangHoa.MaHang LIKE @MaHang OR GPM_HangHoa.TenHangHoa LIKE @TenHang ) AND GPM_HangHoa.TrangThaiHang = 1
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex";

            sqlHangHoa.SelectParameters.Clear();
            sqlHangHoa.SelectParameters.Add("MaHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            sqlHangHoa.SelectParameters.Add("TenHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            sqlHangHoa.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            sqlHangHoa.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = sqlHangHoa;
            comboBox.DataBind();
        }

        protected void cmbHangHoa_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            sqlHangHoa.SelectCommand = @"SELECT GPM_HangHoa.ID, GPM_HangHoa.MaHang, GPM_HangHoa.TenHangHoa, GPM_HangHoa.GiaMua, GPM_DonViTinh.TenDonViTinh 
                                        FROM GPM_DonViTinh INNER JOIN GPM_HangHoa ON GPM_DonViTinh.ID = GPM_HangHoa.IDDonViTinh 
                                                           INNER JOIN GPM_HangHoaTonKho ON GPM_HangHoaTonKho.IDHangHoa = GPM_HangHoa.ID 
                                        WHERE (GPM_HangHoa.ID = @ID)";

            sqlHangHoa.SelectParameters.Clear();
            sqlHangHoa.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = sqlHangHoa;
            comboBox.DataBind();
        }
    }
}