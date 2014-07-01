<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AdminSecurityOfficerBriefing.aspx.cs" Inherits="SMS.SuperVisor.AdminSecurityOfficerBriefing"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Security Officer Briefing</span></div>       
                    <div id="divAdvSearch" runat="server" visible="true">
                        <br />
                                 <table width="900px" class="table">
                                            <tr>                                            
                                                <td>
                                                    <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"></asp:DropDownList>
                                                    <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                                                </td>                                            
                                                <td>
                                                    <asp:Label ID="lblBriefingtype" Text="Briefing Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                  
                                                     <asp:DropDownList ID="txtAlertID" runat="server" CssClass="Labels"></asp:DropDownList>
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
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchAdminAlert" Text="Search" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchAdminAlert_Click" />
                                                         &nbsp;&nbsp;&nbsp;&nbsp; 
                                                    <asp:Button ID="btnClearAdminAlert" Text="Clear" runat="server" 
                                                        CssClass="Buttons"  Width="85px" onclick="btnClearAdminAlert_Click"/>
                                                </td>
                                            </tr>
                                        </table>                        
                    </div>
                <br/>
              <div>
                    <asp:gridview id="gvLoctionTable" runat="server" allowpaging="True" allowsorting="True"
                        autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvLocation_RowDataBound"
                        onrowcommand="gvLocation_RowCommand" onpageindexchanging="gvLocation_PageIndexChanging"
                        cssclass="GridMain2" 
                        onselectedindexchanged="gvLoctionTable_SelectedIndexChanged" PageSize="20">                        
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
                                    <asp:BoundField DataField="DateofBrief" HeaderText="Date"><HeaderStyle Width="200px"/></asp:BoundField>  
                                    <asp:BoundField DataField="TypeofBriefing" HeaderText="Briefing Type"><HeaderStyle Width="200px"/></asp:BoundField>
                                    <asp:BoundField DataField="ReportedTo" HeaderText="Reported To"><HeaderStyle Width="200px"/></asp:BoundField>
                                    <asp:BoundField DataField="Position" HeaderText="Position"><HeaderStyle Width="200px"/></asp:BoundField>
                                    <asp:BoundField DataField="Conducted_By" HeaderText="Conducted By"><HeaderStyle Width="200px"/></asp:BoundField> 
                                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.SOBrief_id") %>' CommandName="View" runat="server"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                                   <ItemTemplate>
                                      <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.SOBrief_id") %>' CommandName="EditRow" runat="server"/>
                                   </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.SOBrief_id") %>' CommandName="DeleteRow" runat="server"/>
                                </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                                       <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField> 
                        </Columns>
            </asp:gridview>
    </div>
  <br />
  <br />
         <div class="table">
             <asp:button id="btnAddNewBriefing" text="Add New Briefing" runat="server" cssclass="Buttons" onclick="btnAddNewBriefing_Click"/>
        </div>
   <br/>
 </div> 
</asp:Content>
