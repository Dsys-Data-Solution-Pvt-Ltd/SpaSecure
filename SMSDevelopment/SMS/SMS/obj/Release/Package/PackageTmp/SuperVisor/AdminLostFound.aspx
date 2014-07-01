<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AdminLostFound.aspx.cs" Inherits="SMS.SuperVisor.AdminLostFound"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
     <div class="divHeader"><span class="pageTitle">Lost/ Found Manager</span></div>       
           <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>                                     
            <br />  
            <div id="divAdvSearch" runat="server" visible="true"> 
            <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1em" Font-Bold="True" Width="750px">                               
                           <table width="750px" class="table" style=" background-color:White">    
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="Input"/>
                                                </td>
                                               <td>
                                                    <asp:Label ID="lblNRIC" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>                    
                                                </td>    
                                                <td>
                                                    <asp:TextBox ID="txtNRIC" runat="server" CssClass="Input"/>
                                                </td>
                                            </tr>
                                            <tr>    
                                                <td>
                                                    <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date:  From"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>                                                    
                                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                     Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                     <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                                                    ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                                               </td>                                                
                                                 <td>
                                                       <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>                                                             
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" class="calender"/>
                                                </td>
                                            </tr> 
                                            <tr>
                                                   <td height="20px">
                                                   </td>
                                            </tr>                                           
                                            <tr>
                                                  <td align="left" colspan="5">
                                                                                                      </td>                        
                                               </tr>
                                            </table> 
                                             
                                         <asp:Panel ID="btnPanel" Width="755px" runat="server" 
                               style=" margin-left:0.005em; background:url(../Images/1397d40aa687.jpg)">                                                
                                        <asp:Button ID="btnSearchKeyAdd" Text="Search" runat="server" CssClass="Buttons" 
                                                     style=" margin-left:20em; height:33px"  Width="85px" onclick="btnSearchKeyAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnClearKeyAdd" Text="Clear" runat="server" CssClass="Buttons" 
                                                        style="height:33px"   Width="85px"/>

                                        
                                        </asp:Panel></asp:panel>
                    </div>
                <br />        
   <div style=" margin-left:1.5em; width:750px">    
    <asp:GridView ID="gvKeySearch" 
            runat="server" AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="750px"
            OnRowDataBound="gvNewKey_RowDataBound" 
            OnRowCommand="gvNewKey_RowCommand" 
            OnPageIndexChanging="gvNewKey_PageIndexChanging" CssClass="GridMain2" 
           onrowdeleted="gvKeySearch_RowDeleted" PageSize="20">            
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
                    <asp:BoundField DataField="Date" HeaderText="Date"></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                    <asp:BoundField DataField="LostStatus" HeaderText="LostStatus"></asp:BoundField>                       
                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Lost_ID") %>' CommandName="View" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                 </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Follow-Up Lost/ Found" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Lost_ID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Lost_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
        </div>        
        <br/>        
         <div> 
         <asp:Panel ID="btnPanel1" Width="750px" runat="server" style=" height:36px; margin-left:22px; background:url(../Images/1397d40aa687.jpg)">                                                
                
               <asp:Button ID="btnNew" Text="Add New Lost / Found" runat="server" 
               CssClass="Buttons" onclick="btnNew_Click" style=" height:32px; margin-left:20em; margin-top:3px"/>  
               </asp:Panel>   
         </div>
    <br />
 </div>
</asp:Content>
