<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AlertReportView.aspx.cs" Inherits="SMS.SuperVisor.AlertReportView"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">View Alert</span></div>
       
                    <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                        <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
                                <table width="750px" class="table">
                                    <tr><td></td></tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAlertType" Text="Alert Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                                
                                                <td>
                                                    <asp:DropDownList ID="ddlAlertType" runat="server" CssClass="Labels">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Person Alert</asp:ListItem>
                                                        <asp:ListItem>Vehicle Alert</asp:ListItem>                                                   
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAlertID" Text="Alert ID" CssClass="Labels" runat="server" 
                                                        Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAlertID" runat="server" CssClass="Input" Visible="False" />
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
                                                    <td height="15px"></td>
                                            
                                            </tr>
                                            </table>
                                            <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                                <td colspan="4" align="center" width="750px">
                                                    <asp:Button ID="btnSearchAdminAlert" Text="Search" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchAdminAlert_Click"/>
                                                         &nbsp;&nbsp;&nbsp;&nbsp; 
                                                    <asp:Button ID="btnClearAdminAlert" Text="Clear" runat="server" 
                                                        CssClass="Buttons"  Width="85px" onclick="btnClearAdminAlert_Click"/>
                                                </td>
                                            </tr>
                                            
                                        </table>
                        </asp:panel>
                    </div>
                <br/>
              <div style=" margin-left:1.5em; width:750px">
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="750px" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
                        cssclass="GridMain2" 
                        onselectedindexchanged="gvLoctionTable_SelectedIndexChanged" 
                        PageSize="100">                        
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
                                    <asp:BoundField DataField="Alert_Type" HeaderText="Alert Type"><HeaderStyle Width="200px"/></asp:BoundField>
                                    <asp:BoundField DataField="AlertBy_Name" HeaderText="Alert By"><HeaderStyle Width="200px"/></asp:BoundField>  
                                    <asp:BoundField DataField="P_Name" HeaderText="Person Name"><HeaderStyle Width="200px"/></asp:BoundField>  
                                    <asp:BoundField DataField="V_ResgistNo" HeaderText="Vehicle Reg. No."><HeaderStyle Width="200px"/></asp:BoundField>  
                                   <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Alert_ID") %>' CommandName="View" runat="server"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>      
                                  <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                     <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Alert_ID") %>' CommandName="DeleteRow" runat="server"/>
                                    </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                           <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField> 
                        </Columns>
            </asp:gridview>
    </div>
  <br />
    <div class="table">
        <table  width="750px" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
        <tr><td colspan="4" align="center" width="750px">
                        <asp:button id="btnNewPersonAlert" text="Add New Person Alert" runat="server" 
                        cssclass="Buttons" onclick="btnNewPersonAlert_Click" />
                         &nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:button id="bntNewVehicleAlert" text="Add New Vehicle Alert" runat="server" 
                        cssclass="Buttons" onclick="bntNewVehicleAlert_Click" />
         </td></tr>
         </table>
    </div>
    <br/>
 </div> 
</asp:Content>
