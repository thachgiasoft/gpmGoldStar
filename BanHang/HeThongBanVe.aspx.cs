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
    public partial class HeThongBanVe : System.Web.UI.Page
    {
        
       public List<HoaDon1> DanhSachHoaDon
        {
            get
            {
                if (ViewState["DanhSachHoaDon"] == null)
                    return new List<HoaDon1>();
                else
                    return (List<HoaDon1>)ViewState["DanhSachHoaDon"];
            }
            set
            {
                ViewState["DanhSachHoaDon"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //dtBanVe dt = new dtBanVe();   
            //ASPxGridViewInBuil.DataSource = dt.LayThongHoaDon();
            //ASPxGridViewInBuil.DataBind();
            
            //if (Session["KTBanLe"] == "GPMBanLe")
            //{
                if (!IsPostBack)
                {
                    DanhSachHoaDon = new List<HoaDon1>();
                    ThemHoaDonMoi();
                    //btnNhanVien.Text = Session["TenThuNgan"].ToString();
                }
              
            //}
            //else
            //{
            //    Response.Redirect("DangNhap.aspx");
            //}
        }

        public void BindGridChiTietHoaDon()
        {
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            gridChiTietHoaDon.DataSource = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1;
            gridChiTietHoaDon.DataBind();
            formLayoutThanhToan.DataSource = DanhSachHoaDon[MaHoaDon];
            formLayoutThanhToan.DataBind();
        }
        protected void btnInsertHang_Click(object sender, EventArgs e)
        {
            try
            {
                dtBanVe dt = new dtBanVe();
                if (cmbKyHieu.Text.Trim() != "")
                {
                    DataTable tbThongTin;
                    tbThongTin = dt.ThongTinKyHieu(cmbKyHieu.Value.ToString());
                    if (tbThongTin.Rows.Count > 0)
                    {
                        ThemHangVaoChiTietHoaDon(tbThongTin);
                        BindGridChiTietHoaDon();
                    }
                    else
                        HienThiThongBao("Mã vé không tồn tại!!");
                }

                cmbKyHieu.Text = "";
                cmbKyHieu.Focus();
                txtSoLuong.Text = "1";
            }
            catch (Exception ex)
            {
                cmbKyHieu.Text = "";
                cmbKyHieu.Focus();
                HienThiThongBao("Error: " + ex);
            }
        }
        public void ThemHoaDonMoi()
        {
            HoaDon1 hd = new HoaDon1();
            DanhSachHoaDon.Add(hd);
            Tab tabHoaDonNew = new Tab();
            int SoHoaDon = DanhSachHoaDon.Count;
            tabHoaDonNew.Name = SoHoaDon.ToString();
            tabHoaDonNew.Text = "Hóa đơn " + SoHoaDon.ToString();
            tabHoaDonNew.Index = SoHoaDon - 1;
            tabControlSoHoaDon.Tabs.Add(tabHoaDonNew);
            tabControlSoHoaDon.ActiveTabIndex = SoHoaDon - 1;
            BindGridChiTietHoaDon();
        }
        public void HuyHoaDon()
        {
            txtTienThua.Text = "";
            txtKhachThanhToan.Text = "";
            int indexTabActive = tabControlSoHoaDon.ActiveTabIndex;
            DanhSachHoaDon.RemoveAt(indexTabActive);
            tabControlSoHoaDon.Tabs.RemoveAt(indexTabActive);
            for (int i = 0; i < tabControlSoHoaDon.Tabs.Count; i++)
            {
                tabControlSoHoaDon.Tabs[i].Text = "Hóa đơn " + (i + 1).ToString();
            }
            if (DanhSachHoaDon.Count == 0)
            {
                ThemHoaDonMoi();
            }
            else
            {
                BindGridChiTietHoaDon();
            }
        }
        public void ThemHangVaoChiTietHoaDon(DataTable tbThongTin)
        {
            string TenKyHieu = tbThongTin.Rows[0]["TenKyHieu"].ToString();
            float GiaVe = float.Parse(tbThongTin.Rows[0]["GiaVe"].ToString());
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            var exitHang = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.FirstOrDefault(item => item.TenKyHieu == TenKyHieu);
            if (exitHang != null)
            {
                int SoLuong = exitHang.SoLuong + int.Parse(txtSoLuong.Text);
                float ThanhTienOld = exitHang.ThanhTien;
                exitHang.SoLuong = SoLuong;
                exitHang.ThanhTien = SoLuong * exitHang.DonGia;
                DanhSachHoaDon[MaHoaDon].TongTien += SoLuong * exitHang.DonGia - ThanhTienOld;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
            }
            else
            {
                ChiTietHoaDon1 cthd = new ChiTietHoaDon1();
                cthd.STT = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.Count + 1;
                cthd.TenKyHieu = TenKyHieu;
                cthd.SoLuong = int.Parse(txtSoLuong.Text);
                cthd.DonGia = GiaVe;
                cthd.ThanhTien = int.Parse(txtSoLuong.Text) * float.Parse(cthd.DonGia.ToString());
                DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.Add(cthd);
                DanhSachHoaDon[MaHoaDon].SoLuongHang++;
                DanhSachHoaDon[MaHoaDon].TongTien += cthd.ThanhTien;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
            }
           
            
        }
        protected void btnUpdateGridHang_Click(object sender, EventArgs e)
        {
            BatchUpdate();
            BindGridChiTietHoaDon();
        }
        private void BatchUpdate()
        {
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            for (int i = 0; i < gridChiTietHoaDon.VisibleRowCount; i++)
            {
                object SoLuong = gridChiTietHoaDon.GetRowValues(i, "SoLuong");
                ASPxSpinEdit spineditSoLuong = gridChiTietHoaDon.FindRowCellTemplateControl(i, (GridViewDataColumn)gridChiTietHoaDon.Columns["SoLuong"], "txtSoLuongChange") as ASPxSpinEdit;
                object SoLuongMoi = spineditSoLuong.Value;
                int STT = Convert.ToInt32(gridChiTietHoaDon.GetRowValues(i, "STT"));
                var exitHang = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.FirstOrDefault(item => item.STT == STT);
                int SoLuongOld = exitHang.SoLuong;
                float ThanhTienOld = exitHang.ThanhTien;
                exitHang.SoLuong = Convert.ToInt32(SoLuongMoi);
                exitHang.ThanhTien = Convert.ToInt32(SoLuongMoi) * exitHang.DonGia;
                DanhSachHoaDon[MaHoaDon].TongTien += exitHang.ThanhTien - ThanhTienOld;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
            }
        }
        public void HienThiThongBao(string thongbao)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + thongbao + "');", true);
        }
        protected void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            txtTienThua.Text = "";
            float TienKhachThanhToan;
            bool isNumeric = float.TryParse(txtKhachThanhToan.Text, out TienKhachThanhToan);
            if (!isNumeric)
            {
                HienThiThongBao("Nhập không đúng số tiền !!"); return;
            }
            int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
            DanhSachHoaDon[MaHoaDon].KhachThanhToan = TienKhachThanhToan;
            DanhSachHoaDon[MaHoaDon].TienThua = TienKhachThanhToan - (DanhSachHoaDon[MaHoaDon].TongTien - float.Parse(txtGiamGia.Text));
            txtTienThua.Text = DanhSachHoaDon[MaHoaDon].TienThua.ToString();

        }

        protected void BtnXoaHang_Click(object sender, EventArgs e)
        {
            try
            {
                int MaHoaDon = tabControlSoHoaDon.ActiveTabIndex;
                int STT = Convert.ToInt32(((ASPxButton)sender).CommandArgument);
                var itemToRemove = DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.Single(r => r.STT == STT);
                DanhSachHoaDon[MaHoaDon].SoLuongHang--;
                DanhSachHoaDon[MaHoaDon].TongTien = DanhSachHoaDon[MaHoaDon].TongTien - itemToRemove.ThanhTien;
                DanhSachHoaDon[MaHoaDon].KhachCanTra = DanhSachHoaDon[MaHoaDon].TongTien - DanhSachHoaDon[MaHoaDon].GiamGia;
                DanhSachHoaDon[MaHoaDon].ListChiTietHoaDon1.Remove(itemToRemove);
                BindGridChiTietHoaDon();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            HuyHoaDon();
        }

        protected void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            ThemHoaDonMoi();
        }

        protected void tabControlSoHoaDon_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            BindGridChiTietHoaDon();
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnHuyKhachHang_Click(object sender, EventArgs e)
        {
            popupThemKhachHang.ShowOnPageLoad = false;
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            popupThemKhachHang.ShowOnPageLoad = true;
        }

        protected void btnThemKhachHang_Click(object sender, EventArgs e)
        {
           
        }
        protected void cmbKhachHang_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsKhachHang.SelectCommand = @"SELECT ID, MaKhachHang,TenKhachHang,CMND,DienThoai,DiemTichLuy
                                        FROM GPM_KhachHang        
                                        WHERE (GPM_KhachHang.ID = @ID)";

            dsKhachHang.SelectParameters.Clear();
            dsKhachHang.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = dsKhachHang;
            comboBox.DataBind();
        }

        protected void cmbKhachHang_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;

            dsKhachHang.SelectCommand = @"SELECT ID, MaKhachHang,TenKhachHang,CMND,DienThoai,DiemTichLuy
                                        FROM (
	                                        select ID, MaKhachHang,TenKhachHang,CMND,DienThoai,DiemTichLuy,
	                                        row_number()over(order by MaKhachHang) as [rn] 
	                                        FROM GPM_KhachHang
	                                        WHERE ((DienThoai LIKE @DienThoai) OR (MaKhachHang LIKE @MaKhachHang) OR (TenKhachHang LIKE @TenKhachHang) OR (CMND LIKE @CMND))
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex";

            dsKhachHang.SelectParameters.Clear();
            dsKhachHang.SelectParameters.Add("DienThoai", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsKhachHang.SelectParameters.Add("CMND", TypeCode.String, string.Format("%{0}%", e.Filter));
            
            dsKhachHang.SelectParameters.Add("MaKhachHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsKhachHang.SelectParameters.Add("TenKhachHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsKhachHang.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            dsKhachHang.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = dsKhachHang;
            comboBox.DataBind();
        }

        protected void txtDiemTichLuy_TextChanged(object sender, EventArgs e)
        {
            if (cmbKhachHang.Text != "")
            {
                string IDKhachHang = cmbKhachHang.Value.ToString();
                dtBanVe data = new dtBanVe();
                float DiemTichLuy = data.DiemTichLuy(IDKhachHang);
                if (float.Parse(txtDiemTichLuy.Text) > DiemTichLuy)
                {
                    txtDiemTichLuy.Text = "0";
                    HienThiThongBao("Điểm tích lũy không đủ !!"); return;
                }
                else
                {
                    int SoDiemCanDoi = Int32.Parse(txtDiemTichLuy.Text);
                    float SoTienDoi  = float.Parse(dtSetting.LayDiemQuyDoiTien());
                    float TongTien = float.Parse(txtTongTien.Text);
                    txtKhachCanTra.Text = (TongTien - (SoTienDoi * SoDiemCanDoi))+"";
                    txtGiamGia.Text = (SoTienDoi * SoDiemCanDoi) + "";
                }
            }
            else
            {
                txtDiemTichLuy.Text = "0";
                cmbKhachHang.Focus();
                HienThiThongBao("Vui lòng chọn khách hàng !!"); return;
            }
        }
    }
    [Serializable]
    public class HoaDon1
    {
        public int IDHoaDon { get; set; }
        public int SoLuongHang { get; set; }
        public float TongTien { get; set; }
        public float GiamGia { get; set; }
        public float KhachCanTra { get; set; }
        public float KhachThanhToan { get; set; }
        public float TienThua { get; set; }
        public List<ChiTietHoaDon1> ListChiTietHoaDon1 { get; set; }
        public HoaDon1()
        {
            SoLuongHang = 0;
            TongTien = 0;
            GiamGia = 0;
            KhachCanTra = 0;
            KhachThanhToan = 0;
            TienThua = 0;
            ListChiTietHoaDon1 = new List<ChiTietHoaDon1>();
        }
    }
    [Serializable]
    public class ChiTietHoaDon1
    {
        public int STT { get; set; }
        public string TenKyHieu { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public ChiTietHoaDon1()
        {
            SoLuong = 0;
            DonGia = 0;
            ThanhTien = 0;
        }
    }
        
    
}