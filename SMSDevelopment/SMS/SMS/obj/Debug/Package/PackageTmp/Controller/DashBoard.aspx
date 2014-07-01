<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="SMS.Controller.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../js/jquery.contextMenu.js" type="text/javascript"></script>
    <style type="text/css">
        /* Generic context menu styles */.contextMenu
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
        function AttachContextMenu(id, StaffID, LocationID) {
            $("#" + id).contextMenu({
                menu: 'myMenu'
            }, function(action, el, pos) {
                if (action == "delete") {
                    if (confirm("Are you sure you want to remove " + $(el).text() + " from this duty ?")) {
                        PageMethods.RemoveStaffFromDuty(StaffID, LocationID, function(result) {
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
            PageMethods.UpdateShiftRemarks(Remark, wrid, colname, function(result) {
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
            PageMethods.SendReportMails(LocationID, LocationName, ShiftName, ShiftID, Identifier, WDRID, MDate, Remark, function(result) {
                if (result == "Success") {
                    alert("Report Sent Successfully");
                }
                else {
                    alert("Error Occured");
                }
            });
        }
    </script>

    <div class="divContainer">
        <div class="divHeader">
            <asp:Button ID="btnRef" runat="server" Text="Refresh" OnClick="btnRef_Click" Style="display: none" />
            <span class="pageTitle">Controller Dashboard</span>
        </div>
        <br />
        <table width="100%" class="table">
            <tr>
                <td>
                    <asp:Button ID="btnContinue" runat="server" Text="Start Continuous Refreshing" CssClass="Buttons"
                        OnClick="btnContinue_Click" Width="215px" />
                </td>
            </tr>
        </table>
        <div style="position:relative;width:1200px">
            <asp:UpdatePanel ID="updSchedule" runat="server">
                <ContentTemplate>
                    <table width="100%" class="table">
                        <tr>
                            <td>
                                <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                                    SelectCommand="SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc"></asp:SqlDataSource>
                                <asp:HiddenField ID="hdnHash" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="pageTitle" style=" margin-left:0em">Current Status</span>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style=" margin-left:-2em">
                                <asp:GridView ID="grdShiftStaff" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="5" CssClass="GridMain" 
                                    EmptyDataText="No Guards Assigned Yet." OnRowDataBound="grdShiftStaff_RowDataBound"
                                    DataSourceID="dsLocation" PageSize="1" 
                                    onpageindexchanging="grdShiftStaff_PageIndexChanging" AllowPaging="True">
                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                    <RowStyle CssClass="NormalRow" />
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px"/>
                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Location" DataField="Location_name" HeaderStyle-Width="150px"
                                            ItemStyle-Width="200px"></asp:BoundField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocid" runat="server" Text='<%# Eval("Location_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Current Checked In Security Officer(s)" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:GridView ID="grdCurrCheckIn" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="1">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="NormalRow" />
                                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <b><asp:Label ID="lblGuardName" runat="server" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("CheckinTime") %>'></asp:Label></b>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No New CheckIns
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Recent Check Outs" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:GridView ID="grdCurrCheckOuts" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="1">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="NormalRow" />
                                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <b><asp:Label ID="lblGuardName" runat="server" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("CheckoutTime") %>'></asp:Label></b>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No New CheckOuts
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Timer ID="tmrUpdateSchedule" runat="server" Interval="10000" OnTick="tmrUpdateSchedule_Tick">
                                </asp:Timer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <ul id="myMenu" class="contextMenu">
        <li class="edit"><a href="#edit">View Profile</a></li>
        <li class="delete"><a href="#delete">Remove From Duty</a></li>
    </ul>
</asp:Content>
