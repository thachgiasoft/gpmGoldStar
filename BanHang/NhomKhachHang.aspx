<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="NhomKhachHang.aspx.cs" Inherits="BanHang.NhomKhachHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ID="gridNhomKhachHang" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID" OnRowDeleting="gridNhomKhachHang_RowDeleting" OnRowInserting="gridNhomKhachHang_RowInserting" OnRowUpdating="gridNhomKhachHang_RowUpdating">
        <SettingsPager Mode="ShowAllRecords" Visible="False">
        </SettingsPager>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" ShowTitlePanel="True" />
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
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?. Thao tác này có thể dẫn đễn việc xóa các Khách Hàng của nhóm!." PopupEditFormCaption="Thông tin nhóm khách hàng" Title="DANH SÁCH NHÓM KHÁCH HÀNG HÀNG" />
        <SettingsSearchPanel Visible="True" />
        <EditFormLayoutProperties>
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Tên Nhóm KH" Name="TenNhomKhachHang">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Ghi Chú" Name="GhiChu">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="5" Name="iconaction">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn VisibleIndex="0" Caption="ID" FieldName="ID">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Tên Nhóm KH" FieldName="TenNhomKhachHang">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField ErrorText="Không được bỏ trống" IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="4">
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
</asp:Content>
