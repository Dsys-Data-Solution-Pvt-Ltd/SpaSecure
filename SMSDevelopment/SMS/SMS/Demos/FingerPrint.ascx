<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FingerPrint.ascx.cs" Inherits="SMS.Demos.FingerPrint1" %>
 <h2><%= ButtonValue%></h2>
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Name:" Style="font-weight: 700"></asp:Label>
        </td>
        <td style="width: 708px;">
            <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True" Width="137px"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                ErrorMessage="" Style="top: -5; color: #990000; font-weight: 700"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Password:" Style="font-weight: 700"></asp:Label>
            <br />
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="137px">Password</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <br />
            <input id="Button2" onclick="Submit()" type="button" value="<%= ButtonValue %>" style="height: 24px;
                width: 141px;" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<asp:HiddenField ID="HiddenField1" runat="server" />

<asp:HiddenField ID="HiddenField2" runat="server" />

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
    InsertCommand="INSERT INTO [User](Name, Password, Template1, Template2) VALUES (@Name, @Password, @Template1, @Template2)"
    SelectCommand="SELECT * FROM [User] WHERE ([Name] = @Name)">
    <InsertParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="Name" PropertyName="Text" />
        <asp:ControlParameter ControlID="TextBox2" Name="Password" PropertyName="Text" />
        <asp:Parameter Name="Template1" />
        <asp:Parameter Name="Template2" />
    </InsertParameters>
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" Name="Name" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>

<script type="text/vbscript">    
    ' Format a byte array to a hex string to be sent to the server.
    Function OctetToHexStr(ByVal arrbytOctet)
        Dim k
        For k = 1 To Lenb(arrbytOctet)
            OctetToHexStr = OctetToHexStr _
              & Right("0" & Hex(Ascb(Midb(arrbytOctet, k, 1))), 2)
        Next
    End Function

    ' Sends a message to the label underneath the submit button.
    Sub SendMessage(message)
            document.getElementById("ctl00_ContentPlaceHolder1_UserIdentity1_Label3").innerHtml = message
    End Sub
</script>
