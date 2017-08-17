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
            if (!IsPostBack)
            {
                data = new dtImportHangHoa();
                data.XoaDuLieuTemp();
            }
            LoadGrid();
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
            data = new dtImportHangHoa();
            DataTable dt = data.DanhSachHangHoa_Import_Temp();
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string MaHang = dr["MaHang"].ToString();
                    string TenHangHoa = dr["TenHangHoa"].ToString();
                    TenHangHoa = dtSetting.convertDauSangKhongDau(TenHangHoa).ToUpper();

                    int IDDonViTinh = Int32.Parse(dr["IDDonViTinh"].ToString());
                    
                    float GiaMua = float.Parse(dr["GiaMua"].ToString());
                    float GiaBan1 = float.Parse(dr["GiaBan1"].ToString());
                    float GiaBan2 = float.Parse(dr["GiaBan2"] != null ? dr["GiaBan2"].ToString() : "0");
                    float GiaBan3 = float.Parse(dr["GiaBan3"] != null ? dr["GiaBan3"].ToString() : "0");
                    float GiaBan4 = float.Parse(dr["GiaBan4"] != null ? dr["GiaBan4"].ToString() : "0");
                    float GiaBan5 = float.Parse(dr["GiaBan5"] != null ? dr["GiaBan5"].ToString() : "0");
                    int TrangThaiHang = Int32.Parse(dr["TrangThaiHang"].ToString());
                    string Barcode = dr["Barcode"] != null ? dr["Barcode"].ToString() : "";

                    data = new dtImportHangHoa();
                    object IDHangHoa = -1;
                    dtHangHoa hh = new dtHangHoa();
                    DataTable dd = data.KiemTraHangHoa(MaHang);
                    if (dd.Rows.Count == 0)
                    {
                        IDHangHoa = hh.ThemHangHoa(MaHang, TenHangHoa, IDDonViTinh + "", GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, TrangThaiHang + "", "");
                        hh.ThemHangVaoTonKho(Int32.Parse(IDHangHoa + ""));
                        
                    }
                    if ((int)IDHangHoa != -1)
                    {
                        DataTable d3 = hh.kiemTraBarcode(IDHangHoa + "", Barcode);
                        if (d3.Rows.Count == 0)
                        {
                            hh.ThemBarCode((int)IDHangHoa, Barcode);
                        }
                    }
                    else
                    {
                        DataRow drx = dd.Rows[0];
                        int ID = Int32.Parse(drx["ID"].ToString());
                        DataTable d3 = hh.kiemTraBarcode(ID + "", Barcode);
                        if (d3.Rows.Count == 0)
                        {
                            hh.ThemBarCode(ID, Barcode);
                        }
                    }
                }

                data.XoaDuLieuTemp();

                string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
                if (Session["IDThuNgan"] != null)
                    IDNhanVien1 = Session["IDThuNgan"].ToString();
                if (Session["IDNhanVien"] != null)
                    IDNhanVien1 = Session["IDNhanVien"].ToString();
                dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Import Hàng hóa", "Lưu dữ liệu import hàng hóa");

                Response.Redirect("HangHoa.aspx");
            }
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
            int intRow = dataTable.Rows.Count;
            if (intRow != 0)
            {
                for (int i = 0; i <= intRow - 1; i++)
                {
                    DataRow dr = dataTable.Rows[i];

                    dtDonViTinh d1 = new dtDonViTinh();
                    int IDDonViTinh = d1.layID_DonViTinh_Ten(dr["Ten Don Vi Tinh"].ToString());

                    dtBaoCao d2 = new dtBaoCao();
                    int TrangThaiHang = d2.layID_LoaiHangHoa_Ten(dr["Trang Thai Hang"].ToString());

                    string MaHang = dr["Ma Hang"].ToString();
                    string TenHangHoa = dr["Ten Hang Hoa"].ToString();

                    float GiaMua = float.Parse(dr["Gia Mua"].ToString());
                    float GiaBan1 = float.Parse(dr["Gia Ban1"].ToString());
                    float GiaBan2 = float.Parse((dr["Gia Ban2"] == null ? dr["Gia Ban2"].ToString() : "0").Replace(".", ","));
                    float GiaBan3 = float.Parse((dr["Gia Ban3"] == null ? dr["Gia Ban3"].ToString() : "0").Replace(".", ","));
                    float GiaBan4 = float.Parse((dr["Gia Ban4"] == null ? dr["Gia Ban4"].ToString() : "0").Replace(".", ","));
                    float GiaBan5 = float.Parse((dr["Gia Ban5"] == null ? dr["Gia Ban5"].ToString() : "0").Replace(".", ","));

                    int TrangThai = Int32.Parse(dr["Trang Thai"].ToString());
                    string Barcode = dr["Barcode"] != null ? dr["Barcode"].ToString() : "";

                    data = new dtImportHangHoa();
                    data.insertHangHoa_temp(MaHang, TenHangHoa, IDDonViTinh, GiaMua, GiaBan1, GiaBan2, GiaBan3, GiaBan4, GiaBan5, TrangThaiHang, TrangThai, Barcode);
                }
                LoadGrid();
            }
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