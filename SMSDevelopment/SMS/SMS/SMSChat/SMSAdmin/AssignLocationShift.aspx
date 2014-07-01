<%@ Page Title="" Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AssignLocationShift.aspx.cs" Inherits="SMS.SuperVisor.AssignLocationShift" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
    function jqCheckAll(item, clas) {
        $("." + clas + " [type='checkbox']").attr('checked', item.checked);
    }
</script>
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Allocate Shift</span>
        </div>
        <br />
         <asp:panel runat="server" ID="Pnl" BackColor="White" style=" margin-left:1.5em; margin-top: 0px;" Font-Bold="True" Width="880">
            
            <table width="100%" class="table">
            <tr>
                <td align="left" width="15%">
                    <asp:Label ID="lblShiftID1" runat="server" CssClass="Labels" 
                        Text="Select Locations"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:DropDownList ID="ddlSite" runat="server" CssClass="Input" DataSourceID="dsLocation"
                        DataTextField="Location_name" DataValueField="Location_id" Width="200px"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left" width="20%">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="4">
                    <asp:SqlDataSource ID="dsLocation" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        
                        SelectCommand="SELECT 0 AS Location_id, '- Select -' AS Location_name UNION SELECT Location_id, Location_name FROM location  Where Current_Status='Present' order by Location_name Asc">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsShift" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        
                        SelectCommand="SELECT ShiftTimeFrom + ' - ' + ShiftTimeTo AS Shift, shift_ID FROM Shift_Master WHERE (shift_ID NOT IN (SELECT ShiftID FROM LocationShiftMap WHERE (LocationID = @LocID)))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSite" Name="LocID" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsAssignedShifts" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        
                        SelectCommand="SELECT Shift_Master.ShiftTimeFrom + ' - ' + Shift_Master.ShiftTimeTo AS Shift, LocationShiftMap.LSID FROM LocationShiftMap INNER JOIN Shift_Master ON LocationShiftMap.ShiftID = Shift_Master.shift_ID WHERE (LocationShiftMap.LocationID = @LocID)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSite" Name="LocID" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
            </tr>
        </table>
        <table width="100%" class="table">
            <tr>
                <td align="center" style="border: 1px solid #3366FF; padding-top: 20px; padding-bottom: 20px"
                    valign="top" width="30%">
                    <asp:GridView ID="gvAvailableShifts" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" CssClass="GridMain" DataSourceID="dsShift"
                        EmptyDataText="No Available Shifts." Width="90%" PageSize="20">
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                        <RowStyle CssClass="NormalRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                        <SelectedRowStyle CssClass="HighlightedRow" />
                        <EmptyDataRowStyle CssClass="NoRecords" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" CssClass="unassigned" onclick="jqCheckAll(this,'unassigned');" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkShift" runat="server" CssClass="unassigned" ToolTip='<%# Eval("shift_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Shifts" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblShift" runat="server" Text='<%# Eval("Shift") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td align="center" valign="middle" width="28%">
                    <asp:Button ID="btnAllocateShift" runat="server" CssClass="Buttons" Text="Allocate Selected Shifts"
                        OnClick="btnAllocateShift_Click" />
                </td>
                <td align="center" style="border: 1px solid #3366FF; padding-top: 20px; padding-bottom: 20px"
                    valign="top" width="30%">
                    <asp:LinkButton ID="lnkUnAssign" runat="server" CssClass="Labels" style="float:left" OnClick="lnkUnAssign_Click">UnAssign Selected</asp:LinkButton><br />
                    <asp:GridView ID="grdAssignedShift" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" CssClass="GridMain" 
                        EmptyDataText="No shift is assigned yet." Width="90%" 
                        DataSourceID="dsAssignedShifts" PageSize="20">
                        <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                        <RowStyle CssClass="NormalRow" />
                        <AlternatingRowStyle CssClass="AlternateRow" />
                        <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                        <SelectedRowStyle CssClass="HighlightedRow" />
                        <EmptyDataRowStyle CssClass="NoRecords" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" CssClass="assigned" onclick="jqCheckAll(this,'assigned');" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkShift" runat="server" CssClass="assigned" ToolTip='<%# Eval("LSID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Allocated Shifts"
                                ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblShift" runat="server" Text='<%# Eval("Shift") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton1" runat="server" style="float:left" CssClass="Labels" OnClick="lnkUnAssign_Click">UnAssign Selected</asp:LinkButton><br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
        </asp:panel>
    </div>
</asp:Content>
