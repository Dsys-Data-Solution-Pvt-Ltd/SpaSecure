<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="OffLeaveSetting.aspx.cs" Inherits="SMS.SuperVisor.OffLeaveSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        
        
        
        .RadSearchBox
        {
            float: left; /*color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        .RadSearchBox:focus
        {
            float: left; /* color: #888888;
            background: url("../img/searchBox.png") no-repeat;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            margin-right: 12px;
            outline: medium none;
            padding: 0 0 0 35px;
            text-shadow: 1px 1px 0 white;
            width: 380px;
            margin: 0px;
            outline: none;
            border: none;*/
        }
        span.rsbInner
        {
            height: 30px;
            margin-left: -35px;
        }
        
        input.rsbInput.radPreventDecorate.rsbEmptyMessage
        {
            height: 28px;
        }
        button.rsbButton.rsbButtonSearch
        {
            float: None;
            height: 34px;
            margin-left: -1px;
        }
        button.rsbButton.rsbButtonSearch:hover
        {
            height: 34px;
            margin-left: -1px;
        }
        
        input.rsbInput:focus
        {
            margin-top: 6px;
        }
        
        input.rsbInput.radPreventDecorate
        {
            margin-top: 6px;
        }
        .RadGrid_Simple .rgRow td
        {
            /*border-color: #fff #c3c3c3;*/
            text-align: left;
        }
        .RadGrid_Simple .rgAltRow td
        {
            /*border-color: #ca4b0c #ffa517;*/
            text-align: left;
        }
    </style>
    <script language="vbscript" type="text/vbscript">
    ' Format a byte array to a hex string to be sent to the server.
        Function OctetToHexStr(ByVal arrbytOctet)
            Dim k
            For k = 1 To Lenb(arrbytOctet)
                OctetToHexStr = OctetToHexStr _
                  & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
            Next
        End Function
           
        'This event fires when new finger was enrolled.
        function DPFPEnrollmentControl_OnEnroll(FingerMask, Template, Status)
            Dim b
            'document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(Template.Serialize)
    document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_TabPanel5_hdnFP").value = OctetToHexStr(Template.Serialize)

        End function 
        
    </script>
    <script src="../swfobject.js" language="javascript"></script>
    <script type="text/javascript">
        function EnableDisableEnroll(chk) {
            if (chk.checked) {
                document.getElementById("thumbPrint").style.display = "";
            }
            else {
                document.getElementById("thumbPrint").style.display = "none";
            }
        }
    </script>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
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
            <span>OffLeave Setting</span>
            <br />
            </div>
        <div class="btnbar">
            <div class="btnbarBox">
                <ul>
                    <li>
                        <asp:LinkButton ID="imdAdd" runat="server" CausesValidation="false" OnClick="imgAdd_Click">
                            <span id="spanAdd1" runat="server" class="iconAdd" style="line-height: 120px;">
                                <asp:Label ID="spanAdd" runat='server' Text="Add"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgEdit" runat="server" CausesValidation="false" OnClick="imgUpdate_Click">
                            <span id="spanUpdate1" runat="server" class="iconUpdate" style="line-height: 120px;">
                                <asp:Label ID="spanUpdate" runat='server' Text="Update"></asp:Label></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="imgDelete" runat="server" CausesValidation="false" OnClick="imgDelete_Click">
                            <span id="spanDelete" runat="server" class="iconDelete" style="line-height: 120px;">
                                <asp:Label ID="spandelete1" runat='server' Text="Delete"></asp:Label>
                            </span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <%--   <ul id="tabs" class="ui-tabs ui-widget ui-widget-content ui-corner-all">

            <li id="Present" runat="server">
                <asp:LinkButton ID="lnkPresent" runat="server" OnClick="lnkPresent_Click" CausesValidation="false">
                    <span id="spanPresent" runat="server" class="icon1">Present Staff</span>
                </asp:LinkButton></li>

            <li id="Past" runat="server">
                <asp:LinkButton ID="lnkPast" runat="server" OnClick="lnkPast_Click"
                    CausesValidation="false">
                    <span id="span_Past" runat="server" class="icon2">Past Staff</span>
                </asp:LinkButton></li>
        </ul>--%>
        <div id="content" runat="server">
            <table width="100%" style="border: 0; margin-top: -7.2px">
                <tr style="vertical-align: top;">
                    <td style="width: 80%">
                        <asp:Panel ID="Panelgrid" runat="server">
                            <telerik:RadGrid ID="OffleaveTable" runat="server" CssClass="RadGrid" GridLines="None"
                                HeaderStyle-Font-Size="12px" AllowPaging="True" PageSize="50" AllowSorting="True"
                                AutoGenerateColumns="False" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="left"
                                HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="false"
                                AllowFilteringByColumn="true">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="OLid">
                                    <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ToggleRowSelection"
                                                    AutoPostBack="True" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="StaffName" HeaderText="Staff Name" DataField="StaffName"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="LeaveType" HeaderText="Leave Type" DataField="LeaveType"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="NoOfDay" HeaderText="Total Day" DataField="NoOfDay"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="RemaingDay" HeaderText="Remaining Day" DataField="RemaingDay"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="SuperiorName" HeaderText="Superior Name" DataField="SuperiorName"
                                            CurrentFilterFunction="Contains" FilterDelay="1000" ShowFilterIcon="false">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                            </telerik:RadGrid>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hdnAdd" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="lnkDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" CancelControlID="btnClearNewItemAdd"
            TargetControlID="hdnAdd" BackgroundCssClass="modalBackground" PopupControlID="pnlAdd">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlAdd" runat="server" BackColor="White" Style="height: 350px; width: 750px;
            margin-top: -15px;">
            <br />
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="divContainer">
                        <%--<div class="divHeader">
                            <span class="pageTitle">Add New Off/ Leave Setting </span>
                        </div>--%>
                        <div>
                            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                        </div>
                        <br />
                        <center>
                            <table width="700px">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label111" CssClass="Labels" runat="server" Text="Add New Type of Leave"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtaddTypeOfLeave" runat="server" CssClass="Input" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddNewType" runat="server" Text="Add " CssClass="Button" OnClick="btnAddNewType_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblStaffname" CssClass="Labels" runat="server" Text="Staff Name"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlStaffname" runat="server" CssClass="Input" Width="280px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTypeOfLeave" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                         <asp:Label ID="Label2" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTypeOfLeave" runat="server" CssClass="Input" Width="280px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNoOfday" CssClass="Labels" runat="server" Text="No. of days"></asp:Label>
                                         <asp:Label ID="Label7" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfday" runat="server" CssClass="Input" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Superior Officer"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtsuperiorOfficer" runat="server" CssClass="Input" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                    <center>
                                        <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Button" Text="Add" OnClick="btnNewItemAdd_Click" />
                                        <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Button" Text="Cancel"
                                            OnClick="btnCancel_Click" />
                                            </center>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupEdit" runat="server" TargetControlID="HiddenField1"
            CancelControlID="btnCancelUpdate" BackgroundCssClass="modalBackground" PopupControlID="pnlpopupEdit">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopupEdit" runat="server" BackColor="White" Style="height: 280px;
            width: 550px; margin-top: -15px; margin-top: -5px">
            <br />
            <asp:UpdateProgress ID="UpdateProgress2" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="up">
                <ProgressTemplate>
                    <div class="divWaiting">
                        <asp:Image ID="imgWait2" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait2" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div class="divContainer">
                        <%-- <div class="divHeader">
                            <span class="pageTitle">Update Off/ Leave Setting</span></div>
                        <div>--%>
                        <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                    </div>
                    <asp:Label ID="lblidUda" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <center>
                        <table width="500px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Staff Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStaffnameUda" runat="server" CssClass="Input" Width="280px">
                                        <asp:ListItem Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTypeOfLeaveUda" runat="server" CssClass="Input" Width="280px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" CssClass="Labels" runat="server" Text="No. of days"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNoOfdayUda" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Labels" Text="Superior Officer"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtsuperiorOfficerUda" runat="server" CssClass="Input" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                <center>
                                    <asp:Button ID="btnsave" runat="server" CssClass="Button" Text="Update" OnClick="btnNewItemAddUda_Click" />
                                    <asp:Button ID="btnCancelUpdate" runat="server" CssClass="Button" Text="Cancel" OnClick="btnCancel_Click" />
                              </center>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:HiddenField ID="delete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDelete" runat="server" TargetControlID="delete"
            CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="pnlDelete">
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
                                        <asp:Label ID="lblDeleteMsg" runat="server" Text="Are You Sure To Delete Record ?"></asp:Label>
                                        <%--Deleting a Asset record and all associated: Base Fixtures<br />
                                        <br />
                                        Do you wish to continue?--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <center>
                                            <asp:Button ID="BtnDeleteYes" OnClick="btnDeleCancel_Click" CausesValidation="false"
                                                Text="Yes" runat="server" CssClass="Button" Height="30px" Width="100px" />
                                            <asp:Button ID="btnCancel21" Text="No" runat="server" CausesValidation="false" OnClick="btnCancel_Click"
                                                CssClass="Button" Style="margin-left: 10px" Height="30px" Width="100px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
