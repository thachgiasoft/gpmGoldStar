<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DonDoiHang.aspx.cs" Inherits="BanHang.DonDoiHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
         <%--popup chi tiet don hang--%>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             popup.SetContentUrl("ChiTietDonDoiHang.aspx?IDDonDoiHang=" + key);
             popup.ShowAtElement();
             // alert(key);
         }

    </script>
    <dx:ASPxButton ID="btnThemPhieuDoiHang" runat="server" Text="Thêm phiếu đổi hàng" HorizontalAlign="Right" VerticalAlign="Middle" PostBackUrl="PhieuDoiHang.aspx">
        <Image IconID="reports_addgroupheader_32x32">
        </Image>
        <Paddings Padding="4px" />
    </dx:ASPxButton>
    <dx:ASPxGridView ID="gridPhieuDoiHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID">
        <SettingsPager Mode="ShowAllRecords">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowTitlePanel="True" />


        <SettingsBehavior ConfirmDelete="True" />
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image">
            </ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image">
            </HideAdaptiveDetailButton>
            <DeleteButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_cancel_16x16" ToolTip="Xóa đơn hàng">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>
        <SettingsSearchPanel Visible="True" />
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" Title="DANH SÁCH PHIẾU ĐỔI HÀNG" ConfirmDelete="Bạn chắc chắn muốn xóa?"/>
        <Columns>
            <dx:GridViewDataTextColumn Caption="Lý Do Đổi" VisibleIndex="6" FieldName="LyDoDoi">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Số Hóa Đơn" VisibleIndex="1" FieldName="IDHoaDon">
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Đổi" VisibleIndex="4" FieldName="NgayDoi">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" VisibleIndex="7" FieldName="NgayCapNhat">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="8">
                
                <DataItemTemplate>
                    <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Kho" FieldName="IDKho" VisibleIndex="0">
                <PropertiesComboBox DataSourceID="sqlKhoHang" TextField="TenCuaHang" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số Tiền Trả" FieldName="SoTienTra" VisibleIndex="5">
                <PropertiesSpinEdit DisplayFormatString="N0">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Nhân Viên Thu Ngân" FieldName="IDNhanVienThuNgan" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="sqlNhanVienThuNgan" TextField="TenNhanVien" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Khách Hàng" FieldName="IDKhachHang" VisibleIndex="3">
                <PropertiesComboBox DataSourceID="sqlKhachHang" TextField="TenKhachHang" ValueField="ID">
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

            <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_NhaCungCap]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="sqlKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenKhachHang] FROM [GPM_KhachHang] WHERE ([DaXoa] = @DaXoa)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                </SelectParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="sqlNhanVienThuNgan" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhanVien] FROM [GPM_NhanVienThuNgan] WHERE ([DaXoa] = @DaXoa)">
             <SelectParameters>
                 <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlKhoHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_ThongTinCuaHangKho] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%--popup chi tiet don hang--%>
     <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1100px"
         Height="600px" FooterText="Thông tin chi tiết đơn đặt hàng"
        HeaderText="Thông tin chi tiết phiếu xuất khác" ClientInstanceName="popup" EnableHierarchyRecreation="True" CloseAction="CloseButton">
    </dx:ASPxPopupControl>
</asp:Content>
