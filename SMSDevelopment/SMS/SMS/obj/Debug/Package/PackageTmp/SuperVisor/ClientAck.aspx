<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ClientAck.aspx.cs" Inherits="SMS.SuperVisor.ClientAck"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer" style="background-color: #FFFFFF">
         <br />
      <%--  <div class="divHeader">--%>
          <table width="100%" cellspacing="5" class="table">
                                         <tr>
                                               <td>
                                                      <asp:Label ID="Label2" Text="Dear," CssClass="Labels" runat="server"></asp:Label>
                                                      &nbsp;&nbsp;&nbsp; &nbsp;
                                                   <asp:Label ID="txtClientName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
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
                                           <tr>
                                             <td  height="30">
                                             </td>
                                          </tr>
                                          <tr>
                                             <td>
                                                 <asp:Button ID="btn" runat="server" Text="Finish" CssClass="Buttons" 
                                                     onclick="btn_Click" Width="72px" />
                                             
                                             </td>
                                          </tr>
                                         
                                           
              </table>
        <%-- </div>--%>
       <br />
       
       
       
   </div>       
  <br />      

</asp:Content>
