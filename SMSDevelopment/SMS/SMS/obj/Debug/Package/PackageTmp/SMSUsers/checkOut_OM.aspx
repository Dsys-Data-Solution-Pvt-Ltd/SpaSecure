<%@ Page Title="" Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="checkOut_OM.aspx.cs" Inherits="SMS.SMSUsers.checkOut_OM" %>

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
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Check Out Operation Manager</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <table id="Menus">
                        <tr>
                            <td style="margin-left: 80px">
                                <center>
                                    <asp:Label ID="Label1" runat="server" CssClass="Labels" Font-Bold="True" Text="Check Out by Thumb Print"></asp:Label>
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
                                        <asp:Label ID="Label3" runat="server" CssClass="Labels" Font-Bold="True" Text="Check Out Manually"></asp:Label>
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
            </tr>
            <tr>
                <td colspan="2">
                    <table width="100%" id="tblEntry" style="display: none; border: none;">
                        <tr>
                            <td width="100%" valign="top">
                                <div id="checkinContractor" runat="server" visible="true">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID1" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtID1" CssClass="Input" runat="server" OnTextChanged="txtID1_TextChanged"
                                                    TabIndex="1" AutoPostBack="true" Width="300px"></asp:TextBox>
                                                <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                                    ForeColor="Red"></asp:Label>
                                            </td>
                                            <td valign="top" rowspan="3">
                                                <asp:Panel ID="Panel1" runat="server" Height="170px" Weight="300px" Width="300px">
                                                    <asp:Image ID="Image3" runat="server" Width="150px" Height="150px" ImageUrl="~/ImageUpload/i m.jpg" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblName1" runat="server" CssClass="Labels" Text="Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName1" runat="server" CssClass="Input" ReadOnly="True" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTeleNo1" runat="server" CssClass="Labels" Text="Phone No." Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTeleNo1" runat="server" CssClass="Input" ReadOnly="True" Width="300px"
                                                    Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcheckinTime" runat="server" CssClass="Labels" Text="Check In Time"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcheckinTime" CssClass="Input" runat="server" ReadOnly="True"
                                                    Width="300px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td dir="ltr">
                                                <asp:Label ID="txtout_no" runat="server" CssClass="Labels" Text="out_no" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtrole" runat="server" CssClass="Labels" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <center>
                                                    <asp:Button ID="btnCheckOut1" CssClass="Button" runat="server" Text="Check Out" OnClick="AddCheckOutGuard"
                                                        Width="105px" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnClear1" CssClass="Button" runat="server" Text="Cancel" OnClick="btnClear1_Click"
                                                        Width="85px" /></center>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="VerificationControl" style="display: none" class="table">
                        <object id="DPFPVerificationControl" classid="CLSID:F4AD5526-3497-4B8C-873A-A108EA777493">
                        </object>
                        <asp:Button ID="btnThumbCheckIn" runat="server" Text="" Style="display: none" Width="0"
                            OnClick="btnThumbCheckIn_Click" />
                        <br />
                        <br />
                        <table width="100%" id="tblThumbInfo" style="display: none" runat="server" visible="false">
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
                                <td>
                                    <asp:Label ID="Label2" CssClass="Labels" runat="server" Text="Checkin Time"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCheckinTime1" CssClass="Labels" runat="server" Text=""></asp:Label>
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
                    <div id="Div1" runat="server" visible="true">
                        <asp:GridView ID="gvContractorTable" runat="server" AllowPaging="true" AllowSorting="true"
                            AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" CssClass="GridMain2"
                            OnPageIndexChanging="gvContractorTable_PageIndexChanging" OnRowDataBound="gvContractorTable_RowDataBound"
                            OnSelectedIndexChanged="gvContractorTable_SelectedIndexChanged" Width="740px"
                            PageSize="20">
                            <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
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
                                <asp:BoundField DataField="checkout_time" HeaderText="Last In Time " HeaderStyle-ForeColor="White" />
                                <asp:BoundField DataField="checkin_time" HeaderText="Last Out Time" HeaderStyle-ForeColor="White"/>
                                <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No." HeaderStyle-ForeColor="White"/>
                                <asp:BoundField DataField="user_name" HeaderText="Name" HeaderStyle-ForeColor="White"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
