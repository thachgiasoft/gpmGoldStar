<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietHoaDonDaIn.aspx.cs" Inherits="BanHang.ChiTietHoaDonDaIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="100%">
            <PanelCollection>
<dx:PanelContent runat="server">
    <dx:ASPxButton ID="btnInHoaDon" runat="server" OnClick="btnInHoaDon_Click" Text="In Hóa Đơn">
        <Image IconID="print_defaultprinter_16x16">
        </Image>
    </dx:ASPxButton>
    <dx:ASPxGridView ID="grdChiTietHoaDon" runat="server" AutoGenerateColumns="False" Width="100%">
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image">
            </ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image">
            </HideAdaptiveDetailButton>
        </SettingsCommandButton>
        <Columns>
            <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" ShowInCustomizationForm="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Giá Bán" FieldName="GiaBan" ShowInCustomizationForm="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Số Lượng" FieldName="SoLuong" ShowInCustomizationForm="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" ShowInCustomizationForm="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Đơn Vị Tính" FieldName="TenDonViTinh" ShowInCustomizationForm="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
                </dx:PanelContent>
</PanelCollection>
        </dx:ASPxPanel>
    </form>
</body>
</html>
