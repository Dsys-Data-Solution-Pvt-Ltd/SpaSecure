<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="FingerEnroll.aspx.cs" Inherits="SMS.Demos.FingerEnroll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script>

    <div>
        <div name="lblStatus" id="lblStatus" class="Labels">
        </div>
        <br />
        <div class="Labels">
            Name :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Name :
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <br />
        <object id="DPFPEnrollmentControl" classid="CLSID:0B4409EF-FD2B-4680-9519-D18C528B265E">
            <param name="MaxEnrollFingerCount" value="4" />
        </object>
        <asp:HiddenField ID="hdnFP" runat="server" />
        <br />
        <br />
        <div class="Labels">
            <a href="FingerPrint.aspx">Verify Thumbprint</a>
        </div>
        <br />
        
    </div>

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
            document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(Template.Serialize)
        End function 
        
    </script>

    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
</asp:Content>
