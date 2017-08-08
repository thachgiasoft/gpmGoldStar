<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietDonHangDuyetThuMua.aspx.cs" Inherits="BanHang.ChiTietDonHangDuyetThuMua" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTiet" KeyFieldName="ID">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
<Settings ShowTitlePanel="True"></Settings>

        <SettingsBehavior ConfirmDelete="True" />

        <SettingsCommandButton>
        <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

        <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            <NewButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_add_16x16" ToolTip="Thêm mới">
                </Image>
            </NewButton>
            <UpdateButton ButtonType="Image" RenderMode="Image">
                <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
                </Image>
            </UpdateButton>
            <CancelButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_close_32x32" ToolTip="Hủy thao tác">
                </Image>
            </CancelButton>
            <EditButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                </Image>
            </EditButton>
            <DeleteButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>

        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>

<SettingsText Title="THÔNG TIN CHI TIẾT" CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" CommandEdit="Sửa"></SettingsText>
<Columns>
    
    <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" VisibleIndex="4">
        <propertiesspinedit DisplayFormatString="N0"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" VisibleIndex="7" ReadOnly="True">
        <propertiesspinedit DisplayFormatString="{0:#,# VND}"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" VisibleIndex="8" ReadOnly="True">
        <propertiesspinedit DisplayFormatString="{0:#,# VND}"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0" ReadOnly="True">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataComboBoxColumn Caption="Hàng Hóa" FieldName="IDHangHoa" ReadOnly="True" VisibleIndex="1">
        <PropertiesComboBox DataSourceID="SqlHangHoa" TextField="TenHangHoa" ValueField="ID">
        </PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewDataComboBoxColumn Caption="Đơn Vị Tính" FieldName="IDDonViTinh" VisibleIndex="2" ReadOnly="True">
        <PropertiesComboBox DataSourceID="SqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
        </PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
</Columns>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE (([DaXoa] = @DaXoa) AND ([TenHangHoa] IS NOT NULL))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
