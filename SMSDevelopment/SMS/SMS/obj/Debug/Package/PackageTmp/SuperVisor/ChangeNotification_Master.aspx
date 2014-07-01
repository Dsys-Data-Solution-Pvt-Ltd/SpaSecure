<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ChangeNotification_Master.aspx.cs" Inherits="SMS.SuperVisor.ChangeNotification_Master" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Change Notification</span></div>
                <br/>
                 <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                                 <table width="750px" style=" background-color:White; margin-left:2em">
                                 <tr><td></td></tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px"></asp:DropDownList>
                                                    <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            
                                               <td>
                                                    <asp:Label ID="lblref" Text="Ref" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                  
                                                      <asp:TextBox ID="txtref" CssClass="Input" runat="server"></asp:TextBox>
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
                                                     ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                                               </td>
                                                
                                               <td>
                                                        <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                                                </td>
                                                 <td>
                                                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                                         Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                                         <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                                          ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td height="15px"></td>
                                            
                                            </tr>
                                            
                                        </table>
                     <asp:Panel ID="Panel1" runat="server" style=" width:57.7em; height:2.3em; margin-left:2em; background: url(../Images/1397d40aa687.jpg)">
                     <asp:Button ID="btnSearchAdminAlert" Text="Search" runat="server" style=" margin-left:320px; margin-top:.2em"
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchAdminAlert_Click"/>
                                                         &nbsp;&nbsp;&nbsp;&nbsp; 
                                                    <asp:Button ID="btnClearAdminAlert" Text="Clear" runat="server" 
                                                        CssClass="Buttons"  Width="85px" onclick="btnClearAdminAlert_Click"/>
                     </asp:Panel>
                        
                    </div>
                    
                    <br />
              <div style=" margin:2em">
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="750px" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
                        cssclass="GridMain">                        
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
                            <asp:BoundField DataField="RefNumber" HeaderText="Ref"><HeaderStyle Width="100px" /></asp:BoundField>
                            <asp:BoundField DataField="NotifyDate" HeaderText="Date"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:BoundField DataField="Attn" HeaderText="Attn"><HeaderStyle Width="200px" /></asp:BoundField>
                            <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Notification_id") %>' CommandName="EditRow" runat="server"/>
                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Notification_id") %>' CommandName="DeleteRow" runat="server"/>
                                </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                       <ItemStyle HorizontalAlign="Center"></ItemStyle>
                              </asp:TemplateField> 
                        </Columns>
             </asp:gridview>
    </div>
  <br />
  <br />
       <asp:Panel ID="Panel2" runat="server" style=" width:57.7em; height:2.3em; margin-left:2em; background: url(../Images/1397d40aa687.jpg)">
                    <asp:button id="btnNewLocation" text="New Notification" runat="server" cssclass="Buttons"
                     style="margin-left:320px; margin-top:.2em"   onclick="btnNewLocation_Click" />
       </asp:Panel>
    <br/>
 </div> 
</asp:Content>
