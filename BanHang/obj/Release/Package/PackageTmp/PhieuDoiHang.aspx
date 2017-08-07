<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="PhieuDoiHang.aspx.cs" Inherits="BanHang.PhieuDoiHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <dx:ASPxFormLayout ID="fromPhieuDoiHang" runat="server" ColCount="6" Width="100%">
            <Items>
                <dx:LayoutGroup Caption="Thông tin phiếu đổi hàng" ColCount="6" ColSpan="6">
                    <Items>
                        <dx:LayoutItem Caption="Số Hóa Đơn" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cmbSoHoaDon" runat="server" AutoPostBack="True" Width="100%" DataSourceID="sqlHoaDon" OnSelectedIndexChanged="cmbSoHoaDon_SelectedIndexChanged" TextField="IDKhachHang" ValueField="ID"  DropDownWidth="450px" DropDownStyle="DropDownList" TextFormatString="{1}" EnableCallbackMode="true">
                                    
                                        <Columns>
                                            <dx:ListBoxColumn Caption="Mã" FieldName="ID" Width="50px" />
                                            <dx:ListBoxColumn Caption="Tên Khách Hàng" FieldName="TenKhachHang" Width="100%" />
                                            <dx:ListBoxColumn Caption="Ngày Bán" FieldName="NgayBan" Width="150px" />               
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sqlHoaDon" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [GPM_HoaDon].[ID], [GPM_KhachHang].TenKhachHang, [GPM_HoaDon].[IDNhanVien], [GPM_HoaDon].[NgayBan] FROM [GPM_HoaDon],[GPM_KhachHang] WHERE ([GPM_HoaDon].[DaXoa] = @DaXoa AND [GPM_HoaDon].IDKhachHang = [GPM_KhachHang].ID) ORDER BY [ID] DESC">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Nhân Viên Thu Ngân">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cmbThuNgan" runat="server" Width="100%" DataSourceID="sqlThuNgan" TextField="TenNhanVien" ValueField="ID" Enabled="False">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sqlThuNgan" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhanVien] FROM [GPM_NhanVienThuNgan] WHERE ([DaXoa] = @DaXoa)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Kho">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cmbKho" runat="server" DataSourceID="sqlKho" Enabled="False" TextField="TenCuaHang" ValueField="ID" Width="100%">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="sqlKho" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_ThongTinCuaHangKho]"></asp:SqlDataSource>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ngày Đổi" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDateEdit ID="txtNgayDoi" runat="server" OnInit="txtNgayDoi_Init" Width="100%">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Lý Do Đổi" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtLyDoDoi" runat="server" Width="100%">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Tiền Còn Lại">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtTienConLai" runat="server" Width="100%" Enabled="False" DisplayFormatString="N0">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Trạng Thái" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    Phiếu tạm
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Hàng Hóa Đổi" ColCount="6" ColSpan="6">
                    <Items>
                        <dx:LayoutItem Caption="Hàng Hóa Đổi" ColSpan="3">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox ID="cmbHangHoaDoi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbHangHoaDoi_SelectedIndexChanged" Width="100%"  DropDownWidth="450px">
                                         <Columns>
           
                                            <dx:ListBoxColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" Width="100%" />
                                            <dx:ListBoxColumn Caption="Số Lượng" FieldName="SoLuong" Width="100px" />               
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Số Lượng" ColSpan="2">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxSpinEdit ID="txtSoLuongDoi" runat="server" AutoPostBack="True" OnNumberChanged="txtSoLuongDoi_NumberChanged" Width="100%">
                                    </dx:ASPxSpinEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnThemDoi" runat="server" OnClick="btnThemDoi_Click" Text="Thêm">
                                        <Image IconID="chart_addchartpane_32x32">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutGroup Caption="Danh Sách Hàng Hóa Đổi" ColSpan="6">
                            <Items>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxGridView ID="gridDanhSachDoi" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowDeleting="gridDanhSachDoi_RowDeleting" Width="100%">
                                                <SettingsBehavior ConfirmDelete="True" ProcessSelectionChangedOnServer="True" />
                                                <SettingsCommandButton>
                                                    <ShowAdaptiveDetailButton ButtonType="Image">
                                                    </ShowAdaptiveDetailButton>
                                                    <HideAdaptiveDetailButton ButtonType="Image">
                                                    </HideAdaptiveDetailButton>
                                                    <DeleteButton ButtonType="Image" RenderMode="Image">
                                                        <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                                                        </Image>
                                                    </DeleteButton>
                                                </SettingsCommandButton>
                                                <SettingsText CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" />
                                                <Columns>
                                                    <dx:GridViewDataComboBoxColumn Caption="Tên Hàng" FieldName="IDHangHoa" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="6">
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataSpinEditColumn Caption="Giá Bán" FieldName="GiaMua" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                                        </PropertiesSpinEdit>
                                                    </dx:GridViewDataSpinEditColumn>
                                                    <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="4">
                                                        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                                        </PropertiesSpinEdit>
                                                    </dx:GridViewDataSpinEditColumn>
                                                    <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" ShowInCustomizationForm="True" VisibleIndex="2">
                                                        <PropertiesSpinEdit DisplayFormatString="g">
                                                        </PropertiesSpinEdit>
                                                    </dx:GridViewDataSpinEditColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
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
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutItem Caption="" ColSpan="3" HorizontalAlign="Right">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton ID="btnThemPhieuDoiHang" runat="server" Text="Thêm Phiếu Đổi Hàng" OnClick="btnThemPhieuDoiHang_Click">
                                <Image IconID="save_saveto_32x32">
                                </Image>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="" ColSpan="3">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton ID="btnHuyPhieuDoiHang" runat="server" Text="Hủy Phiếu Đổi Hàng" OnClick="btnHuyPhieuDoiHang_Click">
                                <Image IconID="save_saveandclose_32x32">
                                </Image>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
            </Items>
        </dx:ASPxFormLayout>
        <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:HiddenField ID="IDPhieuDoiHang_Temp" runat="server" />
</asp:Content>
