<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View7RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View7RiskAssessmentSurvey"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Risk Assessment Survey</span></div>  
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
         
               <table width="100%" cellspacing="8" class="table" style=" background-color:White">
                                           <tr>
                <td colspan="4" style=" height:90px;" align="center">
                <asp:Image runat="server" ID="image1" style="Height:80px; width:100px"></asp:Image>
                   <hr  style=" background-color:Black; color:Black; border-color:Black"></hr>
                </td>
                </tr>       
                                           
                                               
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
                                                    <asp:Label ID="M1" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="Type" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td>  
                                                    <asp:Label ID="txtSectionMType" runat="server" CssClass="Labels"></asp:Label>                                                                                                       
                                                    
                                                </td>   
                                                <td>
                                                      <asp:Label ID="Label30" Text="Manufacturer/Installer" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td>   
                                                    <asp:Label ID="txtSectionMManufacturer" runat="server" CssClass="Labels"></asp:Label>                                                                                                        
                                                    
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
                                                                    <asp:Label ID="ChkDoorContact" runat="server" CssClass="Labels"></asp:Label>                                                                         
                                                              </td>
                                                              <td>
                                                                  
                                                                   <asp:Label ID="ChkWindowContact" runat="server" CssClass="Labels"></asp:Label>       
                                                                      
                                                              </td>
                                                              <td>
                                                                   <asp:Label ID="ChkGlassbreak" runat="server" CssClass="Labels"></asp:Label>       
                                                                  
                                                              </td>
                                                              <td>
                                                                  <asp:Label ID="ChkMotionSensors" runat="server" CssClass="Labels"></asp:Label> 
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
                                                                   <asp:Label ID="ChkProprietary" runat="server" CssClass="Labels"></asp:Label>                                                                   
                                                              </td>
                                                              <td>
                                                                   <asp:Label ID="ChkCentralStation" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>
                                                              <td>
                                                                  <asp:Label ID="ChkPolice" runat="server" CssClass="Labels"></asp:Label>                                                                   
                                                              </td>
                                                              <td>
                                                                  <asp:Label ID="ChkOthers" runat="server" CssClass="Labels"></asp:Label>                                                                   
                                                              </td>
                                                               <td>                                                               
                                                                   <asp:Label ID="M3Other" runat="server" CssClass="Labels"></asp:Label>  
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
                                                      <asp:Label ID="M4" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="5. Does it signal in a central station outside the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                      <asp:Label ID="M5" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="6. Is it connected to facility guard headquarters?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M6" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="7. Is it connected directly to an enforcement headquarters outside the facility proper?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M7" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label6" Text="8. Who responds to alarms?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                                                                         
                                                     <asp:Label ID="M8" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>  
                                                     
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="9. Is there an alarm system protecting high value storage areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M9" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="10. Is there an alarm system protecting other internal areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M10" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                         <tr>
                                                <td>
                                                      <asp:Label ID="Label33" Text="Please(List)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                     <asp:Label ID="M10List" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                                       
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="11. Does this facility have Closed Circuit Television?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M11" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label15" Text="12. If yes, is it monitored continuously? Who monitors?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:Label ID="M12txt" runat="server" CssClass="Labels"></asp:Label>  
                                                </td> 
                                                <td>
                                                    <asp:Label ID="M12" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="13. Is it used for surveillance?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="M13" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="14. Is it used for access control?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M14" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="15. Is it motion / event triggered to record?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="M15" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="16. Is it recorded (constant) 24/7?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M16" runat="server" CssClass="Labels"></asp:Label>  
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
                                                                   <asp:Label ID="ChkVHSTape" runat="server" CssClass="Labels"></asp:Label>     
                                                              </td>
                                                              <td>
                                                                  
                                                                  <asp:Label ID="ChkDVR" runat="server" CssClass="Labels"></asp:Label>         
                                                                    
                                                              </td>
                                                              <td>
                                                                  
                                                                  <asp:Label ID="ChkHardDisc" runat="server" CssClass="Labels"></asp:Label>         
                                                                      
                                                              </td>
                                                              <td>
                                                                  
                                                                  <asp:Label ID="ChkOtherHarddisc" runat="server" CssClass="Labels"></asp:Label>         
                                                              </td>
                                                               <td>                                                                                                                                                                            
                                                                    <asp:Label ID="txtSectionMOtherHarddisc" runat="server" CssClass="Labels"></asp:Label>                                                                         
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
                                                    <asp:Label ID="M18" runat="server" CssClass="Labels"></asp:Label>
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
                                                                      <asp:Label ID="ChBW" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>
                                                              <td>
                                                                      <asp:Label ID="Chkcolor" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>
                                                              <td>
                                                                      <asp:Label ID="ChkInfrared" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>
                                                              <td>
                                                                      <asp:Label ID="ChkPTZ" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>                                                              
                                                              <td>
                                                                      <asp:Label ID="ChkWirlessRF" runat="server" CssClass="Labels"></asp:Label>
                                                              </td>
                                                              <td>                                                                      
                                                                     <asp:Label ID="ChkIP" runat="server" CssClass="Labels"></asp:Label>  
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
                                                     <asp:Label ID="M20" runat="server" CssClass="Labels"></asp:Label>  
                                               </td>                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="21. Is there an inherent weakness in the system itself?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M21" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="22. Is the system supported by properly trained, alert guards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M22" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="23. Is the alarm system for operating areas turned off during working hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M23" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="24. Is the system tested prior to activating it for non-operational periods?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M24" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label48" Text="25. Is the system inspected and maintained regularly by trained personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M25" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label49" Text="26. Are periodic tests conducted frequently to determine the adequacy of response to alarm signals?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M26" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label50" Text="27. Is the system tamper resistant?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M27" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label51" Text="28. Is the system weatherproof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M28" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label52" Text="29. Is an alternate alarm system provided for use in the event of failure of the primary system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M29" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label54" Text="30. Is an alternate or independent source of power available for use in the event of power failure?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M30" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label56" Text="31. Is the emergency power source designed to cut in and operate automatically?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="M31" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label57" Text="32. Are records kept of all alarm signals received to include time, date, location, action taken,
                                                        and cause for alarm?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="M32" runat="server" CssClass="Labels"></asp:Label>  
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
                                                      <asp:Label ID="N1" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                             
                                             
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label59" Text="2. Are they always locked when not is active use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="N2" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>                                 
                                          
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label18" Text="If no, why not?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                     <asp:Label ID="N2Why" runat="server" CssClass="Labels"></asp:Label>  
                                               </td>
                                                
                                           </tr>
                                                                                            
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="3. Is the lock designed or the frame built so that the door cannot be forced by spreading the frame?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="N3" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="4. Are all locks in working order?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="N4" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="5. Are the screws holding the locks firmly in place?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="N5" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                               <td height="65px"></td>
                                          </tr>
                                          
                            </table>    
       
           </asp:Panel>
           
      <table width="738px" style="margin-left:1.5em; height:2.2em; margin-bottom:-0.4em; border: 1px;
                    border-style: groove; border-color: Black; background: url(../Images/1397d40aa687.jpg)">
                    <tr>
                    <td>
            <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" style="margin-left:18em"
                Width="110px" Height="35px" Font-Bold="True" onclick="btnprint_Click"/> 
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
               <asp:Button ID="bntnext" runat="server" CssClass="Buttons" Text="Next" 
                Width="110px" Height="35px" Font-Bold="True" onclick="bntnext_Click"/>   
                
           <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>   
      </td>
                       
    </tr>
     </table>      
        <br />   
           
     </div>
  </div>


</asp:Content>
