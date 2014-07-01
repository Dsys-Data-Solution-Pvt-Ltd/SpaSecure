<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="RiskAssessmentSurvey12.aspx.cs" Inherits="SMS.SuperVisor.RiskAssessmentSurvey12"   %>
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
                                                      <asp:Label ID="Label3" Text="6. Is inventory responsibility assigned to a single employee?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>     
                                                <td colspan="4">
                                                      <asp:Label ID="Label1" Text="7. Is the inventory kept in a secure area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                               <td>
                                                     <asp:DropDownList ID="ddlR7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>    
                                               
                                                                                       
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label40" Text="8. Is access to the inventory controlled?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                               
                                                <td>
                                                     <asp:DropDownList ID="ddlR8" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                 
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label4" Text="9. Is the inventory area separate from other departments?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR9" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                        <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label5" Text="10. Is the inventory area safe from physical damage such as breakage,
                                                            fire, weather, spoilage, etc.?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR10" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label6" Text="11. Have you retained an outside consultant to ascertain further steps to be taken to prevent loss?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                 </td>   
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label9" Text="12. Are scrap materials promptly sold?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR12" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label10" Text="13. Are strict controls and accounting records kept for the sale of scrap material?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR13" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label14" Text="14. Is the sale of scrap or salvageable material a separate department and not handled by
                                                       employees involved in purchasing, production, or sales?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlR14" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label25" Text="Section S. SHIPPING AND RECEIVING" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          
                                          
                                          
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label15" Text="1. Is the shipping/receiving area within a protected area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlS1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label16" Text="2. Is it under security or CCTV surveillance?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlS2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label17" Text="3. Do truck drivers or outside vendors have access to the shipping/receiving area?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlS3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td>
                                                      <asp:Label ID="Label29" Text="Comments" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>   
                                                <td colspan="4">                                                                                                         
                                                    <asp:TextBox ID="txtS3" runat="server" CssClass="Input" Width="528px"></asp:TextBox>
                                                </td> 
                                                
                                          </tr>
                                          
                                           <tr>
                                               <td height="45">
                                                 <asp:Label ID="Label26" Text="Section T. CURRENT SECURITY OFFICERS" CssClass="Labels" 
                                                       runat="server" Font-Bold="True"></asp:Label>
                                              </td>
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label12" Text="1. Who provides present guard coverage?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT1" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT1" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                            <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label27" Text="2. How many total regular hours of duty per week?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT2" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT2" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label30" Text="3. How many stationary guard posts exist?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT3" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT3" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label31" Text="4. How many patrol routes?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT4" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT4" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label32" Text="5. Are there any armed officers at this facility? If Yes, how many?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT5" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT5" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label33" Text="6. Is there additional coverage of Saturdays, Sundays or holidays?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT6" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT6" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                            <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label39" Text="7. How many total additional hours per week?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT7" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT7" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="3">
                                                      <asp:Label ID="Label43" Text="8. How many officers are designated as supervisors?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT8" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                     <asp:DropDownList ID="ddlT8" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                          
                                          
                                          
                                            <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label34" Text="9. Are written post orders available? (If possible, secure a copy)" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT9" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                         
                                           
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label35" Text="10. Is the number of guards, posts and patrol routes adequate for this facility?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT10" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                             <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label36" Text="11. Do guards make written reports of incidents?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT11" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label37" Text="12. Is security responsive to management authority?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT12" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           
                                          
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label38" Text="13. Indicate authorized and actual strength, broken down by positions." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT13" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          
                                           <tr>
                                                <td align="center">
                                                      <asp:Label ID="Label44" Text="Name:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Name1" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                      <asp:Label ID="Label45" Text="Authority:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Aut1" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>                                     
                                          </tr>
                                           <tr>
                                                <td align="center">
                                                      <asp:Label ID="Label46" Text="Name:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Name2" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                      <asp:Label ID="Label47" Text="Authority:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Aut2" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>                                     
                                          </tr>
                                           <tr>
                                                <td align="center">
                                                      <asp:Label ID="Label48" Text="Name:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Name3" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                      <asp:Label ID="Label49" Text="Authority:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Aut3" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>                                     
                                          </tr>
                                           <tr>
                                                <td align="center">
                                                      <asp:Label ID="Label50" Text="Name:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Name4" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td> 
                                                <td>
                                                      <asp:Label ID="Label51" Text="Authority:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                 <td>                                                                                                         
                                                    <asp:TextBox ID="txtT13Aut4" runat="server" CssClass="Input" Width="200px"></asp:TextBox>
                                                </td>                                     
                                          </tr>
                                          
                                          
                                          
                                          
                                          
                                          
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label41" Text="14. Have there been changes since the last survey in either the authorized and actual force strength?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT14" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label42" Text="15. Is present guard force strength commensurate with the degree of security protection required?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT15" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                         
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label19" Text="16. Is the use of guard forces reviewed periodically to assure effective and economical use?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT16" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label20" Text="17. Is supervisory responsibility for guard force operations vested in the security officer." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT17" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label21" Text="18. Is a guard headquarters provided?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT18" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                           <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label22" Text="19. Are guards familiar with the communications equipment used?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT19" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label23" Text="20. Does the guard headquarters have direct communications with local municipal fire and
                                                        police headquarters?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT20" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label2" Text="21. Do members of the guard force meet the minimum qualifications standards?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT21" CssClass="Input" runat="server" Width="50px">
                                                       <asp:ListItem>Yes</asp:ListItem>
                                                       <asp:ListItem>No</asp:ListItem>  
                                                       <asp:ListItem>NA</asp:ListItem>                                                                       
                                                     </asp:DropDownList>
                                                </td>                                          
                                          </tr>
                                          
                                          <tr>
                                                <td colspan="4">
                                                      <asp:Label ID="Label7" Text="22. Are guards armed while on duty? If so, with what type of weapon?" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:DropDownList ID="ddlT22" CssClass="Input" runat="server" Width="50px">
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
