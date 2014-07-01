<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey11.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey11"  %>
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
                                                      <asp:Label ID="Label3" Text="9. Do registration permits bear a permanently affixed serial number and numerical designation
                                                        of year of registration?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ9" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label39" Text="10. Do the regulatory control criteria for registration include:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>     
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="a. Prohibition against transfer of registration permit tags for use with a vehicle other than
                                                        the one for which originally issued" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                               <td>
                                                     <asp:DropDownList ID="ddlQ10A" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="b. Replacement of lost permit tags at the registrant’s expense" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                     <asp:DropDownList ID="ddlQ10B" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="c. Return of tags to the security officer when the vehicle is no longer authorized entry into facility" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ10C" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="d. Destruction of invalidated decals or metal tags" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ10D" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="11. What is the nature and scope of registration records maintained by the security officer?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="12. Do the gate guards make periodic checks to insure that vehicles are operated on the premises
                                                        only by properly licensed persons?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ12" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="13. Is a specified system used to control the movement of commercial trucks and other goods
                                                        conveyances into and out of the area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ13" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="14. Are loading and unloading platforms located outside the operating areas, separated one
                                                        from the other, and controlled by guard supervised entrances?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ14" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="15. Are all trucks and other conveyances required to enter through service gates
                                                        staffed by guards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ15" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="16. If trucks are permitted direct access to operating areas, are truck drivers and vehicle
                                                        contents carefully examined?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ16" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="17. Does the check at entrances cover both incoming and outgoing vehicles?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ17" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label12" Text="18. Are truck registers maintained?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ18" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="19. Are registers maintained on all company vehicles entering and leaving the facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ19" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="20. Are escorts provided when vehicles are permitted access to operating or controlled areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ20" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="21. Does the supervision of loading and unloading operations ensure that unauthorized
                                                        goods or people do not enter or leave the installation via trucks or other conveyances?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ21" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="22. Is a temporary tag issued to visitor’s vehicles?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ22" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="23. Are automobiles allowed to be parked within operating or controlled areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ23" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="24. Are parking lots provided?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ24" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="25. Are interior parking areas located away from sensitive points?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ25" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="26. Are interior parking areas fenced so that occupants of automobiles must pass through a
                                                        pedestrian gate when entering or leaving the working area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ26" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="27. Are separate parking areas provided for visitor’s vehicles?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ27" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="28. What is the extent of guard surveillance over interior parking areas?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ28" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="29. Are there restrictions against employees entering private vehicle parking areas during duty hours?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ29" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="30. Are automobiles allowed to park so close to buildings or structures that they would be a fire hazard
                                                            or obstruct fire fighters?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ30" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="31. Are automobiles permitted to be parked close to the controlled area fences?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ31" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="32. Are parking facilities adequate?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlQ32" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                         
                                          <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label28" Text="Section R. ASSETS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                         
                                         
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label8" Text="1. Do you have an inventory control system?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label11" Text="2. Is an actual inventory taken periodically?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label13" Text="3. Do you separate office supplies from non-inventory related equipment?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label18" Text="4. Do you have periodic reviews of the insurance policies to determine adequate coverage
                                                    against fire, theft, embezzlement, and other types of losses?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label24" Text="5. If inventories are to be used in the business, do you use special requisition forms
                                                        indicating inventory withdrawals for company use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR5" CssClass="Input" runat="server" Width="50px">
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
