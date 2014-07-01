<%@ Page Title="" Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true"
    CodeBehind="FingerPrint.aspx.cs" Inherits="SMS.Demos.FingerPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Labels">
        Name :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Name :
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        InsertCommand="INSERT INTO [User](Name, Password, Template1) VALUES (@Name, @Password, @Template1)"
        SelectCommand="SELECT * FROM [User] WHERE ([Name] = @Name)">
        <InsertParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Name" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox2" Name="Password" PropertyName="Text" />
            <asp:Parameter Name="Template1" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="Name" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:HiddenField ID="hdnFP" runat="server" />

    <script language="vbscript" type="text/vbscript">

        function DPFPVerificationControl_OnComplete(VerificationFeatureSet, Status)
            document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(VerificationFeatureSet.Serialize)
        End function 
        
        ' Format a byte array to a hex string to be sent to the server.
        Function OctetToHexStr(ByVal arrbytOctet)
            Dim k
            For k = 1 To Lenb(arrbytOctet)
                OctetToHexStr = OctetToHexStr _
                  & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
            Next
        End Function
       
    </script>

    <object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
    </object>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>
