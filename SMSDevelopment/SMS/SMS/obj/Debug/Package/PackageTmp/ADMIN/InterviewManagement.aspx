<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="InterviewManagement.aspx.cs" Inherits="SMS.ADMIN.InterviewManagement" Title="" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Interview Management</span>
        </div>
        <br />
       
        <table align="left" width="900px">
              <tr>
              
                        <td align="left">
                            <asp:label id="lblincidentno" cssclass="Labels" runat="server" text="Status"></asp:label>
                        </td>
                        <td>
                          <asp:DropDownList ID="ddlInterviewStatus" runat="server" CssClass="Input" Width="126px">
                              
                              <asp:ListItem Selected="True">Prescreen</asp:ListItem>
                              <asp:ListItem>Invite for Interview</asp:ListItem>
                              <asp:ListItem>Rejected</asp:ListItem>
                           </asp:DropDownList>
                        </td>
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
               </tr>
                <tr>
                        <td height="20px">
                        </td>
                </tr>
              <tr>
                <td align="Center">
                    <asp:button id="btnSearch" cssclass="Buttons" runat="server" text="Search" 
                         Width="85px" onclick="btnSearch_Click" />
                </td>
                 <td>
                    <asp:button id="btnclear" cssclass="Buttons" runat="server" text="Clear" 
                         Width="85px" Visible="False" />
                </td>
            </tr>
            <tr>
                        <td height="20px">
                        </td>
                </tr>
        </table>
       
        <br />
        
    <div>
        <asp:panel  ID="panel1" runat="server">
        <asp:gridview id="gvItemTable" runat="server"
            allowpaging="True" allowsorting="True"
            autogeneratecolumns="False" cellpadding="5" width="100%"
            onrowdatabound="gvItem_RowDataBound"
            onrowcommand="gvItem_RowCommand" 
            cssclass="GridMain">
            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="There is no Candidate registered in System" runat="server">
                </asp:Label>
            </EmptyDataTemplate>
            <Columns>
            
                        <asp:BoundField DataField="Candidate_Name" HeaderText="Candidate Name"></asp:BoundField>
                        <asp:BoundField DataField="Prescreen_date" HeaderText="Prescreen Date"></asp:BoundField>
                        <asp:BoundField DataField="Candiddate_PhoneNo" HeaderText="Phone Number"></asp:BoundField>
                        <asp:BoundField DataField="Interview_Date" HeaderText="Interview Date"></asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
          
                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Interview_id") %>' CommandName="EditRow" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Interview_id") %>' CommandName="DeleteRow" runat="server"/>
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
          <table width="100%">
                 <tr>  
                    <td>
                        <asp:Button ID="btnAddnewIncident" runat="server" Text="New Prescreen" 
                            cssclass="Buttons" onclick="btnAddnewIncident_Click"/>
                    </td>  
                </tr>
            </table>
    </div>
    <br />
 </div>  
</asp:Content>