<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="checkIn_OM.aspx.cs" Inherits="SMS.SMSUsers.checkIn_OM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnFP" runat="server" />
    <script language="vbscript" type="text/vbscript">
        function DPFPVerificationControl_OnComplete(VerificationFeatureSet, Status)
            document.getElementById("ctl00_ContentPlaceHolder1_hdnFP").value = OctetToHexStr(VerificationFeatureSet.Serialize)
            document.getElementById("ctl00_ContentPlaceHolder1_btnThumbCheckIn").Click
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
    <script type="text/javascript">
        function ShowVerificationPortion() {
            document.getElementById("VerificationControl").style.display = "";
            document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "none";


            //document.getElementById("ctl00_ContentPlaceHolder1_tblThumbInfo").style.display = "none";
        }
        function ShowManualPortion() {
            document.getElementById("VerificationControl").style.display = "none";
            document.getElementById("tblEntry").style.display = "";
            document.getElementById("Menus").style.display = "none";
        }
        function ShowMenu() {
            document.getElementById("VerificationControl").style.display = "none";
            document.getElementById("tblEntry").style.display = "none";
            document.getElementById("Menus").style.display = "";
        }
    </script>
    <div class="divHeader">
        <span class="pageTitle">Check In Operation Manager</span></div>
    <div>
        <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
    <br />
    <div>
        <br />
        <asp:Panel runat="server" ID="Panel10" BackColor="White" Width="100%">
            <table width="100%">
                <tr>
                    <td>
                        <table id="Menus">
                            <tr>
                                <td style="margin-left: 80px">
                                    <center>
                                        <asp:Label ID="Label1" runat="server" CssClass="Labels" Font-Bold="True" Text="Check In by Thumb Print"></asp:Label>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <img alt="Thumb Print" src="../Images/thumbphoto.jpg" style="width: 100px; height: 100px;
                                            cursor: pointer" onclick="ShowVerificationPortion();" />
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div id="manually" runat="server">
                            <table id="menually">
                                <tr>
                                    <td>
                                        <center>
                                            <asp:Label ID="Label3" runat="server" CssClass="Labels" Font-Bold="True" Text="Check In Manually"></asp:Label>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <center>
                                            <img alt="Type Manually" src="../Images/Typing.jpg" style="width: 130px; height: 100px;
                                                cursor: pointer" onclick="ShowManualPortion();" visible="false" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <tr>
                        <td colspan="2">
                            <table width="100%" id="tblEntry" style="display: none; border: none">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblContractorID3" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNricID3" CssClass="Input" runat="server" OnTextChanged="txtNricID3_TextChanged"
                                                        AutoPostBack="true" Width="300px"></asp:TextBox>
                                                    <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                        ForeColor="Red"></asp:Label>
                                                    <asp:TextBox ID="txtrole" runat="server" CssClass="Input" Visible="False" Width="30px"></asp:TextBox>
                                                </td>
                                                <td rowspan="3">
                                                    <td valign="top">
                                                        <asp:Panel ID="Panel1" runat="server" Height="150px" Weight="300px" Width="150px">
                                                            <asp:Image ID="Image3" runat="server" Width="150px" Height="150px" ImageUrl="~/ImageUpload/i m.jpg" />
                                                        </asp:Panel>
                                                    </td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblName3" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtName3" CssClass="Input" runat="server" OnTextChanged="txtName3_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTeleNo3" CssClass="Labels" runat="server" Text="Phone No." Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTeleNo3" CssClass="Input" runat="server" Visible="false" OnTextChanged="txtTeleNo3_TextChanged"></asp:TextBox>
                                                    <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <center>
                                                        <asp:Button ID="btncheckin" runat="server" CssClass="Button" Text="Check In" OnClick="btncheckin_Click"
                                                            Width="105px" />
                                                        <asp:Button ID="btnclear" runat="server" CssClass="Button" Text="Cancel" Width="85px"
                                                            OnClick="btnclear_Click" /></center>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="VerificationControl" style="display: none">
                                <object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
                                </object>
                                <asp:Button ID="btnThumbCheckIn" runat="server" Text="" Style="display: none" Width="0"
                                    OnClick="btnThumbCheckIn_Click" />
                                <br />
                                <br />
                                <table width="500px" id="tblThumbInfo" style="display: none" runat="server" visible="false">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Image ID="UserImage" Height="100px" Width="100px" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFin" CssClass="Labels" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" CssClass="Labels" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPhone" CssClass="Labels" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnContinue" CssClass="Button" runat="server" Text="Proceed To Check In"
                                                OnClick="btnContinue_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <a href="#" onclick="ShowMenu();" class="Labels">Go Back To Menu</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="table">
                                <asp:GridView ID="gvContractorTable" runat="server" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" CssClass="GridMain2"
                                    OnPageIndexChanging="gvContractorTable_PageIndexChanging" OnRowDataBound="gvContractorTable_RowDataBound"
                                    OnSelectedIndexChanged="gvContractorTable_SelectedIndexChanged" Width="750px"
                                    PageSize="20">
                                    <HeaderStyle CssClass="HeaderRow" ForeColor="White"/>
                                    <RowStyle CssClass="NormalRow" />
                                    <AlternatingRowStyle CssClass="AlternateRow" />
                                    <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                                    <SelectedRowStyle CssClass="HighlightedRow" />
                                    <EmptyDataRowStyle CssClass="NoRecords" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lblNoRecords" runat="server" Text="no records in the system.">
                                        </asp:Label>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="Checkin_DateTime" HeaderText="In Time"  HeaderStyle-ForeColor="White"/>
                                        <asp:BoundField DataField="user_name" HeaderText="Name" HeaderStyle-ForeColor="White"/>
                                        <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No." HeaderStyle-ForeColor="White"/>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
