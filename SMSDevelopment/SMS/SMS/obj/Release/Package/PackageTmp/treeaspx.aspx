<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="treeaspx.aspx.cs" Inherits="SMS.treeaspx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p></p>
            
            <telerik:RadScriptManager ID="radScript" runat="server">
            </telerik:RadScriptManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
            </telerik:RadSkinManager>
      
    
            <telerik:RadMenu ID="rdDBMenu" runat="server" Flow="Vertical" BackColor="White"  
                EnableRoundedCorners="true" Font-Bold="True" EnableShadows="true" 
                ExpandDelay="500" ForeColor="#66CCFF" Height="387px" Style="z-index:2;font-size:xx-large" 
                Width="205px" EnableAutoScroll="true" EnableEmbeddedScripts="True" 
                GroupSettings-ExpandDirection="Down" OnItemClick="rdDBMenu_ItemClick" >
                <ExpandAnimation Type="InOutQuad"/>
                <DefaultGroupSettings ExpandDirection="Down" />
            </telerik:RadMenu>
        

   
    </div>
    <asp:Label ID="Label1" runat="server" 
        style="top: 298px; left: 363px; position: absolute; height: 37px; width: 295px" 
        Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" 
        style="top: 231px; left: 353px; position: absolute; height: 37px; width: 295px" 
        Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" 
        style="top: 364px; left: 374px; position: absolute; height: 37px; width: 295px" 
        Text="Label"></asp:Label>
    </form>
</body>
</html>
