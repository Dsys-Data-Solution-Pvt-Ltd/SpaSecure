<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey14.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey14"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Security/ Risk Assessment Survey</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                                                    
                      <table width="80%" class="table" cellspacing="5" style=" background-color:White;"> 
                                           
                                               
                                               
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label43" Text="Section U. SECURITY OFFICER RESPONSIBILITIES & DUTIES" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>    
                                               
                                                                                                    
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="Visitor Control/Escort" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUVisitorControl" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <%-- <asp:ListItem>NA</asp:ListItem> --%>
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           
                                           <tr>     
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="Employee Access Control" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                               <td>
                                                     <asp:DropDownList ID="ddlUEmpAccessControl" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        
                                                     </asp:DropDownList>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="Vehicle Gate Control/Parking Lot" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                     <asp:DropDownList ID="ddlUVehicleGate" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="Loading Dock/Inspection of Vehicles" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlULoadingDock" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="Property Control" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUPropertyControl" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="Inspection of Vehicles" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUInspection" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="Key control" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUKeyContorl" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="Building Tours" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUBuildingTour" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="Operate Patrol Vehicle(s)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUOperatePatrol" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="Cash Handling" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUCashHandling" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="Concierge Services" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUConcierge" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="Monitoring Environmental Conditions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUMonitoring" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="Monitoring Alarm System" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUMonitoringAlarm" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="Monitoring Access Control Systems" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUMonitoringAccess" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="Monitoring CCTV Systems" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUMonitoringCCTV" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="Issuing ID Badges/Access Cards" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUIssuingIDBadges" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="Maintaining/Programming Systems" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUMaintaningSystem" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="Responding To Alarm Events" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUResponding" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="Fire Fighting" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUFireFighting" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="Emergency Medical Response" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUEmergencyMedical" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="Bomb Scares/Emergency Evacuation" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlUBombScares" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label25" Text="Section V. CONTROLS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>    
                                          
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="Detailed Post Orders" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVDetailedPostOrders" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="On Site Supervisor" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVOnSiteSuperVisor" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="Extra Inspections" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVExtraInspection" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="Tour Systems" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVTourSystem" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="Dual Control of keys" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVDualControl" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="Special Background Screening" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVSpecialBackground" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                          
                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="Key Hold Harmless Agreement" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVKeyHold" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="Safe Driving Video" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVSafeDrivingVideo" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                      
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="After Use Vehicle Inspection" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVAfterUseVehicle" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="Vehicle Maintenance Logs" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlVVehicleMaintenance" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                            </table>    
                                           
                       <br />
                       <br />
                                    
                                <table width="100%" class="table" style=" margin-top:-2.2em; background: url(../Images/1397d40aa687.jpg); height:2.2em">          
                                            
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Next" Width="85px" onclick="btnItemAdd_Click"/>
                                                        
                                                          <asp:Label ID="lblid" runat="server" Text="" Visible="False"></asp:Label>
                                                        
                                                   <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px"/>--%>
                                                </td>
                                            </tr>
                                 </table>
                           <br />
                    </div>
    </div>

</asp:Content>
