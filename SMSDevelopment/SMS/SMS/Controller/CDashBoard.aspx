<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="CDashBoard.aspx.cs" Inherits="SMS.Controller.CDashBoard"%>
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
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btnContinue" runat="server" Text="Start Continuous Refreshing" CssClass="Buttons"
                        OnClick="btnContinue_Click" Width="205px" />
                </td>
            </tr>
        </table>
        <div style="position:relative;width:1200px">
            <asp:UpdatePanel ID="updSchedule" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                                    SelectCommand="SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc"></asp:SqlDataSource>
                                <asp:HiddenField ID="hdnHash" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="pageTitle">Current Status</span>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grdShiftStaff" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="5" CssClass="GridMain" EmptyDataText="No Guards Assigned Yet." OnRowDataBound="grdShiftStaff_RowDataBound"
                                    DataSourceID="dsLocation">
                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                    <RowStyle CssClass="NormalRow" />
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Location" DataField="Location_name" HeaderStyle-Width="150px"
                                            ItemStyle-Width="150px"></asp:BoundField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocid" runat="server" Text='<%# Eval("Location_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Past Shift Checkout Status" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:GridView ID="grdPastCheckout" runat="server" AutoGenerateColumns="false">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="NormalRow" />
                                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                                </asp:GridView>
                                                <asp:TextBox ID="txtPastRemarks" runat="server" TextMode="MultiLine" Width="98%"
                                                    Height="40px"></asp:TextBox>
                                                <asp:LinkButton ID="lnkPastRemark" runat="server" Text="Add / Update Remarks" CommandName="past"></asp:LinkButton>
                                                <br />
                                                <asp:Button ID="btnSendPastReport" Text="Send Report" runat="server" Width="92px"
                                                    Height="21px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shift Alert" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:GridView ID="grdHandover" runat="server" AutoGenerateColumns="false">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="NormalRow" />
                                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                                </asp:GridView>
                                                <asp:TextBox ID="txtCurrentRemarks" runat="server" TextMode="MultiLine" Width="98%"
                                                    Height="40px"></asp:TextBox>
                                                <asp:LinkButton ID="lnkCurrentRemark" runat="server" Text="Add / Update Remarks"
                                                    CommandName="current"></asp:LinkButton>
                                                <br />
                                                <asp:Button ID="btnSendCurrentReport" Text="Send Report" runat="server" Width="92px"
                                                    Height="21px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Takeover Shift" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="300px">
                                            <ItemTemplate>
                                                <asp:GridView ID="grdTakeOver" runat="server" AutoGenerateColumns="false">
                                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                                    <RowStyle CssClass="NormalRow" />
                                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="21px" />
                                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                                </asp:GridView>
                                                <asp:TextBox ID="txtNextRemarks" runat="server" TextMode="MultiLine" Width="98%"
                                                    Height="40px"></asp:TextBox>
                                                <asp:LinkButton ID="lnkNextRemark" runat="server" Text="Add / Update Remarks" CommandName="next"></asp:LinkButton>
                                                <br />
                                                <asp:Button ID="btnSendNextReport" Text="Send Report" runat="server" Width="92px"
                                                    Height="21px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reassign Staff">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkReassign" runat="server" Text="Reassign Staff" PostBackUrl='<%# GetURL(Eval("Location_id").ToString()) %>'></asp:LinkButton>
                                            </ItemTemplate>
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