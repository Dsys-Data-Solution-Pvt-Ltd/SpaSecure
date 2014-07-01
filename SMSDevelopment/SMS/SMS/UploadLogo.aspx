<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="UploadLogo.aspx.cs" Inherits="SMS.UploadLogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divHeader">
        <span class="pageTitle">Upload Logo</span></div>
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblUploadLogo" runat="server" CssClass="Labels" Font-Bold="True" Text="Select Logo"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Style="height: 22px; width: 217px" />
            </td>
            <td>
                <asp:Button ID="BtnUpload" runat="server" CssClass="Button" 
                    
                    Text="Upload" OnClick="BtnUpload_Click1" />
            </td>
            <td>
                <asp:Image ID="ImgUpload" runat="server" Style="height: 129px; width: 125px" />
            </td>
        </tr>

        <tr>
        <td colspan="4">
        <div class="divContainer">
        <asp:Label ID="lblErr" runat="server" CssClass="ValSummary" ForeColor="Red" Style="top: -13px;
            left: 29px; position: absolute; height: 23px; width: 197px" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Visible="false" Style="top: -15px; left: 82px;
            position: absolute; height: 22px; width: 128px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
       </div>
        </td>
        </tr>

         <tr>
        <td colspan="4">
        <asp:Button ID="BtnSave" runat="server"  Text="Save" CssClass="Button" OnClick="BtnSave_Click" />
        </td>
        </tr>
    </table>
    
        
</asp:Content>
