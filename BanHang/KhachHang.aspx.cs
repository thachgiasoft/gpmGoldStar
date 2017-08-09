using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class KhachHang : System.Web.UI.Page
    {
        dtKhachHang data = new dtKhachHang();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            data = new dtKhachHang();
            KhachHangExport.DataSource = data.LayDanhSachKhachHang();
            KhachHangExport.DataBind();
        }

        protected void gridKhachHang_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            int IDNhomKhachHang = Int32.Parse(e.NewValues["IDNhomKhachHang"].ToString());
            string TenKhachHang = e.NewValues["TenKhachHang"] == null ? "" : e.NewValues["TenKhachHang"].ToString();
            DateTime NgaySinh = DateTime.Parse(e.NewValues["NgaySinh"] == null ? "" : e.NewValues["NgaySinh"].ToString());
            string CMND = e.NewValues["CMND"] == null ? "" : e.NewValues["CMND"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();
            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();

            data = new dtKhachHang();
            if (data.KiemTraSDTKhachHang_KhacID(ID,DienThoai) == 0)
            {
                data.SuaThongTinKhachHang(Int32.Parse(ID), IDNhomKhachHang, TenKhachHang, NgaySinh, CMND, DiaChi, DienThoai, GhiChu);
                e.Cancel = true;
                KhachHangExport.CancelEdit();
                LoadGrid();
            }
            else
            {
                throw new Exception("Số điện thoại này đã được đăng ký.");
            }
            
        }

        protected void gridKhachHang_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            data = new dtKhachHang();
            int IDNhomKhachHang = Int32.Parse(e.NewValues["IDNhomKhachHang"].ToString());
            string TenKhachHang = e.NewValues["TenKhachHang"] == null ? "" : e.NewValues["TenKhachHang"].ToString();
            DateTime NgaySinh = DateTime.Parse(e.NewValues["NgaySinh"] == null ? "" : e.NewValues["NgaySinh"].ToString());
            string CMND = e.NewValues["CMND"] == null ? "" : e.NewValues["CMND"].ToString();
            string DiaChi = e.NewValues["DiaChi"] == null ? "" : e.NewValues["DiaChi"].ToString();
            string DienThoai = e.NewValues["DienThoai"] == null ? "" : e.NewValues["DienThoai"].ToString();

            DateTime date = DateTime.Now;
            string sDate = date.ToString("MMddyyyy");
            int MaKh = 0;
            Random dr = new Random();
            while (MaKh == 0)
            {
                int sR = dr.Next(10000, 99999);
                int kt = data.KiemTraMaKhachHang(sDate + sR);
                if (kt == 0)
                    MaKh = sR;
            }

            string GhiChu = e.NewValues["GhiChu"] == null ? "" : e.NewValues["GhiChu"].ToString();

            if (data.KiemTraSDTKhachHang(DienThoai) == 0)
            {
                data.ThemKhachHang(IDNhomKhachHang, sDate + MaKh, TenKhachHang, NgaySinh, CMND, DiaChi, DienThoai, GhiChu);
                e.Cancel = true;
                KhachHangExport.CancelEdit();
                LoadGrid();
            }
            else
            {
                throw new Exception("Số điện thoại này đã được đăng ký.");
            }

        }

        protected void gridKhachHang_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtKhachHang();
            data.XoaKhachHang(Int32.Parse(ID));
            e.Cancel = true;
            KhachHangExport.CancelEdit();
            LoadGrid();
        }

        protected void btnXuatPDF_Click(object sender, EventArgs e)
        {
            //XuatDuLieu.WritePdfToResponse();
        }

        protected void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportKhachHang.WriteXlsToResponse();
        }

        protected void btnNhapExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportExcel_KhachHang.aspx");
        }
    }
}