using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;
using System.IO;
using DevExpress.XtraRichEdit.API.Native;

namespace BanHang
{
    public partial class HangHoa : System.Web.UI.Page
    {
        dtHangHoa data = new dtHangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
              
        }
        public void LoadGrid()
        {
            gridHangHoa.DataSource = data.LayDanhSachHangHoa();
            gridHangHoa.DataBind();
        }

        protected void gridHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            data = new dtHangHoa();
            int ID = Int32.Parse(e.Keys["ID"].ToString());
            data.XoaHangHoa(ID);
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Hàng hóa", "Xóa hàng hóa ID: " + ID);
        }

        protected void gridHangHoa_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<string> ListBarCode = GetListBarCode();
            data = new dtHangHoa();
            string MaHang = e.NewValues["MaHang"].ToString();
            dtImportHangHoa hh = new dtImportHangHoa();
            DataTable dd = hh.KiemTraHangHoa(MaHang);
            if (dd.Rows.Count == 0)
            {
                string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
                TenHangHoa = dtSetting.convertDauSangKhongDau(TenHangHoa).ToUpper();
                string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();

                string TrangThaiHang = e.NewValues["TrangThaiHang"].ToString();
                float GiaMua = float.Parse(e.NewValues["GiaMua"].ToString());
                float GiaBan1 = float.Parse(e.NewValues["GiaBan1"].ToString());

                float GiaBan2 = float.Parse(e.NewValues["GiaBan2"] != null ? e.NewValues["GiaBan2"].ToString() : "0");
                float GiaBan3 = float.Parse(e.NewValues["GiaBan3"] != null ? e.NewValues["GiaBan3"].ToString() : "0");
                float GiaBan4 = float.Parse(e.NewValues["GiaBan4"] != null ? e.NewValues["GiaBan4"].ToString() : "0");
                float GiaBan5 = float.Parse(e.NewValues["GiaBan5"] != null ? e.NewValues["GiaBan5"].ToString() : "0");
                string GhiChu = e.NewValues["GhiChu"] != null ? e.NewValues["GhiChu"].ToString() : "";

                object IDHangHoa = data.ThemHangHoa(MaHang, TenHangHoa, IDDonViTinh, GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, TrangThaiHang, GhiChu);
                if (IDHangHoa != null)
                {
                    data.ThemDanhSachBarCode(IDHangHoa, ListBarCode);
                }
                if (Int32.Parse(TrangThaiHang) == 1)
                {
                    data = new dtHangHoa();
                    data.ThemHangVaoTonKho(Int32.Parse(IDHangHoa.ToString()));
                }
                e.Cancel = true;
                gridHangHoa.CancelEdit();
                LoadGrid();

                string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
                if (Session["IDThuNgan"] != null)
                    IDNhanVien = Session["IDThuNgan"].ToString();
                if (Session["IDNhanVien"] != null)
                    IDNhanVien = Session["IDNhanVien"].ToString();
                dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Hàng hóa", "Thêm hàng hóa ID: " + IDHangHoa);
            }
            else Response.Write("<script language='JavaScript'> alert('Mã hàng đã tồn tại.'); </script>");
        }

        protected void gridHangHoa_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<string> ListBarCode = GetListBarCode();
            data = new dtHangHoa();
            int ID = Int32.Parse(e.Keys["ID"].ToString());
            string MaHang = e.NewValues["MaHang"].ToString();
            string TenHangHoa = e.NewValues["TenHangHoa"].ToString();
            TenHangHoa = dtSetting.convertDauSangKhongDau(TenHangHoa).ToUpper();
            string IDDonViTinh = e.NewValues["IDDonViTinh"].ToString();
            string TrangThaiHang = e.NewValues["TrangThaiHang"].ToString();
            float GiaMua = float.Parse(e.NewValues["GiaMua"].ToString());
            float GiaBan1 = float.Parse(e.NewValues["GiaBan1"].ToString());
            float GiaBan2 = float.Parse(e.NewValues["GiaBan2"] != null ? e.NewValues["GiaBan2"].ToString() : "0");
            float GiaBan3 = float.Parse(e.NewValues["GiaBan3"] != null ? e.NewValues["GiaBan3"].ToString() : "0");
            float GiaBan4 = float.Parse(e.NewValues["GiaBan4"] != null ? e.NewValues["GiaBan4"].ToString() : "0");
            float GiaBan5 = float.Parse(e.NewValues["GiaBan5"] != null ? e.NewValues["GiaBan5"].ToString() : "0");
            string GhiChu = e.NewValues["GhiChu"] != null ? e.NewValues["GhiChu"].ToString() : "";
            data.SuaThongTinHangHoa(ID, MaHang, TenHangHoa, IDDonViTinh, GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, TrangThaiHang, GhiChu);
            data.SuaDanhSachBarCode(e.Keys["ID"] as object, ListBarCode);
            if (Int32.Parse(TrangThaiHang) == 2 && (dtHangHoa.KiemTraTonKho(ID) == true))
            {
                data = new dtHangHoa();
                data.XoaHangVaoTonKho(ID);
            }
            else if (Int32.Parse(TrangThaiHang) == 1 && (dtHangHoa.KiemTraTonKho(ID) == false))
            {
                data = new dtHangHoa();
                data.ThemHangVaoTonKho(ID);
            }
            e.Cancel = true;
            gridHangHoa.CancelEdit();
            LoadGrid();

            string IDNhanVien = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien, "Hàng hóa", "Cập nhật hàng hóa ID: " + ID);
        }

        protected List<string> GetListBarCode()
        {
            ASPxTokenBox tkbListBarCode = gridHangHoa.FindEditFormTemplateControl("tkbListBarCode") as ASPxTokenBox;
            List<string> ListBarCode = new List<string>();
            foreach (string barCode in tkbListBarCode.Tokens)
            {
                ListBarCode.Add(barCode);
            }
            return ListBarCode;
        }

        protected TokenCollection LoadListBarCode(object ID)
        {
            TokenCollection listBarCode = new TokenCollection();
            if (ID != null)
            {
                DataTable dt = data.GetListBarCode(ID);
                foreach (DataRow row in dt.Rows)
                {
                    listBarCode.Add(row["Barcode"].ToString());
                }
            }
            return listBarCode;
        }

        protected void gridBarCode_Init(object sender, EventArgs e)
        {
            data = new dtHangHoa();
            ASPxGridView gridBarCode = sender as ASPxGridView;
            object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            gridBarCode.DataBind();
        }

        protected void gridBarCode_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            data = new dtHangHoa();
            ASPxGridView gridBarCode = sender as ASPxGridView;
            int ID = Int32.Parse(e.Keys["ID"].ToString());
            object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            string BarCode = e.NewValues["Barcode"] != null ? e.NewValues["Barcode"].ToString() : "";
            data.CapNhatBarCode(ID, IDHangHoa, BarCode);
            e.Cancel = true;
            gridBarCode.CancelEdit();
            gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            gridBarCode.DataBind();

          
        }

        protected void gridBarCode_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtHangHoa();
            ASPxGridView gridBarCode = sender as ASPxGridView;
            object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            string BarCode = e.NewValues["Barcode"] != null ? e.NewValues["Barcode"].ToString() : "";
            data.ThemBarCode(IDHangHoa, BarCode);
            e.Cancel = true;
            gridBarCode.CancelEdit();
            gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            gridBarCode.DataBind();

          
        }

        protected void gridBarCode_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            data = new dtHangHoa();
            int ID = Int32.Parse(e.Keys["ID"].ToString());
            data.XoaBarCode(ID);
            e.Cancel = true;
            ASPxGridView gridBarCode = sender as ASPxGridView;
            object IDHangHoa = gridBarCode.GetMasterRowKeyValue();
            gridBarCode.DataSource = data.GetListBarCode(IDHangHoa);
            gridBarCode.DataBind();
        }

        protected void btnXuatExcel_Click(object sender, EventArgs e)
        {
            dtHangHoa data = new dtHangHoa();
            HangHoaExport.DataSource = data.LayDanhSachHangHoa_FullBarcode();
            HangHoaExport.DataBind();
            export.WriteXlsToResponse();

            string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
            if (Session["IDThuNgan"] != null)
                IDNhanVien1 = Session["IDThuNgan"].ToString();
            if (Session["IDNhanVien"] != null)
                IDNhanVien1 = Session["IDNhanVien"].ToString();
            dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Hàng hóa", "Xuất Exel Hàng hóa");
        }

        protected void btnNhapExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportExcel_HangHoa.aspx");
        }

        protected void btnXuatPDF_Click(object sender, EventArgs e)
        {

        }

        protected void XuatFilePDF_Click(object sender, EventArgs e)
        {
            //HangHoaExport.DataSource = data.getDanhSachHangHoa_Full_Barcode();
            //HangHoaExport.DataBind();
            //export.WritePdfToResponse();
        }

       
    }
}