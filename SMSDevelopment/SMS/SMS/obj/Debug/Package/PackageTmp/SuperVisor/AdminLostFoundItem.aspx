﻿<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminLostFoundItem.aspx.cs" Inherits="SMS.SuperVisor.AdminLostFoundItem"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Lost/ Found Item</span></div>        
               <div id="divAdvSearch" runat="server" visible="true">
                      <br />
                       <%-- <table width="900px">
                                <tr>
                                             <td>
                                                 <asp:Label ID="lblItemNo" Text="Item No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemNo" runat="server" CssClass="Input" />
                                                </td>
                                          
                                                <td align="left">
                                                    <asp:Label ID="lblItemDes" Text="Item Description" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemDes" runat="server" CssClass="Input" />
                                                </td>
                                           
                                                <td align="left">
                                                    <asp:Label ID="lblItemname" Text="Logged In By" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtItemLoggedByName" runat="server" CssClass="Input" />
                                                </td>
                                         </tr>
                                         <tr>
                                                <td align="left">
                                                     <asp:Label ID="lblINo" Text="Signed Out By" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtItemSignedOutBy" runat="server" CssClass="Input" />
                                                </td>
                                                 <td align="left">
                                                        <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                                 </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" 
                                                         ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
                                                            
                                                         <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                         <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                        ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                        onclick="imgBtnFromDate2_Click" style="width: 16px"/>
                                                 </td>
                                                    
                                                <td align"right" align="left">
                                                            <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                <td>
                                                            <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" 
                                                                ontextchanged="txtdateto_TextChanged"></asp:TextBox>
                                                                    
                                                            <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                             Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                             <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" 
                                                              onclick="imgBtnFromDate3_Click" />
                                                </td>
                                         <tr>
                                         
                                                    <td height="20px"></td>
                                         
                                         </tr>
                                         </tr>
                                          
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchItemAdd" Text="Search" runat="server" 
                                                        CssClass="Buttons" onclick="btnSearch_Click" Width="85px"/>
                                                 &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearItemAdd" Text="Clear" runat="server" CssClass="Buttons" 
                                                        onclick="btnClearItemAdd_Click" Width="85px" />
                                                </td>
                                            </tr>
                          
                        </table>--%>
                    </div>  
               <br/>     
                      
             <div>
                <asp:gridview id="gvItemTable" runat="server"
                    allowpaging="True" allowsorting="True"
                    autogeneratecolumns="False" cellpadding="5" width="100%"
                    onrowdatabound="gvItem_RowDataBound"
                    onrowcommand="gvItem_RowCommand" 
                    onpageindexchanging="gvItem_PageIndexChanging"
                    cssclass="GridMain" 
                    onselectedindexchanged="gvItemTable_SelectedIndexChanged" PageSize="20">                    
                    <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
                    <RowStyle CssClass="NormalRow"/>
                    <AlternatingRowStyle CssClass="AlternateRow"/>
                    <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
                    <SelectedRowStyle CssClass="HighlightedRow"/>
                    <EmptyDataRowStyle CssClass="NoRecords"/>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" Text="no record(s) in the system." runat="server">
                        </asp:Label>
                    </EmptyDataTemplate>
                    <Columns>                    
                            <asp:BoundField DataField="loged_Time" HeaderText="In Time"></asp:BoundField>
                            <asp:BoundField DataField="Item_no" HeaderText="Item No."></asp:BoundField>                       
                            <asp:BoundField DataField="Item_Description" HeaderText="Description"></asp:BoundField>
                            <asp:BoundField DataField="loged_Name" HeaderText="Logged In By"></asp:BoundField>
                            <asp:BoundField DataField="Signed_Name" HeaderText="Signed Out By"></asp:BoundField>                          
                            <asp:BoundField DataField="Status" HeaderText="Found/Lost"></asp:BoundField>
                            <asp:BoundField DataField="Found_Nric" HeaderText="Found By"></asp:BoundField>                           
                         <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Item_no") %>' CommandName="EditRow" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Item_no") %>' CommandName="DeleteRow" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                          </asp:TemplateField> 
                    </Columns>
            </asp:gridview>
    </div>
   <div>
             <asp:button id="btnNew" text="Add New Lost/ Found Item" runat="server" 
              cssclass="Buttons" onclick="btnNew_Click"/>
    </div>
   <br />
 </div>
 </asp:Content>
