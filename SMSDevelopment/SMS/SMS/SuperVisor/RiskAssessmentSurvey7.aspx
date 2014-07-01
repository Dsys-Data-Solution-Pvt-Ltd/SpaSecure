<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey7.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey7"  %>
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
                                               <td height="45" colspan="4">
                                                 <asp:Label ID="Label28" Text="Section M. ALARMS & CCTV" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                                            
                                               
                                                                                                    
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="1. Does this facility have an intrusion alarm system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlSectionMFacility" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td>                                                                                                         
                                                    <asp:TextBox ID="txtSectionMType" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>   
                                                <td>
                                                      <asp:Label ID="Label30" Text="Manufacturer/Installer" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td>                                                                                                         
                                                    <asp:TextBox ID="txtSectionMManufacturer" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>  
                                                                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label31" Text="2. What Sensors?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="Panel2" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkDoorContact" runat="server" CssClass="Labels" 
                                                                      Text="Door Contacts" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkWindowContact" runat="server" CssClass="Labels" 
                                                                      Text="Window Contacts" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkGlassbreak" runat="server" CssClass="Labels" 
                                                                      Text="Glass Break Sensors" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkMotionSensors" runat="server" CssClass="Labels" 
                                                                      Text="Motion Sensors" />
                                                              </td>
                                                             
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>                
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label32" Text="3. Who does monitoring?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="Panel3" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkProprietary" runat="server" CssClass="Labels" 
                                                                      Text="Proprietary" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkCentralStation" runat="server" CssClass="Labels" 
                                                                      Text="Central Station" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkPolice" runat="server" CssClass="Labels" 
                                                                      Text="Police" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkOthers" runat="server" CssClass="Labels" 
                                                                      Text="Others" />
                                                              </td>
                                                               <td>                                                                                                         
                                                                    <asp:TextBox ID="M3Other" runat="server" CssClass="Input" Width="138px"></asp:TextBox>
                                                                </td> 
                                                             
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>                
                                          
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="4. Does the system indicate an alert only within the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               <td>
                                                     <asp:DropDownList ID="M4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="5. Does it signal in a central station outside the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                     <asp:DropDownList ID="M5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="6. Is it connected to facility guard headquarters?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="7. Is it connected directly to an enforcement headquarters outside the facility proper?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label6" Text="8. Who responds to alarms?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                                                                         
                                                    <asp:TextBox ID="M8" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>  
                                                     
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="9. Is there an alarm system protecting high value storage areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M9" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="10. Is there an alarm system protecting other internal areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M10" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         <tr>
                                                <td>
                                                      <asp:Label ID="Label33" Text="Please(List)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                    <asp:TextBox ID="txtSectionMPleaseList" runat="server" CssClass="Input" 
                                                        Width="90%"></asp:TextBox>
                                                </td>  
                                                     
                                          </tr>
                                         
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="11. Does this facility have Closed Circuit Television?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label15" Text="12. If yes, is it monitored continuously? Who monitors?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtSectionMmonitoredContinuously" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="M12" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="13. Is it used for surveillance?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M13" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="14. Is it used for access control?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M14" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="15. Is it motion / event triggered to record?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M15" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="16. Is it recorded (constant) 24/7?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M16" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="17. Recorded to:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                           <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="Panel4" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkVHSTape" runat="server" CssClass="Labels" 
                                                                      Text="VHS Tape" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkDVR" runat="server" CssClass="Labels" 
                                                                      Text="DVR" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkHardDisc" runat="server" CssClass="Labels" 
                                                                      Text="Hard Disc" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkOtherHarddisc" runat="server" CssClass="Labels" 
                                                                      Text="Others" />
                                                              </td>
                                                               <td>                                                                                                         
                                                                    <asp:TextBox ID="txtSectionMOtherHarddisc" runat="server" CssClass="Input"></asp:TextBox>
                                                                </td> 
                                                             
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>
                                          
                                          
                                          
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label46" Text="18. Is the camera type sufficient for the application/ location?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlSectionMCameraType" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label47" Text="19. Cameras in use:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                           <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="Panel5" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>
                                                                  <asp:CheckBox ID="ChBW" runat="server" CssClass="Labels" 
                                                                      Text="B&W" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="Chkcolor" runat="server" CssClass="Labels" 
                                                                      Text="Color" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkInfrared" runat="server" CssClass="Labels" 
                                                                      Text="Infrared" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkPTZ" runat="server" CssClass="Labels" 
                                                                      Text="PTZ" />
                                                              </td>
                                                              
                                                              <td>
                                                                  <asp:CheckBox ID="ChkWirlessRF" runat="server" CssClass="Labels" 
                                                                      Text="Wireless RF" />
                                                              </td>
                                                              <td>
                                                                  <asp:CheckBox ID="ChkIP" runat="server" CssClass="Labels" 
                                                                      Text="IP" />
                                                              </td>
                                                              
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>
                                          
                                          
                                          
                                             <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label36" Text="20. Who responds to events?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="M20" runat="server" CssClass="Input" 
                                                        Width="270px"></asp:TextBox>
                                               </td>                                       
                                          </tr>
                                          
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="21. Is there an inherent weakness in the system itself?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M21" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="22. Is the system supported by properly trained, alert guards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M22" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="23. Is the alarm system for operating areas turned off during working hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M23" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="24. Is the system tested prior to activating it for non-operational periods?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M24" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label48" Text="25. Is the system inspected and maintained regularly by trained personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M25" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label49" Text="26. Are periodic tests conducted frequently to determine the adequacy of response to alarm signals?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M26" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label50" Text="27. Is the system tamper resistant?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M27" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label51" Text="28. Is the system weatherproof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M28" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label52" Text="29. Is an alternate alarm system provided for use in the event of failure of the primary system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M29" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label54" Text="30. Is an alternate or independent source of power available for use in the event of power failure?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M30" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label56" Text="31. Is the emergency power source designed to cut in and operate automatically?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M31" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label57" Text="32. Are records kept of all alarm signals received to include time, date, location, action taken,
                                                        and cause for alarm?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="M32" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                          
                                          
                                          
                                          
                                           <tr>
                                               <td height="45" colspan="3">
                                                 <asp:Label ID="Label55" Text="Section N. LOCKS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label58" Text="1. Are all entrances equipped with secure locking devices?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="N1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                             
                                             
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label59" Text="2. Are they always locked when not is active use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="N2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>                                 
                                          
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label18" Text="If no, why not?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                    <asp:TextBox ID="txtN2" runat="server" CssClass="Input" Width="90%"></asp:TextBox>
                                               </td>
                                                
                                           </tr>
                                                                                            
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="3. Is the lock designed or the frame built so that the door cannot be forced by spreading the frame?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="N3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="4. Are all locks in working order?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="N4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="5. Are the screws holding the locks firmly in place?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="N5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
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
