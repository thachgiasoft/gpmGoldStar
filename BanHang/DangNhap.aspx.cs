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
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangNhapQuanLy_Click(object sender, EventArgs e)
        {
            //if (KiemTra() == true)
            //{
            //    data = new dtCheckDangNhap();
            //    string TenDangNhap = txtDangNhap.Value.ToUpper();
            //    string MatKhau = ActionCilent.GetSHA1HashData(txtMatKhau.Value.ToString());
            //    DataTable dt = data.KiemTraQuanLy(TenDangNhap,MatKhau);
            //    if(dt.Rows.Count != 0)
            //    {
            //        DataRow dr = dt.Rows[0];
            //        Session["TenDangNhap"] = dr["TenNguoiDung"].ToString();
            //        Session["UserName"] = txtDangNhap.Value.ToUpper();
            //        Session["KTDangNhap"] = "GPM";
            //        Session["IDNhanVien"] = dr["ID"].ToString();
            //        Session["IDNhom"] = dr["IDNhomNguoiDung"].ToString();
            //        dtLichSuTruyCap.ThemLichSu(Session["IDNhanVien"].ToString(), Session["IDNhom"].ToString(), "Đăng Nhập", dtSetting.LayIDKho(), "Đăng Nhập", "Đăng Nhập");
            //        Response.Redirect("Default.aspx");
            //    }
            //    else
            //    {
            //        Response.Write("<script language='JavaScript'> alert('Đăng Nhập Không Thành Công.'); </script>");
            //        //Response.Redirect("DangNhap.aspx");
            //        txtDangNhap.Value = "";
            //        txtMatKhau.Value = "";
            //    }


            //}
            
        }
        protected void btnDangNhapBanHang_Click(object sender, EventArgs e)
        {
            //if (KiemTra() == true)
            //{
            //    data = new dtCheckDangNhap();
            //    string TenDangNhap = txtDangNhap.Value.ToString();
            //    string MatKhau = ActionCilent.GetSHA1HashData(txtMatKhau.Value.ToString());
            //    DataTable dt = data.KiemTraBanHang(TenDangNhap, MatKhau);
            //    if (dt.Rows.Count != 0)
            //    {
            //        DataRow dr = dt.Rows[0];
            //        Session["TenThuNgan"] = dr["TenNhanVien"].ToString();
            //        Session["IDThuNgan"] = dr["ID"].ToString();
            //        Session["KTBanLe"] = "GPMBanLe";

            //        Response.Redirect("BanHangLe.aspx");
            //    }
            //    else
            //    {
            //        Response.Write("<script language='JavaScript'> alert('Đăng Nhập Không Thành Công.'); </script>");
            //        //Response.Redirect("DangNhap.aspx");
            //        txtDangNhap.Value = "";
            //        txtMatKhau.Value = "";
            //    }
            //}
        }
        public bool KiemTra()
        {
            //if (txtDangNhap.Value.ToString() == "" || txtMatKhau.Value.ToString() == "")
            //{
            //    Response.Write("<script language='JavaScript'> alert('Vui lòng điền đầy đủ thông tin đăng nhập.'); </script>");
            //    return false;
            //}
            return true;
        }
    }
}