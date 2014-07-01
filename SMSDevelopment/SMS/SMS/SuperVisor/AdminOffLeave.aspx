<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminOffLeave.aspx.cs" Inherits="SMS.SuperVisor.AdminOffLeave"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">OFF/Leave Applications</span>
        </div>
        <div>                        
               <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
     <%--   <table align="left" width="900px">
              <tr>              
                        <td align="left">
                            <asp:label id="lblincidentno" cssclass="Labels" runat="server" text="Report No."></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtincidentno" cssclass="Input" runat="server"></asp:textbox>
                        </td>
                        
                        
                         <td align="left">
                            <asp:label id="lblplaceofincident" cssclass="Labels" runat="server" text="Place of Incident"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtplaceofincident" cssclass="Input" runat="server"></asp:textbox>
                        </td>
               </tr>
              <tr>       
                        
                        <td>
                                <asp:label id="lblverifiedby" cssclass="Labels" runat="server" text="Verified By"></asp:label>
                        </td>
                        <td>
                                <asp:textbox id="txtverifiedby" cssclass="Input" runat="server"></asp:textbox>
                        </td>
                        
                        
             
                        <td align="left">
                            <asp:label id="lblreport" cssclass="Labels" runat="server" text="Reported By"></asp:label>
                        </td>
                        <td>
                            <asp:textbox id="txtreport" cssclass="Input" runat="server"></asp:textbox>
                        </td>
             </tr>
             <tr>      
                        <td align="left">
                            <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date: From"></asp:Label>
                        </td>
                        <td>
                             <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>                            
                             <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                              Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                              <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
              
                        <td align="left">
                              <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="To"></asp:Label>
                        </td>
                      <td>
                                <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                            
                                <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                        </td>
                        <td align="right" >
                              &nbsp;</td>
                        <td>
                                &nbsp;</td>
                        
                </tr>
                <tr>
                        <td height="20px">
                        </td>
                </tr>
              <tr>
                <td align="Center">
                    <asp:button id="btnSearch" cssclass="Buttons" runat="server" text="Search" 
                         Width="85px" />
                </td>
                 <td>
                    <asp:button id="btnclear" cssclass="Buttons" runat="server" text="Clear" 
                         Width="85px" />
                </td>
            </tr>
             <tr>
                 <td height="25px">
                 
                 </td>
            </tr>
            
            
        </table>--%>
    

    <div>
        <asp:panel  ID="panel1" runat="server">
        <asp:gridview id="gvPassTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="100%"
            onrowdatabound="gvPass_RowDataBound"
            onrowcommand="gvPass_RowCommand" 
            onpageindexchanging="gvPass_PageIndexChanging"
            cssclass="GridMain" 
            onselectedindexchanged="gvPassTable_SelectedIndexChanged" PageSize="20">
            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                 <asp:Label ID="lblNoRecords" Text="There are no records in the system." runat="server">
                            </asp:Label>                           
            </EmptyDataTemplate>
            <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                        <asp:BoundField DataField="NRIC" HeaderText="NRIC No."></asp:BoundField>
                        <asp:BoundField DataField="DateOfApplication" HeaderText="Date Of Application"></asp:BoundField>
                        <asp:BoundField DataField="LeaveDayCount" HeaderText="Applied Days"></asp:BoundField> 
                        <asp:BoundField DataField="Approved_Status" HeaderText="Status"></asp:BoundField>
                        <asp:BoundField DataField="LeaveType" HeaderText="LeaveType"></asp:BoundField>
                        <asp:BoundField DataField="RemainingDays" HeaderText="Remaining Days"></asp:BoundField>                   
                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Leave_id") %>' CommandName="View" runat="server"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Leave_id") %>' CommandName="DeleteRow" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
            </Columns>
    </asp:gridview>
   </asp:panel>
    </div>
    <br />
    <div>
              <asp:Button ID="btnAddnewIncident" runat="server" Text="Add New OFF/ Leave Application" 
               cssclass="Buttons" onclick="btnAddnewIncident_Click" Width="244px"/>                   
    </div>
    <br />
 </div>  
</asp:Content>
