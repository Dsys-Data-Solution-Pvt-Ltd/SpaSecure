<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ShiftUpdate.aspx.cs" Inherits="SMS.SMSAdmin.ShiftUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer" align="left">
         <div class="divHeader">
              <span class="pageTitle">Shift Update</span>
         </div>
         <div id="divErr" runat="server">
              <asp:label id="lblErrMsg" cssclass="ValSummary" runat="server" Font-Bold="True" 
               ForeColor="Red"></asp:label>
          </div>
      <br />    
        <table id="tblMain" width="100%">
            <tr>
                <td>
                        <asp:hiddenfield id="hdnBTID" runat="server" value="" />
                        <asp:hiddenfield id="hdnBTName" runat="server" value="" />
                </td>
            </tr>
            <tr>
                <td>                   
                         <table width="950px">
                             <tr>
                                <td>
                                    <asp:Label ID="lblShiftDeployment" CssClass="Labels" runat="server" Text="Shift ID" ></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtaddshiftID" CssClass="Input" runat="server" raedonly="true" 
                                        BackColor="#E6E6E6" Font-Bold="False" ReadOnly="True"></asp:TextBox>
                                </td>
                           
                            <td>
                                <asp:Label ID="lblShiftDeploymentName" CssClass="Labels" runat="server" Text="Shift Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtaddshiftName" CssClass="Input" runat="server"></asp:TextBox>
                            </td>
                   
                                <td>
                                    <asp:Label ID="lblShiftLocationName" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtaddLocationName" CssClass="Input" runat="server"></asp:TextBox>
                                </td>
                     </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblShiftDeploymentDateFrom" CssClass="Labels" runat="server" 
                                        Text="Date: From"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtaddDateFrom" CssClass="Input" runat="server"></asp:TextBox>
                                     <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                            Format="MM/dd/yyyy" TargetControlID="txtaddDateFrom" PopupButtonID="imgBtnFromDate1" />
                                        <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                </td>
                           
                                <td>
                                    <asp:Label ID="lblShiftDeploymentDateTo" CssClass="Labels" runat="server" 
                                        Text=" To"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtaddDateTo" CssClass="Input" runat="server"></asp:TextBox>
                                    
                                     <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                            Format="MM/dd/yyyy" TargetControlID="txtaddDateTo" PopupButtonID="imgBtnFromDate2" />
                                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                </td>
                        </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblShiftDeploymentTimeFrom" CssClass="Labels" runat="server" 
                                        Text="Time: From"></asp:Label>
                                </td>
                                <td>
                                    <MKB:timeselector ID="TimeSelector1" runat="server" MinuteIncrement="1" SecondIncrement="1" SelectedTimeFormat="Twelve" AllowSecondEditing="true"/>
                                </td>
                           
                                <td>
                                    <asp:Label ID="lblShiftDeploymentTimeTo" CssClass="Labels" runat="server" 
                                        Text="To"></asp:Label>
                                </td>
                                <td>
                                    <MKB:timeselector ID="TimeSelector2" runat="server" MinuteIncrement="1" SelectedTimeFormat="Twelve" SecondIncrement="1" AllowSecondEditing="true"/>
                                </td>
                        </tr>
                        </table>
                </td>
            </tr> 
            <tr>
                 <td></td>
            </tr>
            
                         
            <tr>
                
                            <td colspan="10" width="100%" >
                                <div style="overflow:auto">
                               <asp:GridView ID="gvKeySearch" runat="server"                                        
                                        AllowPaging="True" AllowSorting="True" 
                                        AutoGenerateColumns="False" CellPadding="5" CssClass="GridMain" Width="100%"
                                       OnRowDataBound="gvShiftUpdate_RowDataBound" 
                                        OnRowCommand="gvShiftUpdate_RowCommand"
                                        OnPageIndexChanging="gvShiftUpdate_PageIndexChanging"  
                                        onselectedindexchanged="gvShiftUpdate_SelectedIndexChanged">
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
                                           <asp:BoundField datafield="Staff_ID" headertext="Staff Id"></asp:BoundField>
                                           <asp:BoundField datafield="FirstName" headertext="Name"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Staff_ID") %>' CommandName="DeleteRow" runat="server"/>
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px" />

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                  
                                  </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
             </tr>
             
                      <table>
                         <tr>
                                <td>
                                    <asp:Label ID="lblEnterStaffNumber" CssClass="Labels" runat="server" Text="Number of Staff Required"></asp:Label>
                                </td>
                            
                                <td>
                                    <asp:TextBox ID="txtaddNumberofStaff" CssClass="Input" runat="server"  
                                        AutoPostBack ="true" ontextchanged="txtaddNumberofStaff_TextChanged"></asp:TextBox>
                                   &nbsp;&nbsp;  <asp:button Id="btnTotalStaffNo" runat="server" text="Add Staff" 
                                        cssclass="Buttons" onclick="btnTotalStaffNo_Click" />
                                </td>
                           </tr> 
                        </table> 
              
            <tr align="center"> 
        
                    
                     <td colspan="3">
                            <div style="text-align: left">
                               
                                    <div class="divHeader" >
                                         <asp:Label ID="lblStaffNumber" CssClass="Labels" runat="server" Text="Enter Staff ID"></asp:Label>
                                   
                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                             <ContentTemplate>
                                                     <asp:PlaceHolder runat="server" ID="myPlaceHolder"></asp:PlaceHolder>
                                               </ContentTemplate>
                                          <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnTotalStaffNo" EventName="Click" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                 </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <br /><br />
                                       <asp:Label runat="server" ID="MyLabel"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                             </div>  
                    </td>
           </tr>             
            
            <tr>
                    <td>
                    </td>
            </tr>
       </table> 
       <br /> 
       <table align="center" width="600px"> 
            <tr>
            
                      <td align="center">
                          <asp:button ID="btnSave" cssclass="Buttons" runat="server" 
                             text="Save" onclick="Add_ShiftUpdate" Width="85px" />
                         &nbsp;&nbsp; &nbsp;<asp:button ID="btnViewAll" cssclass="Buttons" 
                            runat="server" text="View All" onclick="BtnBack" Width="85px" />
                      </td>
                     
             </tr>
             
         </table>
           <br />               
     </div>
</asp:Content>
