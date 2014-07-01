<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="OffLeaveApplication.aspx.cs" Inherits="SMS.SuperVisor.OffLeaveApplication"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
      <div class="divHeader">
         <span class="pageTitle">OFF/ LEAVE APPLICATION FORM</span></div>
           <div>                        
               <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
             </div>
            <br />          
           <div id="divAdvSearch" runat="server" visible="true">
                        <table width="100%">
                        
                        
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblTypeOfLeave" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeOfLeave" runat="server" CssClass="Input" 
                                                            Width="130px" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlTypeOfLeave_SelectedIndexChanged">
                                                        </asp:DropDownList> 
                                                    </td>
                                                    
                                                     <td>
                                                        <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Type of Leave" 
                                                             Visible="False"></asp:Label>
                                                    </td>
                                                    
                                                    <td>
                                                         <asp:TextBox ID="txtaddTypeOfLeave" runat="server" CssClass="Input" Visible="False" /> 
                                                         &nbsp;&nbsp;&nbsp;&nbsp;
                                                         
                                                        <asp:Button ID="btnAddNewType" runat="server" Text="Add New Type" 
                                                             CssClass="Buttons" onclick="btnAddNewType_Click" Visible="False" 
                                                             Width="107px" />
                                                         
                                                    </td>
                                            </tr>
                        
                        
                        
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td colspan="4">
                                                      <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="48%" 
                                                            ReadOnly="True" /> 
                                                    </td>
                                            </tr>
                                            
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNRICno" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                                                    </td>
                                                    <td>
                                                      <asp:TextBox ID="txtNRICno" runat="server" CssClass="Input" ReadOnly="True" /> 
                                                    </td>
                                            </tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblAssignment" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAssignment" runat="server" CssClass="Input" 
                                                            ReadOnly="True" /> 
                                                    </td>
                                            </tr>
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblDateofApplication" CssClass="Labels" runat="server" Text="Date of Application"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateofApplication" runat="server" CssClass="Input" /> 
                                                        <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                                          Format="MM/dd/yyyy" TargetControlID="txtDateofApplication" PopupButtonID="imgBtnFromDate1" />
                                                          <asp:ImageButton ID="imgBtnFromDate1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />                                                    
                                                    </td>
                                            </tr>
                                            
                                               <tr>      
                                                    <td>
                                                        <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Leave Application Period :From"></asp:Label>
                                                    </td>
                                                    <td>
                                                         <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>                            
                                                         <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                                          Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                                                          <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                                    </td>
                                                    <td>
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
                                                   <td>
                                                       <asp:Label ID="lblAssignday" CssClass="Labels" runat="server" 
                                                           Text="Assign Leave Day's" Visible="False"></asp:Label>
                                                   </td>
                                                   <td>
                                                        <asp:TextBox ID="Assignday" CssClass="Input" runat="server" Visible="False"></asp:TextBox>                                                        
                                                   </td>
                                            </tr>
                                            
                                                                                        
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblleavedayCount" CssClass="Labels" runat="server" Text="No. Days Applied"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlleaveDayCount" runat="server" CssClass="Input" AutoPostBack="True" 
                                                            onselectedindexchanged="ddlleaveDayCount_SelectedIndexChanged" 
                                                            Width="100px">
                                                          <asp:ListItem></asp:ListItem>
                                                          <asp:ListItem>1</asp:ListItem>
                                                          <asp:ListItem>2</asp:ListItem>
                                                          <asp:ListItem>3</asp:ListItem>
                                                          <asp:ListItem>4</asp:ListItem>
                                                          <asp:ListItem>5</asp:ListItem>
                                                          <asp:ListItem>6</asp:ListItem>
                                                          <asp:ListItem>7</asp:ListItem>
                                                          <asp:ListItem>8</asp:ListItem>
                                                          <asp:ListItem>9</asp:ListItem>
                                                          <asp:ListItem>10</asp:ListItem>                                                          
                                                        </asp:DropDownList> 
                                                    </td>
                                                     <td>
                                                        <asp:Label ID="lblRemainday" CssClass="Labels" runat="server" Text="Remaining days"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtramainingday" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr>                                                                                       
                                             <tr>                                             
                                                    <td valign="top">
                                                        <asp:Label ID="lblLeaveReason" Text="Leave Reason" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4" height="65">
                                                        <asp:TextBox ID="txtLeaveReason" CssClass="Input" runat="server" Height="100px" 
                                                            Width="600px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>                                                    
                                           </tr>     
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Superior Officer"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtsuperiorOfficer" runat="server" CssClass="Input" Width="95%" /> 
                                                    </td>
                                            </tr>                                                        
                                         <tr>
                                            <td height="50px" colspan="3">
                                            </td>                            
                                        </tr>
                                    <tr>                            
                                            <td colspan="4" align="center" >
                                                 <asp:Button ID="btnNewItemAdd" runat="server" CssClass="Buttons" 
                                                     Text="Submit" Width="85px" onclick="btnNewItemAdd_Click"/>
                                                   &nbsp;&nbsp;&nbsp; &nbsp;              
                                                  <asp:Button ID="btnClearNewItemAdd" runat="server" CssClass="Buttons" 
                                                    Text="Cancel" Width="85px" onclick="btnClearNewItemAdd_Click"/>
                                             </td>
                                   </tr>
                      </table>
           </div>
    <br/>     
 </div>

</asp:Content>
