<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplacementGuard.aspx.cs" Inherits="SMS.SMSAdmin.ReplacementGuard" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
<link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSMain.css" type="text/css" />
<link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSCalander.css" type="text/css" />
<link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSGrid.css" type="text/css" />
</head>
  
<body>
<form id="form11" runat="server">
<script type="text/javascript">
    function jqCheckAll(item, clas) {
        $("." + clas + " [type='checkbox']").attr('checked', item.checked);
    }

    function GetNewData() {
        if ($("[id$=txtdatefrom]").val().trim() != '') {
            $("[id$=btnGetData]").click();
        }
    }

    function CheckShift() {
        if ($("[id$=ddlShift] option:selected").val() == "0") {
            return false;
        }
    }
    </script>
<div>

            <%--         <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                        Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                    <asp:Image ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                        Style="height: 13px" />>--%>

              <asp:SqlDataSource ID="dsAvailableGuard" runat="server" ConnectionString="<%$ ConnectionStrings:SMSConnectionString %>"
                        SelectCommand="usp_GetMonthlyAvailableGuards" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hdnMonthID" Name="MonthID" PropertyName="Value" />
                        </SelectParameters>
             </asp:SqlDataSource>
   <asp:HiddenField ID="hdnMonthID" runat="server" />
<br />
  <asp:GridView ID="gvAvailableGuards" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="5" Width="90%" CssClass="GridMain" EmptyDataText="No Guards Are Available For This Month."
                        DataSourceID="dsAvailableGuard">
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
<br />

  <table width="50%" align="center">
     <tr>
         <td>
             <asp:Label ID="lblcomment" runat="server" Text="Remarks" CssClass="Labels"></asp:Label>
         </td>
         <td>
           <asp:TextBox ID="txtRemarks" CssClass="Input" runat="server" Width="400px" 
                 Height="50px" TextMode="MultiLine"></asp:TextBox>
         </td>         
     </tr>
     <tr>
       <td>
           <asp:Button ID="btnAssign" runat="server" Text="Assign" CssClass="Buttons" 
               onclick="btnAssign_Click" />
       </td>
     </tr>
  </table>
   

</div>
 </form>
</body>
</html>
