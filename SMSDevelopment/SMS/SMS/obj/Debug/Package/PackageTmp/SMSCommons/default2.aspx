<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="default2.aspx.cs" Inherits="SMS.SMSCommons.default2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../js/jquery.contextMenu.js" type="text/javascript"></script>

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
            color: #1F5588;
            font-weight: bold;
            font-family: Verdana;
            font-size: medium;
            letter-spacing: 1.5px;
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
                    window.location = "../ADMIN/Staff_ViewReport.aspx?StaffID=" + StaffID;
                }
            });
        }
    </script>

    <div class="divContainer">
        <div class="divHeader">
            <asp:Label ID="lblWelcom_Heading" Text=" " CssClass="Labels" runat="server" />
            <span class="style3">Sunlight Secure</span></div>
        <table width="100%">
            <tr>
                <td class="Messages">
                    <div id="divSuperUser" runat="server">
                        <asp:ImageButton ID="lnkAdmin" runat="server" CssClass="LnkButton" ImageUrl="~/Images/administration Icon1.png"
                            OnClick="lnkAdmin_Click"></asp:ImageButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkOperations" runat="server" CssClass="LnkButton" ImageUrl="~/Images/operations_icon.png"
                            OnClick="lnkOperations_Click"></asp:ImageButton>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkController" runat="server" CssClass="LnkButton" ImageUrl="~/Images/Controller icon1.png"
                            OnClick="lnkController_Click"></asp:ImageButton>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="lnkSuperUser" runat="server" CssClass="LnkButton" ImageUrl="~/Images/SuperUser.png"
                            OnClick="lnkSuperUser_Click"></asp:ImageButton>
                    </div>
                    <br />
                    <p class="style1">
                        Welcome to <asp:Label ID="lblWelcom_title" Text=" " CssClass="Labels" runat="server" />Sunlight Secure.</p>
                    <p class="style1">
                        To commence <asp:Label ID="lblWelcom_title1" Text=" " CssClass="Labels" runat="server" />Sunlight Secure application, please select your desired action from the menu
                        fields.<br />
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
                <asp:TextBox ID="txtdatefrom" runat="server" Visible="false"></asp:TextBox>
                <asp:MultiView ID="mvAttendence" runat="server">
                    <asp:View ID="vLocations" runat="server">
                        <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="80%" CssClass="GridMain" EmptyDataText="No Locations Have Been Assigned To You."
                            OnRowCommand="grdLocations_RowCommand">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select Location">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLoc" runat="server" CssClass="LnkButton" Text='<%# Eval("Location_name") %>'
                                            CommandArgument='<%# Eval("Location_id") %>' CommandName="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="vGuards" runat="server">
                        <asp:GridView ID="grdSchedule" runat="server" AutoGenerateColumns="false" Width="90%">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                        </asp:GridView>
                        <br />
                        <asp:LinkButton ID="lnkBack" runat="server" CssClass="LnkButton" OnClick="lnkBack_Click">&lt;&lt; Select Location</asp:LinkButton>
                    </asp:View>
                </asp:MultiView>
            </tr>
        </table>
    </div>
    <br />
    <ul id="myMenu" class="contextMenu">
        <li class="edit"><a href="#edit">View Profile</a></li>
    </ul>

</asp:Content>
