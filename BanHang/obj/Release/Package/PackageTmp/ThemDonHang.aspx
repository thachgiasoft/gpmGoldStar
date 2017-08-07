<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="ThemDonHang.aspx.cs" Inherits="BanHang.ThemDonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   
                    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="4" Width="100%">
                        <Items>
                            <dx:LayoutGroup Caption="Thông tin đơn đặt hàng" ColCount="4" ColSpan="4" RowSpan="2">
                                <Items>
                                    <dx:LayoutItem Caption="Nhà Cung Cấp">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="ASPxFormLayout1_NhaCungCap" runat="server" DataSourceID="sqlNhaCungCap" TextField="TenNhaCungCap" ValueField="ID">
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhaCungCap] FROM [GPM_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Ngày Lập Phiếu">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxDateEdit ID="ASPxFormLayoutNgayLapPhieu" runat="server" DateOnError="Today" DisplayFormatString="dd/MM/yyyy" OnInit="ASPxFormLayoutNgayLapPhieu_Init">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Kho">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="txtIDKho" runat="server" DataSourceID="sqlKhoHang" TextField="TenCuaHang" ValueField="ID" ReadOnly="true">
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlKhoHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_ThongTinCuaHangKho] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Ghi Chú" RowSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxTextBox ID="ASPxFormLayoutGhiChu" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                            <dx:LayoutGroup Caption="Thông tin hàng hóa đặt" ColCount="4" ColSpan="4" RowSpan="2">
                                <Items>
                                    <dx:LayoutItem Caption="Hàng Hóa">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="ASPxFormLayoutIDHangHoa" runat="server" DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ASPxFormLayoutIDHangHoa_SelectedIndexChanged" DropDownWidth="350px" DropDownStyle="DropDownList" TextFormatString="{1}" EnableCallbackMode="true">
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="Mã" FieldName="ID" Width="50px" />
                                                        <dx:ListBoxColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" Width="100%" />
                                                        <dx:ListBoxColumn Caption="Giá Bán" FieldName="GiaMua" Width="100px" />               
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionServer %>" SelectCommand="SELECT [GPM_HangHoa].* FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Thuế">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxComboBox ID="ASPxFormLayoutThue" runat="server" DataSourceID="sqlThue" TextField="TenThue" ValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ASPxFormLayoutThue_SelectedIndexChanged">
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlThue" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [GPM_Thue].[ID], [GPM_Thue].[TenThue] + ' - '+[GPM_Thue_CALCU].Ten As TenThue FROM [GPM_Thue],[GPM_Thue_CALCU] WHERE ([GPM_Thue].[DaXoa] = 0 AND [GPM_Thue_CALCU].ID = [GPM_Thue].IDThue_CALCU )">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Số Lượng">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxSpinEdit ID="ASPxFormLayoutSoLuong" runat="server" AutoPostBack="True" OnNumberChanged="ASPxFormLayoutSoLuong_NumberChanged">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Đơn Giá">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxSpinEdit ID="ASPxFormLayoutDonGia" runat="server" ReadOnly="true" DisplayFormatString="N0">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Tiền Chưa Thuế">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxSpinEdit ID="ASPxFormLayoutTienChuaThue" runat="server" ReadOnly="True" DisplayFormatString="N0" Enabled="False">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="VAT">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxSpinEdit ID="ASPxFormLayoutVAT" runat="server" ReadOnly="true" DisplayFormatString="N0" Enabled="False">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Thành Tiền">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxSpinEdit ID="ASPxFormLayoutThanhTien" runat="server" ReadOnly="true" DisplayFormatString="N0" Enabled="False">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" HorizontalAlign="Left">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxButton ID="ASPxFormLayoutThemTemp" runat="server" Text="Thêm" OnClick="ASPxFormLayoutThemTemp_Click">
                                                    <Image IconID="chart_addchartpane_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                             <dx:LayoutGroup Caption="Upload File Excel" ColCount="4" ColSpan="4" RowSpan="2">
                                <Items>
                                    <dx:LayoutItem Caption="Chọn File" HorizontalAlign="Right">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                                                <dx:ASPxUploadControl ID="UploadFileExcel" runat="server" AllowedFileExtensions=".xls" >
                                    </dx:ASPxUploadControl>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                                <dx:ASPxButton ID="btnLoadFileExcel" runat="server" Text="Upload" OnClick="btnLoadFileExcel_Click">
                                                    <Image IconID="miscellaneous_publish_16x16office2013">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                            <dx:LayoutGroup ColSpan="4" Caption="Danh sách hàng hóa" ColCount="4">
                                <Items>
                                    <dx:LayoutItem Caption="" ColSpan="4">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                
                                                <dx:ASPxGridView ID="GridViewDanhSachHangHoa_Temp" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowDeleting="GridViewDanhSachHangHoa_Temp_RowDeleting" OnRowUpdating="GridViewDanhSachHangHoa_Temp_RowUpdating" Width="100%">
                                                    <SettingsBehavior ProcessSelectionChangedOnServer="True" ConfirmDelete="True" />
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
                                                        <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Tiền Chưa Thuế" FieldName="TienChuaThue" ShowInCustomizationForm="True" VisibleIndex="3">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="VAT" FieldName="TienThue" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="5">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" ShowInCustomizationForm="True" VisibleIndex="1">
                                                            <PropertiesSpinEdit DisplayFormatString="g">
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
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
                                    <dx:LayoutItem Caption="" HorizontalAlign="Right" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxButton ID="ASPxFormThem" runat="server" Text="Thêm đơn hàng" OnClick="ASPxFormThem_Click">
                                                    <Image IconID="save_saveto_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer runat="server">
                                                <dx:ASPxButton ID="ASPxFormLayoutHuyDonDatHang" runat="server" Text="Hủy đơn hàng" OnClick="ASPxFormLayoutHuyDonDatHang_Click">
                                                    <Image IconID="save_saveandclose_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
              
</asp:Content>
