<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="Staff_ViewReport.aspx.cs" Inherits="SMS.ADMIN.Staff_ViewReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
        .style1
        {
            width: 217px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">BIO DATA</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:panel runat="server" ID="printview" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750">
            <table width="700" class="table">
            <tr><td></td></tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblheading" CssClass="Labels" runat="server" Text="BIODATA "
                            Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </td>
                </tr>
                 <tr>
                       <td height="35" class="style1">
                       </td>
                       <td></td>
                       <td align="left" rowspan="3">
                           <asp:Image ID="ImgageStaff" runat="server" Width="90px" Height="80px" />
                       </td>  
                </tr>
                <tr>
                    <td align="center" colspan="2">                        
                        <asp:Label ID="txtfullname" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                    </td>
               </tr>     
                    
                <tr>
                       <td height="25" class="style1">
                       </td>
                </tr>
                <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblDOB" CssClass="Labels" runat="server" Text="Date Of Birth" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtDOB" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>     
                <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC /FIN No." 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtNRIC" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>     
               <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblContNo" CssClass="Labels" runat="server" Text="Contact No." 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtContNo" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>     
                <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblSex" CssClass="Labels" runat="server" Text="Sex" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtSex" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>         
                 <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblReligion" CssClass="Labels" runat="server" Text="Religion" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtReligion" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr> 
                <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblRace" CssClass="Labels" runat="server" Text="Race" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtRace" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>   
               <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblAge" CssClass="Labels" runat="server" Text="Age" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtAge" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>        
                <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblMaritalStatus" CssClass="Labels" runat="server" 
                             Text="Marital Status" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtMaritalStatus" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>   
               <tr>
                     <td class="style1">                        
                        <asp:Label ID="lblRole" CssClass="Labels" runat="server" Text="Position" 
                             Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtRole" CssClass="Labels" runat="server" Text=""></asp:Label>
                    </td>
               </tr>
               <tr>
                    <td height="25" class="style1">
                    </td>
               
               </tr>
               
                
            </table>
         
         <br />
         <div>
                    <table class="table">
                         <tr>
                               <td>
                                    <asp:Label ID="lblAttachedDocument" CssClass="Labels" runat="server" Text="Attached Documents"></asp:Label>
                              </td>                         
                         </tr>
                         <tr>
                              <td>
                                  <asp:HyperLink ID="HypNRICWorkPermit" runat="server">Nricworkpermit</asp:HyperLink>
                              </td>                         
                         </tr>
                         <tr>
                              <td>
                                <asp:HyperLink ID="NSRSWSQModules" runat="server">NSRSWSQModules</asp:HyperLink>
                              </td>                         
                         </tr>
                         <tr>
                              <td>
                                 <asp:HyperLink ID="OtherRecognisedCertificate" runat="server">OtherRecognisedCertificate</asp:HyperLink>
                              </td>                         
                         </tr>
                         
                         <tr>
                              <td>
                                  <asp:HyperLink ID="ExemptionCertificate" runat="server">ExemptionCertificate</asp:HyperLink>
                              </td>                         
                         </tr>
                         <tr>
                              <td>
                                <asp:HyperLink ID="SecurityOfficerLicense" runat="server">SecurityOfficerLicense</asp:HyperLink>
                              </td>                         
                         </tr>
                         <tr>
                              <td>
                                 <asp:HyperLink ID="SIRDScreen" runat="server">SIRDScreen</asp:HyperLink>
                              </td>                         
                         </tr>
                    
                    </table>
         
         </div> 
       <table  width="100%" style="margin-left:-0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
        <tr><td colspan="4" align="center" style="width: 897px">
                   <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                     Width="110px" Height="35px" onclick="btnprint_Click" Font-Bold="True"/> 
                     </td></tr></table> 
       </asp:Panel>   
       <br />    
           
     </div>
  </div>


</asp:Content>
