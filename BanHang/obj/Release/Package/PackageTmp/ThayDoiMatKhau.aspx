<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThayDoiMatKhau.aspx.cs" Inherits="BanHang.ThayDoiMatKhau" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <title>Công ty GPM Việt Nam</title>
      <link href="css/style.css" rel="stylesheet" />
</head>
<body>
   <hgroup>
  <h1>HỆ THỐNG QUẢN LÝ BÁN HÀNG</h1>
  <h3>Thay Đổi Mật Khẩu</h3>
</hgroup>
    <form id="form1" runat="server" method="post">
        
          <div class="group">
            <input type="password" name ="txtMatKhau" id="txtMatKhauCu" runat="server"><span class="highlight"></span><span class="bar"></span>
            <label>Nhập Mật Khẩu Củ</label>
          </div>
        <div class="group">
            <input type="password" name ="txtMatKhau" id="txtMatKhauMoi1" runat="server"><span class="highlight"></span><span class="bar"></span>
            <label>Nhập Mật Khẩu Mới</label>
          </div>
        <div class="group">
            <input type="password" name ="txtMatKhau" id="txtMatKhauMoi2" runat="server"><span class="highlight"></span><span class="bar"></span>
            <label>Nhập Lại Mật Khẩu Mới</label>
          </div>
   
      <button id="btnThayDoiMatKhau"  class="button buttonBlue" runat="server"  onserverclick="btnThayDoiMatKhau_Click">Xác Nhận
        <div class="ripples buttonRipples"><span class="ripplesCircle"></span></div>
      </button>
        <button id="btnHuy" class="button buttonBlue" runat="server"  onserverclick="btnHuy_Click">Trở về
        <div class="ripples buttonRipples"><span class="ripplesCircle"></span></div>
      </button>
    </form>
     <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script> 
  <script src="css/index.js"></script>
</body>
</html>
