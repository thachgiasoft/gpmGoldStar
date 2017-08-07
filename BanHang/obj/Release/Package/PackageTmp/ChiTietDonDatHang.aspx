<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietDonDatHang.aspx.cs" Inherits="BanHang.ChiTietDonDatHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

span.dx-vam, span.dx-vat, span.dx-vab, a.dx-vam, a.dx-vat, a.dx-vab 
{ 
    line-height: 100%; 
    padding: 2px 0;
    text-decoration: inherit;
}

.dx-vam, .dx-valm { vertical-align: middle; }
.dx-vam, .dx-vat, .dx-vab { display: inline-block!important; }
.dxpLite_Moderno
{
	font: 14px 'Segoe UI','Helvetica Neue','Droid Sans',Arial,Tahoma,Geneva,Sans-serif;
	color: #2B2B2B;
	padding: 6px 2px;
	float: left;

    box-sizing: border-box;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
}

.dxpDesignMode,
.dxpDesignMode b {
	float: none !important;
}

.dxpDesignMode {
	display: inline;
}

.dxpLite_Moderno .dxp-summary
{
	margin: 0 32px;
}

.dxpLite_Moderno .dxp-summary,
.dxpLite_Moderno .dxp-ellip
{
	color: #979797;
	white-space: nowrap;
	padding: 9px 4px 8px;
}

.dxpLite_Moderno .dxp-summary,
.dxpLite_Moderno .dxp-sep,
.dxpLite_Moderno .dxp-button,
.dxpLite_Moderno .dxp-pageSizeItem,
.dxpLite_Moderno .dxp-num,
.dxpLite_Moderno .dxp-current,
.dxpLite_Moderno .dxp-ellip
{
	margin-left: 4px;
	font-weight: normal;
}
.dxp-summary,
.dxp-sep,
.dxp-button,
.dxp-pageSizeItem,
.dxp-num,
.dxp-current,
.dxp-ellip /*Bootstrap correction*/
{
    -moz-box-sizing: content-box;
    -webkit-box-sizing: content-box;
    box-sizing: content-box;
}
.dxp-summary,
.dxp-sep,
.dxp-button,
.dxp-pageSizeItem,
.dxp-num,
.dxp-current,
.dxp-ellip
{
	display: block;
	float: left;
    line-height: 100%;
}
.dxpLite_Moderno .dxp-disabledButton
{
	text-decoration: none;
	color: #acacac;
}

