<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="EventPlan.aspx.cs" Inherits="SMS.SMSAdmin.EventPlan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="divContainer">
      <div class="divHeader"><span class="pageTitle">Event Planner</span></div>
     <div id="divAdvSearch" runat="server" visible="true">
      <br /> 
       <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
            <tr><td height="10"></td></tr>
                 <tr>                   
                   <td>
                       <asp:Label ID="lblLocation1" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels"> 
                       </asp:DropDownList>
                       <asp:Label ID="searchid" CssClass="Labels" runat="server" Visible="false"></asp:Label>
                   </td>
                   <td>
                        <asp:Label ID="lblEventType1" CssClass="Labels" runat="server" Text="Event Type"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="DropDownList2" runat="server" CssClass="Labels" 
                            >
                       </asp:DropDownList>
                   </td>
                    <td>
                            <asp:Label ID="lbleventid" CssClass="Labels" runat="server" Text="Event ID" Visible="false"></asp:Label>
                     </td>
                     <td>
                          <asp:TextBox runat="server" ID="txteventid" Text="" CssClass="Input" Visible="false"/>
                      </td>
             
              
            </tr>
                 <tr>
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
                        onclick="imgBtnFromDate2_Click" class="calender"/>
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
                              onclick="imgBtnFromDate3_Click" class="calender"/>
                    </td>
               </tr>  
                 
               <tr>
                    <td height="30px"></td>
               </tr> 
               </table>
            <table  width="100%" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                   <td colspan="4" align="center" style="width: 897px">
                   <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" 
                       onclick="btnSearch1_Click" Width="85px" />
               &nbsp;&nbsp;&nbsp;
                   <asp:Button ID="btnCanel" CssClass="Buttons" runat="server" Text="Clear" 
                        Width="85px" onclick="btnCanel_Click" />
               </td>  
            </tr>
            
          </table>
       </asp:panel>   
    </div>
    <br />
          <div>
    <asp:GridView ID="gvNewEventSearch" 
            runat="server" 
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="5" Width="100%"
            OnRowDataBound="gvNewEvent_RowDataBound" 
            OnRowCommand="gvNewEvent_RowCommand" 
            OnPageIndexChanging="gvNewEvent_PageIndexChanging" CssClass="GridMain2" 
         onselectedindexchanged="gvNewEvent_SelectedIndexChanged" PageSize="100">
            
            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle CssClass="NormalRow"/>
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>
            
                    <asp:BoundField DataField="Date_From" HeaderText="Start Date"></asp:BoundField>
                    <asp:BoundField DataField="Date_To" HeaderText="End Date"></asp:BoundField>
            
                    <asp:BoundField DataField="Start_time" HeaderText="Start Time"></asp:BoundField>
                    <asp:BoundField DataField="End_time" HeaderText="End Time"></asp:BoundField>
                    
                    <%--<asp:BoundField DataField="Event_ID" HeaderText="Event ID"></asp:BoundField>--%>
                    <asp:BoundField DataField="Event_Type" HeaderText="Type"></asp:BoundField>
                    <%--<asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>--%>
               
                    <asp:BoundField DataField="Incharg_Name" HeaderText="Person Incharge"></asp:BoundField>
                    <asp:BoundField DataField="Special_Requirment" HeaderText="Special Requirment"></asp:BoundField>
                    <asp:BoundField DataField="Guard_Requirment" HeaderText="Guard Requirment"></asp:BoundField>
              
               
                 <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>

            <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                   <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Event_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>

             <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>

            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField> 
            </Columns>
    </asp:GridView>
  </div>
         <br /><br />
         <div class="table">
         <table>
         <tr><td>          
               <asp:Button ID="btnAddNewEvent" CssClass="Buttons" runat="server" Text="Add New Event" onclick="btnAddNewEvent_Click" Visible="False" />
        </td></tr>
        </table>
        </div>
   <br />
 </div>


</asp:Content>
