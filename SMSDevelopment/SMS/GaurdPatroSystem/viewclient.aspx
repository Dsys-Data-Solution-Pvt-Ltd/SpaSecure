<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="viewclient.aspx.cs" Inherits="GaurdPatroSystem.viewclient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <table style=" width:600px; height:30px; background-color:transparent; margin-top:50px; margin-left:20px">
        <tr><td>
            <asp:Label ID="Label1" runat="server" Text="Client History" style=" font-size:20px; color:Blue; font-style:italic; text-decoration:Underline"></asp:Label>
        </td></tr>
        </table>
            <asp:Panel ID="panel1" runat="server" Width="750px" style="margin-left:20px; margin-top:0px">
                <asp:GridView ID="gvItemTable" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" Width="750px" PageSize="100" 
                    onrowcommand="gvItemTable_RowCommand" onrowdatabound="gvItemTable_RowDataBound">
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
                        <asp:BoundField DataField="Role" HeaderText="Client Name"></asp:BoundField>                       
                        <asp:BoundField DataField="Location_ID" HeaderText="Location Name"></asp:BoundField>
   
                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Staff_ID") %>'
                                    CommandName="Edit" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Staff_ID") %>'
                                    CommandName="DeleteRow" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
       
        <br />
        
        <br />
    </div>


</asp:Content>
