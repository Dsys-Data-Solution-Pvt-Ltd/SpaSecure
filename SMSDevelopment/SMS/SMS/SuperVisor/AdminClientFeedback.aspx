<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="AdminClientFeedback.aspx.cs" Inherits="SMS.SuperVisor.AdminClientFeedback" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
  <div class="divHeader">
     <span class="pageTitle">Client Feedback</span></div>
           <div id="divAdvSearch" runat="server" visible="true">  
             <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                    CssClass="ValSummary"></asp:Label></div>                                 
                  <br />                     
                   <table width="900px" class="table">
                                      <tr>
                                               <td>
                                                    <asp:Label ID="lblAssignment" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"></asp:DropDownList>
                                                    <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>                                                 
                                                <td>
                                                    <asp:Label ID="lblclientname" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtclientname" runat="server" CssClass="Input" />
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
                                                 <td height="25px"></td>                                            
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchPassAdd_Click"/>
                                                       &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Clear" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnClearPassAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
         </div>
       <br />
           <div>
            <asp:gridview id="gvPassTable" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" OnPageIndexChanging="gvPass_PageIndexChanging"
                onselectedindexchanged="gvPass_SelectedIndexChanged"
                cssclass="GridMain2" PageSize="20">            
                    <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center"/>
                    <RowStyle cssclass="NormalRow"/>
                    <AlternatingRowStyle cssclass="AlternateRow"/>
                    <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
                    <SelectedRowStyle cssclass="HighlightedRow"/>
                    <EmptyDataRowStyle cssclass="NoRecords"/>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" text="no record(s) in the system." runat="server">
                        </asp:Label>                
                    </EmptyDataTemplate>
                    <Columns>                    
                             <asp:BoundField datafield="ClientName" headertext="Name"></asp:BoundField>    
                             <asp:BoundField datafield="DateFrom" headertext="Date"><HeaderStyle Width="300px"/></asp:BoundField>                     
                             <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.CF_id") %>' CommandName="View" runat="server"/>
                                </ItemTemplate>
                                 <HeaderStyle Width="50px"/>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.CF_id") %>' CommandName="DeleteRow" runat="server"/>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                          </asp:TemplateField>               
                    </Columns>
       </asp:gridview>
  </div>
  <br />
       <div class="table">                
            <asp:button id="btnNewPass" text="New Client Feedback" runat="server" 
            cssclass="Buttons" Width="202px" onclick="btnNewPass_Click"/>            
          </div>
        <br />
    </div>
</asp:Content>
