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
    public partial class ThayDoiMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KTDangNhap"] != "GPM")
            {
                Response.Redirect("DangNhap.aspx");
            }
        }
        protected void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                dtCheckDangNhap data = new dtCheckDangNhap();
                DataTable db = data.KiemTraNguoiDung(Session["UserName"].ToString(), dtSetting.GetSHA1HashData(txtMatKhauCu.Value.ToString()));
                if (db.Rows.Count != 0)
                {
                    if (KiemTraMatKhauKhop() == true)
                    {
                        int ID = Int32.Parse(Session["IDNhanVien"].ToString());
                        data = new dtCheckDangNhap();
                        string sha1 = dtSetting.GetSHA1HashData(txtMatKhauMoi2.Value.ToString());
                        data.DoiMatKhau(ID, sha1);
                        Session["KTDangNhap"] = null;

                        string IDNhanVien1 = "1"; // Session["IDThuNgan"].ToString();
                        if (Session["IDThuNgan"] != null)
                            IDNhanVien1 = Session["IDThuNgan"].ToString();
                        if (Session["IDNhanVien"] != null)
                            IDNhanVien1 = Session["IDNhanVien"].ToString();
                        dtLichSuHeThong.ThemLichSuTruyCap(IDNhanVien1, "Thay đổi mật khẩu", "Thay đổi mật khẩu");

                        Response.Redirect("DangNhap.aspx");   
                    }
                }
                Response.Write("<script language='JavaScript'> alert('Mật Khẩu củ không đúng.'); </script>");
            }
           
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        public bool KiemTra()
        {
            if (txtMatKhauCu.Value.ToString() == "" || txtMatKhauMoi1.Value.ToString() == "" || txtMatKhauMoi2.Value.ToString() == "")
            {
                Response.Write("<script language='JavaScript'> alert('Vui lòng điền đầy đủ thông tin đăng nhập.'); </script>");
                return false;
            }
            return true;
        }
        public bool KiemTraMatKhauKhop()
        {
            if (txtMatKhauMoi1.Value.ToString() != txtMatKhauMoi2.Value.ToString())
            {
                Response.Write("<script language='JavaScript'> alert('Mật Khẩu Nhập Lại không khớp.'); </script>");
                return false;
            }
            return true;
        }
        
    }
}