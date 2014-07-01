<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="ViewContingencyExercise.aspx.cs" Inherits="SMS.SuperVisor.ViewContingencyExercise"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Contingency Exercise</span></div> 
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
             <table width="100%" cellspacing="10">
             
                                            <tr>
                                               <td align="center" colspan="4" height="70px" valign="top">
                                                     <asp:Label ID="Label1" Text="Contingency Exercise Report" CssClass="Labels" 
                                                         runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                                                
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                            
                                                 <td>
                                                    <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                     <asp:Label ID="txtlocation" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>    
                                                 <td>
                                                      <asp:Label ID="lblExerciseType" Text="Exercise Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                       <asp:Label ID="txtExerciseType" CssClass="Labels" runat="server"></asp:Label>
                                                 </td>
                                            </tr>
                                            
                                            <tr>
                                                 <td valign="top">
                                                      <asp:Label ID="lblManagementStaff" Text="Management Staff" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                        <asp:Label ID="txtManagement" CssClass="Labels" runat="server"></asp:Label>
                                                 </td>
                                            </tr>
                                            <tr>
                                                 <td valign="top">
                                                         <asp:Label ID="lblAttendees" Text="Attendees" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                          <asp:Label ID="txtAttendees" CssClass="Labels" runat="server"></asp:Label>
                                                 </td>
                                            </tr>
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblEmergencyType" Text="Emergency Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                           <asp:Label ID="txtEmergencyType" CssClass="Labels" runat="server"></asp:Label>
                                                 </td>
                                            
                                            </tr>
                                              <tr>
                                                    <td>
                                                        <asp:Label ID="lblDate" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4"> 
                                                         <asp:Label ID="txtDate" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr>
                                              <tr>      
                                                    <td>
                                                        <asp:Label ID="lblReviewDate" Text="Review Date" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4">
                                                            <asp:Label ID="txtReviewDate" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                             </tr>
                                             
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblObjective" Text="Objective & Scope" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                          <asp:Label ID="txtObjective" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblContigencyTigger" Text="Contigency Tiggers" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtContigencyTigger" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblMethodology" Text="Methodology (Schedule for preparation and deployment)" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtMethodology" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblRoles" Text="Roles & Responsibilities" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:Label ID="txtRoles" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                            
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblStatusReporting" Text="Status Reporting Processes and Protocols" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtStatusReporting" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblCommunication" Text="Communications Strategy" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtCommunication" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                            <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblResource" Text="Resources Available" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtResource" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                             <tr>
                                                    <td valign="top">
                                                            <asp:Label ID="lblFinding" Text="Findings" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                           <asp:Label ID="txtFinding" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                    <td colspan="4">
                                                            <asp:Label ID="lblheading" Text="Please mark appropriate number (1 = very low, 5 = very high) and Risk Priority Rating" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                             </tr>
                                             <tr>
                                                    <td>
                                                            <asp:Label ID="lblFrequency" Text="Frequency" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                         <asp:Label ID="txtFrequency" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            </tr>
                                             <tr>     
                                                    <td>
                                                         <asp:Label ID="lblSeverity" Text="Severity" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td>
                                                          <asp:Label ID="txtSeverity" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                            
                                                <td>
                                                    <asp:Label ID="lblRiskFrequecy" Text="Risk (Frequency x Severity)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                     <asp:Label ID="txtRiskFrequency" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td>
                                                          <asp:Label ID="lblRiskPriority" Text="Risk Priority Rating" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="4">
                                                            <asp:Label ID="txtRiskPriority" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            </tr>
                                          <tr>
                                                   
                                                     <td>
                                                            <asp:Label ID="lblRecommended" Text="Recommended Control Measures" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="3">
                                                            <asp:Label ID="txtRecommended" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>                                                    
                                                    
                                            </tr>
                                           <tr>
                                                    <td>
                                                          <asp:Label ID="lblRevisedRisk" Text="Revised Risk Priority Rating (F)x (S)=" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                                     <td colspan="4">
                                                          <asp:Label ID="txtRevisedRisk" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td height="30" colspan="4"></td>
                                            </tr>
                                          
                                    </table>
           
       
          </asp:Panel>
           
       <div align="center">
                    <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                    Width="110px" Height="40px" Font-Bold="True" onclick="btnprint_Click"/> 
        </div>    
           
           
     </div>
  </div>


</asp:Content>
