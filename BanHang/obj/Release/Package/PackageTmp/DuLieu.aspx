<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DuLieu.aspx.cs" Inherits="BanHang.XoaDuLieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   
   
    
   
   
    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" Height="350px"
        TabAlign="Justify" ActiveTabIndex="1" EnableTabScrolling="true">
        <TabStyle Paddings-PaddingLeft="50px" Paddings-PaddingRight="50px">
<Paddings PaddingLeft="50px" PaddingRight="50px"></Paddings>
        </TabStyle>
        <ContentStyle>
            <Paddings PaddingLeft="40px"/>
        </ContentStyle>
        <TabPages>
            <dx:TabPage Text="Xóa dữ liệu rác">
<TabImage IconID="data_deletedatasource_16x16office2013"></TabImage>
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl1" runat="server">
                        <div align="center" style="margin-top:4%">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hệ Thống Website Bán Hàng" Font-Size="XX-Large" margin-top="100px"></dx:ASPxLabel>
                            <div align="center"  style="margin:5%">
                                <dx:ASPxButton ID="btnXoa" runat="server" Text="Xóa dữ liệu" OnClick="btnXoa_Click">
                                </dx:ASPxButton>
                                <div style="margin-top:1%">
                                <dx:ASPxLabel ID="lblThongBao" runat="server" Text=""></dx:ASPxLabel>
                                </div>
                            </div
                           <div align="center" >
  
                             <dx:ASPxProgressBar ID="ProgressBar" runat="server" Position="0" Width="80%" >
                            </dx:ASPxProgressBar>
                        </div
    
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Sao Lưu Dữ Liệu">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl4" runat="server">
                       <div align="center" style="margin-top:4%">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Hệ Thống Website Bán Hàng" Font-Size="XX-Large" margin-top="100px"></dx:ASPxLabel>
                            <div align="center"  style="margin:5%">
                                <dx:ASPxButton ID="btnSaoLuuDuLieu" runat="server" Text="Sao Lưu Dữ Liệu" OnClick="btnSaoLuuDuLieu_Click" >
                                </dx:ASPxButton>
                                <div style="margin-top:1%">
                                <dx:ASPxLabel ID="lblThongBaoSaoLuu" runat="server" Text=""></dx:ASPxLabel>
                                </div>
                            </div
                           <div align="center" >
  
                        </div
    
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Khôi Phục Dữ Liệu">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl9" runat="server">
                        <div align="center" style="margin-top:4%">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Hệ Thống Website Bán Hàng" Font-Size="XX-Large" margin-top="100px"></dx:ASPxLabel>
                            <div align="center"  style="margin:5%">

                                <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2">

                                    <Items>
                                        <dx:LayoutItem Caption="Chọn File">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxUploadControl ID="UploadRestor" runat="server"  Width="280px" AllowedFileExtensions=".bak"></dx:ASPxUploadControl>
                               
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload">
                                                    </dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>

                                </dx:ASPxFormLayout>
                                
                                <div style="margin-top:1%">
                                <dx:ASPxLabel ID="lblThongBaoPhucHoi" runat="server" Text=""></dx:ASPxLabel>
                                </div>
                            </div
                           <div align="center" >
  
                             <dx:ASPxProgressBar ID="ProgressBarPhucHoi" runat="server" Position="0" Width="80%" >
                            </dx:ASPxProgressBar>
                        </div
    
                        </div>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Ngành Hàng">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl6" runat="server">
                        <dx:ASPxButton ID="gridNganhHang_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridNganhHang_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridNganhHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridNganhHang_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Ngành Hàng Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Ngày Hàng" FieldName="TenNganhHang" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNganhHang_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNganhHang_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày Đã Xóa" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="7">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Nhóm Hàng">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl12" runat="server">
                        <dx:ASPxButton ID="gridNhomHang_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridNhomHang_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridNhomHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridNhomHang_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Nhóm Hàng Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Nhóm Hàng" FieldName="TenNhomHang" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhomHang_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhomHang_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày Đã Xóa" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="7">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Mã Hàng">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl11" runat="server">
                        <dx:ASPxButton ID="gridMaHang_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridMaHang_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridMaHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridMaHang_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Mã Hàng Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridMaHang_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridMaHang_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Nhóm Hàng" FieldName="IDNhomHang" ShowInCustomizationForm="True" VisibleIndex="6">
                                    <PropertiesComboBox DataSourceID="sqlNhomHang" TextField="TenNhomHang" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Mã Hàng" FieldName="TenMaHang" ShowInCustomizationForm="True" VisibleIndex="7">
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
                        <asp:SqlDataSource ID="sqlNhomHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhomHang] FROM [GPM_NhomHang] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Hàng Hóa">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl2" runat="server">
                        <%--<dx:ASPxButton ID="gridHangHoa_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridHangHoa_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>--%>
                        <dx:ASPxGridView ID="gridHangHoa" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridHangHoa_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
             
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Hàng Hóa Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Hàng" FieldName="TenHangHoa" ShowInCustomizationForm="True" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Nhà Cung Cấp" FieldName="IDNhaCungCap" ShowInCustomizationForm="True" VisibleIndex="2">
                                    <PropertiesComboBox DataSourceID="sqlNhaCungCap" TextField="TenNhaCungCap" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Mã Hàng" FieldName="IDMaHang" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesComboBox DataSourceID="sqlMaHang" TextField="TenMaHang" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Đơn Vị Tính" FieldName="IDDonViTinh" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataSpinEditColumn Caption="Giá Bán" FieldName="GiaBan1" ShowInCustomizationForm="True" VisibleIndex="6">
                                    <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                    </PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
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
                        <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlMaHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenMaHang] FROM [GPM_MaHang] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhaCungCap] FROM [GPM_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
             <%--<dx:TabPage Text="Danh Mục Combo">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl9" runat="server">
                        <dx:ASPxButton ID="gridDanhMucCombo_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridDanhMucCombo_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridDanhMucCombo" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridDanhMucCombo_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Danh Mục Combo Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridDanhMucCombo_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridDanhMucCombo_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày Đã Xóa" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Nhà Cung Cấp" FieldName="IDNhaCungCap" ShowInCustomizationForm="True" VisibleIndex="6">
                                    <PropertiesComboBox DataSourceID="sqlNCC" TextField="TenNhaCungCap" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="sqlDVT" TextField="TenDonViTinh" ValueField="ID">
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
                        <asp:SqlDataSource ID="sqlNCC" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhaCungCap] FROM [GPM_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sqlDVT" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh]"></asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>--%>
            <dx:TabPage Text="Đơn Vị Tính">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl3" runat="server">
                        <dx:ASPxButton ID="grid_DonViTinh_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="grid_DonViTinh_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="grid_DonViTinh" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="grid_DonViTinh_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
             
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Đơn Vị Tính Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="grid_DonViTinh_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="grid_DonViTinh_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Đơn Vị" FieldName="TenDonViTinh" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mô Tả" FieldName="MoTa" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Hệ Số" FieldName="HeSo" ShowInCustomizationForm="True" VisibleIndex="3">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            
            <dx:TabPage Text="Khách Hàng">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl5" runat="server">
                        <dx:ASPxButton ID="gridKhachHang_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridKhachHang_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridKhachHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridKhachHang_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
             
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Khách Hàng Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="7" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridKhachHang_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridKhachHang_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Khách Hàng" FieldName="TenKhachHang" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="CMND" FieldName="CMND" ShowInCustomizationForm="True" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Địa Chỉ" FieldName="DiaChi" ShowInCustomizationForm="True" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Điện Thoại" FieldName="DienThoai" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="Nhóm Khách Hàng" FieldName="IDNhomKhachHang" ShowInCustomizationForm="True" VisibleIndex="1">
                                    <PropertiesComboBox DataSourceID="sqlNhomKhachHang" TextField="TenNhomKhachHang" ValueField="ID">
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataDateColumn Caption="Ngày Sinh" FieldName="NgaySinh" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesDateEdit DisplayFormatString="">
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
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
                        <asp:SqlDataSource ID="sqlNhomKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhomKhachHang] FROM [GPM_NhomKhachHang] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            
            <dx:TabPage Text="Nhà Cung Cấp">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl7" runat="server">
                        <dx:ASPxButton ID="gridNhaCungCap_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridNhaCungCap_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridNhaCungCap" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridNhaCungCap_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Nhà Cung Cấp Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Nhà Cung Cấp" FieldName="TenNhaCungCap" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="9" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhaCungCap_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhaCungCap_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày Đã Xóa" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Điện Thoại" FieldName="DienThoai" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Địa Chỉ" FieldName="DiaChi" ShowInCustomizationForm="True" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Người Liên Hệ" FieldName="NguoiLienHe" ShowInCustomizationForm="True" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Lĩnh Vực Kinh Doanh" FieldName="LinhVucKinhDoanh" ShowInCustomizationForm="True" VisibleIndex="6">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Nhân Viên Thu Ngân">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl8" runat="server">
                        <dx:ASPxButton ID="gridNhanVienThuNgan_btnXoaTatCa" runat="server" Text="Xóa tất cả" OnClick="gridNhanVienThuNgan_btnXoaTatCa_Click">
                            <Image IconID="actions_cancel_16x16">
                            </Image>
                        </dx:ASPxButton>
                        <dx:ASPxGridView ID="gridNhanVienThuNgan" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnCustomButtonCallback="gridNhanVienThuNgan_CustomButtonCallback" >
                            <Settings ShowTitlePanel="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

                            <SettingsText ConfirmDelete="Chú ý. Dữ liệu sẽ xóa vĩnh viễn khỏi hệ thống" Title="Danh Sách Nhân Viên Thu Ngân Đã Xóa Trước Đó" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Nhân Viên" FieldName="TenNhanVien" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn  VisibleIndex="8" ButtonRenderMode="Image" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhanVienThuNgan_KhoiPhuc">
                                            <Image IconID="scheduling_recurrence_16x16" ToolTip="Khôi phục">
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                        <dx:GridViewCommandColumnCustomButton ID="gridNhanVienThuNgan_Xoa" >
                                             <Image IconID="actions_close_16x16" ToolTip="Xóa" >
                                    </Image>
                                         
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày Đã Xóa" FieldName="NgayCapNhat" ShowInCustomizationForm="True" VisibleIndex="7">
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
           
            
        </TabPages>
    </dx:ASPxPageControl>
   
</asp:Content>
