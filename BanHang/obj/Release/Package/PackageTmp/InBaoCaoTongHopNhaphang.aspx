<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InBaoCaoTongHopNhaphang.aspx.cs" Inherits="BanHang.InBaoCaoTongHopNhaphang" %>

<%@ Register assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.2.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxDocumentViewer ID="report" runat="server">
        </dx:ASPxDocumentViewer>
    
    </div>
    </form>
</body>
</html>
