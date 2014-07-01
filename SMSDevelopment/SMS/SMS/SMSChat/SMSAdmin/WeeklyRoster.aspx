<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="WeeklyRoster.aspx.cs" Inherits="SMS.SuperVisor.WeeklyRoster" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function jqCheckAll(item, clas) {
            $("." + clas + " [type='checkbox']").attr('checked', item.checked);
        }
    </script>
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
         .contextMenu LI.replace A
        {
            background-image: url(../images/True.gif);
        }
        .contextMenu LI.delete A
        {
            background-image: url(../images/page_white_delete.png);
        }
        .contextMenu LI.quit A
        {
            background-image: url(../images/door.png);
        }
        .style2
        {
            width: 25%;
        }
        .style3
        {
            width: 14%;
        }
        .style4
        {
            text-align: left;
            height: 24px;
        }
        .style5
        {
            text-align: left;
            height: 24px;
            width: 136px;
        }
        .style6
        {
            text-align: left;
            width: 136px;
        }
    </style>

    <script type="text/javascript">
        function AttachContextMenu(id,StaffID, LocationID, Date) {
            $("#" + id).contextMenu({
                menu: 'myMenu'
            }, function(action, el, pos) {
                if (action == "delete") {
                    if (confirm("Are you sure you want to remove " + $(el).text() + " from this duty ?")) {
                        PageMethods.RemoveStaffFromDuty(StaffID, LocationID, Date, function(result) {
                            if (result == "Success") {
                                $("[id$=btnRef]").click();
                            }
                            else {
                                alert("Error Occured");
                            }
                        });
                    }
                }
                else if (action == "replace") {
                    $("[id$=hdnReplacements]").val(StaffID + ',' + LocationID + ',' + Date);
                    $(".temp").css("color", "black");
                    $(el).css("color", "yellow");
                }
                else {
                    window.open("../Admin/Staff_ViewReport.aspx?StaffID_Roster=" + StaffID, 'Profile', 'height=700px,width=800px,scrollbars=1');
                }
            });
        }
    </script>
     <asp:HiddenField ID="hdnReplacements" runat="server" />
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Weekly Roster</span></div>
        <br />

         <asp:panel runat="server" ID="Panel3" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" Width="950" >
        <table width="100%" class="table">
            <asp:Button ID="btnRef" runat="server" Text="Refresh" OnClick="btnRef_Click" Style="display: none" />
            <tr>
                <td align="left" width="15%">
                    <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                </td>
                <td align="left" class="style3">
                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels"
                         DataSourceID="dsLocation" DataTextField="Location_name" DataValueField="Location_id">
                    </asp:DropDownList>
                </td>
                <td align="left" class="style2">
                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select first day of month"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" onblur="GetNewData();"
                        OnTextChanged="txtdatefrom_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:calendarextender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2"></asp:calendarextender>
                    <asp:Image ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                       class="calender" />
                </td>
                <td align="left">
                    <asp:Label ID="Label3" CssClass="Labels" runat="server" Text="Select Week"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlWeek" runat="server" CssClass="Labels" DataSourceID="dsWeeks"
                        DataTextField="WeekName" DataValueField="WeekID" AutoPostBack="True" 
                        ForeColor="Black">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6">
                    <asp:Label ID="lblErr" runat="server" CssClass="Labels" ForeColor="Red" Text="Please Select Proper Date"
                        Visible="False"></asp:Label>
                    <asp:SqlDataSource ID="dsAvailableGuard" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="usp_GetWeeklyAvailableGuards" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                            <asp:ControlParameter ControlID="ddlWeek" Name="WeekID" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:HiddenField ID="hdnShifts" runat="server" />
                    <asp:HiddenField ID="hdnMonthID" runat="server" />
                    <asp:HiddenField ID="hdnMRID" runat="server" />
                    <asp:HiddenField ID="hdnHash" runat="server" />
                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="SELECT '0' AS Location_id, '- Select -' AS Location_name UNION SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsShift" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        
                        SelectCommand="SELECT '- Select -' AS Shift, 0 AS shift_ID UNION SELECT Shift_Master.ShiftTimeFrom + ' - ' + Shift_Master.ShiftTimeTo AS Shift, Shift_Master.shift_ID FROM LocationShiftMap INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE (LocationShiftMap.LocationID = @LocID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSite" Name="LocID" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsShiftStaff" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="usp_GetWeeklyDates" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSite" Name="LocationID" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlWeek" Name="WeekID" PropertyName="SelectedValue"
                                Type="Int32" />
                            <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;<asp:SqlDataSource ID="dsWeeks" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="SELECT '- Select -' AS WeekName, 0 AS WeekID UNION SELECT distinct WeekMaster.WeekName, vwWeeklyDeployment.WeekID FROM vwWeeklyDeployment INNER JOIN WeekMaster ON vwWeeklyDeployment.WeekID = WeekMaster.WeekID WHERE (vwWeeklyDeployment.MonthID = @MonthID) AND (vwWeeklyDeployment.LocationID = @LocationID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" 
                                PropertyName="Value" />
                            <asp:ControlParameter ControlID="ddlSite" Name="LocationID" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
        <table width="100%" class="table">
             <tr>
              <td>
                      <asp:Label ID="lblcharator" Text="Alphabet By" CssClass="Labels" runat="server"></asp:Label>&nbsp;&nbsp;           
                           <asp:DropDownList ID="drpcharactor" runat="server" CssClass="Input" 
                          AutoPostBack="True" onselectedindexchanged="drpcharactor_SelectedIndexChanged">
                                                      <asp:ListItem>-</asp:ListItem>
                                                      <asp:ListItem>A</asp:ListItem>
                                                      <asp:ListItem>B</asp:ListItem>
                                                      <asp:ListItem>C</asp:ListItem>
                                                      <asp:ListItem>D</asp:ListItem>
                                                      <asp:ListItem>E</asp:ListItem>
                                                      <asp:ListItem>F</asp:ListItem>
                                                      <asp:ListItem>G</asp:ListItem>
                                                      <asp:ListItem>H</asp:ListItem>
                                                      <asp:ListItem>I</asp:ListItem>                                                      
                                                      <asp:ListItem>J</asp:ListItem>
                                                      <asp:ListItem>K</asp:ListItem>
                                                      <asp:ListItem>L</asp:ListItem>
                                                      <asp:ListItem>M</asp:ListItem>
                                                      <asp:ListItem>N</asp:ListItem>
                                                      <asp:ListItem>O</asp:ListItem>
                                                      <asp:ListItem>P</asp:ListItem>
                                                      <asp:ListItem>Q</asp:ListItem>
                                                      <asp:ListItem>R</asp:ListItem>
                                                      <asp:ListItem>S</asp:ListItem>                                                      
                                                      <asp:ListItem>T</asp:ListItem>
                                                      <asp:ListItem>U</asp:ListItem>
                                                      <asp:ListItem>V</asp:ListItem>
                                                      <asp:ListItem>W</asp:ListItem>
                                                      <asp:ListItem>X</asp:ListItem>
                                                      <asp:ListItem>Y</asp:ListItem>
                                                      <asp:ListItem>Z</asp:ListItem>                                                      
                                      </asp:DropDownList>
                           
            </tr>
             <table class="table" width="52%">
                 <tr>
                     <td class="style5" style="font-size: 8px" valign="bottom">
                         <asp:Label ID="Label5" runat="server" CssClass="Labels" Text="Select Date"></asp:Label>
                     </td>
                     <td class="style4" valign="bottom">
                         <asp:TextBox ID="txtDeployDate" runat="server" CssClass="Input"></asp:TextBox>
                         <asp:calendarextender ID="txtdatefrom0_CalendarExtender" runat="server" 
                             CssClass="AjaxCalendar" Format="MM/dd/yyyy" TargetControlID="txtDeployDate">
                         </asp:calendarextender>
                     </td>
                 </tr>
                 <tr>
                     <td class="style6" style="font-size: 8px" valign="bottom">
                         <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Deploy To Shift"></asp:Label>
                     </td>
                     <td class="style1" valign="bottom">
                         <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="True" 
                             CssClass="Labels" DataSourceID="dsShift" DataTextField="Shift" 
                             DataValueField="shift_ID" 
                             OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                         </asp:DropDownList>
                     </td>
                 </tr>
             </table>
             <br>
             </br>

             <table>
             <tr>
             <td>
             <asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" 
                 AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" 
                 CssClass="GridMain2" DataSourceID="dsAvailableGuard" 
                 EmptyDataText="No Guards Are Available For This Month." PageSize="20" 
                 Width="40%">
                 <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                 <RowStyle CssClass="NormalRow" />
                 <AlternatingRowStyle CssClass="AlternateRow" />
                 <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                 <SelectedRowStyle CssClass="HighlightedRow" />
                 <EmptyDataRowStyle CssClass="NoRecords" />
                 <Columns>
                     <asp:TemplateField>
                         <HeaderTemplate>
                             <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" 
                                 onclick="jqCheckAll(this,'unassigned');" />
                         </HeaderTemplate>
                         <HeaderStyle HorizontalAlign="Left" Width="20px" />
                         <ItemTemplate>
                             <asp:CheckBox ID="chkGuard" runat="server" CssClass="unassigned" 
                                 ToolTip='<%# Eval("Staff_ID") %>' />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Left" 
                         HeaderText="Available Security Officers" ItemStyle-HorizontalAlign="Left" 
                         SortExpression="GuardName">
                         <ItemTemplate>
                             <asp:Label ID="lblGuard" runat="server" Text='<%# Eval("GuardName") %>'></asp:Label>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle HorizontalAlign="Left" />
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
             </td>
             
             <td>
                 <asp:Panel ID="Panel1" runat="server" BorderStyle="Inset" Width="300px">
                     
                             <td>
                                 <asp:Label ID="lblmsgSO" runat="server" CssClass="Labels" Font-Bold="True" 
                                     Text="Security Officer Already Assigned. Do You Want To Continue ?"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="center">
                                 <asp:Button ID="btnyes" runat="server" BackColor="Fuchsia" 
                                     onclick="btnyes_Click" Text="Yes" />
                                 &nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnNo" runat="server" BackColor="Fuchsia" onclick="btnNo_Click" 
                                     Text="No" />
                             </td>
                         </tr>
                    
                 </asp:Panel>
             </td>
             <td align="center" 
                 style="border: 1px solid #3366FF; padding-top: 10px; padding-bottom: 10px" 
                 valign="top">
                 <itemtemplate>
                     <asp:Label ID="lblreplacement" runat="server" CssClass="Labels" 
                         Font-Bold="true" Text=""></asp:Label>
                     &nbsp;&nbsp;<asp:LinkButton ID="lnkReplacement" runat="server" CssClass="Labels" 
                         OnClick="lnkReplacement_Click" Visible="False">RePlacement</asp:LinkButton>
                     <br />
                 </itemtemplate>
                 <asp:GridView ID="grdShiftStaff" runat="server" AllowPaging="True" 
                     AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" 
                     CssClass="GridMain" EmptyDataText="No Guards Assigned Yet." 
                     ondatabound="grdShiftStaff_DataBound" onrowcommand="grdShiftStaff_RowCommand" 
                     onrowcreated="grdShiftStaff_RowCreated" 
                     OnRowDataBound="grdShiftStaff_RowDataBound" PageSize="20" Width="97%">
                     <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                     <RowStyle CssClass="NormalRow" />
                     <AlternatingRowStyle CssClass="AlternateRow" />
                     <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                     <SelectedRowStyle CssClass="HighlightedRow" />
                     <EmptyDataRowStyle CssClass="NoRecords" />
                     <Columns>
                         <asp:BoundField DataField="MDate" HeaderStyle-Width="18%" HeaderText="Dates">
                         <HeaderStyle Width="18%" />
                         </asp:BoundField>
                         <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Schedule" 
                             ItemStyle-HorizontalAlign="Left">
                             <ItemTemplate>
                                 <asp:Label ID="lblwdrID" runat="server" Text='<%# Eval("WRIDS") %>' 
                                     Visible="false"></asp:Label>
                                 <asp:GridView ID="grdSchedule" runat="server" AutoGenerateColumns="false">
                                     <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                     <RowStyle CssClass="NormalRow" />
                                     <AlternatingRowStyle CssClass="AlternateRow" />
                                     <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                                     <SelectedRowStyle CssClass="HighlightedRow" />
                                     <EmptyDataRowStyle CssClass="NoRecords" />
                                 </asp:GridView>
                             </ItemTemplate>
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" />
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
             </td>
             </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
        </asp:panel>
    </div>
    <ul id="myMenu" class="contextMenu">
        <li class="edit"><a href="#edit">View Profile</a></li>
        <li class="delete"><a href="#delete">Remove From Duty</a></li>
        <li class="replace"><a href="#replace">Replacement</a></li>
    </ul>
    
</asp:Content>



