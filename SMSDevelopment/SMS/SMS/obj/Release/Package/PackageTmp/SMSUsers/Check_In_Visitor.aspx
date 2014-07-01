<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="Check_In_Visitor.aspx.cs" Inherits="SMS.SMSUsers.Check_In_Visitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function showBrowse(pFile, idx) {

            document.getElementById("ctl00_ContentPlaceHolder1_Image3").src = pFile;
        }
    </script>
    <script src="../swfobject.js" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <%--    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="divHeader">
        <span class="pageTitle">Check In Visitor</span></div>
    <div>
        <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Style="top: 33px;
            left: 669px; position: absolute; height: 24px; width: 171px"></asp:Label>
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblName2" CssClass="Labels" runat="server" Text="Name"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtName2" CssClass="Input1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVisitorID2" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNricID2" CssClass="Input1" runat="server" OnTextChanged="txtNricID2_TextChanged"
                    AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTeleNo2" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTeleNo2" CssClass="Input1" runat="server"></asp:TextBox>
                <asp:Label ID="lblerr3" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="lblAddress2" CssClass="Labels" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="3" height="56">
                <asp:TextBox ID="txtAddress2" CssClass="Input1" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassNo" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="txtPassNo2" runat="server" CssClass="Input">
                </asp:DropDownList>
                <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPassType2" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="Input" ID="cmbvisitorPass" runat="server">
                    <asp:ListItem>Visitor Pass</asp:ListItem>
                    <asp:ListItem>VIP Pass</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblKeyNo2" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="txtKeyNo2" runat="server" CssClass="Input">
                </asp:DropDownList>
                <asp:Label ID="lblerr4" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblVehicleNo2" CssClass="Labels" runat="server" Text="Vehicle No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVehicleNo2" CssClass="Input1" runat="server"></asp:TextBox>
                <asp:Label ID="lblerr5" runat="server" Text="*" Font-Size="Smaller" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblToVisit2" CssClass="Labels" runat="server" Text="To Visit"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToVisit2" CssClass="Input1" runat="server"></asp:TextBox>
                <asp:Label ID="lblerr6" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblVisitorPurpose2" CssClass="Labels" runat="server" Text="Purpose"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVisitorPurpose2" CssClass="Input1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCompanyFrom2" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtCompanyFrom2" CssClass="Input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemDeclear" CssClass="Labels" runat="server" Text="Item Declaration"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtItemDeclear2" CssClass="Input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="lblRemarks2" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtRemarks2" CssClass="Input" runat="server" TextMode="MultiLine"
                    Height="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <div id="flashArea" class="flashArea" style="height: 100%;">
                    <p class="Labels">
                        <center>
                            This content requires the Adobe Flash Player.<br />
                            <a href="http://www.adobe.com/go/getflashplayer">
                                <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                    alt="Get Adobe Flash player" style="border: none" /><br />
                                <a href="http://www.macromedia.com/go/getflash" />Get Flash</a></center>
                    </p>
                </div>
                <script type="text/javascript">
                    var mainswf = new SWFObject("../take_picture.swf", "main", "650", "350", "9", "#ffffff");
                    mainswf.addParam("scale", "noscale");
                    mainswf.addParam("wmode", "window");
                    mainswf.addParam("allowFullScreen", "false");
                    //mainswf.addVariable("requireLogin", "false");
                    mainswf.write("flashArea");
                </script>
                <br />
                <asp:TextBox ID="txtrole" Text="visitor" runat="server" Visible="False" CssClass="Input"
                    Width="25px"></asp:TextBox>
            </td>
            <td  colspan="2">
                <asp:Image ID="Image3" runat="server" Width="250px" Height="250px"/>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <center>
                    <asp:Button ID="btnCheckIn2" CssClass="Button" runat="server" Text="Check In" OnClick="AddCheckInVisitor"
                        Width="85px" />
                    <asp:Button ID="btnClear2" CssClass="Button" runat="server" Text="Cancel" OnClick="btnClear2_Click"
                        Width="85px" />
                </center>
            </td>
        </tr>
        
        <tr style="display: none" >
            <td valign="top" align="left" colspan="2">
                <asp:Label runat="server" Text="Capture Image" CssClass="Labels" Visible="false"></asp:Label>
                &nbsp;
                <asp:FileUpload runat="server" CssClass="Labels" ID="FileUpload1" Visible="false"
                    onchange="javascript:showBrowse(this.value,0);" accept="gif|jpeg|png|jpg" maxlength="5">
                </asp:FileUpload>
            </td>
            
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvVisitorTable" runat="server" AllowPaging="true" AllowSorting="true"
                    AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" CssClass="GridMain"
                    OnPageIndexChanging="gvVisitorTable_PageIndexChanging" OnRowDataBound="gvVisitorTable_RowDataBound"
                    OnSelectedIndexChanged="gvVisitorTable_SelectedIndexChanged" Width="100%">
                    <HeaderStyle CssClass="HeaderRow" />
                    <RowStyle CssClass="NormalRow" />
                    <AlternatingRowStyle CssClass="AlternateRow" />
                    <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                    <SelectedRowStyle CssClass="HighlightedRow" />
                    <EmptyDataRowStyle CssClass="NoRecords" />
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoRecords" runat="server" Text="No records in the system.">
                        </asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="checkin_time" HeaderText="In Time" HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="checkout_time" HeaderText="Out Time" HeaderStyle-ForeColor="White" />
                        <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No."  HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="user_name" HeaderText="Name" HeaderStyle-ForeColor="White"/>
                        <%--<asp:BoundField DataField="user_address" HeaderText="Address" />--%>
                        <asp:BoundField DataField="telephone" HeaderText="Phone No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="pass_no" HeaderText="Pass No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="Key_no" HeaderText="Key No." HeaderStyle-ForeColor="White"/>
                        <%--  <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No." />--%>
                        <asp:BoundField DataField="to_visit" HeaderText="To Visit" HeaderStyle-ForeColor="White"/>
                        <%-- <asp:BoundField DataField="remarks" HeaderText="Remarks" />--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
