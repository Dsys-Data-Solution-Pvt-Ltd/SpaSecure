<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="AdminFacilityBooking.aspx.cs" Inherits="SMS.ADMIN.AdminFacilityBooking"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
  <div class="divHeader">
     <span class="pageTitle">Facility Booking</span></div>
           <div id="divAdvSearch" runat="server" visible="true">  
             <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>                                 
        <br />                     
           <table width="900px">
                                        <tr>
                                               <td>
                                                    <asp:Label ID="lbltypeFacility" Text="Type of Facility" CssClass="Labels" 
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlfacility" runat="server" CssClass="Input" Width="130px"></asp:DropDownList>
                                                </td>
                                        </tr>
                                        <tr>  
                                                <td>
                                                    <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtname" runat="server" CssClass="Input" />
                                                </td>       
                                                <td>
                                                    <asp:Label ID="lblunitno" Text="Unit No." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtunitno" runat="server" CssClass="Input" />
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
                                                <td colspan="5">
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
                onrowcommand="gvPass_RowCommand" OnPageIndexChanging="gvPass_PageIndexChanging"
                onselectedindexchanged="gvPass_SelectedIndexChanged"
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
                     <asp:BoundField datafield="Location_name" headertext="Location"></asp:BoundField>                  
                     <asp:BoundField datafield="bookingdateFrom" headertext="Booking Date"></asp:BoundField>                   
                     <asp:BoundField datafield="bookingdateTo" headertext="To Date"></asp:BoundField> 
                     <asp:BoundField datafield="bookingtimeFrom" headertext="Booking Time"></asp:BoundField>                   
                     <asp:BoundField datafield="bookingtimeTo" headertext="To Time"></asp:BoundField>    
                     <asp:BoundField datafield="FacilityType" headertext="Facility Type"></asp:BoundField>
                     <asp:BoundField datafield="Name" headertext="Name"></asp:BoundField>
               <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                       <asp:ImageButton ImageUrl="~/Images/reports-stack.png" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Fbook") %>' CommandName="View" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px"/>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Fbook") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>              
            </Columns>
       </asp:gridview>
  </div>
  <br />
           <div>
                <asp:button id="btnNewFacility" text="Add New Facility Booking" runat="server" 
                 cssclass="Buttons" Width="187px" onclick="btnNewPass_Click"/>                      
          </div>
        <br />
    </div>

</asp:Content>
