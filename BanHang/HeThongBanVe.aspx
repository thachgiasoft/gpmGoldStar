<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeThongBanVe.aspx.cs" Inherits="BanHang.HeThongBanVe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HỆ THỐNG BÁN VÉ</title>    
    <style>
        @font-face
        {
            font-family: "digital-7";
            src: url('Fonts/digital-7.ttf');
        }        
        .pnl-content
        {
            font-size: 14px;
            padding: 10px;
            text-align: center;
            white-space: normal;
        }            
        .Separator
        {
            height: 10px;
        }            
    </style>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             chitietbuilInLai.SetContentUrl("ChiTietHoaDonDaIn.aspx?IDHoaDon=" + key);
             chitietbuilInLai.ShowAtElement();
         }
    </script>
    <script type="text/javascript">
        function UpdateGridHeight() {
            sampleGrid.SetHeight(0);

            var containerHeight = ASPxClientUtils.GetDocumentClientHeight();
            if (document.body.scrollHeight > containerHeight)
                containerHeight = document.body.scrollHeight;
            //sampleGrid.SetHeight(containerHeight - tabSoHoaDon.GetHeight() - topPanel.GetHeight());
            sampleGrid.SetHeight(topPanel.GetHeight() - tabSoHoaDon.GetHeight() - PanelBarcode.GetHeight() - 10);
            //console.log('containerHeight = ' + containerHeight);
            //console.log('tabSoHoaDon.GetHeight() = ' + tabSoHoaDon.GetHeight());
            //console.log('topPanel.GetHeight() = ' + topPanel.GetHeight());
            //console.log(containerHeight - tabSoHoaDon.GetHeight() - topPanel.GetHeight());
        }

    </script>
