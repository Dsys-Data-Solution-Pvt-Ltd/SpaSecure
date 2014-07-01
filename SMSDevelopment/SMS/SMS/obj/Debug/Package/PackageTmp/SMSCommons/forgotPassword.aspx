<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="SMS.SMSCommons.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KT Secure</title>
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSMain.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSMain.css" type="text/css" />
    <link rel="Stylesheet" href="../App_Themes/SMSThemes/SMSGrid.css" type="text/css" />
    <%--<link rel="Stylesheet" href="../Styles/StyleSheet2.css" type="text/css" />--%>
</head>
<form id="form1" runat="server">
<div id="wrapper">
    <div class="container">
        <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
        </b></b>
    </div>
    <div style="background-color: Black">
        <img src="../../Images/KnightTempler.png" alt="D-SYS Data Solution" style="margin-top:3px;
            height: 95px; width:105px; margin-left:1px" />
        <img src="../../Images/KTSecure.png" alt="SPA Secure" style="margin-left:600px; width:300px; height:50px; margin-top:-3.5em" />
    </div>
    <div class="seprator">
    </div>
    <table width="100%" cellspacing="0">
        <tr style="background-color:#133E67">
            <td style="width:70%; background-color:#133E67" align="left">
                <asp:label id="lblWelcome" runat="server" class="WelcomeMsg"></asp:label>
            </td>
            <td id="Td1" style="width:70%; background-color:#133E67" align="right">
                <asp:label id="lblTime" runat="server" class="WelcomeMsg"></asp:label>
            </td>
        </tr>
    </table>
    <div class="seprator">
    </div>
    <div class="seprator1">
    </div>
    <div id="content-wrapper">
        <div id="content-inner">
            <body>
                <%--<form id="form2" runat="server">--%>
                <div class="divContainer" visible="False" style="background-color: White">
                    <div class="divHeader" style="height: 28px">
                        <span class="pageTitle"></span><font style="font-weight: 100em; color: Blue; font-size: large;
                            font-size: 25px">Forgot Password</font></div>
                    <asp:Label ID="lblMsg" CssClass="ValSummary" runat="server" Font-Bold="True" ForeColor="Red"
                        Style="font-size: 18px"></asp:Label>
                    <table width="750px" border="0">
                        <tr valign="top" align="left">
                            <td>
                                <table border="0">
                                    <tr>
                                        <td colspan="4">
                                            <div id="divMsg" runat="server" visible="false">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUserName" Text="User ID" CssClass="Labels" runat="server" Style="font-size: 18px" />&nbsp;<span
                                                class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" CssClass="Input" runat="server" Width="161px" Height="18px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSecQues" Text="Secret Question" CssClass="Labels" runat="server"
                                                Style="font-size: 18px"></asp:Label>
                                            <span class="req">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSecQues" runat="server" CssClass="Input" Width="217px" Height="22px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<asp:Label ID="lblSecAns" Text="Secret Answer" CssClass="Labels" runat="server"></asp:Label>--%>
                                            <!--<span class="req">*</span>-->
                                        </td>
                                        <%--<td>
                                            <asp:TextBox ID="txtSecAns" runat="server" Width="217px" CssClass="Input" />
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td height="45px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnGetPassword" Text="Get Password" CssClass="Buttons" runat="server"
                                                AutoPostBack="true" OnClick="btnGetPassword_Click" Style="font-size: 18px" />&nbsp;
                                            <asp:Button ID="btnLogin" Text="Login" CssClass="Buttons" runat="server" OnClick="btnLogin_Click"
                                                Style="font-size: 18px" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpassword" runat="server" CssClass="Input" Visible="False" Height="18px" />
                                            &nbsp;
                                            <asp:TextBox ID="txtemail" runat="server" CssClass="Input" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- </form>--%>
            </body>
        </div>
    </div>
    <div class="container">
        <span class="footertext"></span>
    </div>
    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
    </b></b>
</div>
</form>
</html>
