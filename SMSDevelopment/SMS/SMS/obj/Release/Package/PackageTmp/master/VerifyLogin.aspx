<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyLogin.aspx.cs" Inherits="SMS.master.VerifyLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/wysiwyg.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/login.css" rel="stylesheet" type="text/css" />
<!-- Theme Start -->
<link href="../Styles/styles.css" rel="stylesheet" type="text/css" />
<link href="../Styles/StyleSheet2.css" rel="Stylesheet" type="text/css" />

<script>
    window.history.forward(-1);
    //window.history.backword(-1);
</script>
</head>
<body id="homepage">
    <form id="form1" runat="server">
<div id="header">      
    <asp:Label ID="Label1" runat="server" ForeColor="#CCCCCC" Text="Label" Visible="false"></asp:Label>
<img src="../../Images/KnightTempler.png" alt="D-SYS Data Solution" style="margin-top:3px;
            height: 95px; width:105px; margin-left:1px" />
        <img src="../../Images/KTSecure.png" alt="SPA Secure" style="margin-left:730px;
            height:41px; width:206px; margin-right:0px" />
<table style=" width:100px; height:20px; margin-left:45em; margin-top:-2.2em">
<tr>
<td>
                <div class="hovermenu">
                    <ul>
                        <li><a href="../../master/login3.aspx" id="a3" title="logout" style="color: White;
                            font-family: Verdana, Arial; font-size: 1.2em; font-weight: 20em; text-decoration: none;">
                            Logout</a> </li>
                    </ul>
                </div>
            </td>
</tr>
</table>
</div>
 
    <div>
        <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary" style=" margin-left:33em"></asp:Label>
        </div>
        
    
        <asp:GridView ID="grdLocations" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="5" Width="80%" CssClass="GridMain2" EmptyDataText="No Locations Have Been Assigned To You."
                            OnRowCommand="grdLocations_RowCommand">
                            <HeaderStyle CssClass="HeaderRowForLoc" HorizontalAlign="Center" />
                            <RowStyle CssClass="NormalRowForLoc" />
                            <AlternatingRowStyle CssClass="AlternateRow" />
                            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                            <SelectedRowStyle CssClass="HighlightedRow" />
                            <EmptyDataRowStyle CssClass="NoRecords" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select Location">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkLoc" runat="server" CssClass="LnkButton" Text='<%# Eval("Location_name") %>'
                                            CommandArgument='<%# Eval("Location_id") %>' CommandName="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                       
    </form>
    
</body>
</html>
