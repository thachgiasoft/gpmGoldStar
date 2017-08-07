﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="PhieuChuyenKho.aspx.cs" Inherits="BanHang.PhieuChuyenKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3" Width="100%">
                        <Items>
                            <dx:LayoutGroup Caption="Thông tin phiếu chuyển kho" ColCount="3" ColSpan="3" RowSpan="3">
                                <Items>
                                    <dx:LayoutItem Caption="Kho Xuất">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                                <dx:ASPxComboBox ID="cmbKhoXuat" runat="server" DataSourceID="sqlKho" TextField="TenCuaHang" ValueField="ID">
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlKho" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenCuaHang] FROM [GPM_ThongTinCuaHangKho] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Kho Nhập">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                                <dx:ASPxComboBox ID="cmbKhoNhap" runat="server" DataSourceID="sqlKho" TextField="TenCuaHang" ValueField="ID" >
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Ngày Lập Phiếu">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                                <dx:ASPxDateEdit ID="cmbNgayLapPhieu" runat="server" DateOnError="Today" DisplayFormatString="dd/MM/yyyy" OnInit="cmbNgayLapPhieu_Init">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Ghi Chú" ColSpan="2" RowSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                                <dx:ASPxTextBox ID="txtGhiChu" runat="server" Width="100%">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Trạng Thái">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                                Phiếu tạm
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                            <dx:LayoutGroup Caption="Thông tin hàng hóa" ColCount="3" ColSpan="3" RowSpan="3">
                                <Items>
                                    <dx:LayoutItem Caption="Hàng Hóa">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                                <dx:ASPxComboBox ID="cmbHangHoa" runat="server" DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="cmbHangHoa_SelectedIndexChanged" DropDownWidth="350px" DropDownStyle="DropDownList" TextFormatString="{1}" EnableCallbackMode="true">
                                                    <Columns>
                                                        <dx:ListBoxColumn Caption="Mã" FieldName="ID" Width="50px" />
                                                        <dx:ListBoxColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" Width="100%" />
                                                        <%--<dx:ListBoxColumn Caption="Giá Bán" FieldName="GiaMua" Width="100px" />      --%>         
                                                    </Columns>
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Số Lượng">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                                <dx:ASPxSpinEdit ID="txtSoLuong" runat="server" AutoPostBack="True" OnNumberChanged="txtSoLuong_NumberChanged">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="ĐVT">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                                                <dx:ASPxComboBox ID="cmbDonViTinh" runat="server" DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID" Enabled="False">
                                                </dx:ASPxComboBox>
                                                <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Đơn Giá">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                                                <dx:ASPxTextBox ID="txtDonGia" runat="server" DisplayFormatString="N0">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Thành Tiền">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer12" runat="server">
                                                <dx:ASPxSpinEdit ID="txtThanhTien" runat="server" ReadOnly="true" Enabled="False" DisplayFormatString="N0">
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" HorizontalAlign="Right">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer13" runat="server">
                                                <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click">
                                                    <Image IconID="chart_addchartpane_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                            <dx:LayoutGroup ColSpan="3" Caption="Danh sách hàng hóa" ColCount="3">
                                <Items>
                                    <dx:LayoutItem Caption="" ColSpan="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer14" runat="server">
                                                
                                                <dx:ASPxGridView ID="gridDanhSachHangHoa_Temp" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowDeleting="gridDanhSachHangHoa_Temp_RowDeleting" Width="100%">
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
                                                        <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" ShowInCustomizationForm="True" VisibleIndex="3">
                                                            <PropertiesSpinEdit DisplayFormatString="N0" >
                                                            </PropertiesSpinEdit>
                                                        </dx:GridViewDataSpinEditColumn>
                                                        <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="4">
                                                            <PropertiesSpinEdit DisplayFormatString="N0">
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
                                    <dx:LayoutItem Caption="" HorizontalAlign="Right" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer15" runat="server">
                                                <dx:ASPxButton ID="btnThemPhieuXuat" runat="server" Text="Thêm phiếu chuyển" OnClick="btnThemPhieuXuat_Click">
                                                    <Image IconID="save_saveto_32x32">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                                                <dx:ASPxButton ID="btnHuyPhieuXuat" runat="server" Text="Hủy phiếu chuyển" OnClick="btnHuyPhieuXuat_Click">
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
    <asp:HiddenField ID="IDPhieuChuyenKho" runat="server" />
    </asp:Content>
