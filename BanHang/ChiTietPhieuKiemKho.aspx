<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhieuKiemKho.aspx.cs" Inherits="BanHang.ChiTietPhieuKiemKho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2">
        <Items>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                        <dx:ASPxButton ID="btnDuyet" runat="server" Text="Duyệt Phiếu Kiểm Kho" HorizontalAlign="Right" VerticalAlign="Middle" OnClick="btnDuyet_Click">
                            <Image IconID="spreadsheet_protectsheet_32x32">
                            </Image>
                            <Paddings Padding="4px" />
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
           
        </Items>
      </dx:ASPxFormLayout> 
             <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTietPhieuKiemKho" KeyFieldName="ID" OnRowDeleting="gridChiTietPhieuKiemKho_RowDeleting" OnRowUpdating="gridChiTietPhieuKiemKho_RowUpdating">
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
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Mã Hàng">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Hàng Hóa">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ĐVT">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Tồn Kho">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Thực Tế">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
<Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="6" Name="chucnang">
    </dx:GridViewCommandColumn>
    <dx:GridViewDataComboBoxColumn FieldName="IDHangHoa" Caption="H&#224;ng H&#243;a" VisibleIndex="1" ReadOnly="True">
    <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID"></PropertiesComboBox >
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewDataTextColumn Caption="Tồn Kho" FieldName="TonKho" VisibleIndex="3" ReadOnly="true">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="Chênh Lệch" FieldName="ChenhLech" VisibleIndex="5">
    </dx:GridViewDataTextColumn>
    
    <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0" ReadOnly="true">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" VisibleIndex="2" ReadOnly="true">
        <PropertiesComboBox DataSourceID="SqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
        </PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    
    <dx:GridViewDataSpinEditColumn Caption="Thực Tế" FieldName="ThucTe" VisibleIndex="4">
        <PropertiesSpinEdit DisplayFormatString="g">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
</Columns>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
             <asp:SqlDataSource ID="SqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT DISTINCT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                 <SelectParameters>
                     <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                 </SelectParameters>
             </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
