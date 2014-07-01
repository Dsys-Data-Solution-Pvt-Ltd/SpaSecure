<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View5RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View5RiskAssessmentSurvey"  %>
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
                                               <td height="45">
                                                 <asp:Label ID="Label38" Text="Section J. OTHER OPENINGS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="1. Are there manholes that give direct access to your building or to a door
                                                         that a burglar could easily open?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J1" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="2. Have you permanently closed manholes or similar openings that are no longer used?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               <td>
                                                     <asp:Label ID="J2" runat="server" CssClass="Labels"></asp:Label>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="3. Are your sidewalk doors or grates locked properly and secured?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="J3" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="4. Are your sidewalk doors or grates securely in place so that the entire frame
                                                            cannot be pried open?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="J4" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="5. Are your accessible skylights protected with bars or intrusion alarm?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J5" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="6. Eliminate unused skylights that are only an invitation to burglary." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J6" runat="server" CssClass="Labels"></asp:Label>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="7. Are exposed roof hatches properly secured?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="J7" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="8. Are fan openings or ventilator shafts protected?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J8" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="9. Is there a service tunnel or sewer connected to building?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J9" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="10. Do fire escapes comply with city and state fire regulations?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J10" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="11. Are your fire exits or escapes designed so that a person can leave easily but would have
                                                            difficulty in entering?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J11" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="12. Do fire exit doors have a portable alarm mounted to communicate if door is opened,
                                                        or is it hooked up to the intrusion alarm?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="J12" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="13. Can entrance be gained from an adjoining building?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="J13" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label55" Text="Section K. LIGHTING" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                                                                    
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="1. Is the lighting adequate to illuminate critical areas (i.e., alleys, fire escapes,
                                                            ground level windows)?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K1" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label53" Text="2. Foot candles/LUX on horizontal at ground level? (Estimation" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                   <asp:Label ID="K2" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="3. Is there sufficient illumination over entrances?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K3" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="4. Are the perimeter areas lighted to assist police surveillance of the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K4" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="5. Are the protective lighting system and the working lighting system on the same line?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K5" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="6. Are the protective lights controlled by automatic timer?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K6" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="7. Are the protective lights controlled by photo cells ?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K7" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="8. Are the protective lights controlled by manual switches?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K8" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label13" Text="9. During what hours is this lighting used?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="3">                                                                                                         
                                                    <asp:Label ID="K9" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="10. Are all switch boxes and/or automatic timers secured?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K10" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="11. Can protective lights be compromised easily (i.e., unscrewing of bulbs)?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K11" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label25" Text="12. What types of lights are installed around the property?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>  
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="K12" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="13. Are the fixtures vandal proof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K13" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="14. Is there a glare factor?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K14" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="15. Is there an even distribution of light?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K15" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="16. Is the perimeter of the installation protected by adequate lighting?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K16" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label27" Text="17. Are the cones of illuminations from lamps directed downward and away from the facility
                                                        proper and away from guard personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K17" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label28" Text="18. Are lights mounted to provide a strip of light both inside and outside the fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K18" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label29" Text="19. Are lights checked periodically for proper operation and inoperative lamps
                                                        replaced immediately?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K19" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label30" Text="20. Do light beams overlap to provide coverage in case a bulb burns out?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K20" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label31" Text="21. Is additional lighting provided at vulnerable or sensitive areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K21" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label32" Text="22. Are gate guard booths provided with proper illumination?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K22" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label33" Text="23. Are light finishes or stripes used on lower parts of buildings and structures to aid
                                                            guard observation?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K23" runat="server" CssClass="Labels"></asp:Label>
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
