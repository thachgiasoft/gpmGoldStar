﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DanhSachPhieuXuatTra.aspx.cs" Inherits="BanHang.DanhSachPhieuXuatTra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
            <%--popup chi tiet don hang--%>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             popup.SetContentUrl("ChiTietPhieuXuatTra.aspx?IDPhieuXuatTra=" + key);
             popup.ShowAtElement();
             // alert(key);
         }

    </script>
    <dx:ASPxButton ID="btnThemPhieuXuatKhac" runat="server" Text="Thêm phiếu xuất trả" HorizontalAlign="Right" VerticalAlign="Middle" PostBackUrl="PhieuXuatTra.aspx">
        <Image IconID="reports_addgroupheader_32x32">
        </Image>
        <Paddings Padding="4px" />
    </dx:ASPxButton>
    <dx:ASPxGridView ID="gridPhieuXuatTra" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID">
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
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" Title="DANH SÁCH PHIẾU XUẤT TRẢ" ConfirmDelete="Bạn chắc chắn muốn xóa?"/>
        <Columns>
            <dx:GridViewDataTextColumn Caption="Ghi Chú" VisibleIndex="4" FieldName="GhiChu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Nhà Cung Cấp" VisibleIndex="1" FieldName="IDNhaCungCap">
                <PropertiesComboBox DataSourceID="sqlNhaCungCap" TextField="TenNhaCungCap" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Lập" VisibleIndex="2" FieldName="NgayLap">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" VisibleIndex="5" FieldName="NgayCapNhat">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="6">
                
                <DataItemTemplate>
                    <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Kho" FieldName="IDKho" VisibleIndex="0">
                <PropertiesComboBox DataSourceID="sqlKhoHang" TextField="TenCuaHang" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tổng Tiền" FieldName="TongTien" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatString="N0">
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

            <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhaCungCap] FROM [GPM_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
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