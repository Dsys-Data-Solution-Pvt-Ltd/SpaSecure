<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminContingencyExercise.aspx.cs" Inherits="SMS.SuperVisor.AdminContingencyExercise"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
      <div class="divHeader">
        <span class="pageTitle">Admin Contingency Exercise</span></div>
           <div id="divAdvSearch" runat="server" visible="true">  
             <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>                                 
        <br />                     
           <table width="900px">
                                        <tr>
                                                <td>
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px"></asp:DropDownList>
                                                </td>
                                                 
                                                <td>
                                                    <asp:Label ID="lblExerciseType" Text="Exercise Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExerciseType" runat="server" CssClass="Input" />
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
                                                    <td height="25px"></td>                                            
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="5">
                                                    <asp:Button ID="btnSearchPassAdd" Text="Search" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnSearchPassAdd_Click"/>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Clear" runat="server" 
                                                        CssClass="Buttons" Width="85px" onclick="btnClearPassAdd_Click"/>
                                                </td>
                                            </tr>
                                        </table>
         </div>
       <br />
           <div style="overflow: auto">
            <asp:gridview id="gvPassTable" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="100%" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" 
                cssclass="GridMain">            
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
                     <asp:BoundField datafield="Exercise_Type" headertext="Exercise Type"></asp:BoundField>
                     <asp:BoundField datafield="Date" headertext="Date"></asp:BoundField>
                     <asp:BoundField datafield="Review" headertext="Review Date"></asp:BoundField> 
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnView" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.ContExericise_id") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px"/>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.ContExericise_id") %>' CommandName="Edit" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.ContExericise_id") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>               
            </Columns>
       </asp:gridview>
  </div>
  <br />
           <div>               
                <asp:button id="btnNewPass" text="Add New Contingency Exercise" runat="server" 
                cssclass="Buttons" Width="208px" onclick="btnNewPass_Click"/>      
          </div>
        <br />
    </div>
</asp:Content>
