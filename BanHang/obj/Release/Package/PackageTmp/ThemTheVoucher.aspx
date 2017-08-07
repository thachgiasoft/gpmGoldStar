<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="ThemTheVoucher.aspx.cs" Inherits="BanHang.ThemTheVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxPopupControl ID="PopupControlPhieuChuyenKho" runat="server" PopupElementID="popupArea" CloseAction="None" ShowOnPageLoad="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Nhập thông tin phiếu chuyển kho" ShowCloseButton="False">
        <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%" >
                    <Items>
                        <dx:LayoutGroup Caption="Thông tin thẻ" ColCount="4">
                            <Items>
                                <dx:LayoutItem Caption="Mã Thẻ Voucher" Name="MaVoucher">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                            <dx:ASPxTextBox ID="txtMaTheVoucher" runat="server">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Tên thẻ" Name="TenVoucher">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                            <dx:ASPxTextBox ID="txtTenTheVoucher" runat="server">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Từ ngày" Name="TuNgay">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                            <dx:ASPxDateEdit ID="txtTuNgay" runat="server" DisplayFormatString="dd/MM/yyyy">
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Đến ngày" Name="DenNgay">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                            <dx:ASPxDateEdit ID="txtDenNgay" runat="server" DisplayFormatString="dd/MM/yyyy">
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Số lượng thẻ" Name="SoLuongThe">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                            <dx:ASPxSpinEdit ID="txtSoLuongThe" runat="server">
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Giá trị" Name="GiaTri">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                            <dx:ASPxTextBox ID="txtGiaTri" runat="server">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ColSpan="2" HorizontalAlign="Right" Name="btnTao">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                                            <dx:ASPxButton ID="btnLuu" runat="server" OnClick="btnLuu_Click" Text="Tạo thẻ">
                                                <Image IconID="actions_insert_16x16">
                                                </Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
                

                <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="4" >
                    <Items>
                        <dx:LayoutGroup Caption="Danh sách thẻ được phát" ColCount="2" ColSpan="4">
                            <Items>
                                
                                <dx:LayoutItem Caption="" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer13" runat="server">
                                                
                                                <dx:ASPxGridView ID="gridTempVoucher" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" >
                                                    <SettingsEditing Mode="PopupEditForm">
                                                    </SettingsEditing>
                                                    <Settings ShowFilterRow="True" ShowTitlePanel="True" />

                                                    <SettingsCommandButton>
                                                    <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                                                    <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                                                    </SettingsCommandButton>

                                                    <SettingsPopup>
                                                        <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
                                                    </SettingsPopup>
                                                    <SettingsText Title="DANH SÁCH VOUCHER" />
                                                    <EditFormLayoutProperties ColCount="2">
                                                        <Items>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Mã Voucher" Name="MaVoucher">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Tên Voucher" Name="TenVoucher">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Từ ngày" Name="TuNgay">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Đến ngày" Name="DenNgay">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:GridViewColumnLayoutItem ColumnName="Giá trị" Name="GiaTri">
                                                            </dx:GridViewColumnLayoutItem>
                                                            <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                                                            </dx:EditModeCommandLayoutItem>
                                                        </Items>
                                                    </EditFormLayoutProperties>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Mã Voucher" FieldName="MaVoucher" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Tên Voucher" FieldName="TenVoucher" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Giá trị" FieldName="GiaTri" VisibleIndex="5">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Ngày tạo" FieldName="NgayTao" VisibleIndex="7">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataDateColumn Caption="Từ ngày" FieldName="TuNgay" VisibleIndex="3">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                                            </PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="Đến ngày" FieldName="DenNgay" VisibleIndex="4">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
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
                                                
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                
                                    <dx:LayoutItem Caption="" Name="btnLuuTheVoucher" HorizontalAlign="Right"><LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                                <dx:ASPxButton runat="server" Text="Lưu v&#224; In" ID="btnLuTheVoucher" OnClick="btnLuTheVoucher_Click">
                                                    <Image IconID="print_defaultprinternetwork_16x16">
                                                    </Image>
                                                </dx:ASPxButton>

                                                </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                                <dx:LayoutItem Caption="" Name="btnHuy" HorizontalAlign="Left"><LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                                        <dx:ASPxButton runat="server" Text="Hủy" ID="btnHuy" OnClick="btnHuy_Click">
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
              </dx:PopupControlContentControl>
        </ContentCollection>
        
    </dx:ASPxPopupControl>
</asp:Content>
