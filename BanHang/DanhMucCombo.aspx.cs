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
    public partial class DanhMucCombo : System.Web.UI.Page
    {
        dtHangCombo data = new dtHangCombo();
        protected void Page_Load(object sender, EventArgs e)
        {
             LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtHangCombo();
            gridDanhMucCombo.DataSource = data.DanhSachHangHoaCombo();
            gridDanhMucCombo.DataBind();
        }

        protected void gridDanhMucCombo_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //string ID = e.Keys[0].ToString();
            //int SLTonKho = dtCapNhatTonKho.SoLuong_TonKho(ID, Session["IDKho"].ToString());
            //if (SLTonKho == 0)
            //{
            //    data = new dtHangCombo();
            //    data.XoaHangCombo(ID);
            //    dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Danh Mục Combo:" + ID, Session["IDKho"].ToString(), "Danh Mục", "Xóa");  
            //}
            //else
            //{
            //    throw new Exception("Lỗi: Vui lòng cập nhật số lượng hàng combo về 0");
            //}
            //e.Cancel = true;
            //gridDanhMucCombo.CancelEdit();
            //LoadGrid();
        }

        protected void gridDanhMucCombo_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //int ID = Int32.Parse(e.Keys[0].ToString());
            //string TenHangHoa = e.NewValues["TenHangHoa"] == null ? "" : e.NewValues["TenHangHoa"].ToString();
            //if (TenHangHoa != "")
            //{
            //    string TrangThai = e.NewValues["IDTrangThaiHang"].ToString();
            //    string TrongLuong = e.NewValues["TrongLuong"].ToString();
            //    string TongTien = e.NewValues["GiaBanSauThue"].ToString();
            //    string HanSuDung = e.NewValues["HanSuDung"].ToString();
            //    int SLMoi = Int32.Parse(e.NewValues["SoLuongCon"].ToString());
            //    int SLTonKho =  dtCapNhatTonKho.SoLuong_TonKho(ID.ToString(),Session["IDKho"].ToString());
            //    float GiaBanSauVAT = dtHangHoa.LayGiaBanSauThue(ID.ToString());
            //    if (SLTonKho != SLMoi)
            //    {
            //        DataTable db = data.DanhSachHangHoaCombo_IDHangHoaComBo(ID.ToString());
            //        if (db.Rows.Count > 0)
            //        {
            //            int kt = 0;
            //            foreach (DataRow dr in db.Rows)
            //            {
            //                string IDHangHoa = dr["IDHangHoa"].ToString();
            //                int SLHang = Int32.Parse(dr["SoLuong"].ToString());
            //                int SLTon = dtCapNhatTonKho.SoLuong_TonKho(IDHangHoa,Session["IDKho"].ToString());
            //                int SLTon_SUM = (SLTonKho * SLHang) + SLTon; // số lượng tồn của từng hàng hóa trong combo
            //                if (SLHang * SLMoi > SLTon_SUM)
            //                {
            //                    kt = 1;
            //                    throw new Exception("Lỗi: Hàng tồn kho không đủ: " + dtHangHoa.LayTenHangHoa(IDHangHoa) + " : Số lượng cần(" + (SLHang * SLMoi) + ") :  Số lượng tồn(" + SLTon_SUM + ")");
            //                }
            //            }
            //            if (kt == 0)
            //            {
            //                //throw new Exception("đủ hàng:");
            //                foreach (DataRow dr in db.Rows)
            //                {
            //                    string IDHangHoa = dr["IDHangHoa"].ToString();
            //                    int SLHang = Int32.Parse(dr["SoLuong"].ToString());
            //                    int SLTon = dtCapNhatTonKho.SoLuong_TonKho(IDHangHoa, Session["IDKho"].ToString());
            //                    int SLTon_SUM = (SLTonKho * SLHang) + SLTon; // số lượng tổng tồn của từng hàng hóa trong combo, đã gã hàng
            //                    if (SLHang * SLMoi <= SLTon_SUM)
            //                    {
            //                        //đủ hàng
            //                        int SL_SUM = (SLTon_SUM - (SLMoi * SLHang));
            //                        dtLichSuKho.ThemLichSu(IDHangHoa, Session["IDNhanVien"].ToString(), ((-1) * (SL_SUM - SLTon)).ToString(), "Cập nhật số lượng chi tiết hàng combo:" + dtHangHoa.LayTenHangHoa(IDHangHoa) + "", Session["IDKho"].ToString());
            //                        dtCapNhatTonKho.CapNhatKho(IDHangHoa, SL_SUM.ToString(), Session["IDKho"].ToString());
            //                    }
            //                }
            //                dtLichSuKho.ThemLichSu(ID.ToString(), Session["IDNhanVien"].ToString(), ((-1) * (SLMoi - SLTonKho)).ToString(), "Cập nhật số lượng hàng combo:" + dtHangHoa.LayTenHangHoa(ID.ToString()) + "", Session["IDKho"].ToString());
            //                dtCapNhatTonKho.CapNhatKho(ID.ToString(), SLMoi.ToString(), Session["IDKho"].ToString());
            //            }
            //        }
            //        else
            //        {
            //            throw new Exception("Lỗi: Không có hàng hóa trong combo?");
            //        }
            //        dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Danh Mục Combo:" + TenHangHoa, Session["IDKho"].ToString(), "Danh Mục", "Cập nhật số lượng");  
            //    }
            //    else if (GiaBanSauVAT != float.Parse(TongTien))
            //    {
            //        dtHangHoa.ThemLichSuThayDoiGia(ID.ToString(), dtHangHoa.LayIDDonViTinh(ID.ToString()), dtHangHoa.LayGiaBanSauThue(ID.ToString()), float.Parse(TongTien), Session["IDNhanVien"].ToString(), dtHangHoa.LayMaHang(ID.ToString()));
            //        data = new dtHangCombo();
            //        data.CapNhatHangHoa_Combo(ID, TrangThai, TrongLuong, TongTien, HanSuDung, TenHangHoa);
            //        dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Danh Mục Combo:" + TenHangHoa, Session["IDKho"].ToString(), "Danh Mục", "Cập nhật thông tin");
            //    }
            //    else
            //    {
            //        data = new dtHangCombo();
            //        data.CapNhatHangHoa_Combo(ID, TrangThai, TrongLuong, TongTien, HanSuDung, TenHangHoa);
            //        dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Danh Mục Combo:" + TenHangHoa, Session["IDKho"].ToString(), "Danh Mục", "Cập nhật thông tin");
            //    }
            //}
            //else
            //{
            //    throw new Exception("Lỗi: Vui lòng nhập Tên hàng hóa");
            //}
            //e.Cancel = true;
            //gridDanhMucCombo.CancelEdit();
            //LoadGrid();
        }
    }
}