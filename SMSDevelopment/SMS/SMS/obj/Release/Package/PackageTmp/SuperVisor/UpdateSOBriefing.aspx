<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateSOBriefing.aspx.cs" Inherits="SMS.SuperVisor.UpdateSOBriefing"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
  <div class="divHeader">
    <span class="pageTitle">Update SO Briefing</span></div>
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
                                <asp:Label ID="lblID" Text="Briefing ID" CssClass="Labels" 
                                    runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtID" runat="server" CssClass="Input" 
                                    Width="200px" ReadOnly="True" Visible="False" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <asp:Label ID="lbltypeofBriefing" Text="Type of Briefing" CssClass="Labels" 
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttypeofBriefing" runat="server" CssClass="Input" 
                                    Width="200px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                        
                         <tr>        
                              <td>
                                     <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Date"></asp:Label></td>
                              <td>
                                   <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server"></asp:TextBox>
                                                        
                              <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                                Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                               <asp:ImageButton ID="imgBtnFromDate2" runat="server" 
                              ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                     </tr>
                    
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblLocatlion" Text="Location" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlocation" runat="server" CssClass="Input" Width="200px" />
                                </td>
                        </tr>
                        
                         <tr>
                                <td>
                                    <asp:Label ID="lblAttendees" Text="Attendees" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAttendees" runat="server" CssClass="Input" Width="200px" />
                                </td>
                        </tr>
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblConductedBy" Text="Conducted By" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConductedBy" runat="server" CssClass="Input" 
                                     Width="200px"/>
                                </td>
                        </tr>
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblDetail" Text="Details" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDetail" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr>       
                        
                        <tr>
                            <td height="25">                               
                            </td>                         
                         </tr>
                         
                         
                          <tr>
                                <td>
                                    <asp:Label ID="lblOutcomeHeading" Text="Outcome of Briefing" CssClass="Labels" 
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                          </tr>      
                         
                        <tr>
                                <td>
                                    <asp:Label ID="lblActionDate" Text="Action Date" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txtActionDate" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                  <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                  Format="MM/dd/yyyy" TargetControlID="txtActionDate" PopupButtonID="imgBtnFromDate3" />
                                  <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                        </tr>
                        
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblActionComment" Text="Comments" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActionComment" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr> 
                        
                         <tr>
                            <td height="25">                               
                            </td>                         
                         </tr>
                          <tr>
                                <td>
                                    <asp:Label ID="lblReportedTo" Text="Reported To" CssClass="Labels" 
                                        runat="server" Font-Bold="True"></asp:Label>
                                </td>
                          </tr>      
                         
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblReproedName" Text="Name" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReportedName" runat="server" CssClass="Input" 
                                     Width="200px"/>
                                </td>
                        </tr>
                        <tr>        
                                 <td>
                                    <asp:Label ID="lblPosition" Text="Position" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtposition" runat="server" CssClass="Input" Width="200px"/>
                                </td>
                        </tr>
                                         
                         <tr>
                            <td height="35">                               
                            </td>                         
                         </tr>
                         
                         <tr>
                                   <td align="Center" colspan="4" >
                                         <asp:Button ID="btnsave" runat="server" CssClass="Buttons" 
                                           Text="Save" Width="85px" onclick="btnsave_Click"/>
                                           &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;              
                                          <asp:Button ID="btnView" runat="server" CssClass="Buttons" 
                                           Text="View All" Width="85px" onclick="btnView_Click"/>
                                     </td>
                         </tr>
                    </table>
                    
                        
          </div>
         <br/>     
        
        
                                     
        
        
                                 
                           
          
     </div>

</asp:Content>
