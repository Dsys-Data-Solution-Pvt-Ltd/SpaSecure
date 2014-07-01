<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View6RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View6RiskAssessmentSurvey"  %>
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
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="24. Does the facility have a dependable auxiliary source of power?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K24" runat="server" CssClass="Labels"></asp:Label>                                                     
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="25. Is there alternate power for the lighting system independent of the plant lighting
                                                        or the power system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               <td>
                                                    <asp:Label ID="K25" runat="server" CssClass="Labels"></asp:Label>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="26. Is the power supply for lights adequately protected?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="K26" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="27. Is the standby or emergency equipment tested periodically?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K27" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="28. Is emergency equipment designed to go into operation automatically when needed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K28" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="29. Is wiring tested and inspected periodically to ensure proper operation?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K29" runat="server" CssClass="Labels"></asp:Label>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="30. Are multiple circuits used? If so, are proper switching arrangements provided?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K30" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="31. Is wiring for protective lighting securely mounted?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K31" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="a. Is it in tamper-resistant conduits?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K31A" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="b. Is it mounted underground?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K31B" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="c. If above ground, is it high enough to reduce possibility of tampering?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K31C" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="32. Are switches and control properly located, controlled, and protected?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K32" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="a. Are they weatherproof and tamper resistant?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K32A" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="b. Are they readily accessible to security personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K32B" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="c. Are they located so that they are inaccessible from outside the perimeter barrier?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K32C" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="d. Is there a centrally located switch to control protective lighting? Is it vulnerable?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K32D" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="33. Are the lighting systems designed and location recorded so that repairs can be made
                                                         rapidly in an emergency?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K33" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="34. Is adequate lighting for guard use provided on indoor routes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K34" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="35. Are materials and equipment in shipping and storage areas properly arranged to permit
                                                        adequate lighting?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="K35" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="36. If bodies of water form a part of the perimeter, does the lighting conform to other perimeter
                                                        lighting standards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="K36" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label55" Text="Section L. ACCESS CONTROL" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                                                                    
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="1. How is the employee entrance to the facility controlled during normal business hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                           </tr>
                                           
                                            <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="panTypeofFaculty" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>                                                                 
                                                                      
                                                                   <asp:Label ID="ChkKeys" runat="server" CssClass="Labels"></asp:Label>   
                                                              </td>
                                                              <td>                                                                  
                                                                  <asp:Label ID="ChkAccessCard" runat="server" CssClass="Labels"></asp:Label>       
                                                              </td>
                                                              <td>
                                                                 
                                                                  <asp:Label ID="ChkIDBadges" runat="server" CssClass="Labels"></asp:Label>       
                                                              </td>
                                                              <td>                                                                  
                                                                   <asp:Label ID="ChkSecurityOfficer" runat="server" CssClass="Labels"></asp:Label>      
                                                              </td>
                                                              <td>
                                                                 
                                                                  <asp:Label ID="ChkOpenEntry" runat="server" CssClass="Labels"></asp:Label>       
                                                              </td>
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>                
                                                
                                            
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label53" Text="2. How is the employee entrance to the facility controlled after normal business hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                
                                          </tr>
                                          <tr>
                                               <td colspan="7">
                                                   <asp:Panel ID="Panel1" runat="server">
                                                      <table width="100%">
                                                         <tr>
                                                              <td>
                                                                 
                                                                  <asp:Label ID="ChkAfterKeys" runat="server" CssClass="Labels"></asp:Label>           
                                                                      
                                                              </td>
                                                              <td>                                                                 
                                                                  <asp:Label ID="ChkAfterAccessCard" runat="server" CssClass="Labels"></asp:Label>           
                                                              </td>
                                                              <td>                                                                  
                                                                   <asp:Label ID="ChkAfterIDBadges" runat="server" CssClass="Labels"></asp:Label>          
                                                              </td>
                                                              <td>
                                                                  <asp:Label ID="ChkAfterSecurityOfficer" runat="server" CssClass="Labels"></asp:Label>           
                                                              </td>
                                                              <td>
                                                                  
                                                                  <asp:Label ID="ChkAfterOpenEntry" runat="server" CssClass="Labels"></asp:Label>           
                                                              </td>
                                                        </tr>
                                                    </table>
                                                  </asp:Panel>
                                                </td>
                                            </tr>                
                                          
                                          
                                          
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="3. Is there an access control system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L3" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="4. Does this access control system support access levels?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L4" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="5. Does this access control system support Time Zones?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L5" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="6. Are identification badges issued to all employees?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L6" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="7. Is wearing of badges required?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L7" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="8. Is wearing of badges enforced?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L8" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="9. Is there control of employee movement between areas within the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L9" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="10. Is identification required of all visitors entering the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="L10" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label43" Text="11. Are all visitors registered?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L11" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label44" Text="12. Are employees instructed to challenge strangers in their work areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L12" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label13" Text="13. Who is responsible for lock and key control oversight?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="L13" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label25" Text="14. Are locksmith duties responsible by someone on site? Who?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>  
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="L14" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label45" Text="15. Are locksmith duties contracted? Who?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>  
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="L15" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="16. Are combinations or keys accessible only to those individuals who duties require access to them?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L16" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="17. If combination compromise is suspected, is combination changed immediately?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="L17" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="18. Are doors locked when not in active use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L18" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="19. Were any “locked” doors found open during the inspection?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L19" runat="server" CssClass="Labels"></asp:Label>           
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label27" Text="20. Are locks changed immediately upon theft or loss of keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="L20" runat="server" CssClass="Labels"></asp:Label>           
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
