<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keyCode.aspx.cs" Inherits="BanHang.keyCode" %>

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
  <h3>Kích hoạt hệ thống</h3>
</hgroup>
    <form id="form1" runat="server" method="post">
        <div class="group">
            <input type="text" name ="txtNguoiKichHoat" id="txtNguoiKichHoat" runat="server" />
              <span class="highlight"></span><span class="bar"></span>
            <label>Tên người thiết lập</label>
         </div>
          <div class="group">
            <input type="password" name ="txtKey" id="txtKey" runat="server"><span class="highlight"></span><span class="bar"></span>
            <label>Key kích hoạt</label>
          </div>
  
        <button id="btnKichHoat" class="button buttonBlue" runat="server"   onserverclick="btnKichHoat_Click" >Kích hoạt</button>
    </form>
     <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script> 
  <script src="css/index.js"></script>
</body>
</html>

