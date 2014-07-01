<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="AdminInventoryOut.aspx.cs" Inherits="SMS.ADMIN.AdminInventoryOut" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Inventory Out</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtnric" runat="server" CssClass="Input" Width="180px" />
                    </td>
                    <td>
                        <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblItemType" Text="Item Type" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddItemType" runat="server" Width="180px" CssClass="Input">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblserialNo" Text="Serial No." CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtserialNo" runat="server" CssClass="Input" Width="180px" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                    </td>
                    <td>
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                    </td>
                </tr>
                <tr>
                    <td height="15px">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5">
                        <asp:Button ID="btnSearchLocationAdd" Text="Search" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnSearchLocationAdd_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClearLocationAdd" Text="Clear" runat="server" CssClass="Buttons"
                            Width="85px" OnClick="btnClearLocationAdd_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="overflow: auto">
            <asp:GridView ID="gvLoctionTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" 
                CssClass="GridMain" onpageindexchanging="gvLoctionTable_PageIndexChanging" 
                onselectedindexchanged="gvLoctionTable_SelectedIndexChanged" PageSize="20">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                    </asp:Label>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="FromDate" HeaderText="Issed Date"></asp:BoundField>
                    <asp:BoundField DataField="Item_Type" HeaderText="Item Type"></asp:BoundField>
                    <asp:BoundField DataField="Item_Name" HeaderText="Item Details"></asp:BoundField>
                    <asp:BoundField DataField="Balaceqty" HeaderText="Balance Quantity"></asp:BoundField>
                    <asp:BoundField DataField="Item_Qty" HeaderText="Issued Quantity"></asp:BoundField>
                    <asp:BoundField DataField="FirstName" HeaderText="Issue To"></asp:BoundField>
                    <asp:BoundField DataField="NRICno" HeaderText="NRIC No."></asp:BoundField>
                    <asp:BoundField DataField="Role" HeaderText="Role"></asp:BoundField>
                    <asp:BoundField DataField="SerialNo" HeaderText="Serial No"></asp:BoundField>
                    <asp:BoundField DataField="ModelNo" HeaderText="Model No"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <div>
            <table width="50%">
              <tr>
                 <td>                
                    <asp:Button ID="btnNewInventoryOut" Text="New Inventory Out" runat="server" CssClass="Buttons"
                      OnClick="btnNewInventoryOut_Click" />
                 </td>
                 <td>
                     <asp:Button ID="btnpdf" Text="Exprot to PDF" runat="server" CssClass="Buttons" 
                         onclick="btnpdf_Click" Visible="False"
                     />
                 </td>
                 <td>
                    <asp:Button ID="btnexcel" Text="Export to Excel" runat="server" 
                         CssClass="Buttons" onclick="btnexcel_Click" Visible="False"
                    />
                 </td>
              </tr>
            
            </table>
            
        </div>
        <br />
    </div>
</asp:Content>
