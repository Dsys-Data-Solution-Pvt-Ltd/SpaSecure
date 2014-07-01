<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="ListEmergencyNo.aspx.cs" Inherits="SMS.SuperVisor.ListEmergencyNo"
    Title="List of Emergency No." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function PrintGridData() {
        var prtGrid = document.getElementById('<%=printview.ClientID %>');

        //window.print();
        prtGrid.border = 0;
        //GridView1.Attributes(style) = "page-break-after:always"         
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainerForLE">
        <div class="divHeader">
            <span class="pageTitle">List of Emergency Contact No.</span></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <asp:Panel ID="printview" runat="server" BackColor="White"
                Font-Bold="True" Width="100%" Height="70em">
                <table width="100%" cellspacing="10px">
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="lblIncidentReport" Text="LIST OF EMERGENCY CONTACT NOS" CssClass="Labels"
                                runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" Text="Police" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                      <td colspan="2">
                            <asp:Label ID="Label3" Text=" : 999" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" Text="SCDF" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label5" Text=" : 995" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" Text="Police Hotline" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label7" Text=" : 1800 225 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" Text="Police Hotline" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label9" Text=" : 1800 225 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" Text="Police Coast Guard" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                       <td colspan="2">
                            <asp:Label ID="Label11" Text=" : 6375 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" Text="Traffice Police Hotline" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                       <td colspan="2">
                            <asp:Label ID="Label13" Text=" : 1800 547 1818" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" Text="Internal Security Dept." CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                      <td colspan="2">
                            <asp:Label ID="Label15" Text=" : 6256 6657" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" Text="Non Emergency Ambulance" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                       <td colspan="2">
                            <asp:Label ID="Label17" Text=" : 1800 221 1777" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label18" Text="Electric Supply" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                      <td colspan="2">
                            <asp:Label ID="Label19" Text=" : 6778 8888" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" Text="Gas Supply" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       <td colspan="2">
                            <asp:Label ID="Label21" Text=" : 6752 1800" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label22" Text="CISCO" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                      <td colspan="2">
                            <asp:Label ID="Label23" Text=" : 6747 2888" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label24" Text="ADEMCO" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label25" Text=" : 6224 7377" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label26" Text="PEST Control" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label27" Text=" : 6325 7680" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                  
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="Label28" Text="CONTACT NOS OF POLICE DIVISIONS" CssClass="Labels"
                                runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label29" Text="1) Central Police division" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label37" Text="'A'  " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label30" Text=" : 1800 224 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label38" Text="2) Clementi Police division" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label39" Text="'D'  " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label40" Text=": 1800 774 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label41" Text="3) Tanglin Police division" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label42" Text="'E'  " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label43" Text=": 1800 391 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label44" Text="4) Ang Mo Kio Police division" CssClass="Reportcolor"
                                runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label45" Text="'F'  " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label46" Text=": 1800 218 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label47" Text="5) Bedok Police division" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label48" Text="'G'" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label49" Text=": 1800 244 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label50" Text="4) Jurong Police division" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label51" Text="'J'" CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label52" Text=": 1800 791 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label53" Text="4) Airport Police Station" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label54" Text=" " CssClass="Reportcolor" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label55" Text=": 1800 546 0000" CssClass="Reportcolor" runat="server"
                                Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                   
                </table>
            </asp:Panel>
            
             <div style=" background-color: #E4E4E4;">
                    <center>
                    <%--<a id="print" href="printpage.aspx" class="Button"   runat="server" target="_blank" style="  Height:30px; Width:100px; color:White; padding:7px 30px 7px 30px">Print</a>--%>

                <asp:Button ID="btnprint" CssClass="Button" Height="30px" Width="100px" runat="server"
                    Text="Print" OnClientClick="javascript:PrintGridData();" />
            </center>
        </div>
        </div>
    </div>
</asp:Content>
