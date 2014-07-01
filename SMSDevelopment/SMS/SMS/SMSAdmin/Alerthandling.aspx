<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="Alerthandling.aspx.cs" Inherits="SMS.SMSAdmin.Alerthandling" Title="TSP Secure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
    <div class="divHeader">
        <table>
            <tr>
              <td>
                  <asp:LinkButton ID="LinkButton1" CssClass="LnkButton" runat="server" Font-Underline="false" onclick="LinkButton1_Click">E Mail</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
              </td>
              <td>
                  <asp:LinkButton ID="LinkButton2" CssClass="LnkButton" runat="server" onclick="LinkButton2_Click" Font-Underline="false">Pop Up</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp
              </td>
           </tr>
        </table>   
    </div>
      
   <asp:MultiView ID="MultiView1" runat="server">
       
       <asp:View ID="View1" runat="server">
           <table align="left" >
                <tr align="left">
                    
                    <td colspan="4" align="left"><span class="pageTitle">E mail</span></td>                    
                </tr>
                <tr align="center">
                 
                    <td colspan="2" >
                        <asp:Label ID="lblTo1" CssClass="Labels" runat="server" Text="To:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTo1" CssClass="Input" runat="server"  Width="260px" ></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
              
                    <td colspan="2">
                        <asp:Label ID="lblCc1" CssClass="Labels" runat="server" Text="Cc:" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCc1" CssClass="Input" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                
                    <td colspan="2" valign="top" >
                        <asp:Label ID="lblmsg1" CssClass="Labels" runat="server" Text="Message"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtmsg1" CssClass="Input" runat="server" TextMode="MultiLine" Width="260px" Height="200px" ></asp:TextBox>

                    </td>
                </tr>
                <tr> 
                    
                    <td colspan="3" align="center">
                        <asp:Button ID="btnSend1" CssClass="Buttons" runat="server" Text="Send" />
                   &nbsp;
                        <asp:Button ID="btnDelete1" CssClass="Buttons" runat="server" Text="Delete" 
                            onclick="btnDelete1_Click" />
                    </td>
                </tr>
           </table>
       </asp:View>
       
      <asp:View ID="View2" runat="server">
           <table align="left">
           
                <tr align="left">
                    <td colspan="4" align="left"><span class="pageTitle">Pop Up</span></td>                    
                </tr>
                <tr >
                    <td>
                        <asp:Label ID="lblEmpId2" CssClass="Labels" runat="server" Text="Employee ID:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmpID2" CssClass="Input" runat="server" Width="260px"></asp:TextBox>
                    </td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSend2" CssClass="Buttons" runat="server" Text="Send" />
                    </td>
                </tr>
                <tr align="left">
                    <td valign="top">
                        <asp:Label ID="lblmsg2" CssClass="Labels" runat="server" Text="Message"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtmsg2" CssClass="Input" runat="server" TextMode="MultiLine" Width="260px" Height="200px"  ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnDelete2" CssClass="Buttons" runat="server" Text="Delete" 
                            onclick="btnDelete2_Click" />
                       &nbsp; <asp:Button ID="btnSendAll1" CssClass="Buttons" runat="server" Text="Send All" />
                    </td>
                                
                </tr>
           </table>
       </asp:View>
    </asp:MultiView>
  </div>
  <br />
</asp:Content>
