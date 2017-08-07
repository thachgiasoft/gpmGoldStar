<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="NganhHang.aspx.cs" Inherits="BanHang.NganhHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<dx:ASPxGridView ID="gridNganhHang" runat="server" 
    AutoGenerateColumns="False" KeyFieldName="ID" 
    Width="100%" onrowdeleting="gridNganhHang_RowDeleting" 
        onrowupdating="gridNganhHang_RowUpdating" style="margin-right: 0px" OnRowInserting="gridNganhHang_RowInserting">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings AutoFilterCondition="Contains" ShowFilterRow="True" 
            ShowTitlePanel="True" />
        <SettingsBehavior ConfirmDelete="True" />
<SettingsCommandButton>
<ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

<HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
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
        <SettingsSearchPanel Visible="True" />
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" 
            Title="DANH SÁCH NGÀNH HÀNG" ConfirmDelete="Bạn có chắc chắn muốn xóa không?. Lưu ý thao tác này có thể xóa các Nhóm Hàng, Mã Hàng và Hàng Hóa thuộc ngành hàng!." PopupEditFormCaption="Thông tin ngành hàng" />
        <EditFormLayoutProperties>
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Mã Ngành" Name="MaNganh">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Tên Ngành" Name="TenNganhHang">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Ghi Chú" Name="GhiChu">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" 
                VisibleIndex="10" ShowNewButtonInHeader="True" Name="iconaction">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" FieldName="NgayCapNhat" VisibleIndex="9">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Tên Ngành" FieldName="TenNganhHang" VisibleIndex="2">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="Mã Ngành" FieldName="MaNganh" VisibleIndex="1">
                <PropertiesSpinEdit DisplayFormatString="g">
                    <ValidationSettings>
                        <RequiredField ErrorText="Không được bỏ trống" IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
                <Settings AutoFilterCondition="Contains" />
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
</asp:Content>
