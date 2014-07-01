<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="SMS.master.login1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /* Generic context menu styles */
        .contextMenu
        {
            position: absolute;
            width: 170px;
            z-index: 99999;
            border: solid 1px #CCC;
            background: #EEE;
            padding: 0px;
            margin: 0px;
            display: none;
            font-family: Georgia;
        }
        .contextMenu LI
        {
            list-style: none;
            padding: 0px;
            margin: 0px;
        }
        .contextMenu A
        {
            color: #333;
            text-decoration: none;
            display: block;
            line-height: 20px;
            height: 20px;
            background-position: 6px center;
            background-repeat: no-repeat;
            outline: none;
            padding: 1px 5px;
            padding-left: 28px;
        }
        .contextMenu LI.hover A
        {
            color: #FFF;
            background-color: #3399FF;
        }
        .contextMenu LI.disabled A
        {
            color: #AAA;
            cursor: default;
        }
        .contextMenu LI.hover.disabled A
        {
            background-color: transparent;
        }
        .contextMenu LI.separator
        {
            border-top: solid 1px #CCC;
        }
        /*
	Adding Icons
	
	You can add icons to the context menu by adding
	classes to the respective LI element(s)
*/.contextMenu LI.edit A
        {
            background-image: url(../images/page_white_edit.png);
        }
        .contextMenu LI.cut A
        {
            background-image: url(../images/cut.png);
        }
        .contextMenu LI.copy A
        {
            background-image: url(../images/page_white_copy.png);
        }
        .contextMenu LI.paste A
        {
            background-image: url(../images/page_white_paste.png);
        }
        .contextMenu LI.delete A
        {
            background-image: url(../images/page_white_delete.png);
        }
        .contextMenu LI.quit A
        {
            background-image: url(../images/door.png);
        }
        .style1
        {
            font-size: medium;
        }
        .style2
        {
            font-size: small;
        }
        .style3
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: medium;
            letter-spacing: 1.5px;
            margin-left: 1.5em;
        }
    </style>
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <script type="text/javascript">
        function Print() {
            var grid = document.getElementById('ctl00_InitialContentHolder_ContentPlaceHolder1_printview');
            grid.border = 0;
            var prtwin = window.open(",'grid','left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizeble=1'");
            prtwin.document.write(grid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();

        }
    </script>
    <script type="text/javascript">
        function AttachContextMenu(id, StaffID, LocationID) {
            $("#" + id).contextMenu({
                menu: 'myMenu'
            }, function (action, el, pos) {
                if (action == "delete") {
                    if (confirm("Are you sure you want to remove " + $(el).text() + " from this duty ?")) {
                        PageMethods.RemoveStaffFromDuty(StaffID, LocationID, function (result) {
                            if (result == "Success") {
                                $("[id$=btnRef]").click();
                            }
                            else {
                                alert("Error Occured");
                            }
                        });
                    }
                }
                else {
                    window.location = "../ADMIN/Staff_ViewReport.aspx?StaffID=" + StaffID;
                }
            });
        }
        window.history.forward(-1);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader" style="background-color: #C5061B; color: #FFF;">
            <asp:Label ID="lblWelcom_Heading" Text=" " CssClass="Labels" runat="server" />
            <span class="style3">SPA Secure</span></div>
        <table width="100%">
            <tr>
                <td class="Messages">
                    <div id="divSuperUser" runat="server">
                        <asp:ImageButton ID="lnkAdmin" runat="server" CssClass="LnkButton" ImageUrl="~/Images/administration Icon1.png"
                            OnClick="lnkAdmin_Click" Visible="False"></asp:ImageButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkOperations" runat="server" CssClass="LnkButton" ImageUrl="~/Images/operations_icon.png"
                            OnClick="lnkOperations_Click" Visible="False"></asp:ImageButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkController" runat="server" CssClass="LnkButton" ImageUrl="~/Images/Controller icon1.png"
                            OnClick="lnkController_Click" Visible="False"></asp:ImageButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkSuperUser" runat="server" CssClass="LnkButton" ImageUrl="~/Images/SuperUser.png"
                            OnClick="lnkSuperUser_Click" Visible="False"></asp:ImageButton>
                    </div>
                    <br />
                    <p class="style1">
                        Welcome to
                        <asp:Label ID="lblWelcom_title" Text=" " CssClass="Labels" runat="server" />
                        SPA Secure.</p>
                    <p class="style1">
                        To commence
                        <asp:Label ID="lblWelcom_title1" Text=" " CssClass="Labels" runat="server" />
                        SPA Secure application, please select your desired action from the menu fields.<br />
                    </p>
                    <p class="style2">
                        For further assistance please email: <a href="mailto:support@dsds.co.in">
                            <asp:Label ID="Label1" Text="dsds.co.in" CssClass="Labels" runat="server" />
                        </a>
                    </p>
                    <p>
                        &nbsp;</p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="LnkButton" Visible="false"
                        OnClick="lnkBack_Click" Font-Size="Medium">Select Location</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtdatefrom" runat="server" Visible="false"></asp:TextBox>
                    <asp:MultiView ID="mvAttendence" runat="server">
                        <asp:View ID="vLocations" runat="server">
                            <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="5" Width="100%" CssClass="GridMain3" EmptyDataText="No Locations Have Been Assigned To You."
                                OnRowCommand="grdLocations_RowCommand">
                                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" ForeColor="White" />
                                <RowStyle CssClass="NormalRow" />
                                <AlternatingRowStyle CssClass="AlternateRow" />
                                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                <SelectedRowStyle CssClass="HighlightedRow" />
                                <EmptyDataRowStyle CssClass="NoRecords" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select Location" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLoc" runat="server" ForeColor="Black" CssClass="LnkButton"
                                                Style="text-decoration: underline" Text='<%# Eval("Location_name") %>' CommandArgument='<%# Eval("Location_id") %>'
                                                CommandName="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:View>
                        <asp:View ID="vGuards" runat="server">
                            <asp:GridView ID="grdSchedule" runat="server" AutoGenerateColumns="false" Width="90%"
                                CssClass="GridMain3" EmptyDataText="No Guards are Assigned to this Location in the Roster"
                                OnRowDataBound="OnRowDataBoundgrdSchedule">
                                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                <RowStyle CssClass="NormalRow" />
                                <AlternatingRowStyle CssClass="AlternateRow" />
                                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                <SelectedRowStyle CssClass="HighlightedRow" />
                                <EmptyDataRowStyle CssClass="NoRecords" />
                            </asp:GridView>
                            <br />
                            <%--<asp:LinkButton ID="lnkBack" style=" margin-left:1.5em" runat="server" CssClass="LnkButton" Visible="false">&lt;&lt; Select Location</asp:LinkButton>
                            --%>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lnkbtn" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="620px" Width="730px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="printview" BackColor="White" Style="margin-left: 1.5em"
                    Font-Bold="True" Width="700">
                    <br />
                    <table width="700px">
                        <tr>
                            <td colspan="3">
                                <center>
                                    <asp:Label ID="lblheading" CssClass="Labels" runat="server" Text="BIODATA " Font-Bold="True"
                                        Font-Size="Medium"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px">
                            </td>
                            <td style="width: 420px">
                            </td>
                            <td align="left" rowspan="3">
                                <asp:Image ID="ImgageStaff" runat="server" Width="90px" Height="80px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Name" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtfullname" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDOB" CssClass="Labels" runat="server" Text="Date Of Birth" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtDOB" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC /FIN No." Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtNRIC" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblContNo" CssClass="Labels" runat="server" Text="Contact No." Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtContNo" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSex" CssClass="Labels" runat="server" Text="Sex" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtSex" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblReligion" CssClass="Labels" runat="server" Text="Religion" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtReligion" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRace" CssClass="Labels" runat="server" Text="Race" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtRace" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAge" CssClass="Labels" runat="server" Text="Age" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtAge" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMaritalStatus" CssClass="Labels" runat="server" Text="Marital Status"
                                    Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtMaritalStatus" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRole" CssClass="Labels" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtRole" CssClass="Labels" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="700px">
                        <tr>
                            <td>
                                <asp:Label ID="lblAttachedDocument" CssClass="Labels" runat="server" Text="Attached Documents"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="HypNRICWorkPermit" Text="Nricworkpermit" OnClick="Nricworkpermit_Click"
                                    runat="server">Nricworkpermit</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="NSRSWSQModules" Text="NSRSWSQModules" OnClick="NSRSWSQModules_Click"
                                    runat="server">NSRSWSQModules</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="OtherRecognisedCertificate" Text="OtherRecognisedCertificate"
                                    OnClick="OtherRecognisedCertificate_Click" runat="server">OtherRecognisedCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="ExemptionCertificate" Text="ExemptionCertificate" OnClick="ExemptionCertificate_Click"
                                    runat="server">ExemptionCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SecurityOfficerLicense" Text="SecurityOfficerLicense" OnClick="SecurityOfficerLicense_Click"
                                    runat="server">SecurityOfficerLicense</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SIRDScreen" Text="SIRDScreen" OnClick="SIRDScreen_Click" runat="server">SIRDScreen</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
                <div style="background-color: #E4E4E4;">
                    <center>
                        <a id="print" href="~/Reports/printpage.aspx" class="Button" runat="server" target="_blank"
                            style="height: 30px; width: 100px; color: White; padding: 7px 30px 7px 30px">Print</a>
                        <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                        <asp:Button ID="ButtonCancel" runat="server" CssClass="Button" Text="Cancel" Width="110px"
                            Height="32px" OnClick="btnCancelPop_Click" Font-Bold="True" />
                    </center>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldViewer" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupViewer" runat="server" TargetControlID="HiddenFieldViewer"
        CancelControlID="ButtonCancelViewer" BackgroundCssClass="modalBackground" PopupControlID="PanelViewer">
    </asp:ModalPopupExtender>
    <asp:Panel ID="PanelViewer" runat="server" BackColor="White" Height="620px" Width="730px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdatePanel ID="UpdatePanelviewer" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="PanelV" BackColor="White" Style="margin-left: 1.5em"
                    Font-Bold="True" Width="700">
                    <table width="100%">
                        <tr>
                            <td>
                                <iframe id="ViewerDoc" runat="server" width="100%" height="530px"></iframe>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <%-- <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                                    <asp:Button ID="ButtonCancelViewer" runat="server" CssClass="Button" OnClick="ButtonCancelViewer_Click"
                                        Text="Cancel" Width="110px" Height="35px" Font-Bold="True" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="hdnAlert" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAlert" runat="server" TargetControlID="hdnAlert"
        BackgroundCssClass="modalBackground" PopupControlID="pnlAlert">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlAlert" runat="server" BackColor="White" Height="650px" Width="780px" ScrollBars="Vertical"
        BorderWidth="1px" Style="display: none">
        <asp:UpdatePanel ID="UpdatePanelAlert" runat="server">
            <ContentTemplate>
                <br />
                <center>
                    <asp:Panel runat="server" ID="PnlPersonAlert" Visible="false" Width="720px">
                        <table  style="border:none">
                            <tr>
                                <td>
                                    <h1>
                                        <center>
                                            Person Alert</center>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gvPersonAlert" runat="server" CssClass="RadGrid" GridLines="None"
                                        AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                                        HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                                        Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                                        AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Alert_ID">
                                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                            <Columns>
                                                <telerik:GridBoundColumn UniqueName="P_Name" HeaderText="Name" DataField="P_Name"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Reason">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtmessage" runat="server" Text='<%# Eval("Reason") %>' TextMode="Multiline"
                                                            Width="300px" Height="116px" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Comment">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtmessageR" runat="server" Text='<%# Eval("Comment") %>' TextMode="Multiline"
                                                            Width="300px" Height="116px" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PnlVehicleAlert" Visible="false" Width="720px">
                        <table  style="border:none">
                            <tr>
                                <td>
                                    <h1>
                                        <center>
                                            Vehicle Alert</center>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="gvVehicleAlert" runat="server" CssClass="RadGrid" GridLines="None"
                                        AllowPaging="True" PageSize="50" AllowSorting="True" AutoGenerateColumns="False"
                                        HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" ShowStatusBar="true"
                                        Skin="Simple" HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" EnableAJAX="true"
                                        AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                                        <GroupingSettings CaseSensitive="false" />
                                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Alert_ID">
                                            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                            <Columns>
                                                <telerik:GridBoundColumn UniqueName="V_OwnerName" HeaderText="Name" DataField="V_OwnerName"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                </telerik:GridBoundColumn>
                                               <telerik:GridTemplateColumn HeaderText="Reason">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtmessage" runat="server" Text='<%# Eval("Reason") %>' TextMode="Multiline"
                                                            Width="250px" Height="116px" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Comment">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtmessageR" runat="server" Text='<%# Eval("Comment") %>' TextMode="Multiline"
                                                            Width="250px" Height="116px" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn UniqueName="V_ResgistNo" HeaderText="Vehicle Registration No" DataField="V_ResgistNo"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn UniqueName="V_Type" HeaderText="Vehicle Type" DataField="V_Type"
                                                    CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" ShowFilterIcon="false">
                                                </telerik:GridBoundColumn>
                                                
                                            </Columns>
                                        </MasterTableView>
                                       
                                        <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <div style="background-color: #E4E4E4; width: 700px">
                        <center>
                            <asp:Button ID="btnCancelOK" CssClass="Button" Height="30px" Width="100px" runat="server"
                                Text="OK" OnClick="btnCancelOK_Click" />
                        </center>
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
