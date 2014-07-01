<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ClientFeedback.aspx.cs" Inherits="SMS.SuperVisor.ClientFeedback"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Client Feedback</span></div>
            <div>            
                  <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                      CssClass="ValSummary"></asp:Label>
            </div>  
            <br />
            <div id="divAdvSearch" runat="server" visible="true">   
                                                    
                       <table width="100%" cellspacing="5" class="table">
                       
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
                                           <tr>
                                               <td>
                                                       <asp:Label ID="lblClientManaging" Text=" " CssClass="Labels" runat="server"></asp:Label>
                                                      <%--<asp:Label ID="Label15" Text=" Secure Protection" CssClass="Labels" runat="server"></asp:Label>--%>
                                                </td>
                                          </tr>    
                       
                       
                       
                                         <tr>
                                              <td>
                                                   <asp:Label ID="lblLocation" Text="Location" CssClass="Labels" runat="server"></asp:Label>
                                                   &nbsp;&nbsp;
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Input" Width="130px"> 
                                                    </asp:DropDownList>
                                                    <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>                                             
                                         </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblName" Text="Name " CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                      <asp:TextBox ID="txtClientName" runat="server" CssClass="Input" Width="320px"></asp:TextBox>
                                                </td>
                                          </tr>
                                          <tr>
                                               <td>
                                                      <asp:Label ID="lblposition" Text="Position " CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;
                                                      <asp:TextBox ID="txtposition" runat="server" CssClass="Input" Width="320px"></asp:TextBox>
                                                </td>
                                          </tr>
                                         <tr>
                                               <td>
                                                      <asp:Label ID="Label1" Text="Company " CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;<asp:TextBox ID="txtcompany" runat="server" CssClass="Input" Width="320px"></asp:TextBox></td>
                                          </tr>
                                           <tr>
                                               <td height="25px"></td>
                                          </tr>
                                          
                                          
                                         
                                            <tr>
                                                 <td height="40" valign="bottom">
                                                      <asp:Label ID="lblheadOperationMgt" Text="OPERATIONS MANAGEMENT" 
                                                          CssClass="Labels" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                                                </td>
                                           </tr>                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMAvailable" Text="Available and accessible" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlOMAvailable" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMReturnPhone" Text="Returns phone calls promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlOMReturnPhone" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                            
                                            </tr>
                                            
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMMeetConcrete" Text="Meets concrete deadlines" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlOMMeetConrete" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                            
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMIdentifies" Text="Identifies and resolves service issues in a timely fashion" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlIdentifies" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblOMResponds" Text="Responds with a sense of urgency" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlResponds" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblAnticipates" Text="Anticipates my needs" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlAnticipate" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                            
                                             <tr>
                                                 <td height="40" valign="bottom">
                                                      <asp:Label ID="lblHeadingSecurityMgt" Text="SECURITY PERSONNEL" 
                                                          CssClass="Labels" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                                                </td>
                                           </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMAttendence" Text="Attendence" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMAttendence" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMConsistent" Text="Consistent delivery of quality service" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMConsistent" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMProvides" Text="Provides thoughtful, responsive actions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMProvides" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMQuickly" Text="Quickly focuses on and resolves key issues" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMQuickly" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                            
                                            <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMTactful" Text="Tactful and Disciplined" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMTactful" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMUses" Text="Uses security knowledge to provide realistic solutions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMUses" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMActs" Text="Acts as a trusted security professional" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMActs" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblSMSolicits" Text="Solicits and respects my views and opinions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlSMSolicits" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             
                                             <tr>
                                                 <td height="45" valign="bottom">
                                                      <asp:Label ID="lblheadTM" Text="TOP MANAGEMENT" CssClass="Labels" 
                                                          runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                                                </td>
                                           </tr>
                                           <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMCharge" Text="Charges fees that fairly and appropriately reflect the value of the service provided" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMCharge" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMWorks" Text="Works with me to manage my outside budget" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMWorks" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAppreciate" Text="Appreciates relationship of costs to accomplishing my overall goals" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMAppreciate" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMRespondstoMyBilling" Text="Responds to my billing inquires promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMRespondtoMyBilling" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMBills" Text="Bills are timely and easy to read" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMBills" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAvailable" Text="Available and accessible" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMAvailable" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMReturnPhone" Text="Returns phone calls promptly" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMReturnPhone" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMMeetsConcrete" Text="Meets concrete deadlines" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMMeetConcrete" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMIdentifies" Text="Identifies and resolves service issues in a timely fashion" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMIdentifies" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMRespondsWithSense" Text="Responds with a sense of urgency" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMRespondWithSense" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAnticipate" Text="Anticipates my needs" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMAnticipate" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMMake" Text="Makes me feel important as a client" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMMake" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMIsConstructive" Text="Is constructive and tactful in all business dealings" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMIsConstructive" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMListen" Text="Listens and provides formal/informal feedback and insights" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMListen" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMDemonstrates" Text="Demonstrates high integrity" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMDemonstrate" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                              <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMWilling" Text="Willing to speak their minds and give independent opinions" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMWilling" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMAdds" Text="Adds value to my business" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMAdds" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMKeeps" Text="Keeps me informed on matters of general interest/new trends/ issues" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                          <asp:DropDownList ID="ddlTMKeeps" CssClass="Input" runat="server" Width="50px">
                                                           <asp:ListItem>1</asp:ListItem>
                                                           <asp:ListItem>2</asp:ListItem>
                                                           <asp:ListItem>3</asp:ListItem>
                                                           <asp:ListItem>4</asp:ListItem>
                                                           <asp:ListItem>5</asp:ListItem>
                                                           <asp:ListItem>N/A</asp:ListItem>
                                                         </asp:DropDownList>
                                                 </td>
                                             </tr>
                                             
                                             <tr>
                                                 <td>
                                                         <asp:Label ID="lblTMParticular" Text="If you have any particular compliment, suggestion or complaint please fill up below:" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                             </tr>   
                                             <tr>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtTMParticular" runat="server" CssClass="Input" Width="854px" 
                                                        Height="95px" TextMode="MultiLine"/>
                                                 </td>
                                            </tr>
                                          <tr>
                                              <td height="35">
                                              </td>                                          
                                          </tr>
                                         
                                                                               
                                           <tr>
                                               <td height="25px"></td>
                                          </tr>
                            </table>                                               
                       <br />
                       <br />                                    
                               <table width="100%">                                                       
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnItemAdd" runat="server" CssClass="Buttons" 
                                                        Text="Submit" Width="85px" onclick="btnItemAdd_Click"/>
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnClearItemAdd" 
                                                        runat="server" CssClass="Buttons" 
                                                        Text="Cancel" Width="85px"/>
                                                </td>
                                            </tr>
                                 </table>
                           <br />
                    </div>
    </div>


</asp:Content>
