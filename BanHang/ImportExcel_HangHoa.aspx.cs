using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ImportExcel_HangHoa : System.Web.UI.Page
    {
        private string strFileExcel = "";
        dtImportHangHoa data = new dtImportHangHoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            data = new dtImportHangHoa();
            data.XoaDuLieuTemp();
        }

        private void LoadGrid()
        {
            data = new dtImportHangHoa();
            gridHangHoa_Temp.DataSource = data.DanhSachHangHoa_Import_Temp();
            gridHangHoa_Temp.DataBind();
        }

        protected void gridHangHoa_Temp_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtImportHangHoa();
            data.XoaDuLieuTemp_ID(ID);
            e.Cancel = true;
            gridHangHoa_Temp.CancelEdit();
            LoadGrid();
        }

        protected void btnNhap_Click(object sender, EventArgs e)
        {
            Import();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //data = new dtImportHangHoa();
            //DataTable dt = data.DanhSachHangHoa_Import_Temp();
            //if (dt.Rows.Count != 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        string MaHang = dr["MaHang"].ToString();
            //        string TenHangHoa = dr["TenHangHoa"].ToString();
            //        TenHangHoa = dtSetting.convertDauSangKhongDau(TenHangHoa).ToUpper();

            //        int IDNhomHang = Int32.Parse(dr["IDNhomHang"].ToString());
            //        TenHangHoa = dtSetting.convertDauSangKhongDau(TenHangHoa).ToUpper();
            //        int IDDonViTinh = Int32.Parse(dr["IDDonViTinh"].ToString());
            //        int IDNhaSanXuat = Int32.Parse(dr["IDNhaSanXuat"].ToString());
                    
            //        float GiaMua = float.Parse(dr["GiaMua"].ToString());
            //        float GiaBan1 = float.Parse(dr["GiaBan1"].ToString());

            //        float GiaBan2 = float.Parse(dr["GiaBan2"] != null ? dr["GiaBan2"].ToString() : "0");
            //        float GiaBan3 = float.Parse(dr["GiaBan3"] != null ? dr["GiaBan3"].ToString() : "0");
            //        float GiaBan4 = float.Parse(dr["GiaBan4"] != null ? dr["GiaBan4"].ToString() : "0");
            //        float GiaBan5 = float.Parse(dr["GiaBan5"] != null ? dr["GiaBan5"].ToString() : "0");
            //        DateTime NgayCapNhat = DateTime.Parse(dr["NgayCapNhat"].ToString());
            //        int TrangThai = Int32.Parse(dr["TrangThai"].ToString());
            //        string GhiChu = dr["GhiChu"] != null ? dr["GhiChu"].ToString() : "";
            //        int DaXoa = Int32.Parse(dr["DaXoa"].ToString());
            //        string Barcode = dr["Barcode"] != null ? dr["Barcode"].ToString() : "";

            //        data = new dtImportHangHoa();
            //        object IDHangHoa = -1;
            //        dataHangHoa hh = new dataHangHoa();
            //        DataTable dd = data.KiemTraHangHoa(MaHang);
            //        if (dd.Rows.Count == 0)
            //        {
            //            IDHangHoa = hh.insertHangHoa_Full(IDNhomHang, MaHang, TenHangHoa, IDDonViTinh, IDNhaSanXuat, GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, 0, GhiChu, DaXoa);
            //             Thêm hàng hóa vào các kho....
            //            dtThongTinCuaHangKho dtx = new dtThongTinCuaHangKho();
            //            DataTable dtax = dtx.LayDanhSach();
            //            for (int i = 0; i < dtax.Rows.Count; i++)
            //            {
            //                DataRow drx = dtax.Rows[i];
            //                int IDKho = Int32.Parse(drx["ID"].ToString());
            //                dtHangHoa da = new dtHangHoa();
            //                da.ThemHangVaoTonKho(IDKho, (int)IDHangHoa, 0, DateTime.Now, GiaBan1);
            //            } 
            //        }
            //        if ((int)IDHangHoa != -1)
            //        {
            //            DataTable d3 = hh.KiemTraBarcode((int)IDHangHoa, Barcode);
            //            if (d3.Rows.Count == 0)
            //            {
            //                hh.ThemBarCode((int)IDHangHoa, Barcode);
            //            }
            //        }
            //        else
            //        {
            //            DataRow drx = dd.Rows[0];
            //            int ID = Int32.Parse(drx["ID"].ToString());
            //            DataTable d3 = hh.KiemTraBarcode(ID, Barcode);
            //            if (d3.Rows.Count == 0)
            //            {
            //                hh.ThemBarCode(ID, Barcode);
            //            }
            //        }
            //    }

            //    data.XoaDuLieuTemp();
            //    ActionServer.CapNhatServer();
            //    dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Inport Hàng Hóa", dtSetting.LayIDKho(), "Hàng Hóa", "Import"); 
            //    Response.Redirect("HangHoa.aspx");
          //  }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            data.XoaDuLieuTemp();
            Response.Redirect("HangHoa.aspx");
        }
        private void Import()
        {
            if (string.IsNullOrEmpty(UploadFileExcel.FileName))
            {
                Response.Write("<script language='JavaScript'> alert('Chưa chọn file.'); </script>");
                return;
            }

            UploadFile();
            string Excel = Server.MapPath("~/Uploads/") + strFileExcel;

            string excelConnectionString = string.Empty;
            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Excel + ";Extended Properties=Excel 8.0;";

            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
            OleDbCommand cmd = new OleDbCommand("Select * from [Sheet$]", excelConnection);
            excelConnection.Open();
            OleDbDataReader dReader = default(OleDbDataReader);
            dReader = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dReader);
            int r = dataTable.Rows.Count;
            Import_Temp(dataTable);

        }

        private void Import_Temp(DataTable dataTable)
        {
            //int intRow = dataTable.Rows.Count;
            //if (intRow != 0)
            //{
            //    for (int i = 0; i <= intRow - 1; i++)
            //    {
            //        DataRow dr = dataTable.Rows[i];

            //        dtNhomHang d = new dtNhomHang();
            //        int IDNhomHang = d.LayDanhSachNhomHang_GetID(dr["NhomHang"].ToString());
            //        dtDonViTinh d1 = new dtDonViTinh();
            //        int IDDonViTinh = d1.LayDonViTinh_GetID(dr["DonViTinh"].ToString());
            //        dtHangSanXuat d2 = new dtHangSanXuat();
            //        int IDNhaSanXuat = d2.LayNhaSanXuat_GetID(dr["NhaSanXuat"].ToString());
            //        string MaHang = dr["MaHang"].ToString();
            //        string TenHangHoa = dr["TenHangHoa"].ToString();

            //        float GiaMua = float.Parse(dr["GiaMua"].ToString());
            //        float GiaBan1 = float.Parse(dr["GiaBan1"].ToString());

            //        float GiaBan2 = float.Parse(dr["GiaBan2"] != null ? dr["GiaBan2"].ToString() : "0");
            //        float GiaBan3 = float.Parse(dr["GiaBan3"] != null ? dr["GiaBan3"].ToString() : "0");
            //        float GiaBan4 = float.Parse(dr["GiaBan4"] != null ? dr["GiaBan4"].ToString() : "0");
            //        float GiaBan5 = float.Parse(dr["GiaBan5"] != null ? dr["GiaBan5"].ToString() : "0");
            //        DateTime NgayCapNhat = DateTime.Parse(dr["NgayCapNhat"].ToString());
            //        int TrangThai = Int32.Parse(dr["TrangThai"].ToString());
            //        string GhiChu = dr["GhiChu"] != null ? dr["GhiChu"].ToString() : "";
            //        int DaXoa = Int32.Parse(dr["DaXoa"].ToString());
            //        string Barcode = dr["Barcode"] != null ? dr["Barcode"].ToString() : "";

            //        data = new dtImportHangHoa();
            //        data.insertHangHoa_temp(IDNhomHang, MaHang, TenHangHoa, IDDonViTinh, IDNhaSanXuat, GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, NgayCapNhat, TrangThai, GhiChu, DaXoa, Barcode);
            //    }
            //    LoadGrid();
            //}
        }

        private void UploadFile()
        {
            string folder = null;
            string filein = null;
            string ThangNam = null;

            ThangNam = string.Concat(System.DateTime.Now.Month.ToString(), System.DateTime.Now.Year.ToString());
            if (!Directory.Exists(Server.MapPath("~/Uploads/") + ThangNam))
            {
                Directory.CreateDirectory(Server.MapPath("~/Uploads/") + ThangNam);
            }
            folder = Server.MapPath("~/Uploads/" + ThangNam + "/");

            if (UploadFileExcel.HasFile)
            {
                strFileExcel = Guid.NewGuid().ToString();
                string theExtension = Path.GetExtension(UploadFileExcel.FileName);
                strFileExcel += theExtension;

                filein = folder + strFileExcel;
                UploadFileExcel.SaveAs(filein);
                strFileExcel = ThangNam + "/" + strFileExcel;
            }
        }

    }
}