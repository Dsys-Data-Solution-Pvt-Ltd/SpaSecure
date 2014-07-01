<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View3RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View3RiskAssessmentSurvey" %>
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
                                                 <asp:Label ID="Label38" Text="Section D. CRITICAL AREAS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="1. Are there critical or restricted areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="D1" runat="server"  CssClass="Labels" ></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label39" Text="2. What is in these areas" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="D2" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label40" Text="3. How is access to these areas controlled?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="D3" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="4. Do the walls in these areas extend to the structural ceiling or the roof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="D4" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="5. Are these areas alarmed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="D5" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="6. Are these areas monitored by CCTV?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="D6" runat="server"  CssClass="Labels"></asp:Label>   
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="7. Is classified material stored on site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="D7" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="1">
                                                      <asp:Label ID="Label41" Text="Comments:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="D7Comment" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label42" Text="Section E. INTERIOR PHYSICAL CHARACTERISTICS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label43" Text="1. Describe the security problem at this site." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E1" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label44" Text="2. What is the general purpose of site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E2" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label45" Text="3. What are the usual business hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E3" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label46" Text="4. Which hours and days represent high activity use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E4" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label47" Text="5. How many people have access to site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:Label ID="E5" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="6. Is site normally open to the public?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="E6" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                         
                                         
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label48" Text="7. List number of rooms occupied by the various departments and officers." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:Label ID="E7" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label49" Text="8. Who does maintenance?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E8" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label50" Text="9. On what schedule does maintenance operate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E9" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label51" Text="10. List the estimated dollar value of equipment and property in each department/office." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>    
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="E10" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label52" Text="11. What area has the highest dollar value?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E11" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label53" Text="12. What area contains the most sensitive material?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="E12" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label54" Text="Section F. INTERIOR LIGHTING" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="1. Is there a back-up system for emergency lights?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="F1" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="2. Is the lighting provided during the day adequate for security purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="F2" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="3. Is the lighting at night sufficient for security purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="F3" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="4. Is the lighting at night for surveillance by the local police department?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="F4" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label55" Text="Section G. EXTERIOR PHYSICAL CHARACTERISTICS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                                                                    
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="1. Is the fence strong and in good repair?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="G1" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="2. Is the fence height such that an intruder cannot climb over it?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G2" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="3. Is the distance of the fence from building a minimum of 10 feet?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G3" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="4. Are boxes or other materials placed a minimum of 10 feet from the fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G4" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="5. Are there weeds or trash adjoining the building that should be removed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                  <asp:Label ID="G5" runat="server"  CssClass="Labels" ></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="6. Are creates, stock or merchandise allowed to be piled near building?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="G6" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="7. Is there a cleared area on both sides of the fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G7" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="8. Are unsecured overpasses or subterranean passageways near fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="G8" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="9. Are fence gates solid and in good condition?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="G9" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="10. Are fence gates properly locked?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="G10" runat="server" CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="11. Are fence gates’ hinges secure and non-removable?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G11" runat="server"  CssClass="Labels"></asp:Label>   
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="12. What types of locks and chains are used to secure gate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="G12" runat="server"  CssClass="Labels"></asp:Label>   
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
