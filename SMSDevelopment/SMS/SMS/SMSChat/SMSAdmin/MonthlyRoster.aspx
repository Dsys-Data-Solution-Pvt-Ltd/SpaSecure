<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="MonthlyRoster.aspx.cs" Inherits="SMS.SuperVisor.MonthlyRoster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <script type="text/javascript">
        function jqCheckAll(item, clas) {
            $("." + clas + " [type='checkbox']").attr('checked', item.checked);
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
        }
    </script>
    
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Monthly Roster</span>
        </div>
        <br />
        <asp:panel runat="server" ID="Panel2" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" Width="950" >
        <table width="100%" class="table">
            <tr>
                <td align="left" style="width: 21%">
                    <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                </td>
                <td align="left" width="20%">
                    <%--<asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels" onchange="GetNewData();"
                        DataSourceID="dsLocation" DataTextField="Location_name" 
                        DataValueField="Location_id" ForeColor="Black">
                    </asp:DropDownList>--%>
                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels"
                        DataSourceID="dsLocation" DataTextField="Location_name" 
                        DataValueField="Location_id" ForeColor="Black">
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
                            <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" 
                                PropertyName="SelectedValue" Type="String" />
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
       
             <tr>
              <td style="width: 21%">
                      <asp:Label ID="lblcharator" Text="Alphabet By" CssClass="Labels" runat="server"></asp:Label>&nbsp;&nbsp;           
                           <asp:DropDownList ID="drpcharactor" runat="server" CssClass="Input" 
                          onselectedindexchanged="drpcharactor_SelectedIndexChanged" 
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
            </tr>
            </table>
           
           <table width="100%" class="table">
            <tr>
                <td width="30%" align="center" style="border: 1px solid #3366FF; padding-top: 20px;
                    padding-bottom: 20px" valign="top">
                    <asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" Width="90%" 
                        CssClass="GridMain2" EmptyDataText="No Guards Are Available For This Month."
                        DataSourceID="dsAvailableGuard" PageSize="20">
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                        <RowStyle CssClass="NormalRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                        <SelectedRowStyle CssClass="HighlightedRow" />
                        <EmptyDataRowStyle CssClass="NoRecords" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" CssClass="unassigned" runat="server" onclick="jqCheckAll(this,'unassigned');" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkGuard" CssClass="unassigned" runat="server" ToolTip='<%# Eval("Staff_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available Security Officers" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" SortExpression="GuardName">
                                <ItemTemplate>
                                    <asp:Label ID="lblGuard" runat="server" Text='<%# Eval("GuardName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="center" valign="middle" width="28%">
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel1" runat="server" BorderStyle="Inset">
                                   <table>
                                     <tr>
                                        <td>
                                            <asp:Label ID="lblmsgSO" runat="server" 
                                                Text="Security Officer Already Assigned. Do You Want To Continue ?" 
                                                CssClass="Labels" Font-Bold="True"></asp:Label>
                                        </td>                                      
                                     </tr>
                                     <tr>
                                         <td align="center">
                                             <asp:Button ID="btnyes" runat="server" Text="Yes" BackColor="Fuchsia" 
                                                 onclick="btnyes_Click" />
                                             &nbsp;&nbsp;&nbsp;
                                             <asp:Button ID="btnNo" runat="server" Text="No" BackColor="Fuchsia" 
                                                 onclick="btnNo_Click" Width="34px" />
                                         </td>
                                     </tr>
                                   
                                   </table>
                                </asp:Panel>                            
                            </td>                        
                        </tr>
                       <tr>
                          <td>
                             <asp:Label ID="lblShiftID2" CssClass="Labels" runat="server" Text="Deploy To Shift : "></asp:Label>
                              <asp:DropDownList ID="ddlShift" runat="server" Style="margin-top: 10px" CssClass="Input"
                                 DataSourceID="dsShift" DataTextField="Shift" DataValueField="MRID" onchange=""
                                OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True">
                              </asp:DropDownList>
                          </td>
                       </tr>
                        <tr>
                          <td height="45" valign="bottom">
                              <asp:Button ID="btnremark" runat="server" Text="Remark" Visible="true" 
                                  CssClass="Buttons" onclick="btnremark_Click"/>                          
                          </td>
                       </tr>
                       <tr>
                          <td valign="top" height="30">
                             <asp:Label ID="lblremark" CssClass="Labels" runat="server" 
                                  Text="Re-Placement Reason" Visible="False"></asp:Label>
                              <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" Visible="False" CssClass="Input"
                                  Width="200px" Height="34px"></asp:TextBox>
                          </td>
                       </tr>
                      
                    </table>
                   
                </td>
                
                <td width="30%" style="border: 1px solid #3366FF; padding-top: 20px; padding-bottom: 20px"
                    align="center" valign="top">
                    <asp:DataList ID="dlShiftAssignment" runat="server" RepeatLayout="Flow" DataSourceID="dsShiftStaff"
                        OnItemDataBound="dlShiftAssignment_ItemDataBound" 
                        onselectedindexchanged="dlShiftAssignment_SelectedIndexChanged"/>
                        <ItemTemplate>
                            <asp:Label ID="lblShift" CssClass="Labels" Font-Bold="true" runat="server" Text='<%# Eval("ShiftName") %>'></asp:Label>&nbsp;&nbsp;<asp:LinkButton
                                ID="lnkUnAssign" runat="server" CssClass="Labels" OnClick="lnkUnAssign_Click">UnAssign Selected</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="lblreplacement" CssClass="Labels" Font-Bold="true" runat="server" Text=''></asp:Label>&nbsp;&nbsp;<asp:LinkButton
                                ID="lnkReplacement" runat="server" CssClass="Labels" OnClick="lnkReplacement_Click">RePlacement</asp:LinkButton><br />
                            <br />
                            <asp:GridView ID="grdShiftStaff" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="5" Width="90%" CssClass="GridMain" EmptyDataText="No Guards Assigned Yet."
                                OnRowDataBound="grdShiftStaff_RowDataBound">
                                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                                <RowStyle CssClass="NormalRow" />
                                <AlternatingRowStyle CssClass="AlternateRow" />
                                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                <SelectedRowStyle CssClass="HighlightedRow" />
                                <EmptyDataRowStyle CssClass="NoRecords" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
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
                            </asp:GridView>
                            <asp:HiddenField ID="hdnLocID" runat="server" Value='<%# Eval("MRID") %>' />
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
         
            <tr>
                <td height="50px" colspan="3">
                    <asp:LinkButton ID="LinkButton1" runat="server" Visible="False"></asp:LinkButton>
                </td>
            </tr>
        </table>
        </asp:panel>
    </div>
</asp:Content>