</head>
<body>
    <form id="formBanHangLe" runat="server">    
    
    <dx:ASPxPanel ID="topPanel" ClientInstanceName="topPanel" runat="server" Width="65%" FixedPosition="WindowLeft">
        <PanelCollection>
            <dx:PanelContent ID="TopPanelContent" runat="server" SupportsDisabledAttribute="True">
                <dx:ASPxPanel ID="PanelBarcode" ClientInstanceName="PanelBarcode" runat="server" Width="100%" DefaultButton="btnInsertHang">
                <PanelCollection>
                <dx:PanelContent ID="PanelConTentBarcode" runat="server">
                    <div class="pnl-content"> 
                                     
                        <table width="95%">
                            <tr>
                                <td width="80%">
                                     <asp:Button ID="btnInsertHang" runat="server" OnClick="btnInsertHang_Click" Style="display: none"/>                                                                                     
                                    <dx:ASPxComboBox ID="cmbKyHieu" runat="server" ValueType="System.String"  
                                        DropDownWidth="600" DataSourceID="SqlDanhSachKyHieu" 
                                        TextFormatString="{1} - {2}" Width="100%"
                                         ValueField="ID" >
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="MaKyHieu" Width="80px" Caption="Mã Ký Hiệu" />
                                            <dx:ListBoxColumn FieldName="TenKyHieu" Width="200px" Caption="Tên Ký Hiệu"/>
                                            <dx:ListBoxColumn FieldName="GiaVe" Width="100px" Caption="Giá Vé"/>
                                            <dx:ListBoxColumn FieldName="GhiChu" Width="200px" Caption="Ghi Chú" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="SqlDanhSachKyHieu" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_KyHieuGiaVe]"></asp:SqlDataSource>
                                 </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td width="15%">                            
                                    <dx:ASPxSpinEdit ID="txtSoLuong" ClientInstanceName="txtSoLuong" runat="server" Caption="Số lượng" TabIndex="0"
                                        Font-Bold="True" Number="1" Width="100px" NumberType="Integer">                                    
                                    </dx:ASPxSpinEdit>
                                </td> 
                            </tr>
                        </table>          
                    </div>
                </dx:PanelContent>
                </PanelCollection>
                </dx:ASPxPanel>
                <dx:ASPxPanel ID="PanelGridHangHoa" ClientInstanceName="PanelGridHangHoa"  runat="server" Width="96%" DefaultButton="btnUpdateGridHang">
                    <Paddings Padding="0px" />
                    <PanelCollection>
                    <dx:PanelContent ID="PanelContentGridHangHoa" runat="server">
                    <table width="100%">
                        <tr>
                            <td width="40px" align="center">
                                    <dx:ASPxButton ID="btnUpdateGridHang" ClientInstanceName="btnUpdateGridHang" 
                                runat="server" ClientVisible="False" 
                                OnClick="btnUpdateGridHang_Click">                                        
                                </dx:ASPxButton>                             
                                <dx:ASPxButton ID="btnThemHoaDon" runat="server" RenderMode="Link" 
                                    OnClick="btnThemHoaDon_Click" >
                                    <Image IconID="actions_add_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxTabControl ID="tabControlSoHoaDon" runat="server" ClientInstanceName="tabSoHoaDon" 
                                    EnableTabScrolling="True" TabAlign="Justify" Width="100%"                                         
                                        AutoPostBack="True" 
                                    OnActiveTabChanged="tabControlSoHoaDon_ActiveTabChanged">
                                    <ActiveTabStyle Font-Bold="True" ForeColor="Blue">
                                    </ActiveTabStyle>
                                </dx:ASPxTabControl>
                            </td>
                            <td width="40px" align="center">
                                <dx:ASPxButton ID="btnHuyHoaDon" runat="server" OnClick="btnHuyHoaDon_Click" 
                                    RenderMode="Link">
                                    <Image IconID="actions_close_32x32" ToolTip="Xóa hóa đơn đang tính">
                                    </Image>
                                </dx:ASPxButton>
                            </td>     
                        </tr>                            
                    </table>
                    <dx:ASPxGridView runat="server" Width="100%" ID="gridChiTietHoaDon" 
                        ClientInstanceName="sampleGrid" KeyFieldName="STT"
                        AutoGenerateColumns="False"                      
                        EnableCallBacks="False" >
                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" ShowFooter="True" />
                        <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>                        
                        </SettingsCommandButton>
                        <SettingsText EmptyDataRow="Không có hàng đang thanh toán" />
                        <columns>
                            <dx:GridViewDataTextColumn Caption="STT" FieldName="STT" VisibleIndex="0" 
                                AdaptivePriority="1" Name="STT" Width="50px" >                                    
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Ký Hiệu"  FieldName="TenKyHieu" VisibleIndex="2">                                    
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Số lượng" FieldName="SoLuong" VisibleIndex="4" Width="100px">
                            <PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                <DataItemTemplate>
                                    <dx:ASPxSpinEdit ID="txtSoLuongChange" runat="server" Width="100%" 
                                        NumberType="Integer" Value='<%# Eval("SoLuong") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Đơn giá" FieldName="DonGia" 
                                VisibleIndex="5" Width="80px">                                   
                            <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom"></PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataButtonEditColumn Caption="Xóa" ShowInCustomizationForm="True" Width="50px" 
                                VisibleIndex="7">
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="BtnXoaHang" runat="server" CommandName="XoaHang"
                                        CommandArgument='<%# Eval("STT") %>' 
                                        onclick="BtnXoaHang_Click" RenderMode="Link">
                                        <Image IconID="actions_cancel_32x32">
                                        </Image>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataButtonEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="6" Width="120px">
                                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                        </columns>                                                  
                        <settingspager pagesize="50" numericbuttoncount="6" Mode="ShowAllRecords" />
                        <TotalSummary>
                            <dx:ASPxSummaryItem DisplayFormat="Tổng tiền: {0:N0}" FieldName="ThanhTien" ShowInColumn="Thành tiền" SummaryType="Sum" />
                            <dx:ASPxSummaryItem DisplayFormat="{0} hàng hóa" FieldName="MaHang" ShowInColumn="Mã hàng" SummaryType="Count" />
                            <dx:ASPxSummaryItem DisplayFormat="Tổng số lượng: {0}" FieldName="SoLuong" ShowInColumn="SoLuong" SummaryType="Sum" />
                        </TotalSummary>      
                        <Styles>
                            <Header Font-Bold="True" HorizontalAlign="Center">
                            </Header>
                            <AlternatingRow Enabled="True">
                            </AlternatingRow>
                            <Footer Font-Bold="True" ForeColor="#0000CC" HorizontalAlign="Right">
                            </Footer>
                        </Styles>
                    </dx:ASPxGridView> 
                </dx:PanelContent>
            </PanelCollection>
            </dx:ASPxPanel>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    <dx:ASPxPanel id="RightPanel" runat="server" fixedposition="WindowRight" Width="35%">
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                <div class="pnl-content" style="width: 100%;">
                    <table width="100%">
                        <tr>                            
                            <td align="left" width="50%">                                
                                <dx:ASPxButton ID="btnNhanVien" runat="server" Text="Nhân viên A" 
                                    RenderMode="Link">
                                    <Image IconID="businessobjects_bodetails_32x32">
                                    </Image>
                                </dx:ASPxButton>                                
                            </td>
                            <td align="right" width="50%">
                                
                            </td>
                        </tr>
                    </table>
                    <div class="Separator">                
                    </div>
                    <table width="100%">                        
                        <tr>
                            <td width="85%">
                                <dx:ASPxComboBox ID="cmbKhachHang" runat="server" ValueType="System.String" 
                                        DropDownWidth="700" DropDownStyle="DropDown" 
                                        ValueField="ID"
                                        NullText="Tìm kiếm khách hàng ......." Width="100%" TextFormatString="{0} - {1} - {4}"
                                        EnableCallbackMode="true" CallbackPageSize="10" 
                                        OnItemsRequestedByFilterCondition="cmbKhachHang_ItemsRequestedByFilterCondition"
                                        OnItemRequestedByValue="cmbKhachHang_ItemRequestedByValue" AutoPostBack="True" OnSelectedIndexChanged="cmbKhachHang_SelectedIndexChanged" 
                                        
                                        >                                    
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="MaKhachHang" Width="100px" Caption="Mã Khách Hàng" />
                                            <dx:ListBoxColumn FieldName="TenKhachHang" Width="200px" Caption="Tên Khách Hàng"/>
                                            <dx:ListBoxColumn FieldName="CMND" Width="120px" Caption="CMND"/>
                                            <dx:ListBoxColumn FieldName="DienThoai" Width="120px" Caption="Điện thoại" />
                                            <dx:ListBoxColumn FieldName="DiemTichLuy" Width="120px" Caption="Điểm Tích Lũy" />
                                        </Columns>
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="dsKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" >                                       
                                    </asp:SqlDataSource>
                            </td>
                            <td width="15%" align="right">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" RenderMode="Link" OnClick="ASPxButton1_Click">
                                    <Image IconID="actions_newemployee_32x32devav" ToolTip="Thêm khách hàng">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    <div class="Separator">                
                    </div>
                    <div id="divTabThanhToan">                    
                    <dx:ASPxPageControl ID="pageControlThanhToan" runat="server" Width="100%" 
                        ActiveTabIndex="1">
                        <TabPages>
                            <dx:TabPage Text="Hóa đơn">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl1" runat="server">                                        
                                        <dx:ASPxFormLayout ID="formLayoutThanhToan" runat="server" Width="100%" 
                                            ClientInstanceName="formLayoutThanhToan">
                                            <Items>
                                                <dx:LayoutItem Caption="Số lượng hàng" FieldName="SoLuongHang" Visible="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                                            <dx:ASPxTextBox ID="txtSoLuongHang" runat="server" ReadOnly="True" 
                                                            Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="TỔNG TIỀN" FieldName="TongTien" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                                            <dx:ASPxTextBox ID="txtTongTien" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0" Width="100%">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                             
                                                <dx:LayoutItem Caption="ĐIỂM TÍCH LŨY" FieldName="DiemTichLuy" 
                                                    VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer11" runat="server">
                                                            <dx:ASPxTextBox ID="txtDiemTichLuy" runat="server"   NullText="0"
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0" 
                                                                ForeColor="Red" AutoPostBack="True" OnTextChanged="txtDiemTichLuy_TextChanged">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="GIẢM GIÁ" FieldName="GiamGia" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                                            <dx:ASPxTextBox ID="txtGiamGia" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0" Width="100%">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="KHÁCH CẦN TRẢ" FieldName="KhachCanTra" 
                                                    VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                                            <dx:ASPxTextBox ID="txtKhachCanTra" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0" 
                                                                ForeColor="Red">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="KHÁCH THANH TOÁN" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                                            <dx:ASPxTextBox ID="txtKhachThanhToan" runat="server" NullText="0"
                                                                OnTextChanged="txtKhachThanhToan_TextChanged" AutoPostBack="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="TIỀN THỒI" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                                            <dx:ASPxTextBox ID="txtTienThua" runat="server" NullText="0" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="35pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0" 
                                                                ForeColor="#0000CC">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                            </Items>
                                            <Paddings Padding="0px" />
                                        </dx:ASPxFormLayout>  
                                        <dx:ASPxButton ID="btnThanhToan" runat="server" Text="THANH TOÁN" 
                                            EnableTheming="False" Font-Bold="True" Font-Names="Courier New" 
                                            Font-Size="25pt" Height="50px" BackColor="#33CCFF" Native="True" 
                                            OnClick="btnThanhToan_Click">                                    
                                        </dx:ASPxButton>                                      
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                        <ContentStyle>
                            <Paddings Padding="2px" />
                        </ContentStyle>
                    </dx:ASPxPageControl>
                    </div>
                    <div class="Separator">                
                    </div>                 
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>       
    
    
    <script type="text/javascript">
        // <![CDATA[
        ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function (s, e) {
            UpdateGridHeight();
        });
        ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (s, e) {
            UpdateGridHeight();
        });
        // ]]> 
    </script>   
    
    
    <dx:ASPxPopupControl ID="popupThemKhachHang" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="600px"
         Height="300px"
        HeaderText="Thêm khách hàng" ClientInstanceName="popupThemKhachHang" CloseAction="CloseButton">
         <ContentCollection>
    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2" Width="100%">
        <Items>
            <dx:LayoutItem Caption="Nhóm Khách Hàng" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                        <dx:ASPxComboBox ID="cmbNhomKhachHang" runat="server" DataSourceID="sqkNhomKhachHang" TextField="TenNhomKhachHang" ValueField="ID" Width="100%">
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="sqkNhomKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhomKhachHang] FROM [GPM_NhomKhachHang]">
                           
                        </asp:SqlDataSource>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Tên Khách Hàng" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                        <dx:ASPxTextBox ID="txtTenKhachHang" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Số Điện Thoại" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                        <dx:ASPxTextBox ID="txtSoDienThoai" runat="server" Width =" 100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Địa Chỉ" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                        <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Right">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                        <dx:ASPxButton ID="btnThemKhachHang" runat="server" OnClick="btnThemKhachHang_Click">
                            <Image IconID="save_saveto_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer17" runat="server">
                        <dx:ASPxButton ID="btnHuyKhachHang" runat="server" OnClick="btnHuyKhachHang_Click">
                            <Image IconID="save_saveandclose_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
  </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
        <dx:ASPxPopupControl ID="chitietbuilInLai" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" ClientInstanceName="chitietbuilInLai" PopupVerticalAlign="WindowCenter"  Width="1000px" Height="600px" HeaderText="Chi tiết hóa đơn">
        </dx:ASPxPopupControl>

        <iframe name="PrintingFrame" style="display: block; width:0px; height:0px;"></iframe>
    </form>    
    </body>
</html>
