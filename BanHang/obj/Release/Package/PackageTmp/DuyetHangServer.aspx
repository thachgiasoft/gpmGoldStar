<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DuyetHangServer.aspx.cs" Inherits="BanHang.DuyetHangServer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
       <%--Chi tiết đơn đặt hàng--%>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             popup.SetContentUrl("ChiTietDonDatHang.aspx?IDDonDatHang=" + key);
             popup.ShowAtElement();
             // alert(key);
         }
    </script>
    <dx:ASPxGridView ID="gridDanhSachDonHangChoDuyet" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnRowDeleting="gridDanhSachDonHangChoDuyet_RowDeleting" OnCustomButtonCallback="gridDanhSachDonHangChoDuyet_CustomButtonCallback">
        <Settings ShowFilterRow="True" />
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings AutoFilterCondition="Contains" ShowFilterRow="True" ShowTitlePanel="True" />
        <SettingsBehavior ConfirmDelete="True" />
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
                <Image IconID="save_save_32x32office2013">
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
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>
         <SettingsSearchPanel Visible="True" />
         <SettingsText CommandDelete="Xóa" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" Title="DANH SÁCH ĐƠN HÀNG CHỜ DUYỆT" />
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="7" ButtonRenderMode="Image" ButtonType="Image">
                 <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="DuyetDonHang">
                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Duyệt Đơn Hàng">
                            </Image>              
                        </dx:GridViewCommandColumnCustomButton>
                       
                    </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Lập Phiếu" FieldName="NgayLap" VisibleIndex="1">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Ghi Chú" FieldName="GhiChu">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tổng Tiền" FieldName="TongTien" VisibleIndex="2">
                <PropertiesSpinEdit DisplayFormatString="N0">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="6">
                
                <DataItemTemplate>
                    <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Chi Nhánh" FieldName="IDKho" VisibleIndex="0">
                <PropertiesComboBox DataSourceID="sqlKho" TextField="TenCuaHang" ValueField="ID">
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
       <asp:SqlDataSource ID="sqlKho" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenCuaHang] FROM [GPM_ThongTinCuaHangKho] WHERE ([DaXoa] = @DaXoa)">
           <SelectParameters>
               <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
           </SelectParameters>
       </asp:SqlDataSource>
    <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1100px"
         Height="600px" FooterText="Thông tin chi tiết đơn đặt hàng"
        HeaderText="Thông tin chi tiết đơn đặt hàng" ClientInstanceName="popup" EnableHierarchyRecreation="True" Modal="True">
    </dx:ASPxPopupControl>
    </asp:Content>
