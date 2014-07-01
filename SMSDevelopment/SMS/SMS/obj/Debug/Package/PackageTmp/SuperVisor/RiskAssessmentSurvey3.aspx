<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey3.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey3"  %>
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
                                                 <asp:Label ID="Label38" Text="Section D. CRITICAL AREAS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="1. Are there critical or restricted areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="D1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label39" Text="2. What is in these areas" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="D2" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label40" Text="3. How is access to these areas controlled?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="D3" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="4. Do the walls in these areas extend to the structural ceiling or the roof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="D4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="5. Are these areas alarmed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="D5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="6. Are these areas monitored by CCTV?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="D6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="7. Is classified material stored on site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="D7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label41" Text="Comments:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="Dcomment" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
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
                                                    <asp:TextBox ID="E1" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label44" Text="2. What is the general purpose of site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E2" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label45" Text="3. What are the usual business hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E3" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label46" Text="4. Which hours and days represent high activity use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E4" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label47" Text="5. How many people have access to site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E5" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="6. Is site normally open to the public?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="E6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label48" Text="7. List number of rooms occupied by the various departments and officers." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E7" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label49" Text="8. Who does maintenance?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E8" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label50" Text="9. On what schedule does maintenance operate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E9" runat="server" CssClass="Input" 
                                                        Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label51" Text="10. List the estimated dollar value of equipment and property in each department/office." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>    
                                                <td colspan="5">                                                                                                         
                                                    <asp:TextBox ID="E10" runat="server" CssClass="Input" 
                                                        Width="90%"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label52" Text="11. What area has the highest dollar value?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E11" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label53" Text="12. What area contains the most sensitive material?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                              
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="E12" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
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
                                                     <asp:DropDownList ID="F1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="2. Is the lighting provided during the day adequate for security purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="F2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="3. Is the lighting at night sufficient for security purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="F3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" 
                                                          Text="4. Is the lighting at night for surveillance by the  police department?" 
                                                          CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="F4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
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
                                                     <asp:DropDownList ID="G1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="2. Is the fence height such that an intruder cannot climb over it?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="3. Is the distance of the fence from building a minimum of 10 feet?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="4. Are boxes or other materials placed a minimum of 10 feet from the fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="5. Are there weeds or trash adjoining the building that should be removed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="6. Are creates, stock or merchandise allowed to be piled near building?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="7. Is there a cleared area on both sides of the fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="8. Are unsecured overpasses or subterranean passageways near fence?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G8" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="9. Are fence gates solid and in good condition?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G9" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="10. Are fence gates properly locked?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G10" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="11. Are fence gates’ hinges secure and non-removable?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="12. What types of locks and chains are used to secure gate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="G12" CssClass="Input" runat="server" Width="50px">
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
                                                        
                                                         <asp:Label ID="lblid" runat="server" Visible="False"></asp:Label>
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
