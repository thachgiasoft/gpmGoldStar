<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="HangHoa.aspx.cs" Inherits="BanHang.HangHoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">
    preventEndEdit_LostFocus_onBarCode = false;
    var listBarCode = [];
    function onBarCode_KeyDown(s, e) {
        var keyCode = ASPxClientUtils.GetKeyCode(e.htmlEvent);
        if (keyCode === ASPx.Key.Esc) {
            txtBarCode.SetText('');
            preventEndEdit_LostFocus_onBarCode = true;
        }
        if (keyCode === ASPx.Key.Tab || keyCode === ASPx.Key.Enter) {
            listBarCode.push(txtBarCode.GetText());
            tkbListBarCode.AddToken(txtBarCode.GetText());
            txtBarCode.SetText('');
            preventEndEdit_LostFocus_onBarCode = true;
        }
    }
    function onBarCode_LostFocus(s, e) {
        if (!preventEndEdit_LostFocus_onBarCode) {
            tkbListBarCode.AddToken(txtBarCode.GetText());
            txtBarCode.SetText('');
        }
        preventEndEdit_LostFocus_onBarCode = false;
    }
</script>
    <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="100%"><PanelCollection>
    <dx:PanelContent runat="server">
        <dx:ASPxButton ID="XuatFilePDF" runat="server" OnClick="XuatFilePDF_Click" Text="Xuất PDF">
            <Image IconID="export_exporttopdf_16x16">
            </Image>
        </dx:ASPxButton>
        <dx:ASPxButton ID="btnXuatExcel" runat="server" OnClick="btnXuatExcel_Click" Text="Xuất Excel">
                            <Image IconID="export_exporttoxls_16x16">
                            </Image>
                        </dx:ASPxButton>
        <%--<dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="8" Width="10%">
        <Items>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                        <dx:ASPxButton ID="XuatFilePDF" runat="server" OnClick="XuatFilePDF_Click" Text="Xuất PDF">
                            <Image IconID="export_exporttopdf_16x16">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                        <dx:ASPxButton ID="btnXuatExcel" runat="server" OnClick="btnXuatExcel_Click" Text="Xuất Excel">
                            <Image IconID="export_exporttoxls_16x16">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                        <dx:ASPxButton ID="btnNhapExcel" runat="server" OnClick="btnNhapExcel_Click" Text="Nhập Excel">
                            <Image IconID="export_exporttoxlsx_16x16gray">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>--%>
        <dx:ASPxGridViewExporter ID="export" runat="server" GridViewID="HangHoaExport">
        </dx:ASPxGridViewExporter>
        <dx:ASPxButton ID="btnNhapExel" runat="server" OnClick="btnNhapExcel_Click" Text="Nhập Exel">
            <Image IconID="export_exporttoxls_16x16">
            </Image>
        </dx:ASPxButton>
    </dx:PanelContent>
    </PanelCollection>
    </dx:ASPxPanel>
    <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="100%" DefaultButton="ASPxButton1">
        <PanelCollection>
        <dx:PanelContent ID="PanelContent1" runat="server">
            <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" ClientVisible="false"  Text="ASPxButton">
                <ClientSideEvents Click="function(s, e){ txtBarCode.Focus();}" />
            </dx:ASPxButton>
            <dx:ASPxGridView ID="gridHangHoa" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridHangHoa_RowDeleting" OnRowInserting="gridHangHoa_RowInserting" OnRowUpdating="gridHangHoa_RowUpdating">
                    <SettingsDetail ShowDetailRow="True" />
                    <Templates>
                        <EditForm>
                            <div style="padding: 4px 3px 4px">
                                <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors"
                                    runat="server">
                                </dx:ASPxGridViewTemplateReplacement>                    
                            </div>
                            <div style="padding: 4px 3px 4px">

                                <dx:ASPxTextBox ID="txtBarCode" ClientInstanceName="txtBarCode" Caption="Barcode" runat="server" Width="100%">
                                    <ClientSideEvents KeyDown="onBarCode_KeyDown" LostFocus="onBarCode_LostFocus" />
                                </dx:ASPxTextBox>
                                <br />
                                <dx:ASPxTokenBox ID="tkbListBarCode" ClientInstanceName="tkbListBarCode" runat="server"
                                    AllowMouseWheel="True" Tokens='<%# LoadListBarCode(Eval("ID")) %>' Width="100%" NullText="Danh sách BarCode của hàng hóa">
                                </dx:ASPxTokenBox>                    
                            </div>
                            <div style="text-align: right; padding: 2px">
                                <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                                    runat="server">
                                </dx:ASPxGridViewTemplateReplacement>
                                <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                                    runat="server">
                                </dx:ASPxGridViewTemplateReplacement>
                            </div>
                        </EditForm>
                        <DetailRow>
                            <dx:ASPxGridView ID="gridBarCode" runat="server" AutoGenerateColumns="False" 
                                KeyFieldName="ID" oninit="gridBarCode_Init" 
                                Width="100%" onrowdeleting="gridBarCode_RowDeleting" 
                                onrowinserting="gridBarCode_RowInserting" 
                                onrowupdating="gridBarCode_RowUpdating">
                                <SettingsCommandButton>
                                    <ShowAdaptiveDetailButton ButtonType="Image">
                                    </ShowAdaptiveDetailButton>
                                    <HideAdaptiveDetailButton ButtonType="Image">
                                    </HideAdaptiveDetailButton>
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
                                <Columns>
                                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" 
                                        ShowNewButtonInHeader="True" VisibleIndex="3">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0">
                                        <EditFormSettings Visible="False" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="BarCode" FieldName="Barcode" 
                                        VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ngày cập nhật" FieldName="NgayCapNhat" 
                                        VisibleIndex="2">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <Styles>
                                    <Header HorizontalAlign="Center">
                                    </Header>
                                </Styles>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRow="True" ShowTitlePanel="True" />
                    <SettingsBehavior ConfirmDelete="True" />
                    <SettingsCommandButton RenderMode="Image">
                        <ShowAdaptiveDetailButton ButtonType="Image">
                        </ShowAdaptiveDetailButton>
                        <HideAdaptiveDetailButton ButtonType="Image">
                        </HideAdaptiveDetailButton>
                        <NewButton>
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
                    <SettingsSearchPanel Visible="True" />
                    <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin hàng hóa" Title="DANH SÁCH HÀNG HÓA" />
                    <EditFormLayoutProperties>
                        <Items>
                            <dx:GridViewTabbedLayoutGroup>
                                <Items>
                                    <dx:GridViewLayoutGroup Caption="Thông tin hàng hóa" ColCount="2">
                                        <Items>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Nhóm Hàng" Name="IDNhomHang">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Mã Hàng" Name="MaHang">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Tên Hàng Hóa" Name="TenHangHoa">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Đơn Vị Tính" Name="IDDonViTinh">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Nhà Sản Xuất" Name="IDNhaSanXuat">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Giá Mua" Name="GiaMua">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem Caption="Giá Bán" ColumnName="Giá Bán" Name="GiaBan1">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Ghi Chú" Name="GhiChu">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem Caption="Trạng Thái" ColSpan="2" ColumnName="Trạng Thái" Name="TrangThai">
                                            </dx:GridViewColumnLayoutItem>
                                        </Items>
                                    </dx:GridViewLayoutGroup>
                                    <dx:GridViewLayoutGroup Caption="Thông tin thêm" ColCount="2" Name="GiaMua">
                                        <Items>
                                            <dx:GridViewColumnLayoutItem ColumnName="Giá Bán 2" Name="GiaBan2">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Giá Bán 3" Name="GiaBan3">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Giá Bán 4" Name="GiaBan4">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Giá Bán 5" Name="GiaBan5">
                                            </dx:GridViewColumnLayoutItem>
                                        </Items>
                                    </dx:GridViewLayoutGroup>
                                </Items>
                            </dx:GridViewTabbedLayoutGroup>
                        </Items>
                    </EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewDataComboBoxColumn Caption="Nhóm Hàng" FieldName="IDNhomHang" VisibleIndex="0">
                            <PropertiesComboBox DataSourceID="sqlNhomHang" TextField="TenNhomHang" ValueField="ID">
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Đơn Vị Tính" FieldName="IDDonViTinh" VisibleIndex="3">
                            <PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Nhà Sản Xuất" FieldName="IDNhaSanXuat" VisibleIndex="4">
                            <PropertiesComboBox DataSourceID="sqlHangSX" TextField="TenNhanHang" ValueField="ID">
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="12">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="13" Name="iconaction">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="1">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Mua" FieldName="GiaMua" VisibleIndex="5">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Bán" FieldName="GiaBan1" VisibleIndex="6">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Bán 2" FieldName="GiaBan2" Visible="False" VisibleIndex="7">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Bán 3" FieldName="GiaBan3" Visible="False" VisibleIndex="8">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Bán 4" FieldName="GiaBan4" Visible="False" VisibleIndex="9">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá Bán 5" FieldName="GiaBan5" Visible="False" VisibleIndex="10">
                            <PropertiesSpinEdit DisplayFormatString="g">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Trạng Thái" FieldName="TrangThai" VisibleIndex="11">
                            <PropertiesComboBox>
                                <Items>
                                    <dx:ListEditItem Text="Hàng Hóa Thường" Value="0" />
                                    <dx:ListEditItem Text="Hàng Hóa Combo" Value="1" />
                                    <dx:ListEditItem Text="Hàng Ngừng Nhập" Value="3" />
                                    <dx:ListEditItem Text="Hàng Không Kinh Doanh" Value="4" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <Styles>
                        <Header Font-Bold="True" HorizontalAlign="Center">
                        </Header>
                        <AlternatingRow Enabled="True">
                        </AlternatingRow>
                        <TitlePanel Font-Bold="True" HorizontalAlign="Left">
                        </TitlePanel>
                    </Styles>
                </dx:ASPxGridView>
        </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    
    
    <asp:SqlDataSource ID="sqlHangSX" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhanHang] FROM [GPM_HangSanXuat] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>                
    <dx:ASPxGridView ID="HangHoaExport" runat="server" Visible="False" AutoGenerateColumns="False">
        <SettingsCommandButton>
        <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

        <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
        </SettingsCommandButton>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="NhomHang" FieldName="TenNhomHang" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="MaHang" FieldName="MaHang" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="TenHangHoa" FieldName="TenHangHoa" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NhaSanXuat" FieldName="TenNhanHang" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DonViTinh" FieldName="TenDonViTinh" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaMua" FieldName="GiaMua" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaBan1" FieldName="GiaBan1" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaBan2" FieldName="GiaBan2" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaBan3" FieldName="GiaBan3" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaBan4" FieldName="GiaBan4" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GiaBan5" FieldName="GiaBan5" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="NgayCapNhat" FieldName="NgayCapNhat" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="TrangThai" FieldName="TrangThai" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="GhiChu" FieldName="GhiChu" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="DaXoa" FieldName="DaXoa" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Barcode" FieldName="Barcode" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
    <asp:SqlDataSource ID="sqlNhomHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhomHang] FROM [GPM_NhomHang] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
