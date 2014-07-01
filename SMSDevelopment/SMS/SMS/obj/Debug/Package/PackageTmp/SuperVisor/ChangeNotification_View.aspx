<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="ChangeNotification_View.aspx.cs" Inherits="SMS.SuperVisor.ChangeNotification_View" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Change Notification</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
        </div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
        <asp:Panel ID="printview" runat="server" > 
            <table width="80%" cellspacing="5" class="table" style=" background-color:White">
                <tr>
                    <td>
                        <asp:Label ID="lblEnterPassNumber" Text="Our Ref" CssClass="Labels" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblRefNo" runat="server" CssClass="Labels" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" Text="Date" CssClass="Labels" runat="server"></asp:Label>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbldate" CssClass="Labels" runat="server"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" Text="Attn" CssClass="Labels" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblAttn" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td>
                 Dear Sir, 
                </td>
                </tr>
                 <tr>
                <td>
                RE: CHANGE OF SECURITY GUARD FOR YOUR PREMISE
                </td>
                </tr>
                 <tr>
                <td>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We would like to inform you that we are placing our relief security guard for the above assignment as our
           permanent guard will be attending urgent matters for a few days.<br />
           Please be informed that the under mentioned personnel deployed at your Site/Premises will be replaced on <asp:Label runat="server" ID="lblreplaced" CssClass="Labels" ></asp:Label> &nbsp;as follows:
                </td>
                </tr>
           </table>
         
            <table width="80%" cellspacing="5" class="table" style=" background-color:White">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label3" Text="Name" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" Text="NRIC NO" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Security Guard :
                    </td>
                    <td>
                        <asp:Label ID="txtguardfrom" Text="" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtguardfromNric" Text="" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr><td>
                Is being replaced by the following personnel:
                </td></tr>
                <tr>
                    <td>Security Guard :
                    </td>
                    <td>
                        <asp:Label ID="txtToguard" Text="" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="txtToguardnric" Text="" CssClass="Labels" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>                
           </table>
           <p class="table" style=" background-color:White">We would appreciate if you monitor his performance and give us your feedback. We provide our guard with adequate training and we will continuously monitor them.
           </p>
           <p class="table" style=" background-color:White">Please be assured of our best service and attention at all times.Should you have any enquiries, kindly contact the undersigned @62937772.</p>
           <p class="table" style=" background-color:White">
           Thank You.
           </p>
           </asp:Panel>
            <table width="100%" class="table" style=" margin-top:-1.5em; background: url(../Images/1397d40aa687.jpg); height:2.2em">   
                <tr>
                    <td align="Center" colspan="2">
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearPassAdd" Text="Print" runat="server" CssClass="Buttons"
                            Width="85px" onclick="btnClearPassAdd_Click" Font-Bold="True" 
                            Height="30px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
