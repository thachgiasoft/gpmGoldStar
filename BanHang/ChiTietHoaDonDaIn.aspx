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
            <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" ShowInCustomizationForm="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Đơn Vị Tính" FieldName="TenDonViTinh" ShowInCustomizationForm="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="Giá Bán" FieldName="GiaBan" ShowInCustomizationForm="True" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" ShowInCustomizationForm="True" VisibleIndex="4">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="5">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
        </Columns>
    </dx:ASPxGridView>
                </dx:PanelContent>
</PanelCollection>
        </dx:ASPxPanel>
        <dx:ASPxPopupControl ID="chitietbuilInLai" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" ClientInstanceName="chitietbuilInLai" PopupVerticalAlign="WindowCenter"  Width="1000px" Height="600px" HeaderText="Chi tiết hóa đơn">
        </dx:ASPxPopupControl>
    </form>

</body>
</html>
