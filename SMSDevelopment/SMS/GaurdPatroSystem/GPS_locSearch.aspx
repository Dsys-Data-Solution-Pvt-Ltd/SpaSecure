<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="GPS_locSearch.aspx.cs" Inherits="GaurdPatroSystem.GPS_locSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <%--<div class="divHeader">
            <span class="pageTitle"> GPS Location Search</span>
        </div>--%>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <%-- </ContentTemplate>        
        </asp:UpdatePanel>--%>
       <asp:Panel ID="pnl1" runat="server" style=" background-color:transparent; width:750px; height:140px; margin-left:18px">
       <table style=" background-color:transparent; width:750px">
       <tr><td><asp:Label ID="SearchLocID" runat="server" Visible="False" Width="20px"></asp:Label></td></tr>
       
       <tr>
       <td colspan="1" style="width:250px">
       <asp:Label ID="lblLocation" Text="Location" runat="server" style=" margin-left:0px; font-size:18px"></asp:Label>
       
       <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="130px" style="margin-left:40px"
                         class="Lable2"  
               onselectedindexchanged="ddllocation_SelectedIndexChanged">
                    </asp:DropDownList>
      
       
       </td>
       <td align="left">
       <asp:Label ID="lbldate" Text="Date From" runat="server" style=" margin-left:0px; font-size:18px"></asp:Label>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:TextBox ID="txtpatrotime" runat="server" Width="33%" OnTextChanged="txtpatrotime_TextChanged" AutoPostBack="true"></asp:TextBox>
             <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                  Format="MM/dd/yyyy" TargetControlID="txtpatrotime" 
                 PopupButtonID="imgBtnFromDate2" />
                  <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
           
       </td>
       </tr>
        <tr><td></td></tr>
         <tr>
         <td colspan="5">
        
         </td>
         </tr>
       </table>    
                    
        
       </asp:Panel>
        <br />
            <asp:Panel ID="panel1" runat="server" Width="750px" style="margin-left:20px; margin-top:-80px">
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
                        <asp:BoundField DataField="LocationID" HeaderText="Location Name"></asp:BoundField>                       
                        <asp:BoundField DataField="FileName" HeaderText="File Name"></asp:BoundField>
                        <asp:BoundField DataField="CurrentDate" HeaderText=" Date"></asp:BoundField>
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/reports-stack.png" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.LocationID") %>'
                                    CommandName="View" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Location") %>'
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
