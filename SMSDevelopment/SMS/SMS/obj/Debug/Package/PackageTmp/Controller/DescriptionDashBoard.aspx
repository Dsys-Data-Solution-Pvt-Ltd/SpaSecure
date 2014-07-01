<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="DescriptionDashBoard.aspx.cs" Inherits="SMS.Controller.DescriptionDashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Refresh" content="200" />
    <%--<script src="../js/jquery.contextMenu.js" type="text/javascript"></script>--%>
    <link rel="Stylesheet" href="../Styles/StyleSheet1.css" type="text/css" />
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
            width: 647px;
        }
    </style>
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
                    var newstaffid = StaffID.replace("===", "");
                    window.location = '../ADMIN/Staff_ViewReport.aspx?StaffID=' + newstaffid;
                }
            });
        }

        function UpdateRemarks(tbid, wrid, colname) {
            var Remark = $("#" + tbid).val();
            PageMethods.UpdateShiftRemarks(Remark, wrid, colname, function (result) {
                if (result == "Success") {
                    alert("Remark Updated Successfully");
                }
                else {
                    alert("Error Occured");
                }
            });
            return false;
        }

        function SendReport(LocationID, LocationName, ShiftName, ShiftID, Identifier, WDRID, MDate, tbid) {
            var Remark = $("#" + tbid).val();
            PageMethods.SendReportMails(LocationID, LocationName, ShiftName, ShiftID, Identifier, WDRID, MDate, Remark, function (result) {
                if (result == "Success") {
                    alert("Report Sent Successfully");
                }
                else {
                    alert("Error Occured");
                }
            });
        }

        function show_popup() {
            var p = window.createPopup();
            var pbody = p.document.body
            pbody.style.backgroundColor = "Aqua";
            pbody.style.border = "solid green 2px";
            pbody.innerHTML = "This is my Profile...........................<br/>Do you want to check my profile?";
            p.show(450, 450, 450, 450, document.body);
        }

        function show_popup1(r, z, y) {

            window.open("WebForm1.aspx?t1=" + r + "&t2=" + z + "&t3=" + y, 'Popup', 'width=450,height=250,scrollbars=no,resizable=no,status bar=no,toolbar=no,directories=no,location=no,menubar=no,status=no,left=0,top=0,titlebar=no,location bar=no');
            //window.moveTo(1200,1200);
            window.moveTo(450, 450);
        }
        window.history.forword(-1);
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle" style="margin-top: -15em">Detailed Dashboard</span>
        </div>
        <marquee direction="left" scrolldelay="10" width="1120px" style="height: 29px">
            <asp:Label ID="lblLocation" runat="server" width="1120px" Font-Bold="True" Font-Size="20px" ForeColor="#6291A9" style="height: 30px"></asp:Label></marquee>
        <asp:Label runat="server" ID="dispmessage" Visible="false"></asp:Label>
        <br />
        <%--<asp:Panel runat="server" ID="Pnl" BackColor="White" Style="margin-left: 0.7em; margin-top: 0px;"
            Font-Bold="True" Width="775px" Height="40em">--%>
            <table width="100%" class="tableNew">
                <tr>
                    <td>
                        <asp:Button ID="btnContinue" runat="server" Visible="false" Text="Start Continuous Refreshing"
                            CssClass="Buttons" OnClick="btnContinue_Click" Width="255px" />
                    </td>
                </tr>
            </table>
            <%--<asp:Panel runat="server" style="margin-left:1.5em" visible="true">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <img alt="Refreshing" src="../Images/process.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </asp:Panel>--%>
            <table width="100%" class="tableNew" id="TblGrid" runat="server">
                <tr>
                    <td>
                        <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>">
                        </asp:SqlDataSource>
                        <asp:HiddenField ID="hdnHash" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="divHeaderForDashBoard">
                            <span class="pageTitle" style="margin-left: 0.5em;">Current Status</span>
                            <br />
                        </div>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <span class="pageTitle" style="margin-left: 0em">
                            <asp:Label runat="server" Text="" ID="lblMsg"> </asp:Label>
                        </span>
                        <br />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <telerik:RadGrid ID="grdMain" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellSpacing="0" CssClass="GridMain" EmptyDataText="No Guards Assigned Yet." GridLines="None"
                                    OnItemDataBound="grdMain_ItemDataBound" OnNeedDataSource="grdMain_NeedDataSource"
                                    ShowFooter="True" Width="750px">
                                    <MasterTableView AlternatingItemStyle-BackColor="#99CCFF" AlternatingItemStyle-ForeColor="#333333"
                                        CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                        CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF"
                                        ShowHeader="True">
                                        <Columns>
                                            <%--<telerik:GridBoundColumn DataField="Location_name" HeaderTooltip="Check Location"
                                HeaderText="Location" UniqueName="Location_name" FilterControlAltText="Filter Location_name column">
                            </telerik:GridBoundColumn>--%>
                                            <telerik:GridTemplateColumn HeaderStyle-CssClass="pageTitle" HeaderText="Location"
                                                HeaderTooltip="Sites For Security Officer" UniqueName="Location_name">
                                                <ItemTemplate>
                                                    <asp:Label ID="locationName" runat="server" Font-Bold="true" Text='<%# Eval("Location_name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="pageTitle" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocid" runat="server" Text='<%# Eval("Location_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-CssClass="pageTitle" HeaderText="Current Shift"
                                                UniqueName="CurrentShift">
                                                <ItemTemplate>
                                                    <telerik:RadGrid ID="grdCurrentShift1" runat="server">
                                                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                        <ItemStyle CssClass="NormalRow" />
                                                        <AlternatingItemStyle CssClass="AlternateRow" />
                                                        <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                        <SelectedItemStyle CssClass="HighlightedRow" />
                                                        <MasterTableView AlternatingItemStyle-BackColor="#99CCFF" AlternatingItemStyle-ForeColor="#333333"
                                                            CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                            CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn UniqueName="checkOutUserInner">
                                                                    <ItemTemplate>
                                                                        <%--<b><asp:Label ID="lblGuardName" runat="server" Text='<%# Eval("UserName") %>' ToolTip='<%# Eval("checkout_time") %>'></asp:Label></b>--%>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <NoRecordsTemplate>
                                                                No Current Shift
                                                            </NoRecordsTemplate>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="pageTitle" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-CssClass="pageTitle" HeaderText="Next Shift"
                                                UniqueName="NextShift">
                                                <ItemTemplate>
                                                    <telerik:RadGrid ID="grdNextShift1" runat="server">
                                                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                        <ItemStyle CssClass="NormalRow" />
                                                        <AlternatingItemStyle CssClass="AlternateRow" />
                                                        <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                        <SelectedItemStyle CssClass="HighlightedRow" />
                                                        <MasterTableView AlternatingItemStyle-BackColor="#99CCFF" AlternatingItemStyle-ForeColor="#333333"
                                                            CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                            CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn UniqueName="checkOutUserInner">
                                                                    <ItemTemplate>
                                                                        <%--<b><asp:Label ID="lblGuardName" runat="server" Text='<%# Eval("UserName") %>' ToolTip='<%# Eval("checkout_time") %>'></asp:Label></b>--%>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <NoRecordsTemplate>
                                                                No Next Shift
                                                            </NoRecordsTemplate>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="pageTitle" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-CssClass="pageTitle" HeaderText="Recently Checkin"
                                                UniqueName="checkInUser">
                                                <ItemTemplate>
                                                    <telerik:RadGrid ID="grdCurrCheckIn1" runat="server">
                                                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                        <ItemStyle CssClass="NormalRow" />
                                                        <AlternatingItemStyle CssClass="AlternateRow" />
                                                        <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                        <SelectedItemStyle CssClass="HighlightedRow" />
                                                        <MasterTableView AlternatingItemStyle-BackColor="#99CCFF" AlternatingItemStyle-ForeColor="#333333"
                                                            CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                            CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                    <ItemTemplate>
                                                                        <%--<b><asp:Hyperlink ID="lblGuardCIStatus" runat="server" ToolTip='<%# Eval("Checkin_DateTime") %>'>Hello</asp:Hyperlink></b>--%>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <NoRecordsTemplate>
                                                                No New CheckIns
                                                            </NoRecordsTemplate>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="pageTitle" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderStyle-CssClass="pageTitle" HeaderText="Recently Checkout"
                                                UniqueName="checkOutUser">
                                                <ItemTemplate>
                                                    <telerik:RadGrid ID="grdCurrCheckOuts1" runat="server">
                                                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                        <ItemStyle CssClass="NormalRow" />
                                                        <AlternatingItemStyle CssClass="AlternateRow" />
                                                        <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                        <SelectedItemStyle CssClass="HighlightedRow" />
                                                        <MasterTableView AlternatingItemStyle-BackColor="#99CCFF" AlternatingItemStyle-ForeColor="#333333"
                                                            CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                            CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                            <Columns>
                                                                <telerik:GridTemplateColumn UniqueName="checkOutUserInner">
                                                                    <ItemTemplate>
                                                                        <%--<b><asp:Hyperlink ID="lblGuardCOStatus" runat="server" ToolTip='<%# Eval("checkout_time") %>'>Hello</asp:Hyperlink></b>--%>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                            <NoRecordsTemplate>
                                                                No New CheckOuts
                                                            </NoRecordsTemplate>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="pageTitle" />
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <AlternatingItemStyle BackColor="#99CCFF" ForeColor="#333333" />
                                        <EditItemStyle ForeColor="#0066FF" />
                                    </MasterTableView>
                                    <HeaderStyle BackColor="#D0E2F0" BorderColor="#4596DD" BorderStyle="Solid" Font-Bold="True"
                                        Font-Size="Medium" ForeColor="#707070" />
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <table width="100%" class="tableNew" runat="server">
                        <tr>
                            <td>
                                <div class="divHeaderForDashBoard">
                                    <span class="pageTitle" style="margin-left: 0.5em;">Currently Assigned Users</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:MultiView ID="mvGuards" runat="server">
                                    <asp:View ID="vGuards" runat="server">
                                        <asp:GridView ID="grdSchedule" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CssClass="GridMainDashBoard" EmptyDataText="Currently No Gaurds are Assigned">
                                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                            <RowStyle CssClass="NormalRow" />
                                            <AlternatingRowStyle CssClass="AlternateRow" />
                                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                            <SelectedRowStyle CssClass="HighlightedRow" />
                                            <Columns>
                                                <%--<asp:BoundField DataField="StaffName" HeaderText="Currently Assigned User">
                                                    <ItemStyle Font-Size="Small" />
                                                </asp:BoundField>--%>
                                                <%--<asp:TemplateField HeaderText="Currently Assigned User">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkLoc" runat="server" CssClass="LnkButton" Text='<%# Eval("StaffName") %>'
                                                            CommandArgument='<%# Eval("StaffID") %>' CommandName="Select" ToolTip='<%# Eval("Role") %>'
                                                            Font-Size="Small"></asp:Label></ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle CssClass="NoRecords" />
                                        </asp:GridView>
                                        <br />
                                        <%--<asp:LinkButton ID="lnkBack" style=" margin-left:1.5em" runat="server" CssClass="LnkButton" Visible="false">&lt;&lt; Select Location</asp:LinkButton>
                                        --%>
                                    </asp:View>
                                </asp:MultiView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        <%--</asp:Panel>--%>
    </div>
</asp:Content>
