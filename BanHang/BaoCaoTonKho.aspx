<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="BaoCaoTonKho.aspx.cs" Inherits="BanHang.BaoCaoTonKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="In báo cáo" ColCount="2" HorizontalAlign="Center">
                <Items>
                    <dx:LayoutItem Caption="Loại hàng hóa">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="cmbLoaiHangHoa" runat="server" Width="100%">
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnInBaoCao" runat="server" HorizontalAlign="Center" OnClick="btnInBaoCao_Click">
                                    <Image IconID="print_defaultprinter_16x16">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <%--popup chi tiet--%>
     <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" Width="100%">
         <Items>
             <dx:LayoutItem Caption="">
                 <LayoutItemNestedControlCollection>
                     <dx:LayoutItemNestedControlContainer runat="server">
                         <dx:ASPxGridView ID="gridBaoCaoTonKho" runat="server" AutoGenerateColumns="False" Width="100%">
                             <Settings ShowFilterRow="True" />
                             <SettingsCommandButton>
                                 <ShowAdaptiveDetailButton ButtonType="Image">
                                 </ShowAdaptiveDetailButton>
                                 <HideAdaptiveDetailButton ButtonType="Image">
                                 </HideAdaptiveDetailButton>
                             </SettingsCommandButton>
                             <Columns>
                                 <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0">
                                 </dx:GridViewCommandColumn>
                                 <dx:GridViewDataTextColumn Caption="Mã hàng" FieldName="MaHang" ShowInCustomizationForm="True" VisibleIndex="1">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="Tên hàng hóa" FieldName="TenHangHoa" ShowInCustomizationForm="True" VisibleIndex="2">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="Số lượng còn" FieldName="SoLuongCon" ShowInCustomizationForm="True" VisibleIndex="4">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn Caption="Đơn vị tính" FieldName="IDDonViTinh" ShowInCustomizationForm="True" VisibleIndex="3">
                                     <PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
                                     </PropertiesComboBox>
                                 </dx:GridViewDataComboBoxColumn>
                                 <dx:GridViewDataTextColumn Caption="Ngày cập nhật" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="6">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn Caption="Loại hàng hóa" FieldName="TrangThaiHang" ShowInCustomizationForm="True" VisibleIndex="5">
                                     <PropertiesComboBox DataSourceID="sqlLoaiHangHoa1" TextField="TenTrangThai" ValueField="ID">
                                     </PropertiesComboBox>
                                 </dx:GridViewDataComboBoxColumn>
                             </Columns>
                         </dx:ASPxGridView>
                         <asp:SqlDataSource ID="sqlLoaiHangHoa1" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_TrangThaiHang]"></asp:SqlDataSource>
                         <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [TenDonViTinh], [ID] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                             <SelectParameters>
                                 <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                             </SelectParameters>
                         </asp:SqlDataSource>
                     </dx:LayoutItemNestedControlContainer>
                 </LayoutItemNestedControlCollection>
             </dx:LayoutItem>
         </Items>
    </dx:ASPxFormLayout>
     <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1000px"
         Height="550px" FooterText="Thông tin tồn kho"
        HeaderText="Thông tin chi tiết tồn kho" ClientInstanceName="popup" EnableHierarchyRecreation="True">
    </dx:ASPxPopupControl>
</asp:Content>
