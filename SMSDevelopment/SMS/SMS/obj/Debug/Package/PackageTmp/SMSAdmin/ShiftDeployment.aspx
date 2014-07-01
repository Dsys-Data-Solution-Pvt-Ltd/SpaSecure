<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="ShiftDeployment.aspx.cs" Inherits="SMS.SMSAdmin.ShiftDeployment"
    %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Shift Deployment</span>
        </div>
        <br />
            <table width="900px" >
            <tr>
                <td align="left">
                    <asp:label id="lblShiftID1" cssclass="Labels" runat="server" text="Shift ID"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtStaffNo" cssclass="Input" runat="server"></asp:textbox>
                </td>
            
                <td align="left">
                    <asp:label id="lblShiftName1" cssclass="Labels" runat="server" text="Shift Name"></asp:label>
                </td>
                <td>
                    <asp:textbox id="txtShiftName1" cssclass="Input" runat="server"></asp:textbox>
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
                        onclick="imgBtnFromDate2_Click" style="height: 13px"/>
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
                              onclick="imgBtnFromDate3_Click" style="width: 16px" />
                    </td>
                 
            </tr>
            <tr>
                 <td height="20px" colspan="1"></td>
            </tr>
            <tr>
                
                <td align="left" colspan="3">
                    <asp:button id="btnSearch1" cssclass="Buttons" runat="server" text="Search" 
                        onclick="btnSearch1_Click" Width="85px" />
                   &nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" Text="Clear" runat="server" CssClass="Buttons" 
                   onclick="btnClearItemAdd_Click" Width="85px" />    
                </td>
                
            </tr>
        </table>
        <br />
       <center>
            <div style="overflow: auto">
                <asp:GridView id="gvShiftTable" runat="server" allowpaging="true"
                 allowsorting="true" autogeneratecolumns="false"
                  cellpadding="5" cellspacing="0" width="100%"
                 onrowdatabound="gvShift_RowDataBound"
                  onrowcommand="gvShift_RowCommand"
                   onpageindexchanging="gvShift_PageIndexChanging" cssclass="GridMain" 
                    onselectedindexchanged="gvShiftTable_SelectedIndexChanged" >
            
            <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center" />
            <RowStyle cssclass="NormalRow" />
            <AlternatingRowStyle cssclass="AlternateRow" />
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow" />
            <EmptyDataRowStyle cssclass="NoRecords" />
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>
            
                    <asp:BoundField datafield="ShiftDateFrom" headertext="Date From"></asp:BoundField>    
                    <asp:BoundField datafield="ShiftDateTo" headertext=" Date To"></asp:BoundField>
                    
                    <asp:BoundField datafield="ShiftTimeFrom" headertext="Time From"></asp:BoundField>
                    <asp:BoundField datafield="ShiftTimeTo" headertext="Time To"></asp:BoundField>
                 
                  
                     <asp:BoundField datafield="shift_ID" headertext="Shift ID"></asp:BoundField>
                    <asp:BoundField datafield="shiftdep" headertext="Name "></asp:BoundField>
                
                
                    
                 
                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.shift_ID") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                 <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.shift_ID") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                  </asp:TemplateField> 
                
                
            </Columns>
    </asp:gridview>
            </div>
        </center>
        <br />
        <left>
                <asp:button id="btnAddNewShift2" cssclass="Buttons" runat="server" text="Add New Shift"
                onclick="Button3_Click" />
        </left>
        <br />
        <br />
    </div>
    
</asp:Content>