.dxpLite_Moderno .dxp-button
{
	color: #045cad;
	padding: 8px 14px;
	text-align: center;
	text-decoration: none;
	white-space: nowrap;

	background: #E9E9E9;
	border: 1px solid LightGrey;
	border-radius: 2px;
	-webkit-border-radius: 2px;

	box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.1), inset 0px 1px 0px 0px rgba(255, 255, 255, 0.35);
	-webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.1), inset 0px 1px 0px 0px rgba(255, 255, 255, 0.35);
}
.dxp-current,
.dxp-disabledButton, 
.dxp-disabledButton span
{
    cursor: default;
}
.dxp-button,
.dxp-dropDownButton,
.dxp-num
{
    cursor: pointer;
}
.dxWeb_rpHeaderTopLeftCorner_Moderno,
.dxWeb_rpHeaderTopRightCorner_Moderno,
.dxWeb_rpBottomLeftCorner_Moderno,
.dxWeb_rpBottomRightCorner_Moderno,
.dxWeb_rpTopLeftCorner_Moderno,
.dxWeb_rpTopRightCorner_Moderno,
.dxWeb_rpGroupBoxBottomLeftCorner_Moderno,
.dxWeb_rpGroupBoxBottomRightCorner_Moderno,
.dxWeb_rpGroupBoxTopLeftCorner_Moderno,
.dxWeb_rpGroupBoxTopRightCorner_Moderno,
.dxWeb_mHorizontalPopOut_Moderno,
.dxWeb_mHorizontalPopOutHover_Moderno,
.dxWeb_mVerticalPopOut_Moderno,
.dxWeb_mVerticalPopOutHover_Moderno,
.dxWeb_mVerticalPopOutRtl_Moderno,
.dxWeb_mSubMenuItem_Moderno,
.dxWeb_mSubMenuItemChecked_Moderno,
.dxWeb_mScrollUp_Moderno,
.dxWeb_mScrollUpHover_Moderno,
.dxWeb_mScrollUpDisabled_Moderno,
.dxWeb_mScrollDown_Moderno,
.dxWeb_mScrollDownHover_Moderno,
.dxWeb_mScrollDownDisabled_Moderno,
.dxWeb_tcScrollLeft_Moderno,
.dxWeb_tcScrollRight_Moderno,
.dxWeb_tcScrollLeftHover_Moderno,
.dxWeb_tcScrollRightHover_Moderno,
.dxWeb_tcScrollLeftPressed_Moderno,
.dxWeb_tcScrollRightPressed_Moderno,
.dxWeb_tcScrollLeftDisabled_Moderno,
.dxWeb_tcScrollRightDisabled_Moderno,
.dxWeb_nbCollapse_Moderno,
.dxWeb_nbExpand_Moderno,
.dxWeb_splVSeparator_Moderno,
.dxWeb_splVSeparatorHover_Moderno,
.dxWeb_splHSeparator_Moderno,
.dxWeb_splHSeparatorHover_Moderno,
.dxWeb_splVCollapseBackwardButton_Moderno,
.dxWeb_splVCollapseBackwardButtonHover_Moderno,
.dxWeb_splHCollapseBackwardButton_Moderno,
.dxWeb_splHCollapseBackwardButtonHover_Moderno,
.dxWeb_splVCollapseForwardButton_Moderno,
.dxWeb_splVCollapseForwardButtonHover_Moderno,
.dxWeb_splHCollapseForwardButton_Moderno,
.dxWeb_splHCollapseForwardButtonHover_Moderno,
.dxWeb_pcCloseButton_Moderno,
.dxWeb_pcPinButton_Moderno,
.dxWeb_pcRefreshButton_Moderno,
.dxWeb_pcCollapseButton_Moderno,
.dxWeb_pcMaximizeButton_Moderno,
.dxWeb_pcSizeGrip_Moderno,
.dxWeb_pcSizeGripRtl_Moderno,
.dxWeb_pPopOut_Moderno,
.dxWeb_pPopOutDisabled_Moderno,
.dxWeb_pAll_Moderno,
.dxWeb_pAllDisabled_Moderno,
.dxWeb_pPrev_Moderno,
.dxWeb_pPrevDisabled_Moderno,
.dxWeb_pNext_Moderno,
.dxWeb_pNextDisabled_Moderno,
.dxWeb_pLast_Moderno,
.dxWeb_pLastDisabled_Moderno,
.dxWeb_pFirst_Moderno,
.dxWeb_pFirstDisabled_Moderno,
.dxWeb_tiBackToTop_Moderno,
.dxWeb_smBullet_Moderno,
.dxWeb_tvColBtn_Moderno,
.dxWeb_tvColBtnRtl_Moderno,
.dxWeb_tvExpBtn_Moderno,
.dxWeb_tvExpBtnRtl_Moderno,
.dxWeb_fmFolder_Moderno,
.dxWeb_fmFolderLocked_Moderno,
.dxWeb_fmCreateButton_Moderno,
.dxWeb_fmMoveButton_Moderno,
.dxWeb_fmRenameButton_Moderno,
.dxWeb_fmDeleteButton_Moderno,
.dxWeb_fmRefreshButton_Moderno,
.dxWeb_fmDwnlButton_Moderno,
.dxWeb_fmCreateButtonDisabled_Moderno,
.dxWeb_fmMoveButtonDisabled_Moderno,
.dxWeb_fmRenameButtonDisabled_Moderno,
.dxWeb_fmDeleteButtonDisabled_Moderno,
.dxWeb_fmRefreshButtonDisabled_Moderno,
.dxWeb_fmDwnlButtonDisabled_Moderno,
.dxWeb_ucClearButton_Moderno,
.dxWeb_ucClearButtonDisabled_Moderno,
.dxWeb_isPrevBtnHor_Moderno,
.dxWeb_isNextBtnHor_Moderno,
.dxWeb_isPrevBtnVert_Moderno,
.dxWeb_isNextBtnVert_Moderno,
.dxWeb_isPrevPageBtnHor_Moderno,
.dxWeb_isPrevPageBtnHorOutside_Moderno,
.dxWeb_isNextPageBtnHor_Moderno,
.dxWeb_isNextPageBtnHorOutside_Moderno,
.dxWeb_isPrevPageBtnVert_Moderno,
.dxWeb_isPrevPageBtnVertOutside_Moderno,
.dxWeb_isNextPageBtnVert_Moderno,
.dxWeb_isNextPageBtnVertOutside_Moderno,
.dxWeb_isPrevBtnHorDisabled_Moderno,
.dxWeb_isNextBtnHorDisabled_Moderno,
.dxWeb_isPrevBtnVertDisabled_Moderno,
.dxWeb_isNextBtnVertDisabled_Moderno,
.dxWeb_isPrevPageBtnHorDisabled_Moderno,
.dxWeb_isPrevPageBtnHorOutsideDisabled_Moderno,
.dxWeb_isNextPageBtnHorDisabled_Moderno,
.dxWeb_isNextPageBtnHorOutsideDisabled_Moderno,
.dxWeb_isPrevPageBtnVertDisabled_Moderno,
.dxWeb_isPrevPageBtnVertOutsideDisabled_Moderno,
.dxWeb_isNextPageBtnVertDisabled_Moderno,
.dxWeb_isNextPageBtnVertOutsideDisabled_Moderno,
.dxWeb_isDot_Moderno,
.dxWeb_isDotDisabled_Moderno,
.dxWeb_isDotSelected_Moderno,
.dxWeb_fmGvHeaderFilter_Moderno,
.dxWeb_fmGvHeaderFilterActive_Moderno,
.dxWeb_fmThumbnailCheck_Moderno,
.dxWeb_isPlayBtn_Moderno,
.dxWeb_isPauseBtn_Moderno,
.dxWeb_igCloseButton_Moderno,
.dxWeb_igNextButton_Moderno,
.dxWeb_igPrevButton_Moderno,
.dxWeb_igPlayButton_Moderno,
.dxWeb_igPauseButton_Moderno,
.dxWeb_igNavigationBarMarker_Moderno
{
	display: block;
}
.dxWeb_pPrevDisabled_Moderno
{
    background-position: -235px -381px;
    width: 12px;
    height: 12px;
}
.dxigControl_Moderno.dxTouchUI .dxWeb_igCloseButton_Moderno,
.dxigControl_Moderno.dxTouchUI .dxWeb_igPauseButton_Moderno,
.dxigControl_Moderno.dxTouchUI .dxWeb_igPlayButton_Moderno,
.dxm-hovered .dxWeb_fmCopyButton_Moderno,
.dxm-hovered .dxWeb_fmCreateButton_Moderno,
.dxm-hovered .dxWeb_fmDeleteButton_Moderno,
.dxm-hovered .dxWeb_fmDwnlButton_Moderno,
.dxm-hovered .dxWeb_fmMoveButton_Moderno,
.dxm-hovered .dxWeb_fmRefreshButton_Moderno,
.dxm-hovered .dxWeb_fmRenameButton_Moderno,
.dxm-hovered .dxWeb_fmUplButton_Moderno,
.dxm-hovered .dxWeb_mAdaptiveMenu_Moderno,
.dxm-hovered .dxWeb_mHorizontalPopOut_Moderno,
.dxm-hovered .dxWeb_mSubMenuItemChecked_Moderno,
.dxm-hovered .dxWeb_mVerticalPopOut_Moderno,
.dxm-hovered .dxWeb_mVerticalPopOutRtl_Moderno,
.dxm-scrollBtnHovered .dxWeb_mScrollDown_Moderno,
.dxm-scrollBtnHovered .dxWeb_mScrollUp_Moderno,
.dxpc-closeBtnHover .dxWeb_pcCloseButton_Moderno,
.dxpc-collapseBtnChecked .dxWeb_pcCollapseButton_Moderno,
.dxpc-collapseBtnHover .dxWeb_pcCollapseButton_Moderno,
.dxpc-collapseBtnHover.dxpc-collapseBtnChecked .dxWeb_pcCollapseButton_Moderno,
.dxpc-maximizeBtnChecked .dxWeb_pcMaximizeButton_Moderno,
.dxpc-maximizeBtnHover .dxWeb_pcMaximizeButton_Moderno,
.dxpc-maximizeBtnHover.dxpc-maximizeBtnChecked .dxWeb_pcMaximizeButton_Moderno,
.dxpc-pinBtnChecked .dxWeb_pcPinButton_Moderno,
.dxpc-pinBtnHover .dxWeb_pcPinButton_Moderno,
.dxpc-pinBtnHover.dxpc-pinBtnChecked .dxWeb_pcPinButton_Moderno,
.dxpc-refreshBtnHover .dxWeb_pcRefreshButton_Moderno,
.dxp-hoverDropDownButton .dxWeb_pPopOut_Moderno,
.dxpnl-btnHover .dxWeb_pnlExpand_Moderno,
.dxpnl-btnHover .dxWeb_pnlExpandArrowBottom_Moderno,
.dxpnl-btnHover .dxWeb_pnlExpandArrowLeft_Moderno,
.dxpnl-btnHover .dxWeb_pnlExpandArrowRight_Moderno,
.dxpnl-btnHover .dxWeb_pnlExpandArrowTop_Moderno,
.dxpnl-btnSelected .dxWeb_pnlExpand_Moderno,
.dxpnl-btnSelected .dxWeb_pnlExpandArrowBottom_Moderno,
.dxpnl-btnSelected .dxWeb_pnlExpandArrowLeft_Moderno,
.dxpnl-btnSelected .dxWeb_pnlExpandArrowRight_Moderno,
.dxpnl-btnSelected .dxWeb_pnlExpandArrowTop_Moderno,
.dxpnl-btnSelected.dxpnl-btnHover .dxWeb_pnlExpand_Moderno,
.dxpnl-btnSelected.dxpnl-btnHover .dxWeb_pnlExpandArrowBottom_Moderno,
.dxpnl-btnSelected.dxpnl-btnHover .dxWeb_pnlExpandArrowLeft_Moderno,
.dxpnl-btnSelected.dxpnl-btnHover .dxWeb_pnlExpandArrowRight_Moderno,
.dxpnl-btnSelected.dxpnl-btnHover .dxWeb_pnlExpandArrowTop_Moderno,
.dxp-pressedDropDownButton .dxWeb_pPopOut_Moderno,
.dxr-grExpBtnHover .dxWeb_rPopOut_Moderno,
.dxr-itemHover .dxWeb_rPopOut_Moderno,
.dxrpCollapsed .dxWeb_rpCollapseButton_Moderno,
.dxWeb_edtCheckBoxChecked_Moderno,
.dxWeb_edtCheckBoxCheckedDisabled_Moderno,
.dxWeb_edtCheckBoxGrayed_Moderno,
.dxWeb_edtCheckBoxGrayedDisabled_Moderno,
.dxWeb_edtCheckBoxUnchecked_Moderno,
.dxWeb_edtCheckBoxUncheckedDisabled_Moderno,
.dxWeb_fmBreadCrumbsSeparatorArrow_Moderno,
.dxWeb_fmBreadCrumbsUpButton_Moderno,
.dxWeb_fmBreadCrumbsUpButtonDisabled_Moderno,
.dxWeb_fmBreadCrumbsUpButtonHover_Moderno,
.dxWeb_fmCopyButton_Moderno,
.dxWeb_fmCopyButtonDisabled_Moderno,
.dxWeb_fmCreateButton_Moderno,
.dxWeb_fmCreateButtonDisabled_Moderno,
.dxWeb_fmDeleteButton_Moderno,
.dxWeb_fmDeleteButtonDisabled_Moderno,
.dxWeb_fmDwnlButton_Moderno,
.dxWeb_fmDwnlButtonDisabled_Moderno,
.dxWeb_fmFolder_Moderno,
.dxWeb_fmFolderLocked_Moderno,
.dxWeb_fmMoveButton_Moderno,
.dxWeb_fmMoveButtonDisabled_Moderno,
.dxWeb_fmRefreshButton_Moderno,
.dxWeb_fmRefreshButtonDisabled_Moderno,
.dxWeb_fmRenameButton_Moderno,
.dxWeb_fmRenameButtonDisabled_Moderno,
.dxWeb_fmThumbnailCheck_Moderno,
.dxWeb_fmUplButton_Moderno,
.dxWeb_fmUplButtonDisabled_Moderno,
.dxWeb_igCloseButton_Moderno,
.dxWeb_igNavigationBarMarker_Moderno,
.dxWeb_igNextButton_Moderno,
.dxWeb_igNextButtonDisabled_Moderno,
.dxWeb_igNextButtonHover_Moderno,
.dxWeb_igNextButtonPressed_Moderno,
.dxWeb_igPauseButton_Moderno,
.dxWeb_igPlayButton_Moderno,
.dxWeb_igPrevButton_Moderno,
.dxWeb_igPrevButtonDisabled_Moderno,
.dxWeb_igPrevButtonHover_Moderno,
.dxWeb_igPrevButtonPressed_Moderno,
.dxWeb_isDot_Moderno,
.dxWeb_isDotDisabled_Moderno,
.dxWeb_isDotPressed_Moderno,
.dxWeb_isDotSelected_Moderno,
.dxWeb_isNextBtnHor_Moderno,
.dxWeb_isNextBtnHorDisabled_Moderno,
.dxWeb_isNextBtnVert_Moderno,
.dxWeb_isNextBtnVertDisabled_Moderno,
.dxWeb_isNextPageBtnHor_Moderno,
.dxWeb_isNextPageBtnHorDisabled_Moderno,
.dxWeb_isNextPageBtnHorOutside_Moderno,
.dxWeb_isNextPageBtnHorOutsideDisabled_Moderno,
.dxWeb_isNextPageBtnVert_Moderno,
.dxWeb_isNextPageBtnVertDisabled_Moderno,
.dxWeb_isNextPageBtnVertOutside_Moderno,
.dxWeb_isNextPageBtnVertOutsideDisabled_Moderno,
.dxWeb_isPauseBtn_Moderno,
.dxWeb_isPlayBtn_Moderno,
.dxWeb_isPrevBtnHor_Moderno,
.dxWeb_isPrevBtnHorDisabled_Moderno,
.dxWeb_isPrevBtnVert_Moderno,
.dxWeb_isPrevBtnVertDisabled_Moderno,
.dxWeb_isPrevPageBtnHor_Moderno,
.dxWeb_isPrevPageBtnHorDisabled_Moderno,
.dxWeb_isPrevPageBtnHorOutside_Moderno,
.dxWeb_isPrevPageBtnHorOutsideDisabled_Moderno,
.dxWeb_isPrevPageBtnVert_Moderno,
.dxWeb_isPrevPageBtnVertDisabled_Moderno,
.dxWeb_isPrevPageBtnVertOutside_Moderno,
.dxWeb_isPrevPageBtnVertOutsideDisabled_Moderno,
.dxWeb_izEWCloseButton_Moderno,
.dxWeb_izHint_Moderno,
.dxWeb_mAdaptiveMenu_Moderno,
.dxWeb_mHorizontalPopOut_Moderno,
.dxWeb_mScrollDown_Moderno,
.dxWeb_mScrollUp_Moderno,
.dxWeb_mSubMenuItem_Moderno,
.dxWeb_mSubMenuItemChecked_Moderno,
.dxWeb_mVerticalPopOut_Moderno,
.dxWeb_mVerticalPopOutRtl_Moderno,
.dxWeb_nbCollapse_Moderno,
.dxWeb_nbExpand_Moderno,
.dxWeb_pAll_Moderno,
.dxWeb_pAllDisabled_Moderno,
.dxWeb_pcCloseButton_Moderno,
.dxWeb_pcCollapseButton_Moderno,
.dxWeb_pcMaximizeButton_Moderno,
.dxWeb_pcPinButton_Moderno,
.dxWeb_pcRefreshButton_Moderno,
.dxWeb_pcSizeGrip_Moderno,
.dxWeb_pcSizeGripRtl_Moderno,
.dxWeb_pFirst_Moderno,
.dxWeb_pFirstDisabled_Moderno,
.dxWeb_pLast_Moderno,
.dxWeb_pLastDisabled_Moderno,
.dxWeb_pNext_Moderno,
.dxWeb_pNextDisabled_Moderno,
.dxWeb_pnlExpand_Moderno,
.dxWeb_pnlExpandArrowBottom_Moderno,
.dxWeb_pnlExpandArrowLeft_Moderno,
.dxWeb_pnlExpandArrowRight_Moderno,
.dxWeb_pnlExpandArrowTop_Moderno,
.dxWeb_pPopOut_Moderno,
.dxWeb_pPopOutDisabled_Moderno,
.dxWeb_pPrev_Moderno,
.dxWeb_pPrevDisabled_Moderno,
.dxWeb_rDialogBoxLauncher_Moderno,
.dxWeb_rDialogBoxLauncherDisabled_Moderno,
.dxWeb_rDialogBoxLauncherHover_Moderno,
.dxWeb_rDialogBoxLauncherPressed_Moderno,
.dxWeb_rGlrDown_Moderno,
.dxWeb_rGlrDownDisabled_Moderno,
.dxWeb_rGlrDownHover_Moderno,
.dxWeb_rGlrPopOut_Moderno,
.dxWeb_rGlrPopOutDisabled_Moderno,
.dxWeb_rGlrPopOutHover_Moderno,
.dxWeb_rGlrUp_Moderno,
.dxWeb_rGlrUpDisabled_Moderno,
.dxWeb_rGlrUpHover_Moderno,
.dxWeb_rMinBtn_Moderno,
.dxWeb_rMinBtnChecked_Moderno.dxWeb_rMinBtn_Moderno,
.dxWeb_rMinBtnChecked_Moderno.dxWeb_rMinBtnDisabled_Moderno,
.dxWeb_rMinBtnChecked_Moderno.dxWeb_rMinBtnHover_Moderno,
.dxWeb_rMinBtnChecked_Moderno.dxWeb_rMinBtnPressed_Moderno,
.dxWeb_rMinBtnDisabled_Moderno,
.dxWeb_rMinBtnHover_Moderno,
.dxWeb_rMinBtnPressed_Moderno,
.dxWeb_rpCollapseButton_Moderno,
.dxWeb_rPopOut_Moderno,
.dxWeb_splHCollapseBackwardButton_Moderno,
.dxWeb_splHCollapseBackwardButtonHover_Moderno,
.dxWeb_splHCollapseForwardButton_Moderno,
.dxWeb_splHCollapseForwardButtonHover_Moderno,
.dxWeb_splHSeparator_Moderno,
.dxWeb_splHSeparatorHover_Moderno,
.dxWeb_splVCollapseBackwardButton_Moderno,
.dxWeb_splVCollapseBackwardButtonHover_Moderno,
.dxWeb_splVCollapseForwardButton_Moderno,
.dxWeb_splVCollapseForwardButtonHover_Moderno,
.dxWeb_splVSeparator_Moderno,
.dxWeb_splVSeparatorHover_Moderno,
.dxWeb_tcScrollLeft_Moderno,
.dxWeb_tcScrollLeftDisabled_Moderno,
.dxWeb_tcScrollLeftHover_Moderno,
.dxWeb_tcScrollLeftPressed_Moderno,
.dxWeb_tcScrollRight_Moderno,
.dxWeb_tcScrollRightDisabled_Moderno,
.dxWeb_tcScrollRightHover_Moderno,
.dxWeb_tcScrollRightPressed_Moderno,
.dxWeb_tiBackToTop_Moderno,
.dxWeb_tvColBtn_Moderno,
.dxWeb_tvColBtnRtl_Moderno,
.dxWeb_tvExpBtn_Moderno,
.dxWeb_tvExpBtnRtl_Moderno,
.dxWeb_ucClearButton_Moderno,
.dxWeb_ucClearButtonDisabled_Moderno
{
    <%--background-image: url('<%=WebResource("DevExpress.Web.ASPxThemes.App_Themes.Moderno.Web.sprite.png")%>');--%>
    background-repeat: no-repeat;
    background-color: transparent;
}

