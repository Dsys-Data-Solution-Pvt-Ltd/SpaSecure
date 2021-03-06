<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="DailyRoster.aspx.cs" Inherits="SMS.SuperVisor.DailyRoster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblShiftID1" CssClass="Labels" runat="server" Text="Select Location"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="Labels" AutoPostBack="true"
                        DataSourceID="dsLocation" DataTextField="Location_name" DataValueField="Location_id"
                        OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Select Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" onblur="GetNewData();"
                        AutoPostBack="true" OnTextChanged="txtdatefrom_TextChanged1"></asp:TextBox>
                    <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                    <asp:Image ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                        class="calender" />
                </td>
                <td>
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
                            <asp:ControlParameter ControlID="drpcharactor" Name="StartMatch" PropertyName="SelectedValue"
                                Type="String" />
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
        <table width="100%">
            <tr style="display: none">
                <td>
                    <asp:Label ID="lblcharator" Text="Alphabet By" CssClass="Labels" runat="server"></asp:Label>&nbsp;&nbsp;
                    <asp:DropDownList ID="drpcharactor" runat="server" CssClass="Input" AutoPostBack="True"
                        OnSelectedIndexChanged="drpcharactor_SelectedIndexChanged">
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
                <td>
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Inset" Width="300px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblmsgSO" runat="server" CssClass="Labels" Font-Bold="True" Text="Security Officer Already Assigned. Do You Want To Continue ?"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnyes" runat="server" BackColor="Fuchsia" OnClick="btnyes_Click"
                                        Text="Yes" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnNo" runat="server" BackColor="Fuchsia" OnClick="btnNo_Click" Text="No" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" style="border: 1px solid #E4E4E4; padding-top: 10px; padding-bottom: 10px;
                    width: 50%;" valign="top" width="25%">
                    <table width="80%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblText" runat="server" Text="Please Check Security Officer First"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Labels" Text="DeployToShift"></asp:Label>
                            </td>
                            <td align="left" valign="bottom">
                                <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="True" CssClass="Input"
                                    DataSourceID="dsShift" DataTextField="Shift" DataValueField="shift_ID" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblWarning" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <%-- <asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="5" DataSourceID="dsAvailableGuard" EmptyDataText="No Guards Are Available For This Month."
                            PageSize="20" Width="90%">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRow" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" AutoPostBack="true"
                                            OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGuard" runat="server" CssClass="unassigned" ToolTip='<%# Eval("Staff_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Available Security Officers"
                                    ItemStyle-HorizontalAlign="Left" SortExpression="GuardName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuard" runat="server" Text='<%# Eval("GuardName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    --%>
                    <telerik:RadGrid ID="gvAvailableGuards" runat="server" CssClass="RadGrid" Style="border: none;"
                        GridLines="None" AllowPaging="True" PageSize="300" AllowSorting="True" AutoGenerateColumns="False"
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
                <td align="center" style="border: 1px solid #E4E4E4; padding-top: 10px; padding-bottom: 10px"
                    valign="top">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" OnRowCommand="GridView1_RowCommand"
                        OnRowDeleting="GridView1_RowDeleting" PageSize="20" Width="100%">
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                        <RowStyle CssClass="NormalRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                        <SelectedRowStyle CssClass="HighlightedRow" />
                        <EmptyDataRowStyle CssClass="NoRecords" />
                        <Columns>
                            <%-- <asp:BoundField DataField="Staff_ID" HeaderText="ID"><HeaderStyle Width="10px" /></asp:BoundField>--%>
                            <asp:BoundField DataField="Shift" HeaderText="shift">
                                <HeaderStyle Width="350px" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StaffName" HeaderText="StaffName">
                                <HeaderStyle Width="350px" ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StaffID" HeaderText="StaffID">
                                <HeaderStyle Width="350px" ForeColor="White" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="replace" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnView" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>'
                                        CommandName="replace" ImageUrl="../Images/reports-stack.png" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="50px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="profile" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>'
                                        CommandName="profile" ImageUrl="../Images/Edit.gif" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="50px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.StaffID") %>'
                                        CommandName="DeleteRow" ImageUrl="~/Images/Delete.gif" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="50px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="HiddenFieldAdd" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupAdd" runat="server" TargetControlID="HiddenFieldAdd"
            CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminADDpnl">
        </asp:ModalPopupExtender>
        <asp:Panel ID="AdminADDpnl" runat="server" BackColor="White" Height="620px" Width="750px"
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
                    <asp:Panel runat="server" ID="printview" BackColor="White" Style="margin-left:10px"
                        Font-Bold="True" Width="730px">
                        <table width="730px">
                            <tr>
                                <td colspan="3">
                                <center>
                                    <asp:Label ID="lblheading" CssClass="Labels" runat="server" Text="BIODATA " Font-Bold="True"
                                        Font-Size="Medium"></asp:Label></center>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:210px">
                                </td>
                                <td style="width:420px">
                                </td>
                                <td align="left" rowspan="3">
                                    <asp:Image ID="ImgageStaff" runat="server" Width="90px" Height="80px" style="float:right;" />
                                </td>
                            </tr>
                            <tr>
                            <td>
                             <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="Name" Font-Bold="True"></asp:Label></td>
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
                                <asp:LinkButton ID="HypNRICWorkPermit" Text="Nricworkpermit" OnClick="Nricworkpermit_Click" runat="server">Nricworkpermit</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="NSRSWSQModules" Text="NSRSWSQModules" OnClick="NSRSWSQModules_Click"  runat="server">NSRSWSQModules</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="OtherRecognisedCertificate" Text="OtherRecognisedCertificate" OnClick="OtherRecognisedCertificate_Click"  runat="server">OtherRecognisedCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="ExemptionCertificate" Text="ExemptionCertificate"  OnClick="ExemptionCertificate_Click" runat="server">ExemptionCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SecurityOfficerLicense" Text="SecurityOfficerLicense" OnClick="SecurityOfficerLicense_Click"  runat="server">SecurityOfficerLicense</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SIRDScreen" Text="SIRDScreen"  OnClick="SIRDScreen_Click" runat="server">SIRDScreen</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <br />
                    <div style="background-color: #E4E4E4; margin-left:10px; width:730px">
                        <center>
                         <a id="print" href="~/Reports/printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                           <%-- <asp:Button ID="btnprint" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                            <asp:Button ID="ButtonCancel" runat="server" CssClass="Button" Text="Cancel" Width="80px"
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
    <asp:Panel ID="PanelViewer" runat="server" BackColor="White"
        Height="620px" Width="730px" BorderWidth="1px" Style="display: none">
       
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
                            <asp:Button ID="ButtonCancelViewer" runat="server" CssClass="Button"  OnClick="ButtonCancelViewer_Click" Text="Cancel" Width="110px"
                                Height="35px"  Font-Bold="True" />
                        </center>
                   </td>
                   </tr>
                   </table>
                </asp:Panel>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>







    </div>
    <%--<ul id="myMenu" class="contextMenu">
        <li class="edit"><a href="#edit" class="temp">View Profile</a></li>
        <li class="delete"><a href="#delete" class="temp">Remove From Duty</a></li>
        <li class="replace"><a href="#replace" class="temp">Replacement</a></li>
    </ul>--%>
</asp:Content>
