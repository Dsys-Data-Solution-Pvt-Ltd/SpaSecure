<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ViewPreRegisteredVisitors.aspx.cs" Inherits="SMS.Client.ViewPreRegisteredVisotors"
    EnableEventValidation="false" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<style>
    #ctl00_ContentPlaceHolder1_tsExpectedTime table
    {
        width:160px; border:1px solid gray;
        }
#ctl00$ContentPlaceHolder1$tsExpectedTime_txtHour
{position:absolute;
        margin-left:0px;
        width:30px;
        height:30px;
    
    }
    #ctl00$ContentPlaceHolder1$tsExpectedTime_txtMinute
    {
        position:absolute;
        margin-left:60px;
        width:30px;
        height:30px;
        }
</style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="panelgrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="panelgrid" LoadingPanelID="RadAjaxLoadingPanel2">
                    </telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="Label398"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" Skin="Sunset" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div class="divHeader">
        <span class="pageTitle">Pre - Registered Visitors</span></div>
    <div class="btnbar" style="margin-top: 20px">
        <div class="btnbarBox">
            <ul>
                <li>
                    <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="ImgAdd_Click">
                        <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                            <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgUpdate" runat="server" CausesValidation="false" OnClick="ImgUpdate_Click">
                        <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                            <asp:Label ID="spanUpdate" runat='server' Text="Edit"></asp:Label></span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="ImgDelete_Click">
                        <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                            Delete </span>
                    </asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton ID="imgCopy" runat="server" CausesValidation="false" OnClick="ImageView">
                        <span id="spanCopy" runat="server" class="iconCopy" style="line-height: 120px;">View
                        </span>
                    </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="content" runat="server">
        <br />
        <asp:Panel ID="panelgrid" runat="server">
            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>--%>
            <telerik:RadGrid ID="gvPreRegisteredVisits" runat="server" CssClass="RadGrid" GridLines="None"
                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                AllowFilteringByColumn="true">
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="PRVID">
                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                            AllowFiltering="false">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                    AutoPostBack="True" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="FromDate1" HeaderText="From Date" DataField="FromDate1"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ToDate1" DataField="ToDate1" HeaderText="To Date"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ExpectedTime" DataField="ExpectedTime" HeaderText="Arrival Time"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Name" DataField="Name" HeaderText="Name" CurrentFilterFunction="Contains"
                            AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Invited_By" DataField="Invited_By" HeaderText="Invited By"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Company" DataField="Company" HeaderText="Company"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Position" DataField="Position" HeaderText="Position"
                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
            </telerik:RadGrid>
            <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
        </asp:Panel>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="hdnAdd"
            CancelControlID="btnCancelCStaff" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Height="380px" Width="750px"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress8" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait81" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait81" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="700px">
                            <tr>
                                <td>
                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddllocation_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                                <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="Labels" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDate" PopupButtonID="imgBtnFromDate" />
                                    <asp:Image ID="imgBtnFromDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="Labels" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtToDate" PopupButtonID="imgBtnToDate" />
                                    <asp:Image ID="imgBtnToDate" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="Labels" Text="Expected Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="tsExpectedTime" runat="server" MinuteIncrement="1" SecondIncrement="1" Width="150px" Height="50px"
                                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                                </td>
                                <td>
                                    <asp:Label ID="lblpurpose" runat="server" CssClass="Labels" Text="Purpose"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpurpose" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblVechicle" runat="server" CssClass="Labels" Text="Vehicle Registration No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVechicle" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInvitedBy" runat="server" CssClass=" Labels" Text="Invited By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvitedBy" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbltelephone" runat="server" CssClass=" Labels" Text="Telephone"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttelephone" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <asp:Button ID="btnAddVisitor" runat="server" Text="Add  Visitor" OnClick="btnAddVisitor_Click"
                                            CssClass="Button" Height="30px" Width="100px" />
                                        <asp:Button ID="btnCancelCStaff" CssClass="Button" Height="30px" Width="100px" runat="server"
                                            Text="Cancel" OnClick="btnCancelCStaff_Click" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
            CancelControlID="BtnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlUpdate" runat="server" BackColor="White" Height="400px" Width="750px"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait83" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait83" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="700px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocationUpdate" runat="server" CssClass="Labels">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDateUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDateUpdate" PopupButtonID="Image1" />
                                    <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="Labels" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDateUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtToDateUpdate" PopupButtonID="Image2" />
                                    <asp:Image ID="Image2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" CssClass="Labels" Text="Expected Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="tsExpectedTimeUpdate" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" CssClass="Labels" Text="Purpose"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpurposeUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNameUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" CssClass="Labels" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompanyUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPositionUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="Labels" Text="Vehicle Registration No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVechicleUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" CssClass=" Labels" Text="Invited By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvitedByUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" CssClass=" Labels" Text="Telephone"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttelephoneUpdate" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                            CssClass="Button" Height="30px" Width="100px" />
                                        <asp:Button ID="BtnCancelUpdate" CssClass="Button" Height="30px" Width="100px" runat="server"
                                            Text="Cancel" OnClick="BtnCancelUpdate_Click" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="hdnDelete"
            CancelControlID="btnCancelDelete" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDelete" runat="server" BackColor="White" Height="200px" Width="320px"
            BorderWidth="2px" Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress5" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait5" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait5" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <center>
                        <br />
                        <div>
                            <table width="290px" style="height: 170px">
                                <tr>
                                    <td>
                                        Do you want to delete this record ?
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="Deletepopup_Yes_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancelDelete" Text="No" runat="server" CausesValidation="false"
                                                OnClick="btnCancelDelete_Click" CssClass="Button" Style="margin-left: 10px" Height="30px"
                                                Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="hdnView" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupView" runat="server" TargetControlID="hdnView"
            CancelControlID="btnCancelView" BackgroundCssClass="modalBackground" PopupControlID="pnlView">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" BackColor="White" Height="400px" Width="750px"
            Style="display: none">
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait82" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait82" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="700px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddllocationView" runat="server" CssClass="Labels">
                                    </asp:DropDownList>
                                    <asp:Label ID="Label20" runat="server" Text="" Visible="false"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" CssClass="Labels" Text="From Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDateView" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtFromDateView" PopupButtonID="Image3" />
                                    <asp:Image ID="Image3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="Labels" Text="To Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtToDateView" runat="server" CssClass="Input"></asp:TextBox>
                                    <AJAX:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="AjaxCalendar"
                                        Format="MM/dd/yyyy" TargetControlID="txtToDateView" PopupButtonID="Image4" />
                                    <asp:Image ID="Image4" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                                        class="calender" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" CssClass="Labels" Text="Expected Time"></asp:Label>
                                </td>
                                <td>
                                    <MKB:TimeSelector ID="tsExpectedTimeView" runat="server" MinuteIncrement="1" SecondIncrement="1"
                                        SelectedTimeFormat="TwentyFour" AllowSecondEditing="true" DisplaySeconds="False" />
                                </td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass=" Labels" Text="Telephone"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttelephoneView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNameView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" CssClass="Labels" Text="Company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompanyView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" CssClass="Labels" Text="Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPositionView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" CssClass="Labels" Text="Vehicle Registration No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVechicleView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label29" runat="server" CssClass=" Labels" Text="Invited By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInvitedByView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" CssClass="Labels" Text="Purpose"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpurposeView" runat="server" CssClass="Input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <center>
                                        <asp:Button ID="btnCancelView" CssClass="Button" Height="30px" Width="100px" runat="server"
                                            Text="Cancel" OnClick="btnCancelView_Click" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
