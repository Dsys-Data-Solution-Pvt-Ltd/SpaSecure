<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminDepartment.aspx.cs" Inherits="SMS.SMSAdmin.AdminDepartment" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Department Master</span></div>
        <table id="tblMain" width="100%">
            <tr>
                <td>
                    <div id="divAdvSearch" runat="server" visible="true">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlAdminDepartmentSearch" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDepartName" Text="Department Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDepartmentNameSearch" runat="server" CssClass="Input" />
                                                </td>
                                                
                                                <td>
                                                    <asp:Label ID="lblDepartmentCode" Text="Department Code" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDepartmentCode" runat="server" CssClass="Input" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnSearchDepartment" Text="Search" runat="server" CssClass="Buttons" />
                                                    <asp:Button ID="btnClearDepartmentAdd" Text="Clear" runat="server" 
                                                        CssClass="Buttons" onclick="btnClearDepartmentAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%-- <div style="overflow:auto">
    <asp:GridView ID="gvSearchKey" 
            runat="server" 
            AllowPaging="true" AllowSorting="true" 
            AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" Width="100%"
            OnRowDataBound="gvBTable_RowDataBound" 
            OnRowCommand="gvBTable_RowCommand" 
            OnPageIndexChanging="gvBTable_PageIndexChanging" CssClass="GridMain">
            
            <HeaderStyle CssClass="HeaderRow"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                <li>To add Billing Table click the Add New Billing Table button.</li>
            </EmptyDataTemplate>
            

            <Columns>
                <asp:BoundField DataField="BillingTableName" HeaderText="Key No"></asp:BoundField>
                <asp:BoundField DataField="PrimaryCurrencyDesc" HeaderText="Description"></asp:BoundField>
                <asp:BoundField DataField="BGrpDesc" HeaderText="No of Keys"></asp:BoundField>
                 <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.BillingTableId") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
    </asp:GridView>
    </div>--%>
    <div>
        <table>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnNewPass" Text="Add New Pass" runat="server" CssClass="Buttons"
                        OnClick="btnNewDepartment_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
