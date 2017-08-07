<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportExcel_NhaCungCap.aspx.cs" Inherits="BanHang.ImportExcel_NhaCungCap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
            <Items>
                <dx:LayoutGroup Caption="Nhập file Excel" ColCount="8">
                    <Items>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                    <dx:ASPxUploadControl ID="UploadFileExcel" runat="server" AllowedFileExtensions=".xls" >
                                    </dx:ASPxUploadControl>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                    <dx:ASPxButton ID="btnNhap" runat="server" OnClick="btnNhap_Click" Text="Upload">
                                        <Image IconID="miscellaneous_publish_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                    <dx:ASPxButton ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Lưu tất cả dữ liệu">
                                        <Image IconID="save_saveto_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                    <dx:ASPxButton ID="btnHuy" runat="server" OnClick="btnHuy_Click" Text="Hủy">
                                        <Image IconID="actions_cancel_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Thông tin dữ liệu nhập vào">
                      <Items>
                                
                                <dx:LayoutItem Caption="" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer13" runat="server">
                                                
                                                <dx:ASPxGridView ID="gridNhaCungCap_Temp" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridNhaCungCap_Temp_RowDeleting">
                                                    <SettingsEditing Mode="PopupEditForm">
                                                    </SettingsEditing>
                                                    <Settings ShowTitlePanel="True" />
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
                                                            <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
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
                                                            <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                                                            </Image>
                                                        </DeleteButton>
                                                    </SettingsCommandButton>
                                                    <SettingsPopup>
                                                        <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
                                                    </SettingsPopup>
                         
                                                    <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin mã hàng" Title="DANH SÁCH NHÀ CUNG CẤP" />
                                                    <EditFormLayoutProperties>
                                                        <Items>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Mã Hàng" Name="MaHang" Caption="Mã Hàng">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Tên Mã Hàng" Name="TenMaHang">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Nhóm Hàng" Name="IDNhomHang">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Đơn Vị Tính" Name="IDDonViTinh">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                                                            </dx:EditModeCommandLayoutItem>
                                                        </Items>
                                                    </EditFormLayoutProperties>
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="9">
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Nhà Cung Cấp" FieldName="TenNhaCungCap" VisibleIndex="0">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="Không được bỏ trống" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="Không được bỏ trống" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Điện Thoại" FieldName="DienThoai" VisibleIndex="1">
                                                            <PropertiesTextEdit>
                                                                <ValidationSettings>
                                                                    <RequiredField ErrorText="Không được bỏ trống" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Fax" FieldName="Fax" ShowInCustomizationForm="True" VisibleIndex="2">
                                                            <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Email" FieldName="Email" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Địa Chỉ" FieldName="DiaChi" ShowInCustomizationForm="True" VisibleIndex="4">
                                                        </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="NguoiLienHe" ShowInCustomizationForm="True" Caption="Người Liên Hệ" VisibleIndex="5">
</dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Mã số thuế" FieldName="MaSoThue" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Lĩnh Vực Kinh Doanh" FieldName="LinhVucKinhDoanh" ShowInCustomizationForm="True" VisibleIndex="7">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Ghi chú" FieldName="GhiChu" ShowInCustomizationForm="True" VisibleIndex="8">
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
                                                
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                
                            </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
    </div>
    </form>
</body>
</html>
