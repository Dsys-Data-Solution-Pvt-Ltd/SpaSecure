<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="UpdateOffLeave.aspx.cs" Inherits="SMS.SuperVisor.UpdateOffLeave"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Update Off/ Leave</span></div>
      <div id="divErr" runat="server">
          <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
           ForeColor="Red"></asp:Label> </div>
          <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
          <asp:HiddenField ID="hdnBTName" runat="server" Value="" />    
        
            <br />          
           <div id="divAdvSearch" runat="server" visible="true">
                    
                       <table width="100%">
                        
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblID" CssClass="Labels" runat="server" Text="Leave ID" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtID" runat="server" CssClass="Input" Visible="False" /> 
                                                    </td>
                                            </tr>
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblTypeOfLeave" CssClass="Labels" runat="server" Text="Type of Leave"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTypeOfLeave" runat="server" CssClass="Input" 
                                                            Width="130px" Enabled="False">
                                                        </asp:DropDownList> 
                                                    </td>
                                                    
                                                     <td>
                                                        <asp:Label ID="lbladdnewType" CssClass="Labels" runat="server" Text="Add Leave Type"></asp:Label>
                                                    </td>
                                                    
                                                    <td>
                                                         <asp:TextBox ID="txtaddTypeOfLeave" runat="server" CssClass="Input"/> 
                                                         &nbsp;&nbsp;&nbsp;&nbsp;
                                                         
                                                        <asp:Button ID="btnAddNewType" runat="server" Text="Add New Type" 
                                                             CssClass="Buttons" onclick="btnAddNewType_Click" />
                                                         
                                                    </td>
                                            </tr>
                                            
                                            
                                            
                        
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblname" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td colspan="4">
                                                      <asp:TextBox ID="txtname" runat="server" CssClass="Input" Width="593px" /> 
                                                    </td>
                                            </tr>
                                            
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblNRICno" CssClass="Labels" runat="server" Text="NRIC No."></asp:Label>
                                                    </td>
                                                    <td>
                                                      <asp:TextBox ID="txtNRICno" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr>
                                            <tr>
                                                   <td>
                                                        <asp:Label ID="lblAssignment" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAssignment" runat="server" CssClass="Input" /> 
                                                    </td>
                                            </tr>
                                             <tr>
                                                   <td>
                                                        <asp:Label ID="lblDateofApplication" CssClass="Labels" runat="server" Text="Date of Application"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDateofApplication" runat="server" CssClass="Input" /> 
                                                         <AJAX:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="AjaxCalendar"
                                                          Format="MM/dd/yyyy" TargetControlID="txtDateofApplication" PopupButtonID="ImageButton1" />
                                                          <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp" />
                                                    
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
                                                        <asp:Label ID="lblleavedayCount" CssClass="Labels" runat="server" Text="No. Days Applied"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlleaveDayCount" runat="server" CssClass="Input" 
                                                            Enabled="False">
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
                                                    <td colspan="4" height="65" valign="top">
                                                        <asp:TextBox ID="txtLeaveReason" CssClass="Input" runat="server" Height="120px" 
                                                            Width="600px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    
                                           </tr>                          
                                            <tr>
                                                     <td>
                                                          <asp:Label ID="lblStatus" CssClass="Labels"  runat="server" Text="Approved Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                         <asp:DropDownList ID="ddlApproved" runat="server" CssClass="Input" Width="130px">                                                           
                                                           <asp:ListItem>Pending</asp:ListItem>                                                           
                                                           <asp:ListItem>Yes</asp:ListItem>                                                           
                                                           <asp:ListItem>No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    
                                                    </td>
                                           
                                           </tr>
                      
                                                        
                            <tr>
                                <td height="50px" colspan="3">
                                </td>
                            
                            </tr>
                            <tr>
                            
                                   <td align="Center" colspan="4" >
                                         <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                           Text="Save" Width="85px" onclick="btnsave_Click"/>
                                           &nbsp;&nbsp;&nbsp; &nbsp;              
                                          <asp:Button ID="btnClear" runat="server" CssClass="Buttons" 
                                           Text="View All" Width="85px" onclick="btnClear_Click"/>
                                     </td>
                           </tr>
                      </table>
                    
                        
          </div>
         <br/>     
        
                                 
                           
          
     </div>

</asp:Content>
