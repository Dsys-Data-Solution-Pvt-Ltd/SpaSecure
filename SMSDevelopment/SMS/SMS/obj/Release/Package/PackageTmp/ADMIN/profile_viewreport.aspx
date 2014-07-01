<%@ Page Title="" Language="C#" MasterPageFile="~/master/Spamaster.Master" AutoEventWireup="true"
    CodeBehind="profile_viewreport.aspx.cs" Inherits="SMS.ADMIN.profile_viewreport" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span>BIO DATA</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" Style="border: 1px solid lightgray;">
                <table width="750px" style="background-color: White; width: 100%; border: none;">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="left" rowspan="3" style="width: 150px;">
                            <center>
                                <asp:Image ID="ImgageStaff" runat="server" Style="width: 150px; height: 121px;" />
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="Labels" runat="server" Text="Name" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtfullname" CssClass="Labels" runat="server" Font-Bold="True" Style="float: left;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDOB" CssClass="Labels" runat="server" Text="Date Of Birth" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtDOB" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNRIC" CssClass="Labels" runat="server" Text="NRIC /FIN No." Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtNRIC" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblContNo" CssClass="Labels" runat="server" Text="Contact No." Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtContNo" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSex" CssClass="Labels" runat="server" Text="Sex" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtSex" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReligion" CssClass="Labels" runat="server" Text="Religion" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtReligion" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRace" CssClass="Labels" runat="server" Text="Race" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtRace" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAge" CssClass="Labels" runat="server" Text="Age" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtAge" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMaritalStatus" CssClass="Labels" runat="server" Text="Marital Status"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtMaritalStatus" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRole" CssClass="Labels" runat="server" Text="Position" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="txtRole" CssClass="Labels" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
              
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblAttachedDocument" CssClass="Labels" runat="server" Text="Attached Documents"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="HypNRICWorkPermit" Text="Nricworkpermit" OnClick="Nricworkpermit_Click" runat="server">Nricworkpermit</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="NSRSWSQModules" Text="NSRSWSQModules" OnClick="NSRSWSQModules_Click"  runat="server">NSRSWSQModules</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="OtherRecognisedCertificate" Text="OtherRecognisedCertificate" OnClick="OtherRecognisedCertificate_Click"  runat="server">OtherRecognisedCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="ExemptionCertificate" Text="ExemptionCertificate"  OnClick="ExemptionCertificate_Click" runat="server">ExemptionCertificate</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SecurityOfficerLicense" Text="SecurityOfficerLicense" OnClick="SecurityOfficerLicense_Click"  runat="server">SecurityOfficerLicense</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="SIRDScreen" Text="SIRDScreen"  OnClick="SIRDScreen_Click" runat="server">SIRDScreen</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
            
            </asp:Panel>
            <br />
            <div style=" background-color: #E4E4E4;padding: 9px;">
                    <center>
                     <a id="print" href="~/Reports/printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>

                        </center>
                </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldViewer" runat="server" />
    <asp:ModalPopupExtender ID="ModalPopupViewer" runat="server" TargetControlID="HiddenFieldViewer"
        CancelControlID="ButtonCancelViewer" BackgroundCssClass="modalBackground" PopupControlID="PanelViewer">
    </asp:ModalPopupExtender>
    <asp:Panel ID="PanelViewer" runat="server" BackColor="White"
        Height="620px" Width="730px" BorderWidth="1px" Style="display: none">
       
        <asp:UpdatePanel ID="UpdatePanelviewer" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="PanelV" BackColor="White" Style="margin-left: 1.5em"
                    Font-Bold="True" Width="700">
                   <table width="100%">
                   <tr>
                   <td>
                   <iframe id="ViewerDoc" runat="server" width="100%" height="530px"></iframe>
                   </td>
                   </tr>

                   <tr>
                   <td>
                    <center>
                           <%-- <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Print" Width="110px"
                                Height="35px" OnClientClick="Print()" Font-Bold="True" />--%>
                            <asp:Button ID="ButtonCancelViewer" runat="server" CssClass="Button"  OnClick="ButtonCancelViewer_Click" Text="Cancel" Width="110px"
                                Height="35px"  Font-Bold="True" />
                        </center>
                   </td>
                   </tr>
                   </table>
                </asp:Panel>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
