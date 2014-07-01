<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="DailyRoster.aspx.cs" Inherits="SMS.SuperVisor.DailyRoster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function jqCheckAll(item, clas) {
            $("." + clas + " [type='checkbox']").attr('checked', item.checked);
        }
        function jqCheck(item, clas) {
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
        .contextMenu LI.delete A
        {
            background-image: url(../images/page_white_delete.png);
        }
        .contextMenu LI.replace A
        {
            background-image: url(../images/True.gif);
        }
        .contextMenu LI.quit A
        {
            background-image: url(../images/door.png);
        }
        .style1
        {
            width: 12%;
        }
    </style>

    <script type="text/javascript">
        
    </script>

    <asp:HiddenField ID="hdnReplacements" runat="server" />
    <div class="divContainer">
        <div class="divHeader">
            <asp:Button ID="btnRef" runat="server" Text="Refresh" OnClick="btnRef_Click" Style="display: none" />
            <span class="pageTitle">Daily Roster</span>
        </div>
        <br />
        <asp:panel runat="server" ID="Panel3" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" Width="950" >
        <table width="100%" class="table">
            <tr>
                <td align="left" width="15%">
                    <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels" AutoPostBack="true"
                         DataSourceID="dsLocation" DataTextField="Location_name" DataValueField="Location_id"
                        OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" class="style1">
                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select Date"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" onblur="GetNewData();"
                        AutoPostBack="true" OnTextChanged="txtdatefrom_TextChanged1"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                    <asp:Image ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                        class="calender"/>
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="5">
                    <asp:Label ID="lblErr" runat="server" CssClass="Labels" ForeColor="Red" Text="Please Select Proper Date"
                        Visible="False"></asp:Label>
                    <asp:SqlDataSource ID="dsAvailableGuard" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="usp_GetDailyAvailableGuards" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="Dt" Type="DateTime" />
                            <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:HiddenField ID="hdnMonthID" runat="server" />
                    <asp:HiddenField ID="hdnWeekID" runat="server" />
                    <asp:HiddenField ID="hdnHash" runat="server" />
                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="SELECT '0' AS Location_id, '- Select -' AS Location_name UNION SELECT Location_id, Location_name FROM location where Current_Status='Present' order by Location_name Asc">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsShift" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="SELECT '- Select -' AS Shift, 0 AS shift_ID UNION SELECT Shift_Master.ShiftTimeFrom + ' - ' + Shift_Master.ShiftTimeTo AS Shift, Shift_Master.shift_ID FROM LocationShiftMap INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE (LocationShiftMap.LocationID = @LocID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSite" Name="LocID" PropertyName="SelectedValue" />
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
                           AutoPostBack="True" 
                          onselectedindexchanged="drpcharactor_SelectedIndexChanged">
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
             
              
                  <tr>
                      <td align="center" style="border: 1px solid #3366FF; padding-top: 10px;
                    padding-bottom: 10px; width: 30%;" valign="top" width="25%">
                          <table width="95%">
                              <tr>
                                  <td align="left" style="font-size: 8px" valign="bottom">
                                      <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="Deploy To Shift"></asp:Label>
                                  </td>
                                  <td align="left" valign="bottom">
                                      <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="True" 
                                          CssClass="Input" DataSourceID="dsShift" DataTextField="Shift" 
                                          DataValueField="shift_ID" 
                                          OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                                      </asp:DropDownList>
                                  </td>
                              </tr>
                          </table>
                          <asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" 
                              AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" 
                              CssClass="GridMain2" DataSourceID="dsAvailableGuard" 
                              EmptyDataText="No Guards Are Available For This Month." PageSize="20" 
                              Width="90%">
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
                              <table>
                                  <tr>
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
                              </table>
                          </asp:Panel>
                      </td>
                      <td align="center" 
                          style="border: 1px solid #3366FF; padding-top: 10px; padding-bottom: 10px" 
                          valign="top">
                          <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                              AllowSorting="True" AutoGenerateColumns="False" CellPadding="5" 
                              CssClass="GridMain" onrowcommand="GridView1_RowCommand" 
                              onrowdeleting="GridView1_RowDeleting" PageSize="20" Width="100%">
                              <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                              <RowStyle CssClass="NormalRow" />
                              <AlternatingRowStyle CssClass="AlternateRow" />
                              <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                              <SelectedRowStyle CssClass="HighlightedRow" />
                              <EmptyDataRowStyle CssClass="NoRecords" />
                              <Columns>
                                  <%-- <asp:BoundField DataField="Staff_ID" HeaderText="ID"><HeaderStyle Width="10px" /></asp:BoundField>--%>
                                  <asp:BoundField DataField="Shift" HeaderText="shift">
                                  <HeaderStyle Width="350px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="StaffName" HeaderText="StaffName">
                                  <HeaderStyle Width="350px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="StaffID" HeaderText="StaffID">
                                  <HeaderStyle Width="350px" />
                                  </asp:BoundField>
                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="replace" 
                                      ItemStyle-HorizontalAlign="Center">
                                      <ItemTemplate>
                                          <asp:ImageButton ID="btnView" runat="server" 
                                              CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>' 
                                              CommandName="replace" ImageUrl="../Images/reports-stack.png" />
                                      </ItemTemplate>
                                      <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                      <ItemStyle HorizontalAlign="Center" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="profile" 
                                      ItemStyle-HorizontalAlign="Center">
                                      <ItemTemplate>
                                          <asp:ImageButton ID="btnEdit" runat="server" 
                                              CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>' 
                                              CommandName="profile" ImageUrl="../Images/Edit.gif" />
                                      </ItemTemplate>
                                      <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                      <ItemStyle HorizontalAlign="Center" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Delete" 
                                      ItemStyle-HorizontalAlign="Center">
                                      <ItemTemplate>
                                          <asp:ImageButton ID="btnDelete" runat="server" 
                                              CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>' 
                                              CommandName="DeleteRow" ImageUrl="~/Images/Delete.gif" />
                                      </ItemTemplate>
                                      <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                      <ItemStyle HorizontalAlign="Center" />
                                  </asp:TemplateField>
                              </Columns>
                          </asp:GridView>
                          <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                      </td>
                  <tr>
                      <td colspan="2">
                      </td>
                  </tr>
              
        </table>
        </asp:panel>
    </div>
    <%--<ul id="myMenu" class="contextMenu">
        <li class="edit"><a href="#edit" class="temp">View Profile</a></li>
        <li class="delete"><a href="#delete" class="temp">Remove From Duty</a></li>
        <li class="replace"><a href="#replace" class="temp">Replacement</a></li>
    </ul>--%>
</asp:Content>
