<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ThumbAfter.aspx.cs" Inherits="SMS.ADMIN.ThumbAfter"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
   <div>
         <asp:Label ID="lblerror" runat="server" Text=" "></asp:Label>
   </div>
    <br />
        <div>
                 <table width="100%" style=" margin-left:3em; background-color:White; margin-top:1em">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnclientvisit" runat="server" Text="Client Visit" 
                                    CssClass="Buttons" onclick="btnclientvisit_Click" Width="190px" />
                            </td>
                            <td>
                                <asp:Button ID="btnSiteVisit" runat="server" Text="Site Visit" 
                                    CssClass="Buttons" onclick="btnSiteVisit_Click" Width="190px"/>
                            </td>
                            
                       </tr>
                       <tr>
                          
                            <td align="center"> 
                                <asp:Button ID="btnSecurityRisk" runat="server" Text="Security Risk Survey" 
                                    CssClass="Buttons" onclick="btnSecurityRisk_Click" Width="190px"/>
                            </td>
                            <td>
                            <asp:Button ID="btnChangeNotification" runat="server" 
                                    Text="Change Notification" CssClass="Buttons" 
                                    onclick="btnChangeNotification_Click" Width="190px"/>
                            </td>
                      </tr>
                      <tr>
                           
                            <td align="center">
                                <asp:Button ID="btnStaffFeedback" runat="server" Text="Staff Feedback" 
                                    CssClass="Buttons" onclick="btnStaffFeedback_Click" Width="190px"/>
                            </td>
                      </tr>
                      <tr>
                            <td align="center">
                                
                            </td> 
                            <td>
                            
                            </td>                          
                      </tr>
                </table>
                  
        </div>
   </div>     


</asp:Content>
