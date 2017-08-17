<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="ThemKhachHangHuyVe.aspx.cs" Inherits="BanHang.ThemKhachHangHuyVe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thông tin hàng hóa" ColCount="3"  HorizontalAlign="Center">
                <Items>
                    <dx:LayoutItem Caption="Mã số vé">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="cmbMaSoVe" runat="server" ValueType="System.String" 
                                    DropDownWidth="600" DropDownStyle="DropDownList"   AutoPostBack="True"
                                    ValueField="ID"
                                    NullText="Nhập mã hàng.." Width="100%" TextFormatString="{1}"
                                    EnableCallbackMode="true" CallbackPageSize="10" OnSelectedIndexChanged="cmbMaSoVe_SelectedIndexChanged"               
                                    >                                    
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="KyHieu" Width="80px" Caption="Ký hiệu" />
                                        <dx:ListBoxColumn FieldName="SoThuTu" Width="200px" Caption="Số thứ tự"/>
                                        <dx:ListBoxColumn FieldName="GiaVe" Width="200px" Caption="Giá vé"/>
                                    </Columns>
                                    <DropDownButton Visible="False">
                                    </DropDownButton>
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ký hiệu vé">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtKyHieu" runat="server" Width="100%" ReadOnly="True">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Giá vé">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtGiaVe" runat="server" Width="100%" ReadOnly="True">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ghi chú">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtGhiChu" runat="server" Width="100%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnLuu" runat="server" Width="100%" Text="Lưu hủy vé" OnClick="btnLuu_Click">
                                    <Image IconID="save_saveto_16x16">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnHuy" runat="server" Width="100%" Text="Hủy" OnClick="btnHuy_Click">
                                    <Image IconID="actions_cancel_16x16">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <asp:HiddenField ID="IDPhieuKhachHangTraHangTem_Temp" runat="server" />
</asp:Content>
