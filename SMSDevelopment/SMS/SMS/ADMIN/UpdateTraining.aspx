<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="UpdateTraining.aspx.cs" Inherits="SMS.ADMIN.UpdateTraining" Title="Update Training" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
       <div class="divHeader">
            <span class="pageTitle">Training Update</span></div>
       <div id="divErr" runat="server">
             <asp:Label ID="lblErrMsg" CssClass="ValSummary" runat="server" Font-Bold="True" 
             ForeColor="Red"></asp:Label>
      </div> 
       <asp:HiddenField ID="hdnBTID" runat="server" Value="" />
        <asp:HiddenField ID="hdnBTName" runat="server" Value="" /> 
   <br />      
       
           <table width="100%">
           
                        <tr>
                            <td>
                                <asp:Label ID="lbltrainingid" Text="Trainging id" CssClass="Labels" 
                                    runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttrainingid" runat="server" CssClass="Input" 
                                    Width="169px" ReadOnly="True" Visible="False" />
                              
                        </tr>
           
                        <tr>
                            <td>
                                <asp:Label ID="lbltraingType" Text="Training Topic" CssClass="Labels" 
                                    runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txttraingType" runat="server" CssClass="Input" 
                                    Width="169px" />
                                <asp:Label ID="lblerr" CssClass="ValSummary" runat="server" Text="*" 
                                 Font-Size="Smaller" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                        
                         <tr>        
                              <td align="left">
                                     <asp:Label ID="lbldatefrom" CssClass="Labels"  runat="server" Text="Start Date"></asp:Label></td>
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
                                   <asp:Label ID="lbldateto" CssClass="Labels"  runat="server" Text="End Date"></asp:Label></td>
                            <td>
                                  <asp:TextBox ID="txtdateto" CssClass="Input" runat="server"></asp:TextBox>
                                                                
                                  <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                                  Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                                  <asp:ImageButton ID="imgBtnFromDate3" runat="server" 
                                  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"/>
                             </td>
                    </tr>
                        
                        
                        
                        <tr>
                                <td>
                                    <asp:Label ID="lblVenue" Text="Venue" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVenue" runat="server" CssClass="Input" Width="169px" />
                                </td>
                        </tr>
                        
                        
                         <tr>
                                <td>
                                    <asp:Label ID="lblfacilitation" Text="Facilitator" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtfacilitation" runat="server" CssClass="Input" 
                                        Width="169px" />
                                </td>
                        </tr>
                        
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblTrainees" Text="Trainees" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTrainees" runat="server" CssClass="Input" Width="700px" 
                                        Height="75px" TextMode="MultiLine" />
                                </td>
                        </tr>
                         
                         
                          <tr>
                            <td height="25">
                            </td>
                         </tr>
                        <tr>
                                <td valign="top">
                                    <asp:Label ID="lblTraineeDetail" Text="Details" CssClass="Labels" 
                                        runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTraineeDetail" runat="server" CssClass="Input" Width="700px" 
                                        Height="85px" TextMode="MultiLine" />
                                </td>
                        </tr>
                         <tr>
                            <td height="35">
                            </td>                         
                         </tr>
                         
                         <tr>
                                    <td colspan="4" align="center">
                                    <asp:Button ID="btnsave" Text="Save" runat="server" 
                                    CssClass="Buttons" Width="85px" onclick="btnsave_Click"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearTraining" Text="View All" runat="server" 
                                    CssClass="Buttons"  Width="85px" onclick="btnClearTraining_Click" /> </td>
                         </tr>
                    </table>
      <br/>  
    </div>

</asp:Content>
