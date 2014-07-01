<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View9RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View9RiskAssessmentSurvey"  %>
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
                                                      <asp:Label ID="Label3" Text="24. Is a current key control directive in effect?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O24" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="25. Are inventories and inspections conducted by the key control officer to ensure compliance
                                                            with directives?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               <td>
                                                      <asp:Label ID="O25" runat="server" CssClass="Labels"></asp:Label>
                                                </td>    
                                                                               
                                          </tr>                                          
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="How often?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="O25How" runat="server" CssClass="Labels"></asp:Label>
                                                </td> 
                                                
                                          </tr>
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="26. When was the last visual key audit made? (to ensure they had not been loaned, lost or stolen) Date :" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>
                                                <td colspan="5">                                                                                                         
                                                     <asp:Label ID="O26" runat="server" CssClass="Labels"></asp:Label>
                                                </td> 
                                                
                                          </tr>
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label2" Text="27. Were all the keys accounted for? If not, how many were missing?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                     <asp:Label ID="O27" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="28. Are keys turned in during vacation periods?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                      <asp:Label ID="O28" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                 
                                          </tr>
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="29. Are keys turned in when employees resign, are transferred, or are fired?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td>
                                                    <asp:Label ID="O29" runat="server" CssClass="Labels"></asp:Label>
                                                </td>   
                                                
                                          </tr>
                                          
                                         
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="30. Are losses or thefts of keys promptly investigated by the key control personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                      <asp:Label ID="O30" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                 
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="31. Is the removal of keys from the premises prohibited when they are not needed elsewhere?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O31" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="32. Are locks and combinations changed immediately upon loss or theft of keys or transfers
                                                        or resignation of employees?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O32" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label33" Text="33. Are locks changed or rotated within the installation at least annually regardless of transfers
                                                        or known violations of key security?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                         </tr>
                                         <tr>       
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="O33" runat="server" CssClass="Labels"></asp:Label>
                                                </td>  
                                                     
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="34. Are current records kept of combinations to safes and the dates when these combinations
                                                            are changed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                                
                                                <td>
                                                      <asp:Label ID="O34" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="35. Are these records adequately protected?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O35" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="36. Has a system been set up to provide submasters to supervisors and officials on a need basis,
                                                            with facilities divided into different zones or areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                      <asp:Label ID="O36" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="37. If master keys are used, are they devoid of marking identifying them as master keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O37" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="38. Are master keys controlled more closely than change keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O38" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="39. Must all requests for reproduction or duplication of keys be approved by the key control officer?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O39" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="40. Are key holders ever allowed to duplicate keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O40" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                            
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label4" Text="If so, under what circumstances?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                         </tr>
                                         <tr>       
                                                <td colspan="5">                                                                                                         
                                                     <asp:Label ID="O40txt" runat="server" CssClass="Labels"></asp:Label>
                                                </td>  
                                                     
                                          </tr>  
                                            
                                            
                                          
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label46" Text="41 If not, are keys clearly marked “Do Not Duplicate”?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O41" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="42. Where the manufacturer’s serial number on combination locks and padlocks might be visible
                                                       to unauthorized persons, has the number been recorded and then obliterated?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O42" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="43. Are locks on inactive gates and storage facilities under seal?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O43" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="44. Are seals checked regularly by supervisory or key control personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O44" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="45. Are measures in effect to prevent the unauthorized removal of locks on open cabinets,
                                                        gates, or buildings?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="O45" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label55" Text="Section P. OFFICE SECURITY CHECKLIST" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="1. Can entrance be reduced without loss of efficiency?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="P1" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="2. Are office doors locked when unattended for a long period of time?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P2" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="3. Is there a clear view of entrance, stairs, and elevators from receptionist’s desk?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P3" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="4. Are maintenance people, visitors, etc., required to show identification to receptionist?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="P4" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td>
                                                      <asp:Label ID="Label25" Text="If not, why not?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                     <asp:Label ID="P4txt" runat="server" CssClass="Labels"></asp:Label>
                                               </td>
                                                
                                           </tr>
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="5. Are desks and files locked when office is left unattended?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                      <asp:Label ID="P5" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="6. Are items of value left on desks or in an unsecure manner?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P6" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="7. Is all computer hardware secured?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="P7" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label27" Text="8. Are floors from of projections, cracks and debris?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P8" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label28" Text="9. During normal working hours, is the storage facility kept locked when not in use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P9" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label30" Text="10. How many people have keys to this door?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>                                                                                                         
                                                    <asp:Label ID="P10txt" runat="server" CssClass="Labels"></asp:Label>
                                              </td>
                                                <td>
                                                      <asp:Label ID="P10" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          <tr> 
                                          
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="11. Do you restrict office keys to those who actually need them?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                      <asp:Label ID="P11" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="12. Do you keep complete up-to date records of the disposition of all office keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                      <asp:Label ID="P12" runat="server" CssClass="Labels"></asp:Label>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="13. Do you have adequate procedures for collecting keys from former employees?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="P13" runat="server" CssClass="Labels"></asp:Label>
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
