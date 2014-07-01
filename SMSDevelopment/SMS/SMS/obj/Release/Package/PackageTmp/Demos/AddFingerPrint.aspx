<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFingerPrint.aspx.cs"
    Inherits="SMS.Demos.AddFingerPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="Labels">
            <asp:TextBox ID="txtNRIC" runat="server"></asp:TextBox>
        </div>
        <br />
        <object id="DPFPEnrollmentControl" classid="CLSID:0B4409EF-FD2B-4680-9519-D18C528B265E">
            <param name="MaxEnrollFingerCount" value="4" />
        </object>
        <asp:HiddenField ID="hdnFP" runat="server" />
        <br />

        <script language="vbscript" type="text/vbscript">
    ' Format a byte array to a hex string to be sent to the server.
        Function OctetToHexStr(ByVal arrbytOctet)
            Dim k
            For k = 1 To Lenb(arrbytOctet)
                OctetToHexStr = OctetToHexStr _
                  & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
            Next
        End Function
           
        'This event fires when new finger was enrolled.
        function DPFPEnrollmentControl_OnEnroll(FingerMask, Template, Status)
            Dim b
            document.getElementById("hdnFP").value = OctetToHexStr(Template.Serialize)
        End function 
        
        </script>

    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </form>
</body>
</html>
