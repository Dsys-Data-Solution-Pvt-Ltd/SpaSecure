<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="DashBoardNew.aspx.cs" Inherits="SMS.Controller.DashBoardNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Refresh" content="200" />
    <%--<script src="../js/jquery.contextMenu.js" type="text/javascript"></script>--%>
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
    </style>
    <script type="text/javascript">
        function Print() {
            var grid = document.getElementById('ctl00_ContentPlaceHolder1_printview');
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
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForLE">
        <div class="divHeader">
            <asp:Button ID="btnRef" runat="server" Text="Refresh" OnClick="btnRef_Click" Style="display: none" />
            <span class="pageTitle">Controller Dashboard</span>
        </div>
        <br />
        <%--<asp:Panel runat="server" ID="Pnl" BackColor="White" Style="margin-left:0.7em; margin-top: 0px;"
            Font-Bold="True" Width="775px" Height="80em">--%>
        <table width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnContinue" runat="server" Visible="false" Text="Start Continuous Refreshing"
                        CssClass="Buttons" OnClick="btnContinue_Click" Width="255px" />
                </td>
            </tr>
        </table>
        <table width="100%" class="tableNew">
            <tr>
                <td>
                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>"
                        SelectCommand="SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc">
                    </asp:SqlDataSource>
                    <asp:HiddenField ID="hdnHash" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="divHeaderForDashBoard">
                        <span class="pageTitle" style="margin-left: 0em">Current Status</span>
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0"
                                GridLines="None" OnItemCreated="RadGrid1_ItemCreated" OnNeedDataSource="RadGrid1_NeedDataSource1"
                                ShowFooter="True" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
                                OnItemCommand="RadGrid1_ItemCommand" EmptyDataText="No Guards Assigned Yet."
                                DataSourceID="dsLocation" Skin="Simple" Width="100%" PageSize="10" ShowHeader="True">
                                <MasterTableView AlternatingItemStyle-ForeColor="#333333" AlternatingItemStyle-BackColor="#FFFFFF"
                                    CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                    CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF"
                                    DataSourceID="dsLocation">
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Location" UniqueName="Location_name" HeaderTooltip="Sites For Security Officer"
                                            HeaderStyle-CssClass="headerColor">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="locationName" Text='<%# Eval("Location_name") %>' runat="server"
                                                    Font-Bold="true"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="pageTitle" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn Visible="false" UniqueName="NavigateID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocid" runat="server" Text='<%# Eval("Location_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Current Shift" UniqueName="CurrentShift"
                                            HeaderStyle-CssClass="pageTitle">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="grdCurrentShift" runat="server" OnItemDataBound="grdCurrentShift_ItemDataBound">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="NormalRow" />
                                                    <AlternatingItemStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedItemStyle CssClass="HighlightedRow" />
                                                    <MasterTableView AlternatingItemStyle-ForeColor="#333333" AlternatingItemStyle-BackColor="#FFFFFF"
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
                                        <telerik:GridTemplateColumn HeaderText="Next Shift" UniqueName="NextShift" HeaderStyle-CssClass="pageTitle">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="grdNextShift" runat="server" OnItemDataBound="grdCurrentNext_ItemDataBound"
                                                    AllowPaging="True">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="NormalRow" />
                                                    <AlternatingItemStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedItemStyle CssClass="HighlightedRow" />
                                                    <MasterTableView AlternatingItemStyle-ForeColor="#333333" AlternatingItemStyle-BackColor="#FFFFFF"
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
                                        <telerik:GridTemplateColumn HeaderText="Recently Checkin" UniqueName="checkInUser"
                                            HeaderStyle-CssClass="pageTitle">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="grdCurrCheckIn" runat="server" OnItemDataBound="grdCurrCheckIn_ItemDataBound"
                                                    AllowPaging="True" OnItemCommand="grdCurrCheckIn_ItemCommand" AutoGenerateColumns="false">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="NormalRow" />
                                                    <AlternatingItemStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedItemStyle CssClass="HighlightedRow" />
                                                    <MasterTableView AlternatingItemStyle-ForeColor="#333333" AlternatingItemStyle-BackColor="#FFFFFF"
                                                        CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                        CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="CheckINName" Text='<%# Eval("Name") %>' CommandArgument='<%# Eval("UserID") %>'
                                                                        CommandName="CheckIN" ToolTip='<%# Eval("UserID") %>' runat="server" Font-Bold="true"></asp:LinkButton>
                                                                    <%--<b><asp:Hyperlink ID="lblGuardCIStatus" runat="server" ToolTip='<%# Eval("Checkin_DateTime") %>'>Hello</asp:Hyperlink></b>--%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcheckout_time" runat="server" Text='<%# Eval("Checkin_DateTime") %>'
                                                                        ToolTip='<%# Eval("Checkin_DateTime") %>'></asp:Label>
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
                                        <telerik:GridTemplateColumn HeaderText="Recently Checkout" UniqueName="checkOutUser"
                                            HeaderStyle-CssClass="pageTitle">
                                            <ItemTemplate>
                                                <telerik:RadGrid ID="grdCurrCheckOuts" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                                    OnItemCommand="grdCurrCheckOuts_ItemCommand">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <ItemStyle CssClass="NormalRow" />
                                                    <AlternatingItemStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedItemStyle CssClass="HighlightedRow" />
                                                    <MasterTableView AlternatingItemStyle-ForeColor="#333333" AlternatingItemStyle-BackColor="#FFFFFF"
                                                        CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                        CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="checkOutUserInner">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="CheckOutName" Text='<%# Eval("UserName") %>' CommandArgument='<%# Eval("userid") %>'
                                                                        CommandName="CheckOut" ToolTip='<%# Eval("userid") %>' runat="server" Font-Bold="true"></asp:LinkButton>
                                                                    <%--<b><asp:Hyperlink ID="lblGuardCOStatus" runat="server" ToolTip='<%# Eval("checkout_time") %>'>Hello</asp:Hyperlink></b>--%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcheckout_time" runat="server" Text='<%# Eval("checkout_time") %>'
                                                                        ToolTip='<%# Eval("checkout_time") %>'></asp:Label>
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
                                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                        <HeaderStyle Width="20px"></HeaderStyle>
                                    </ExpandCollapseColumn>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <AlternatingItemStyle BackColor="#FFFFFF" ForeColor="#333333" />
                                    <EditItemStyle ForeColor="#0066FF" />
                                </MasterTableView>
                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#C5061B" Font-Size="Medium" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <%--</asp:Panel>--%>
    </div>
    <asp:HiddenField ID="hdnUpdate" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupUpdate" runat="server" TargetControlID="hdnUpdate"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdate">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlUpdate" runat="server" BackColor="White" ScrollBars="Vertical"
        Height="650px" Width="800px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div class="divWaiting">
                    <asp:Image ID="imgWait83" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait83" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <center>
                    <marquee direction="left" scrolldelay="10" width="750px" style="height: 29px">
            <asp:Label ID="lblLocation" runat="server" width="750px" Font-Bold="True" Font-Size="20px" ForeColor="#6291A9" style="height: 30px"></asp:Label></marquee>
                    <asp:Label runat="server" ID="dispmessage" Visible="false"></asp:Label>
                    <br />
                    <table width="750px" id="TblGrid" runat="server">
                        <tr>
                            <td>
                                <asp:SqlDataSource ID="SqlDataSourcegridmain" runat="server" ConnectionString="<%$ ConnectionStrings:spasecurelatestConnectionString %>">
                                </asp:SqlDataSource>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
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
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="grdMain" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellSpacing="0" CssClass="GridMain" EmptyDataText="No Guards Assigned Yet." GridLines="None"
                                            DataSourceID="SqlDataSourcegridmain" OnItemDataBound="grdMain_ItemDataBound"
                                            OnNeedDataSource="grdMain_NeedDataSource" ShowFooter="True" Width="750px" Skin="Simple">
                                            <MasterTableView CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
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
                                                                <MasterTableView CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
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
                                                                <MasterTableView CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
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
                                                            <telerik:RadGrid ID="grdCurrCheckIn1" runat="server" AutoGenerateColumns="false">
                                                                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="NormalRow" />
                                                                <AlternatingItemStyle />
                                                                <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                                <SelectedItemStyle CssClass="HighlightedRow" />
                                                                <MasterTableView CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                                    CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                            <ItemTemplate>
                                                                                  <asp:Label ID="CheckINName" runat="server" Text='<%# Eval("Name") %>'
                                                                                    ToolTip='<%# Eval("UserID") %>'></asp:Label> 
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcheckout_time" runat="server" Text='<%# Eval("Checkin_DateTime") %>'
                                                                                    ToolTip='<%# Eval("Checkin_DateTime") %>'></asp:Label>
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
                                                            <telerik:RadGrid ID="grdCurrCheckOuts1" runat="server" AutoGenerateColumns="false">
                                                                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="NormalRow" />
                                                                <AlternatingItemStyle CssClass="AlternateRow" />
                                                                <PagerStyle CssClass="PagingRow" Height="21px" HorizontalAlign="Right" />
                                                                <SelectedItemStyle CssClass="HighlightedRow" />
                                                                <MasterTableView CommandItemSettings-ShowExportToExcelButton="False" CommandItemSettings-ShowExportToPdfButton="False"
                                                                    CommandItemSettings-ShowRefreshButton="True" EditItemStyle-ForeColor="#0066FF">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="checkOutUserInner">
                                                                            <ItemTemplate>
                                                                            
                                                                                <asp:Label ID="CheckOutName" runat="server" Text='<%# Eval("UserName") %>'
                                                                                    ToolTip='<%# Eval("userid") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="checkInUserInner">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcheckout_time" runat="server" Text='<%# Eval("checkout_time") %>'
                                                                                    ToolTip='<%# Eval("checkout_time") %>'></asp:Label>
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
                                            <HeaderStyle ForeColor="White" BackColor="#C5061B" Font-Bold="True" Font-Size="Medium" />
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table1" width="750px" runat="server">
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
                                            CssClass="GridMainDashBoard" EmptyDataText="Currently No Gaurds are Assigned"
                                            OnRowDataBound="OnRowDataBoundgrdSchedule">
                                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                            <RowStyle CssClass="NormalRow" />
                                            <AlternatingRowStyle CssClass="AlternateRow" />
                                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                            <SelectedRowStyle CssClass="HighlightedRow" />
                                            <%-- <Columns>
                                              
                                            </Columns>--%>
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
                    <br />
                    <div style="background-color: #E4E4E4; width: 750px">
                        <center>
                            <asp:Button ID="btnCancel" CssClass="Button" Height="30px" Width="100px" runat="server"
                                Text="Cancel" OnClick="btnCancel_Click" />
                        </center>
                    </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
        CancelControlID="Button1" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="650px" Width="700px"
        BorderWidth="1px" Style="display: none">
        <asp:UpdateProgress ID="UpdateProgress9" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div class="divWaiting" style="margin-top: 400px">
                    <asp:Image ID="imgWait1" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                    <asp:Label ID="lblWait1" runat="server" Text=" Please wait... " Font-Bold="true"
                        Font-Size="Large" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <br />
                <center>
                    <asp:Panel runat="server" ID="printview" BackColor="White" Font-Bold="True" Width="650px">
                        <table width="650px">
                            <tr>
                                <td colspan="2">
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
                        <table width="650px">
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
                    </asp:Panel>
                    <br />
                    <div style="background-color: #E4E4E4; width: 650px">
                        <center>
                            <a id="print" href="~/Reports/printpage.aspx" class="Button" runat="server" target="_blank"
                                style="height: 30px; width: 100px; color: White; padding: 7px 30px 7px 30px">Print</a>
                            <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                            <asp:Button ID="Button1" runat="server" CssClass="Button" Text="Cancel" Width="80px"
                                Height="32px" OnClick="btnCancelPop_Click" Font-Bold="True" />
                        </center>
                    </div>
                </center>
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
</asp:Content>
