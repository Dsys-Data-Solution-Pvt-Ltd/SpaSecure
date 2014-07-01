<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login3.aspx.cs" Inherits="SMS.master.login3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SPA Secure</title>
    <link rel="Stylesheet" href="../css/progressbarr.css" />
    <link rel='stylesheet' type='text/css' href='../css/styles.css' />
    <link rel='stylesheet' type='text/css' href='../css/css.css' />
    <link href="../css/login-box.css" rel="stylesheet" type="text/css" />
    <link href="../Css/MyCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="wrapper">
        <!-- / main wrapper \ -->
        <div id="mainWrapper">
            <!-- / header container \ -->
            <div id="headerCntr">
                <div class="autocenter">
                    <table width="100%">
                        <tr>
                            <td>
                                <div>
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 465px">
                                                <a href="#" class="logo" style="border: 0px solid white;">
                                                    
                                                    <asp:Image runat="server" ID="imgHeaderLogo" Style="height: 80px; width: 100px">
                                                    </asp:Image>
                                                </a>
                                            </td>
                                            <td align="left">
                                                <h2 style="font-family: Calibri; font-size: 35px; margin-left: 95px;">
                                                    SPA Secure</h2>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="RedHeader">
            <div class="autocenter">
                <h4 style="width: 100%; color: white; float: left; background: none repeat scroll 0% 0% rgb(204, 0, 51);
                    background-color: rgb(204, 0, 51); background-image: none; background-repeat: repeat;
                    background-attachment: scroll; background-position: 0% 0%; background-clip: border-box;
                    background-origin: padding-box; background-size: auto auto;">
                    Login Here
                </h4>
            </div>
        </div>
        <div class="GrayHeader">
        </div>
        <br />
        <br />
        <br />
        <div align="center" style="padding-top: 100px">
            <table style="font-family: Arial, Helvetica, sans-serif; font-size: small; background-color: #E5E5E5;">
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="margin-left: 10px;">
                        Login ID
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="margin-left: 10px;">
                        Password
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="Button1" runat="server" BackColor="#BB0000" BorderStyle="None" ForeColor="White"
                            OnClick="Button1_Click" class="submit" Text="Login" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left" style="padding-left: 22px">
                        <p>
                            <a href="#" id="fPassword" runat="server" title="Forgot Password?">Forgot Password?</a></p>
                        <asp:Label ID="Labelerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="HiddenFieldDelete" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupDeleteimage" runat="server" TargetControlID="fPassword"
            CancelControlID="btnCancel21" BackgroundCssClass="modalBackground" PopupControlID="paneldeleteimage">
        </asp:ModalPopupExtender>
        <asp:Panel ID="paneldeleteimage" runat="server" BackColor="White" Height="200px"
            Width="320px" BorderWidth="1px" BorderColor="LightGray">
            <br />
            <div>
                <p style="margin-left: 25px; margin-top: 8px; font-size: larger">
                    <asp:Label runat="server" Text="Please contact your administrator to reset your password"
                        ID="lbldeletemessage"></asp:Label>
                </p>
                <center>
                    <asp:Button ID="btnCancel21" Text="Ok" runat="server" BackColor="#BB0000" OnClick="btnCancelDelete_Click"
                        ForeColor="White" Style="margin-left: 10px" Height="30px" Width="100px" />
                </center>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="HiddenFieldUpdate" runat="server" />
        <asp:ModalPopupExtender ID="ModalPopupVerify" runat="server" TargetControlID="HiddenFieldUpdate"
            CancelControlID="ButtonVerifyCancel" BackgroundCssClass="modalBackground" PopupControlID="AdminVerifypnl">
        </asp:ModalPopupExtender>
        <asp:Panel ID="AdminVerifypnl" runat="server" BackColor="Transparent" ScrollBars="Vertical" BorderWidth="1px"
            Height="200px" Width="490px" Style="display: none; border-color:lightgray; background-color:white;" >
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="updCappOperationalPanel">
                <ProgressTemplate>
                    <div class="divWaiting" style="margin-top: 400px">
                        <asp:Image ID="imgWait3" runat="server" ImageAlign="Middle" ImageUrl="~/img/progress.gif" /><br />
                        <asp:Label ID="lblWait3" runat="server" Text=" Please wait... " Font-Bold="true"
                            Font-Size="Large" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="updCappOperationalPanel" runat="server">
                <ContentTemplate>
                    <center>
                        <table width="100%" style="margin-top: 20px;">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CellPadding="5" Width="100%" EmptyDataText="No Locations Have Been Assigned To You."
                                        OnRowCommand="grdLocations_RowCommand">
                                        <HeaderStyle HorizontalAlign="Center" BackColor="#BB0000" ForeColor="White" />
                                        <RowStyle />
                                        <AlternatingRowStyle CssClass="AlternateRow" />
                                        <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                                        <SelectedRowStyle CssClass="HighlightedRow" />
                                        <EmptyDataRowStyle CssClass="NoRecords" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select Location">
                                                <ItemTemplate>
                                                    <asp:Button ID="lnkLoc" runat="server" Text='<%# Eval("Location_name") %>' CommandArgument='<%# Eval("Location_id") %>'
                                                        CommandName="Select"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="ButtonVerifyCancel" CausesValidation="false" runat="server" Text="Cancel"
                                        BackColor="#BB0000" ForeColor="White" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    </form>
    <div id="footer" style="border: none">
        <span style="float: right; margin-left: 225px; margin-top: 120px; color: black; font-size: 11px;
            font-family: Helvetica Neue, Helvetica, Helvetica, Arial, sans-serif;">@ Copyright
            2014 <a href="http://www.dsds.co.in" target="_blank">D-Sys Data Solutions</a>. All
            rights reserved.</span>
    </div>
</body>
</html>
