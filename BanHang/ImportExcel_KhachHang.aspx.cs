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
    public partial class ImportExcel_KhachHang : System.Web.UI.Page
    {
        private string strFileExcel = "";
        dtKhachHang data = new dtKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["KTDangNhap"] != "GPM")
            //{
            //    Response.Redirect("DangNhap.aspx");
            //}
            //else
            //{
            //    if (dtSetting.LayTrangThaiMenu_ChucNang(Session["IDNhom"].ToString(), 3) != 1)
            //    {
                    if (!IsPostBack)
                    {
                        // xóa dữ liệu bảng temp
                        data = new dtKhachHang();
                        data.XoaDuLieuTemp();

                    }
                    LoadGrid();
                //}
                //else
                //{
                //    Response.Redirect("Default.aspx");
                //}
            //}
           
        }
        private void LoadGrid()
        {
            data = new dtKhachHang();
            gridKhachHang_Temp.DataSource = data.DanhSachKhachHang_Import_Temp();
            gridKhachHang_Temp.DataBind();
        }
        protected void gridKhachHang_Temp_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
           
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("KhachHang.aspx");
        }

        protected void btnNhap_Click(object sender, EventArgs e)
        {
            Import();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            data = new dtKhachHang();
            DataTable db = data.DanhSachKhachHang_Import_Temp();
            if (db.Rows.Count != 0)
            {
                foreach (DataRow dr in db.Rows)
                {
                    string IDNhomKhachHang = dr["IDNhomKhachHang"].ToString();
                    string MaKhachHang = dr["MaKhachHang"].ToString();
                    string TenKhachHang = dr["TenKhachHang"].ToString();
                    string NgaySinh = dr["NgaySinh"].ToString();
                    string DiaChi = dr["DiaChi"].ToString();
                    string CMND = dr["CMND"].ToString();
                    string DienThoai = dr["DienThoai"].ToString();
                    string DiemTichLuy = dr["DiemTichLuy"].ToString();

                    string GhiChu = dr["GhiChu"].ToString();

                    if (data.KiemTraSDTKhachHang(DienThoai) == 0)
                    {
                        data.ThemKhachHang(Int32.Parse(IDNhomKhachHang), MaKhachHang, TenKhachHang, DateTime.Parse(NgaySinh), CMND, DiaChi, DienThoai, GhiChu);
                        LoadGrid();
                    }

                }

                Response.Redirect("KhachHang.aspx");
            }
            else
            {
                Response.Write("<script language='JavaScript'> alert('Dữ liệu trống? Vui lòng kiểm tra lại.'); </script>");
            }
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
        private void Import_Temp(DataTable datatable)
        {
            int intRow = datatable.Rows.Count;
            if (intRow != 0)
            {
                for (int i = 0; i <= intRow - 1; i++)
                {
                    DataRow dr = datatable.Rows[i];

                    DateTime date = DateTime.Now;
                    string sDate = date.ToString("MMddyyyy");
                    int MaKh = 0;
                    Random rdom = new Random();
                    while (MaKh == 0)
                    {
                        int sR = rdom.Next(10000, 99999);
                        int kt = data.KiemTraMaKhachHang(sDate + sR);
                        if (kt == 0)
                            MaKh = sR;
                    }
                    string maKHang = sDate + MaKh;

                    dtNhomKhachHang dtNhomKH = new dtNhomKhachHang();
                    int IDNhomKhachHang = dtNhomKH.LayIDNhomKhachHang_Ten("Nhóm khách hàng");

                    string TenKhachHang = dr["Tên khách hàng"].ToString();
                    string NgaySinh = dr["Ngày sinh"] == null ? "" : dr["Ngày sinh"].ToString();
                    string CMND = dr["CMND"] == null ? "" : dr["CMND"].ToString();
                    string DiaChi = dr["Địa chỉ"] == null ? "" : dr["Địa chỉ"].ToString();
                    string DienThoai = dr["SĐT"].ToString();
                    string GhiChu = dr["Ghi chú"] == null ? "" : dr["Ghi chú"].ToString();

                    data = new dtKhachHang();
                    data.ThemKhachHang_Temp(IDNhomKhachHang, maKHang, TenKhachHang, DateTime.Parse(NgaySinh), CMND, DiaChi, DienThoai, GhiChu);
                    LoadGrid();
                }
            }

        }
       
        protected void gridKhachHang_Temp_RowDeleting1(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int ID = Int32.Parse(e.Keys[0].ToString());
            data = new dtKhachHang();
            data.XoaDuLieuTemp_ID(ID);
            e.Cancel = true;
            gridKhachHang_Temp.CancelEdit();
            LoadGrid();
        }
    }
}