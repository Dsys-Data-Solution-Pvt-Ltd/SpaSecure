<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewAppraisalForm.aspx.cs" Inherits="SMS.SuperVisor.ViewAppraisalForm"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 545px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" >
        <div class="divHeader">
            <span class="pageTitle">Security Appraisal</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" Style="margin-left: 0.2em; width: 59.6em; height: 30em"> 
           
              <table width="700px" cellspacing="5" class="table" style=" background-color:White">
                         
                                             <tr> 
                                                    <td>
                                                            <asp:Label ID="lbllocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                   &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="txtlocation" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                             </tr>                           
                                            <tr>
                                                    <td>
                                                        <asp:Label ID="lblName" Text="Name" CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;&nbsp;&nbsp;    
                                                            <asp:Label ID="txtName" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                            
                                                   </td>
                                           </tr>
                                          
                                             <tr>
                                                  <td>
                                                        <asp:Label ID="lblNric" Text="NRIC No." CssClass="Labels" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;    
                                                            <asp:Label ID="txtNric" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                            
                                                   </td>
                                             </tr>
                                             
                                             <tr> 
                                                    <td>
                                                            <asp:Label ID="lblDate" Text="Date :" CssClass="Labels" runat="server"></asp:Label>
                                                   &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="txtDate" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                             </tr>  
                                                    
                                              <tr>  
                                                    <td colspan="2" height="35" valign="bottom">
                                                            <asp:Label ID="lblHeadStafftocomplete" Text="Staff to Complete :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    
                                              </tr> 
                                              
                                              
                                              
                                               
                                              
                                               <tr>  
                                                    <td height="50px" valign="bottom" class="style1">
                                                            <asp:Label ID="lblSelfEvaluation" Text="1) SELF EVALUATION :" CssClass="Labels" 
                                                                runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>  
                                              <tr>  
                                                    <td class="style1">
                                                            <asp:Label ID="lblAdequateTraining" Text="Do you feel you have adequate training/skills for your current position & job Description :" CssClass="Labels" runat="server"></asp:Label>
                                                    
                                                        <asp:Label ID="txtAdequateTraining" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlAdequateTraining" runat="server">
                                                       
                                                           <asp:Label ID="lblAdequateNo" Text="If No, what courses/training would be beneficial :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:Label ID="txtAdequateNo" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              
                                              
                                               <tr>  
                                                    <td class="style1">
                                                            <asp:Label ID="lbljobDescription" Text="Is your job Description up to date : If No, Please mark up the job Description." CssClass="Labels" runat="server"></asp:Label>
                                                    <%--</td>
                                                    <td>--%>
                                                        <asp:Label ID="txtjobDescription" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblSufficientMaterials" Text="Do you have sufficient materials & equipment to adequately perform your job :" CssClass="Labels" runat="server"></asp:Label>
                                                   <%-- </td>
                                                    <td>--%>
                                                        <asp:Label ID="txtSufficientMaterials" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                   
                                                     
                                                       <asp:Panel ID="pnlSufficientMaterial" runat="server" Visible="False">
                                                       
                                                           <asp:Label ID="lblNoSufficientMaterial" Text="If No, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:Label ID="txtNoSufficientMaterial" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                       
                                                   </td>
                                              </tr>
                                              
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblotherArea" Text="Are there any other areas you would like to also do in your job :" CssClass="Labels" runat="server"></asp:Label>
                                                   <%-- </td>
                                                    <td>--%>
                                                       <asp:Label ID="txtotherArea" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlotherArea" runat="server">
                                                       
                                                           <asp:Label ID="lblyesotherArea" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:Label ID="txtyesotherArea" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblotherposition" Text="Is there any other position in the company you feel would be better suited :" CssClass="Labels" runat="server"></asp:Label>
                                                   <%-- </td>
                                                    <td>--%>
                                                       <asp:Label ID="txtotherposition" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlotherposition" runat="server">
                                                       
                                                           <asp:Label ID="lblyesotherposition" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:Label ID="txtyesotherposition" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                               <tr>  
                                                    <td height="50px" valign="bottom" class="style1">
                                                            <asp:Label ID="lblCompanyEvalution" Text="2) COMPANY EVALUATION :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>   
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblcurrentCompany" Text="Are you happy with the current company direction (size, growth, etc) :" CssClass="Labels" runat="server"></asp:Label>
                                                    <%--</td>
                                                    <td>--%>
                                                        <asp:Label ID="txtcurrentCompany" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlcurrentCompany" runat="server">
                                                       
                                                           <asp:Label ID="lblNocurrentCompany" Text="If No, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                          <asp:Label ID="txtNocurrentCompany" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblcompanyArea" Text="Are there any areas that the company could be addressing to better meet client's needs, or improve sales :" CssClass="Labels" runat="server"></asp:Label>
                                                   <%-- </td>
                                                    <td>--%>
                                                       <asp:Label ID="txtcompanyArea" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlYescompanyArea" runat="server">
                                                       
                                                           <asp:Label ID="lblyescompanyArea" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                           <asp:Label ID="txtyescompanyArea" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblcompanyidentify" Text="Can you identify any ways to improve efficiency in your job or in the company :" CssClass="Labels" runat="server"></asp:Label>
                                                   <%-- </td>
                                                    <td>--%>
                                                       <asp:Label ID="txtcompanyidentify" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlcompanyidentify" runat="server">
                                                       
                                                           <asp:Label ID="lblYescompanyidentify" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                          <asp:Label ID="txtyescompanyidentify" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>  
                                                    <td height="50px" valign="bottom" class="style1">
                                                            <asp:Label ID="lblManagementEvalution" Text="3) MANAGEMENT EVALUATION :" 
                                                                CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                              </tr>   
                                              
                                               <tr>  
                                                    <td class="style1">
                                                         <asp:Label ID="lblmanagementneeds" Text="Are their any areas you feel the management needs improving :" CssClass="Labels" runat="server"></asp:Label>
                                                    <%--</td>
                                                    <td>--%>
                                                       <asp:Label ID="txtmanagementneeds" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                    </td>
                                              </tr> 
                                              
                                              <tr>
                                                   <td colspan="3">
                                                       <asp:Panel ID="pnlmanagementneed" runat="server">
                                                       
                                                           <asp:Label ID="lblyesmanagementneed" Text="If Yes, Explain :" CssClass="Labels" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                          <asp:Label ID="txtyesmanagementneed" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                       </asp:Panel>
                                                   </td>
                                              </tr>
                                              
                                              <tr>
                                                  <td height="25px" class="style1">                                                                                                       
                                                  </td>                                              
                                              </tr>
                                              <tr><td>
                                                   </td></tr>
                                           </table>
                                            <table class="table" width="80%" style=" background: url(../Images/1397d40aa687.jpg); height:2.2em">
                                             <tr><td> 
                                             <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" style=" margin-left:18em" 
                    Width="110px" Height="35px" onclick="btnprint_Click" Font-Bold="True"/> 
                                          </td></tr></table> 
                            
     
     
          </asp:Panel>
           
         
           
           
     </div>
  </div>


</asp:Content>
