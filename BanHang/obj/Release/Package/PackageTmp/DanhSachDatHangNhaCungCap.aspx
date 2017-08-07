<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DanhSachDatHangNhaCungCap.aspx.cs" Inherits="BanHang.DanhSachDatHangNhaCungCap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <script type="text/javascript">
            function OnMoreInfoClick(element, key) {
                popup.SetContentUrl("ChiTietDatHangNhaCungCap.aspx?IDDonDatHang=" + key);
                popup.ShowAtElement();
                // alert(key);
            }
    </script>
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="In đơn đặt hàng" ColCount="2" ColSpan="2">
                <Items>
                    <dx:LayoutItem Caption="Chọn phiếu in">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="cmbIDDonHang" runat="server" DataSourceID="sqlDonHang"  ValueType="System.String"  DropDownWidth="600" DropDownStyle="DropDown" 
                                    ValueField="ID"  Width="100%" >
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Mã" FieldName="ID" Width="50px" />
                                        <dx:ListBoxColumn Caption="Nhà cung cấp" FieldName="TenNhaCungCap" Width="100%" />
                                        <dx:ListBoxColumn Caption="Người lập phiếu" FieldName="TenNguoiDung" Width="100px" />
                                        <dx:ListBoxColumn Caption="Ngày lập phiếu" FieldName="NgayLap" Width="100px" />               
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sqlDonHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand=" SELECT [GPM_DonDatHangServer].NgayLap,[GPM_DonDatHangServer].[ID], [GPM_NhaCungCap].TenNhaCungCap,[GPM_NguoiDung].TenNguoiDung FROM [GPM_DonDatHangServer],[GPM_NhaCungCap],[GPM_NguoiDung] WHERE ([GPM_DonDatHangServer].IDNhaCungCap = [GPM_NhaCungCap].ID AND [GPM_DonDatHangServer].IDNguoiDung = [GPM_NguoiDung].ID  AND [TrangThai] = @TrangThai)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="TrangThai" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Left">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnInPhieu" runat="server" Text="In Phiếu" OnClick="btnInPhieu_Click">
                                    <Image IconID="print_print_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
        </dx:ASPxFormLayout>
    <dx:ASPxGridView ID="gridDanhSachDonHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridDanhSachDonHang_CustomButtonCallback">
        <Templates>
            <EditForm>
                <%-- <dx:ASPxTextBox ID="txttest" runat="server" Width="100%">
                </dx:ASPxTextBox> --%>
                <div style="text-align: right; padding: 2px">
                </div>
            </EditForm>
        </Templates>
        <SettingsEditing Mode="EditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" ShowTitlePanel="True" />
        <SettingsCommandButton RenderMode="Link">
            <ShowAdaptiveDetailButton ButtonType="Image">
            </ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image">
            </HideAdaptiveDetailButton>
            <NewButton ButtonType="Link" RenderMode="Link">
                <Image Url="ThemDonHang.aspx" >
                </Image>
            </NewButton>
        </SettingsCommandButton>
        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" />
        <SettingsText CommandDelete="Xóa" CommandNew="Thêm" Title="DANH SÁCH ĐƠN ĐẶT HÀNG NHÀ CUNG CẤP" PopupEditFormCaption="Thông tin đơn hàng"/>
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="9" ButtonRenderMode="Image" ButtonType="Image" Name="iconaction">
                 <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="DuyetDonHang">
                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Duyệt Đơn Hàng">
                            </Image>              
                        </dx:GridViewCommandColumnCustomButton>
                       
                    </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Ghi Chú" VisibleIndex="7" FieldName="GhiChu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Lập Phiếu" VisibleIndex="5" FieldName="NgayLap">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="8">
                
                <DataItemTemplate>
                    <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tổng Tiền" FieldName="TongTien" VisibleIndex="6">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Chi Nhánh" FieldName="IDKho" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="sqlKho" TextField="TenCuaHang" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Nhà Cung Cấp" FieldName="IDNhaCungCap" VisibleIndex="3">
                <PropertiesComboBox DataSourceID="sqlNhaCungCap" TextField="TenNhaCungCap" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="Mã" FieldName="ID" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Người Lập" FieldName="IDNguoiDung" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="sqlNguoiDung" TextField="TenNguoiDung" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="Số Hóa Đơn" FieldName="SoHoaDon" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
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
        <asp:SqlDataSource ID="sqlNguoiDung" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguoiDung] FROM [GPM_NguoiDung] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhaCungCap] FROM [GPM_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
     <asp:SqlDataSource ID="sqlKho" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenCuaHang] FROM [GPM_ThongTinCuaHangKho] WHERE ([DaXoa] = @DaXoa)">
         <SelectParameters>
             <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
         </SelectParameters>
     </asp:SqlDataSource>
    <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="900px"
         Height="600px" FooterText="Thông tin chi tiết đơn đặt hàng"
        HeaderText="Thông tin chi tiết đơn đặt hàng" ClientInstanceName="popup" EnableHierarchyRecreation="True">
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popupIn" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1000px"
         Height="550px" FooterText="Thông tin bảng kê"
        HeaderText="In Đơn Đặt Hàng" ClientInstanceName="popupIn" EnableHierarchyRecreation="True">
    </dx:ASPxPopupControl>
</asp:Content>
