<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhanQuyen.aspx.cs" Inherits="BanHang.PhanQuyen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxGridView ID="gridPhanQuyen" runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="ID" OnRowUpdating="gridPhanQuyen_RowUpdating">
            <SettingsPager Mode="ShowAllRecords">
            </SettingsPager>
            <SettingsEditing Mode="Batch">
            </SettingsEditing>
            <Settings ShowTitlePanel="True" />
<SettingsCommandButton>
<ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

<HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
</SettingsCommandButton>

            <SettingsText CommandBatchEditCancel="Hủy thao tác" CommandBatchEditUpdate="Lưu tất cả" Title="DANH SÁCH QUYỀN " />
            <Columns>
                <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Danh Mục" FieldName="TenDanhMuc" VisibleIndex="1" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn Caption="Trạng Thái" FieldName="TrangThai" VisibleIndex="2">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Chức Năng" FieldName="ChucNang" VisibleIndex="3">
                </dx:GridViewDataCheckColumn>
            </Columns>
            <Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
        </dx:ASPxGridView>
    
    </div>
    </form>
</body>
</html>
