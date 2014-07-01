<%@ Page Title="" Language="C#" MasterPageFile="~/master/Spamaster.Master" AutoEventWireup="true"
    CodeBehind="UploadGuardTourData.aspx.cs" Inherits="SMS.master.UploadGuardTourData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Upload Logo</span></div>
    </div>
    <asp:Panel runat="server" ID="Pnl" BackColor="White" Font-Bold="True" Width="700px"
        Height="200">
        <asp:Label ID="lblerror1" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"
            Style="margin-left: 23em;"></asp:Label>
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="SearchLocID" runat="server" Visible="False" Width="20px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLocation" Text="Select Location" CssClass="Labels" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" Width="150px"
                        class="Label2" Style="margin-left: -0.1em">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblUploadLogo" runat="server" CssClass="Labels" Font-Bold="True" Text="Select File"></asp:Label>
                </td>
                <td>
                <%--  <telerik:RadAsyncUpload ID="FileUpload1" runat="server" Width="50px" Height="20px"
                                        CssClass="input" MultipleFileSelection="Disabled" MaxFileInputsCount="1" EnableAjaxSkinRendering="True"
                                        EnableFileInputSkinning="True">
                                    </telerik:RadAsyncUpload>--%>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                <center>
                    <asp:Button ID="BtnUpload" runat="server" CssClass="button" 
                       Text="Upload" OnClick="BtnUpload_Click1" />
                        </center>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
