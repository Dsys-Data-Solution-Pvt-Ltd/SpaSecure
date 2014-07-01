<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ViewShifts.aspx.cs" Inherits="SMS.ADMIN.ViewShifts" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Shift Management</span><br />
            <br />
        </div>
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imgAdd_Click">
                        <span class="iconAdd" id="SpanAdd1" runat="server" style="line-height: 120px;">
                            <asp:Label ID="SpanAdd" runat="server" Text="Add New Inventory"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                        <span class="iconUpdate" id="SpanUpdate1" runat="server" style="line-height: 120px;">
                            <asp:Label ID="SpanUpdate" runat="server" Text="Update"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                        <span class="iconDelete" id="SpanDelete" runat="server" style="line-height: 120px;">
                            <asp:Label ID="Label1" runat="server" Text="Delete"></asp:Label>
                        </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <%--<asp:UpdatePanel ID="UpdatePanelradgri" runat="server">
            <ContentTemplate>--%>
        <br />
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <asp:Panel ID="Panelgrid" runat="server">
            <telerik:RadGrid ID="RadGridCatalog" runat="server" Skin="Simple" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                HeaderStyle-HorizontalAlign="left" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white"
                AutoGenerateColumns="False" ShowStatusBar="true" AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="shift_ID">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" EnableViewState="true" OnCheckedChanged="CheckBox1_CheckedChanged"
                                    AutoPostBack="true" />
                            </ItemTemplate>
                            <HeaderStyle Width="10px"></HeaderStyle>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="ShiftTimeFrom" HeaderText="From Time" DataField="ShiftTimeFrom"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            <HeaderStyle Width="120px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ShiftTimeTo" HeaderText="To Time" DataField="ShiftTimeTo"
                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                            <HeaderStyle Width="120px"></HeaderStyle>
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>
        </asp:Panel>
        <asp:HiddenField ID="hdnupdate" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnupdate"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupAdd" runat="server" BackColor="White" Width="600px" Style="display: none;
            padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait" runat="server" Text=" Please wait... " Font-Bold="true" Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblFromTime" Text="From Time" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <MKB:TimeSelector ID="tsFromTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                    SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblToTime" Text="To Time" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <MKB:TimeSelector ID="tsToTime" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                    SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnSearchLocationAdd" Text="Add" runat="server" CssClass="Button"
                                        Height="30px" Width="100px" OnClick="btnSearchLocationAdd_Click" />
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="Button" Style="margin-left: 10px"
                                        Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="HiddenField1"
            CancelControlID="Button3" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupUpdate" runat="server" BackColor="White" Width="600px" Style="display: none;
            padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWaitupd" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWaitupd" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <br />
                    <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
                    <asp:HiddenField ID="hdnBTName" runat="server" Value="" />
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" Text="From Time" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <MKB:TimeSelector ID="tsFromTimeupd" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                    SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" Text="To Time" CssClass="Labels" runat="server"></asp:Label>
                            </td>
                            <td>
                                <MKB:TimeSelector ID="tsToTimeupd" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                    SelectedTimeFormat="Twelve" DisplaySeconds="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="Button1" Text="Update" runat="server" CssClass="Button" Height="30px"
                                        Width="100px" OnClick="btnSearchLocationUpdate_Click" />
                                    <asp:Button ID="Button3" Text="Cancel" runat="server" CssClass="Button" Style="margin-left: 10px"
                                        Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="HiddenField2"
            CancelControlID="btncanceldelete" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupDelete" runat="server" BackColor="White" Width="400px" Style="display: none;
            padding: 5px 5px 5px 5px;">
            <asp:UpdateProgress ID="UpdateProgress3" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWaitdel" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWaitdel" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <br />
                    <table width="100%" class="table">
                        <tr>
                            <td align="center">
                                <center>
                                    Are you sure want to delete?<br />
                                    <br />
                                    <asp:HiddenField ID="hdnitmID" runat="server" />
                                    <asp:Button ID="Button2" Text="Delete" runat="server" CssClass="Button" Height="30px"
                                        Width="100px" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btncanceldelete" Text="Cancel" runat="server" CssClass="Button" Style="margin-left: 10px"
                                        Height="30px" Width="100px" OnClick="btnCancel_Click" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <br />
    </div>
</asp:Content>
