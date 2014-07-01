<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey2.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey2"  %>
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
                                                <td colspan="4">
                                                      <asp:Label ID="Label3" Text="21. Are all safe’s contents, the combinations and the controls needed to maintain security
                                                        kept confidential?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B21" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="22. Are removable panels and grates in which a person or inventory may be concealed
                                                        periodically removed and checked?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B22" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="23. Can these panels and grates be more securely fastened without compromising the item
                                                       to which they are installed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B23" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="24. Will you require police, fire department, or building authority approval to more securely fasten
                                                            those panels and grates?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B24" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                 </td>   
                                          </tr>
                                          
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="25. Are the incoming electrical lines well secured and vandal proof?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B25" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="26. Are the panels on all electrical items fastened?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B26" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="27. Are the electrical power grids, panels, backup, power supplies, etc., kept in a separate
                                                            locked area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B27" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="28. Have you conducted a walk around the property to see if trees, hedges, walls, and fences
                                                            can hide a person or goods?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B28" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="29. If an obstruction to visibility exists, are you taking steps to correct?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B29" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="30. To prevent property and confidential materials from going out with the trash,
                                                        are you keeping a secure trash collection area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B30" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="31. To prevent roof access, are trees and their branches next to building removed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B31" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="32. Are ladders kept secure?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B32" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="33. Are you aware that noisy equipment can mask unauthorized entry?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B33" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="34. Are all exterior building entry points alarmed?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B34" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="35. Are you aware that certain internal and external conditions may affect the alarm?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B35" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="36. Is there a log of alarm malfunctions and their causes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B36" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="37. Have all the causes of alarm malfunctions been remedied?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B37" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="38. Is there an alarm listing and maintenance schedule?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B38" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="39. Has the police or security company’s response to an alarm been tested?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B39" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="40. Are key management personnel frequently tested on alarm use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B40" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="41. Have key personnel been given specific alarm control assignments to include alarm opening,
                                                            closing, checkout procedures and accountability?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B41" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="42. Are there clearly established money handling procedures to follow for safeguarding cash,
                                                            deposits, etc.?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B42" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="43. Do you have a policy for reporting a theft other than security breaches?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B43" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label25" Text="44. Are office machines, shop equipment, and other easily moved items marked for
                                                            identification purposes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B44" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label26" Text="45. Are vendors, safe people and repairpersons logged in and out, and when necessary,
                                                            given visitor’s passes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B45" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label27" Text="46. Are the employees frequently updated on security procedures?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B46" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label28" Text="47. Are you keeping a file of security deficiencies and a schedule for correction?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="B47" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label29" Text="Section C. SECURITY POLICY AND PROGRAMS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         <tr>
                                                <td colspan="2">
                                                      <asp:Label ID="Label30" Text="1. The number of company full-time security personnel at this facility is" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td colspan="2">                                                                                                         
                                                    <asp:TextBox ID="C1" runat="server" CssClass="Input" 
                                                        Width="300px"></asp:TextBox>
                                                </td>                                          
                                          </tr>
                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label31" Text="2. Has management established and communicated a security policy?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label32" Text="3. Have security procedures been published?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                               <td colspan="4">
                                                      <asp:Label ID="Label33" Text="4. Is there a designated individual to supervise the security program at this site?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                         
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="5. Does the company conduct pre-employment background screens on all potential employees?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="6. Does the company conduct pre-employment drug screens on all potential employees?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="7. Does the company conduct periodic or “for cause” drug screens?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="8. Is there a policy on criminal prosecution?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="C8" CssClass="Input" runat="server" Width="50px">
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
                                                    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
                                                        
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