.dxpLite_Moderno .dxp-current
{
	color: #979797;
	background-color: #dcdcdc;
	text-decoration: none;
}

.dxpLite_Moderno .dxp-num
{
	color: #045cad;
	text-decoration: underline;
	padding: 6px 12px 5px;
    margin-top: 3px;
}

.dxWeb_pNextDisabled_Moderno
{
    background-position: -248px -381px;
    width: 12px;
    height: 12px;
}
.dx-clear
{
	display: block;
	clear: both;
	height: 0;
	width: 0;
	font-size: 0;
	line-height: 0;
	overflow: hidden;
	visibility: hidden;
}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTietDonHang" KeyFieldName="ID" OnRowDeleting="gridChiTietDonHang_RowDeleting" OnRowUpdating="gridChiTietDonHang_RowUpdating">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
<Settings ShowTitlePanel="True"></Settings>

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

<SettingsText Title="Th&#244;ng Tin Chi Tiết Đơn Đặt H&#224;ng" CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" CommandEdit="Sửa"></SettingsText>
        <EditFormLayoutProperties>
            <Items>
                <dx:GridViewColumnLayoutItem Caption="Hàng Hóa" ColumnName="Hàng Hóa" Name="IDHangHoa">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem Caption="Số Lượng" ColumnName="Số Lượng" Name="SoLuong">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
<Columns>
    <dx:GridViewCommandColumn VisibleIndex="8" ShowEditButton="True">
    </dx:GridViewCommandColumn>
    <dx:GridViewDataComboBoxColumn FieldName="IDHangHoa" Caption="H&#224;ng H&#243;a" VisibleIndex="1" ReadOnly="True">
    <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID"></PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" VisibleIndex="7">
        <propertiesspinedit DisplayFormatString="N0"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    
    <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" VisibleIndex="4">
        <propertiesspinedit DisplayFormatString="N0"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" VisibleIndex="3">
        <propertiesspinedit DisplayFormatString="g"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0">
    </dx:GridViewDataTextColumn>
</Columns>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
        <asp:SqlDataSource ID="sqlThue" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [GPM_Thue].[ID], [GPM_Thue].[TenThue] + ' - '+[GPM_Thue_CALCU].Ten As TenThue FROM [GPM_Thue],[GPM_Thue_CALCU] WHERE ([GPM_Thue].[DaXoa] = 0 AND [GPM_Thue_CALCU].ID = [GPM_Thue].IDThue_CALCU )">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
