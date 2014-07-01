<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ViewClientFeedback.aspx.cs" Inherits="SMS.SuperVisor.ViewClientFeedback"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 93px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer" style="background-color: #FFFFFF">
        <div class="divHeader">
            <span class="pageTitle">Client Feedback</span></div>           
          
          <br/>
           <div id="divAdvSearch" runat="server" visible="true">
           <asp:Panel ID="printview" runat="server" > 
           
              <table width="100%" cellspacing="5">
                                           
                             <asp:Panel ID="Panel2" runat="server" Visible="false">
                     
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label2" Text="Dear," CssClass="Labels" runat="server"></asp:Label>&nbsp;&nbsp;
                                                      <asp:Label ID="txtclientname" CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>
                                                <td colspan="4" valign="top">
                                                      <asp:Label ID="Label1" Text="Thank you for completing our Online. Client Satisfaction Survey." CssClass="Labels" runat="server"></asp:Label>
                                                      
                                                      <asp:Label ID="Label17" Text="Your answers will help " CssClass="Labels" runat="server"></asp:Label>
                                                      <asp:Label ID="lblClientHelp" Text="  " CssClass="Labels" runat="server"></asp:Label>
                                                      <asp:Label ID="Label19" Text="Us better serve you and all clients in the future. " CssClass="Labels" runat="server"></asp:Label>
                                                      <asp:Label ID="lblClientAnalysis" Text="  " CssClass="Labels" runat="server"></asp:Label>
                                                      <asp:Label ID="Label21" Text=" We will be analysing the results of the Client Satisfaction Survey when the survey period ends. If it is believed that more information is needed about your feedback you may be contacted via email for clarification." CssClass="Labels" runat="server"></asp:Label>
                                                       
                                                </td>                                          
                                          </tr>                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label3" Text="Thank you very much again." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label4" Text="Sincerely," CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label5" Text="Managing Director" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                          </asp:Panel> 
                           
                                           
                                          <tr>
                                              <td>
                                                   <asp:Label ID="lblLocation" Text="Location :" CssClass="Labels" runat="server"></asp:Label>
                                                   &nbsp;&nbsp;&nbsp;
                                                       <asp:Label ID="txtlocation" runat="server" CssClass="Labels" 
                                                       Font-Bold="True"></asp:Label>
                                                </td>                                             
                                         </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblName" Text="Name :" CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                                      <asp:Label ID="txtname" runat="server" CssClass="Labels" Font-Bold="True"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblposition" Text="Position :" CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="txtposition" runat="server" CssClass="Labels" Font-Bold="True"></asp:Label>
                                                </td>
                                          </tr>
                                         <tr>
                                               <td>
                                                      <asp:Label ID="Label6" Text="Company :" CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;<asp:Label ID="txtcompany" runat="server" CssClass="Labels" 
                                                          Font-Bold="True"></asp:Label></td>      
                                          </tr>
                                             <tr>
                                               <td height="55px"></td>
                                          </tr>
                                            <tr>
                                                 <td height="40" valign="bottom">
                                                      <asp:Label ID="lblheadOperationMgt" Text="OPERATIONS MANAGEMENT" 
                                                          CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                           </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMAvailable" Text="Available and accessible" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtOMAvailable" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMReturnPhone" Text="Returns phone calls promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:Label ID="txtOMReturnPhone" runat="server"  CssClass="Labels" ></asp:Label> 
                                                        
                                                 </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMMeetConcrete" Text="Meets concrete deadlines" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtOMMeetConcrete" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                            
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMIdentifies" Text="Identifies and resolves service issues in a timely fashion" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtOMIdentifies" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMResponds" Text="Responds with a sense of urgency" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtOMResponds" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblAnticipates" Text="Anticipates my needs" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtAnticipates" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                            
                                             <tr>
                                                 <td height="40" valign="bottom">
                                                      <asp:Label ID="lblHeadingSecurityMgt" Text="SECURITY PERSONNEL" 
                                                          CssClass="Labels" runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                           </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMAttendence" Text="Attendence" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtSMAttendence" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMConsistent" Text="Consistent delivery of quality service" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtSMConsistent" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMProvides" Text="Provides thoughtful, responsive actions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtSMProvides" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMQuickly" Text="Quickly focuses on and resolves key issues" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtSMQuickly" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMTactful" Text="Tactful and Disciplined" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtSMTactful" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMUses" Text="Uses security knowledge to provide realistic solutions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtSMUses" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMActs" Text="Acts as a trusted security professional" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtSMActs" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMSolicits" Text="Solicits and respects my views and opinions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:Label ID="txtSMSolicits" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             
                                             <tr>
                                                 <td height="45" valign="bottom">
                                                      <asp:Label ID="lblheadTM" Text="TOP MANAGEMENT" CssClass="Labels" 
                                                          runat="server" Font-Bold="True"></asp:Label>
                                                </td>
                                           </tr>
                                             
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMCharge" Text="Charges fees that fairly and appropriately reflect the value of the service provided" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMCharge" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMWorks" Text="Works with me to manage my outside budget" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMWorks" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAppreciate" Text="Appreciates relationship of costs to accomplishing my overall goals" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMAppreciate" runat="server"  CssClass="Labels" ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMRespondstoMyBilling" Text="Responds to my billing inquires promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMRespondstoMyBilling" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMBills" Text="Bills are timely and easy to read" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtTMBills" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAvailable" Text="Available and accessible" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:Label ID="txtTMAvailable" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMReturnPhone" Text="Returns phone calls promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:Label ID="txtTMReturnPhone" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMMeetsConcrete" Text="Meets concrete deadlines" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMMeetsConcrete" runat="server" CssClass="Labels"
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMIdentifies" Text="Identifies and resolves service issues in a timely fashion" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMIdentifies" runat="server" CssClass="Labels" 
                                                             ></asp:Label> 
                                                 </td>
                                             </tr>
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMRespondsWithSense" Text="Responds with a sense of urgency" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                        <asp:Label ID="txtTMRespondsWithSense" runat="server" CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAnticipate" Text="Anticipates my needs" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtTMAnticipate" runat="server" CssClass="Labels" 
                                                             ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMMake" Text="Makes me feel important as a client" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtTMMake" runat="server" CssClass="Labels" 
                                                             ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMIsConstructive" Text="Is constructive and tactful in all business dealings" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMIsConstructive" runat="server" CssClass="Labels" 
                                                             ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMListen" Text="Listens and provides formal/informal feedback and insights" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMListen" runat="server" CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMDemonstrates" Text="Demonstrates high integrity" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMDemonstrate" runat="server" CssClass="Labels" 
                                                             ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMWilling" Text="Willing to speak their minds and give independent opinions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtTMWilling" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAdds" Text="Adds value to my business" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                         <asp:Label ID="txtTMAdds" runat="server"  CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMKeeps" Text="Keeps me informed on matters of general interest/new trends/ issues" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:Label ID="txtTMkeeps" runat="server" CssClass="Labels" 
                                                              ></asp:Label> 
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMParticular" Text="If you have any particular compliment, suggestion or complaint please fill up below:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                             </tr>   
                                             <tr>
                                             
                                             
                                                <td colspan="2" height="75" valign="top">                                                          
                                                              
                                                        <asp:Label ID="txtParticular" runat="server"  CssClass="Labels" 
                                                            ></asp:Label>   
                                                              
                                                 </td>
                                            
                                            </tr>
                                             
                                             
                                          <tr>
                                              <td height="35">
                                              </td>
                                          
                                          </tr>   
                                             
                                             
                                 <asp:Panel ID="Panel1" runat="server" Visible="false">
                            
                                          <tr>
                                               <td height="35">
                                                   <asp:Label ID="Label8" Text="Dear Valued Client," CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>
                                                <td colspan="4" valign="top">
                                                      <asp:Label ID="Label9" Text="
                                                       We want to thank you for giving us the opportunity to serve you as security partners. We want to serve you better and are committed to continuously improving our client service standards.
                                                        " CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          
                                          </tr>
                                          <tr>
                                                <td colspan="4" valign="bottom" height="25">
                                                      <asp:Label ID="Label12" Text="
                                                       In order to do this, your valuable feedback is very important. Please accept my invitation to fill up the online survey form below.
                                                        " CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          
                                          </tr>                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label10" Text="Thank you very much for your effort." CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>                                          
                                          <tr>
                                               <td class="style2">
                                                      <asp:Label ID="Label11" Text="Kind regards," CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label13" Text="" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                          <tr>
                                               <td>
                                                      <asp:Label ID="Label14" Text="Managing Director" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                          </tr>
                                          
                                  </asp:Panel>           
                                          
                                        
                            </table>    
          </asp:Panel>
           
       <div align="center">
                    <asp:Button ID="btnprint" runat="server" CssClass="Buttons" Text="Print" 
                    Width="110px" Height="40px" Font-Bold="True" 
                        onclick="btnprint_Click"/> 
       </div>    
           
           
     </div>
  </div>

</asp:Content>
