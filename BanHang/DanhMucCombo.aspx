<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DanhMucCombo.aspx.cs" Inherits="BanHang.DanhMucCombo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     <%--popup chi tiet don hang--%>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             popup.SetContentUrl("ChiTietHangHoaCombo.aspx?IDHangHoaComBo=" + key);
             popup.ShowAtElement();
             // alert(key);
         }

    </script>
     <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2">
        <Items>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
    <dx:ASPxButton ID="btnThemHangHoaComBo" runat="server" Text="Thêm hàng combo" HorizontalAlign="Right" VerticalAlign="Middle" PostBackUrl="ThemHangHoaCombo.aspx">
        <Image IconID="actions_add_32x32">
                            </Image>
        <Paddings Padding="4px" />
    </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
           
        </Items>
      </dx:ASPxFormLayout> 
    <dx:ASPxGridView ID="gridDanhMucCombo" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDeleting="gridDanhMucCombo_RowDeleting" OnRowUpdating="gridDanhMucCombo_RowUpdating" KeyFieldName="ID">
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
        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" />
        </SettingsPopup>
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin danh mục combo" Title="DANH SÁCH DANH MỤC COMBO" />
          <EditFormLayoutProperties ColCount="2">
              <Items>
                  <dx:GridViewColumnLayoutItem ColumnName="Tên Hàng Hóa" ColSpan="2" Name="TenHangHoa">
                  </dx:GridViewColumnLayoutItem>
                  <dx:GridViewColumnLayoutItem ColumnName="Tổng Tiền" ColSpan="2">
                  </dx:GridViewColumnLayoutItem>
                  <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Trạng Thái">
                  </dx:GridViewColumnLayoutItem>
                  <dx:EditModeCommandLayoutItem HorizontalAlign="Right" ColSpan="2">
                  </dx:EditModeCommandLayoutItem>
              </Items>
          </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" VisibleIndex="10" ShowEditButton="True" Name="iconaction">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" VisibleIndex="1">
                <PropertiesTextEdit>
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="ĐVT" VisibleIndex="3" FieldName="IDDonViTinh">
<PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tổng Tiền" VisibleIndex="4" FieldName="GiaBan1">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom" DisplayFormatInEditMode="True">
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="9">
                
                <DataItemTemplate>
                    <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                </DataItemTemplate>
            </dx:GridViewDataButtonEditColumn>
            <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0" ReadOnly="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Trạng Thái" FieldName="TrangThaiHang" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="SqlTrangThaiHang" TextField="TenTrangThai" ValueField="ID">
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
     <asp:SqlDataSource ID="SqlTrangThaiHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_TrangThaiHang] WHERE ([ID] &gt; @ID)">
         <SelectParameters>
             <asp:Parameter DefaultValue="2" Name="ID" Type="Int32" />
         </SelectParameters>
     </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
     <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1100px"
         Height="600px" FooterText="Thông tin chi tiết hàng hóa combo"
        HeaderText="Thông tin chi tiết hàng hóa combo" ClientInstanceName="popup" EnableHierarchyRecreation="True" CloseAction="CloseButton">
    </dx:ASPxPopupControl>
</asp:Content>
