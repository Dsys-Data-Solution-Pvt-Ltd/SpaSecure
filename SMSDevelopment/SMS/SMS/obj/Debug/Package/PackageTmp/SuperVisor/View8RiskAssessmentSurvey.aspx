<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="View8RiskAssessmentSurvey.aspx.cs" Inherits="SMS.SuperVisor.View8RiskAssessmentSurvey"  %>
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
                                                      <asp:Label ID="Label3" Text="6. Is the bolt protected or constructed so that it cannot be cut?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="N6" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="7. Are locks’ combinations changed immediately upon resignation, discharge, suspension
                                                         of an employee having possession of a master key(s)?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               <td>
                                                     <asp:Label ID="N7" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                          
                                          </tr>
                                          
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="If no, why not?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="4">                                                                                                         
                                                    <asp:Label ID="N7txt" runat="server" CssClass="Labels"></asp:Label>  
                                                </td> 
                                                
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="8. Are your locks changed on a regular basis regardless of transfers, or known violations of
                                                        security?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                     <asp:Label ID="N8" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                 
                                          </tr>
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label2" Text="If no, why not?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                              
                                                <td colspan="4">                                                                                                         
                                                    <asp:Label ID="N8Why" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                                 
                                          </tr>
                                          
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label7" Text="9. When was the last time the locks were changed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="4">                                                                                                         
                                                   <asp:Label ID="N9" runat="server" CssClass="Labels"></asp:Label>  
                                                </td> 
                                                
                                          </tr>
                                          
                                             <tr>
                                               <td height="45" colspan="4">
                                                 <asp:Label ID="Label4" Text="Section O. KEY CONTROL AND LOCK SECURITY CHECKLIST" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="1. Has a key control officer been appointed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="O1" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                 
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="2. Are locks and keys to all buildings and entrances supervised and controlled by
                                                        the key control officer?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O2" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="3. Does the key control officer have overall authority and responsibility for issuance and replacement
                                                        of locks and keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O3" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label33" Text="4. What is the basis for the issuance of keys, especially master keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                         </tr>
                                         <tr>       
                                                <td colspan="5">                                                                                                         
                                                    <asp:Label ID="O4" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>  
                                                     
                                          </tr>
                                          
                                          <tr>
                                                <td>
                                                      <asp:Label ID="Label6" Text="5. Total keys issued?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                                                                         
                                                    <asp:Label ID="O5Keytxt" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>  
                                                <td>
                                                      <asp:Label ID="Label8" Text="Total Masters" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>                                                                                                         
                                                   <asp:Label ID="O5Master" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>  
                                                <td>
                                                     <asp:Label ID="O5" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="6. Are keys issued only to authorized personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O6" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label15" Text="7. Who determines who is authorized ?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:Label ID="O7txt" runat="server" CssClass="Labels"></asp:Label>  
                                                </td> 
                                                <td>
                                                    <asp:Label ID="O7" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="8. Is the authorization in writing?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O8" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="9. Are keys issued to other than facility personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O9" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="10. Is the removal of keys from the premises prohibited?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O10" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="11. Are keys not in use, secured in a locked, fireproof cabinet?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O11" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                            
                                          
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label46" Text="12. Are these keys tagged and accounted for?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O12" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="13. Is the key cabinet for duplicate keys regarded as an area of high security?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O13" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="14. Is the key or combination to this cabinet maintained under appropriate security or secrecy?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O14" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="15. If the combination is recorded is it secured?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O15" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="16. Are the key lockers and record files in order and current?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O16" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="17. Are keys issued to other than installation personnel?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:Label ID="O17" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td>
                                                      <asp:Label ID="Label25" Text="18. If so, on what basis?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="4">                                                                                                         
                                                    <asp:Label ID="O18" runat="server" CssClass="Labels"></asp:Label>  
                                               </td>
                                                
                                           </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label24" Text="19. Are key issued out of" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O19option" runat="server" CssClass="Labels"></asp:Label>  
                                                </td> 
                                                <td>
                                                     <asp:Label ID="O19" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="20. Are issued keys cross-referenced?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O20" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="21. Are current records maintained indicating the following:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                          </tr>
                                          <tr> 
                                          
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="a. Buildings and/or entrances for which keys are issued?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                    <asp:Label ID="O21A" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="b. Number and identification of keys issued?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O21b" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="c. Location and number of master keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O21c" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label48" Text="d. Location and number of duplicate keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O21d" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label49" Text="e. Issue and turn-in of keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O21e" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label50" Text="f. Location of locks and keys held in reverse?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O21f" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label51" Text="g. Clear record or person to whom key is issued" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="O21g" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label52" Text="22. Is an audit ever made, asking holders to actually produce keys to ensure they have not
                                                        been loaned or lost?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="O22" runat="server" CssClass="Labels"></asp:Label>  
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label54" Text="23. Who is responsible for ascertaining the possessions of keys?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>                                                                                          
                                          </tr>
                                          <tr>
                                               <td colspan="5">                                                                                                         
                                                   <asp:Label ID="O23" runat="server" CssClass="Labels"></asp:Label>  
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
