<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.master" AutoEventWireup="true"
    CodeBehind="MonthlyRoster.aspx.cs" Inherits="SMS.SMSAdmin.MonthlyRoster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     function jqCheckAll(item, clas) {
         //$(".[type='Checkbox']");
         //$("." + clas + " [type='checkbox']").attr('checked', item.checked);
         //if ($([type = 'CheckBox'])) {item.checked;}
         //item.checked;
     }

     function GetNewData() {
         if ($("[id$=txtdatefrom]").val().trim() != '') {
             $("[id$=btnGetData]").click();
         }
     }
     //function CheckShift() {
     //if ($("[id$=ddlShift] option:selected").val() == "0") {
     //return false;
     //}
     //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>  --%>  
            <div class="divContainer">
        <div class="divHeader">
            <asp:Label ID="dllshift" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="staffcount" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="Lblmgaid" runat="server" Text="" Visible="false"></asp:Label>
            <span class="pageTitle">Monthly Roster</span>
        </div>
        <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        <br />
        <asp:Panel runat="server" ID="Panel2" BackColor="White" Font-Bold="True" Width="100%">
            <table width="100%">
                <tr>
                    <td align="left" style="width: 21%">
                        <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                    </td>
                    <td align="left" width="20%">
                        <%--<asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels" onchange="GetNewData();"
                        DataSourceID="dsLocation" DataTextField="Location_name" 
                        DataValueField="Location_id" ForeColor="Black">
                    </asp:DropDownList>--%>
                        <asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels" DataSourceID="dsLocation"
                            DataTextField="Location_name" DataValueField="Location_id" ForeColor="Black"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Button ID="btnGetData" runat="server" Text="" OnClick="btnGetData_Click" Style="display: none"
                            Width="0px" />
                    </td>
                    <td align="left" style="width: 25%">
                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select first day of month"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:Image ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            class="calender" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblErr" runat="server" CssClass="Labels" ForeColor="Red" Text="Please Select Proper Date"
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="4">
                        <asp:SqlDataSource ID="dsAvailableGuard" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                            SelectCommand="usp_GetMonthlyAvailableGuards" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                                <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsAvailableSupervisor" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                            SelectCommand="usp_GetMonthlyAvailableSupervisor" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                                <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:HiddenField ID="hdnShifts" runat="server" />
                        <asp:HiddenField ID="hdnMonthID" runat="server" />
                        <asp:HiddenField ID="hdnMRID" runat="server" />
                        <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                            SelectCommand="SELECT 0 AS Location_id, '- Select -' AS Location_name UNION SELECT Location_id, Location_name FROM location  where Current_Status='Present' order by Location_name Asc">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsShift" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                            SelectCommand="Select '- Select -' AS Shift,0 as MRID UNION SELECT Shift_Master.ShiftTimeFrom + ' - ' + Shift_Master.ShiftTimeTo AS Shift, MonthlyRoster.MRID FROM LocationShiftMap INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID INNER JOIN MonthlyRoster ON LocationShiftMap.LSID = MonthlyRoster.LocationShiftID WHERE (LocationShiftMap.LocationID = @LocID and MonthlyRoster.MonthID=@MonthID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlSite" Name="LocID" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsShiftStaff" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                            SelectCommand="SELECT Shift_Master.shift_ID, Shift_Master.ShiftTimeFrom + ' - ' + Shift_Master.ShiftTimeTo AS ShiftName, LocationShiftMap_1.LSID, MonthlyRoster_1.MRID, (SELECT COUNT(*) AS Expr1 FROM WeeklyGuardAssign INNER JOIN WeekDayRoster ON WeeklyGuardAssign.WDRID = WeekDayRoster.WDRID INNER JOIN WeeklyRoster ON WeekDayRoster.WRID = WeeklyRoster.WRID INNER JOIN MonthlyRoster ON WeeklyRoster.MRID = MonthlyRoster.MRID INNER JOIN LocationShiftMap ON MonthlyRoster.LocationShiftID = LocationShiftMap.LSID WHERE (WeeklyGuardAssign.EditingStarted = 1) AND (LocationShiftMap.LocationID = @LocID) AND (MonthlyRoster.MonthID = @MonthID))+(SELECT COUNT(*) AS Expr1 FROM DailyGuardAssign INNER JOIN WeekDayRoster ON DailyGuardAssign.WDRID = WeekDayRoster.WDRID INNER JOIN WeeklyRoster ON WeekDayRoster.WRID = WeeklyRoster.WRID INNER JOIN MonthlyRoster ON WeeklyRoster.MRID = MonthlyRoster.MRID INNER JOIN LocationShiftMap ON MonthlyRoster.LocationShiftID = LocationShiftMap.LSID WHERE (DailyGuardAssign.EditingStarted = 1) AND (LocationShiftMap.LocationID = @LocID) AND (MonthlyRoster.MonthID = @MonthID)) AS EditCount FROM LocationShiftMap AS LocationShiftMap_1 INNER JOIN Shift_Master ON LocationShiftMap_1.ShiftID = Shift_Master.shift_ID INNER JOIN MonthlyRoster AS MonthlyRoster_1 ON LocationShiftMap_1.LSID = MonthlyRoster_1.LocationShiftID WHERE (LocationShiftMap_1.LocationID = @LocID) AND (MonthlyRoster_1.MonthID = @MonthID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlSite" Name="LocID" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                    </td>
                </tr>
                <tr style="display: none">
                    <td style="width: 21%">
                        <asp:Label ID="lblcharator" Text="Alphabet By" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpcharactor" runat="server" CssClass="Input" OnSelectedIndexChanged="drpcharactor_SelectedIndexChanged"
                            AutoPostBack="True">
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
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <!---Changes In Padding Top By Sandeep Date:7/7/2012-->
                    <td width="20%" align="left" style="border: 1px solid #E4E4E4; padding-top: 2px;
                        padding-bottom: 20px; padding-left: 2px; padding-right: 2px" valign="top">
                        <%--<asp:Panel ID="pnl2" runat="server" Width="40%" style="border: 1px solid #3366FF; padding-top: 20px; padding-bottom: 20px"
                    align="center" valign="top">
                    <table>

          <tr>
          
           
             <td width="20%" align="center" style="border: 1px solid #FFFFFF; padding-top: 20px;
                    padding-bottom: 20px" valign="top">--%>
                        <%--<asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="5" Width="100%" EmptyDataText="No Guards Are Available For This Month."
                            DataSourceID="dsAvailableGuard" PageSize="20" OnRowDataBound="gvAvailableGuards_RowDataBound">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField>
                                <HeaderTemplate>
                                         <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" 
                                            AutoPostBack="true" 
              OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                     </HeaderTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGuard" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Staff_ID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="10px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="Available Security Officers" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" SortExpression="GuardName">
                                    <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard" runat="server" Text='<%# Eval("GuardName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>--%>
                        <telerik:RadGrid ID="gvAvailableGuards" runat="server" CssClass="RadGrid" GridLines="None"
                            AllowPaging="True" PageSize="300" AllowSorting="True" AutoGenerateColumns="False"
                            HeaderStyle-Font-Size="12px" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="Left"
                            DataSourceID="dsAvailableGuard" EmptyDataText="No Guards Are Available For This Month."
                            HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="False"
                            AllowFilteringByColumn="true">
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="Staff_ID">
                                <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                        AllowFiltering="false">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGuard" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Staff_ID") %>' />
                                        </ItemTemplate>
                                        <%-- <HeaderTemplate>
                                         <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="ToggleSelectedState"
                                         AutoPostBack="True" />
                                       </HeaderTemplate>--%>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="GuardName" HeaderText="Available Security Officers"
                                        DataField="GuardName" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                        ShowFilterIcon="false">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <%--  <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                            AllowColumnsReorder="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>--%>
                            <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                        </telerik:RadGrid>
                    </td>
                    <!---Changes In Padding Top By Sandeep Date:7/7/2012-->
                    <td width="20%" align="center" style="border: 1px solid #E4E4E4; padding-top: 2px;
                        padding-bottom: 20px; padding-left: 2px; padding-right: 2px" valign="top">
                        <%-- <asp:GridView ID="gvAvailableSupervisor" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="5" Width="100%" EmptyDataText="No Supervisor Are Available For This Month."
                            DataSourceID="dsAvailableSupervisor" PageSize="20">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField>
                                <HeaderTemplate>
                                         <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" 
                                            AutoPostBack="true" 
              OnCheckedChanged="chkSelectAll_CheckedChanged1" />
                                     </HeaderTemplate>
                                     <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGuard1" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Staff_ID") %>' />
                                        
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="Available Supervisor" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" SortExpression="SupervisorName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupervisor" runat="server" Text='<%# Eval("SupervisorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        --%>
                        <telerik:RadGrid ID="gvAvailableSupervisor" runat="server" CssClass="RadGrid" GridLines="None"
                            AllowPaging="True" PageSize="300" AllowSorting="True" AutoGenerateColumns="False"
                            HeaderStyle-Font-Size="12px" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="Left"
                            DataSourceID="dsAvailableSupervisor" EmptyDataText="No Supervisor Are Available For This Month."
                            HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white" AllowMultiRowSelection="False"
                            AllowFilteringByColumn="true">
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="SupervisorName">
                                <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                        AllowFiltering="false">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                OnCheckedChanged="chkSelectAll_CheckedChanged1" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGuard1" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Staff_ID") %>' />
                                        </ItemTemplate>
                                        <%-- <HeaderTemplate>
                                         <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="ToggleSelectedState"
                                         AutoPostBack="True" />
                                       </HeaderTemplate>--%>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="SupervisorName" HeaderText="Available Supervisor"
                                        DataField="SupervisorName" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                        ShowFilterIcon="false">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <%--  <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                            AllowColumnsReorder="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>--%>
                            <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                        </telerik:RadGrid>
                        <%--</td>
                        </tr>
                        </table>
                        </asp:Panel>--%>
                    </td>
                    <td valign="top">
                        <table style="margin-top: 80px;">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Inset">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblmsgSO" runat="server" Text="Security Officer/Supervisor Already Assigned. Do You Want To Continue ?"
                                                        CssClass="Labels" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="btnyes" runat="server" Text="Yes" BackColor="Fuchsia" OnClick="btnyes_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnNo" runat="server" Text="No" BackColor="Fuchsia" OnClick="btnNo_Click"
                                                        Width="34px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblShiftID2" CssClass="Labels" runat="server" Text="Deploy To Shift : "></asp:Label>
                                    <asp:DropDownList ID="ddlShift" runat="server" Style="margin-top: 10px" CssClass="Input"
                                        DataSourceID="dsShift" DataTextField="Shift" DataValueField="MRID" onchange=""
                                        OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="45" valign="bottom">
                                    <asp:Button ID="btnremark" runat="server" Text="Remark" Visible="true" CssClass="Button"
                                        OnClick="btnremark_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="30">
                                    <asp:Label ID="lblremark" CssClass="Labels" runat="server" Text="Re-Placement Reason"
                                        Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" Visible="False" CssClass="Input"
                                        Width="180px" Height="100px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="30%" style="border: 1px solid #E4E4E4; padding-top: 20px; padding-bottom: 20px"
                        align="center" valign="top">
                        <asp:DataList ID="dlShiftAssignment" runat="server" RepeatLayout="Flow" DataSourceID="dsShiftStaff"
                            OnItemDataBound="dlShiftAssignment_ItemDataBound">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblShift" CssClass="Labels" Font-Bold="true" runat="server" Text='<%# Eval("ShiftName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkUnAssign" runat="server" Style="text-decoration: underline"
                                                CssClass="Labels" OnClick="lnkUnAssign_Click">UnAssign Selected</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblreplacement" CssClass="Labels" Font-Bold="true" runat="server"
                                                Text=''></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkReplacement" runat="server" Style="text-decoration: underline"
                                                CssClass="Labels" OnClick="lnkReplacement_Click">RePlacement</asp:LinkButton><br />
                                        </td>
                                    </tr>
                                </table>
                                <%-- <asp:GridView ID="grdShiftStaff" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="5" Width="90%" CssClass="GridMain" EmptyDataText="No Guards Assigned Yet."
                                    OnRowDataBound="grdShiftStaff_RowDataBound" OnPageIndexChanging="grdShiftStaff_PageIndexChanging"
                                    PageSize="2">
                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                    <RowStyle CssClass="NormalRow" />
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                    OnCheckedChanged="chkSelectAll_CheckedChanged2" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkGuard" CssClass='<%# String.Format("assigned{0}",Eval("MRID")) %>'
                                                    runat="server" ToolTip='<%# Eval("MGAID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned Security Officers" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGuard" runat="server" Text='<%# Eval("GuardName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                                <telerik:RadGrid ID="grdShiftStaff" runat="server" CssClass="RadGrid" GridLines="None"
                                    AllowPaging="True" PageSize="300" AllowSorting="True" AutoGenerateColumns="False"
                                    HeaderStyle-Font-Size="12px" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="Left"
                                    OnItemDataBound="grdShiftStaff_RowDataBound" OnPageIndexChanged="grdShiftStaff_PageIndexChanging"
                                    EmptyDataText="No Guards Assigned Yet." HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white"
                                    AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="GuardName">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                                AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                        OnCheckedChanged="chkSelectAll_CheckedChanged2" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkGuard" CssClass='<%# String.Format("assigned{0}",Eval("MRID")) %>'
                                                        runat="server" ToolTip='<%# Eval("MGAID") %>' />
                                                </ItemTemplate>
                                                <%-- <HeaderTemplate>
                                         <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="ToggleSelectedState"
                                         AutoPostBack="True" />
                                       </HeaderTemplate>--%>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="GuardName" HeaderText="Assigned Security Officers"
                                                DataField="GuardName" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <%--  <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                            AllowColumnsReorder="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>--%>
                                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                </telerik:RadGrid>
                                <asp:HiddenField ID="hdnLocID" runat="server" Value='<%# Eval("MRID") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td width="30%" style="border: 1px solid #E4E4E4; padding-top: 20px; padding-bottom: 20px"
                        align="center" valign="top">
                        <asp:DataList ID="dlShiftAssignment1" runat="server" RepeatLayout="Flow" DataSourceID="dsShiftStaff"
                            OnItemDataBound="dlShiftAssignment1_ItemDataBound">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblShift" CssClass="Labels" Font-Bold="true" runat="server" Text='<%# Eval("ShiftName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkUnAssign1" runat="server" CssClass="Labels" Style="text-decoration: underline"
                                                OnClick="lnkUnAssign1_Click">UnAssign Selected</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblreplacement" CssClass="Labels" Font-Bold="true" runat="server"
                                                Text=''></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkReplacementForSV" runat="server" Style="text-decoration: underline"
                                                CssClass="Labels" OnClick="lnkReplacementForSV_Click">RePlacement</asp:LinkButton><br />
                                        </td>
                                    </tr>
                                </table>
                                <%-- <asp:GridView ID="grdShiftStaff1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="5" Width="90%" CssClass="GridMain" EmptyDataText="No Supervisor Assigned Yet."
                                    OnRowDataBound="grdShiftStaff1_RowDataBound" PageSize="2" OnPageIndexChanging="grdShiftStaff1_PageIndexChanging">
                                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                    <RowStyle CssClass="NormalRow" />
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                    OnCheckedChanged="chkSelectAll_CheckedChanged3" />
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkGuard" CssClass='<%# String.Format("assigned{0}",Eval("MRID")) %>'
                                                    runat="server" ToolTip='<%# Eval("MGAID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned Supervisor" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupervisor" runat="server" Text='<%# Eval("SupervisorName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                                <telerik:RadGrid ID="grdShiftStaff1" runat="server" CssClass="RadGrid" GridLines="None"
                                    AllowPaging="True" PageSize="300" AllowSorting="True" AutoGenerateColumns="False"
                                    HeaderStyle-Font-Size="12px" ShowStatusBar="true" Skin="Simple" HeaderStyle-HorizontalAlign="Left"
                                    OnItemDataBound="grdShiftStaff1_RowDataBound" OnPageIndexChanged="grdShiftStaff1_PageIndexChanging"
                                    EmptyDataText="No Guards Assigned Yet." HeaderStyle-BackColor="#ad1c1c" HeaderStyle-ForeColor="white"
                                    AllowMultiRowSelection="False" AllowFilteringByColumn="true">
                                    <GroupingSettings CaseSensitive="false" />
                                    <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="SupervisorName">
                                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" ShowFilterIcon="false"
                                                AllowFiltering="false">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                                        OnCheckedChanged="chkSelectAll_CheckedChanged3" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkGuard" CssClass='<%# String.Format("assigned{0}",Eval("MRID")) %>'
                                                        runat="server" ToolTip='<%# Eval("MGAID") %>' />
                                                </ItemTemplate>
                                                <%-- <HeaderTemplate>
                                         <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="ToggleSelectedState"
                                         AutoPostBack="True" />
                                       </HeaderTemplate>--%>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="SupervisorName" HeaderText="Assigned Supervisor"
                                                DataField="SupervisorName" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                ShowFilterIcon="false">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <%--  <ClientSettings Selecting-AllowRowSelect="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                                            AllowColumnsReorder="True">
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>--%>
                                    <SelectedItemStyle BorderWidth="0px" Font-Bold="true" ForeColor="White" BackColor="Red" />
                                </telerik:RadGrid>
                                <asp:HiddenField ID="hdnLocID1" runat="server" Value='<%# Eval("MRID") %>' />
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:LinkButton ID="LinkButton1" runat="server" Visible="False"></asp:LinkButton>
                        <asp:HiddenField ID="hdnMessage" runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
   <%-- </ContentTemplate></asp:UpdatePanel>--%>
</asp:Content>
