<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="Check_In_Contractor.aspx.cs" Inherits="SMS.SMSUsers.Check_In_Contractor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function showBrowse(pFile, idx) {

            document.getElementById("ctl00_ContentPlaceHolder1_Image3").src = pFile;
        }
    </script>
    <script src="../swfobject.js" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divHeader">
        <span class="pageTitle">Check In Contractor</span></div>
    <div>
        <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblName3" CssClass="Labels" runat="server" Text="Name"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtName3" CssClass="Input" runat="server"></asp:TextBox>
                <asp:Label ID="lblname" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    Visible="false" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblContractorID3" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNricID3" CssClass="Input" runat="server" OnTextChanged="txtNricID3_TextChanged"
                    AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTeleNo3" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTeleNo3" runat="server" CssClass="Input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress3" CssClass="Labels" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtAddress3" CssClass="Input" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassNo3" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="txtPassNo3" runat="server" CssClass="Input">
                </asp:DropDownList>
                <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPassType3" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="Input" ID="cmbContractorPass" runat="server">
                    <asp:ListItem>Contractor Pass</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblKeyNo3" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="txtKeyNo3" runat="server" CssClass="Input">
                </asp:DropDownList>
                <asp:Label ID="lblerr4" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblVehicleNo3" CssClass="Labels" runat="server" Text="Vehicle No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVehicleNo3" CssClass="Input" runat="server"></asp:TextBox>
                <asp:Label ID="lblerr5" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCompanyfrom3" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtCompanyfrom3" CssClass="Input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblpurpose" CssClass="Labels" runat="server" Text="Purpose"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpurpose" CssClass="Input" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblServingAt1" CssClass="Labels" runat="server" Text="Serving At/Workstation"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtServingAt1" CssClass="Input" runat="server"></asp:TextBox>
                <asp:Label ID="lblerr6" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemDeclear3" CssClass="Labels" runat="server" Text="Item Declaration"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtItemDeclear3" CssClass="Input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRemarks3" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtRemarks3" CssClass="Input" runat="server" TextMode="MultiLine"
                    Height="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <div id="flashArea" class="flashArea" style="height: 100%;">
                    <p class="Labels">
                        <center>
                            This content requires the Adobe Flash Player.<br />
                            <a href="http://www.adobe.com/go/getflashplayer">
                                <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                                    alt="Get Adobe Flash player" style="border: none" /><br />
                                <a href="http://www.macromedia.com/go/getflash" />Get Flash</a>
                        </center>
                    </p>
                </div>
                <script type="text/javascript">
                    var mainswf = new SWFObject("../take_picture.swf", "main", "800", "350", "9", "#ffffff");
                    mainswf.addParam("scale", "noscale");
                    mainswf.addParam("wmode", "window");
                    mainswf.addParam("allowFullScreen", "false");
                    //mainswf.addVariable("requireLogin", "false");
                    mainswf.write("flashArea");
                </script>
                <br />
                <asp:TextBox ID="txtrole" Text="Contractor" runat="server" Visible="False" CssClass="Input"
                    Width="25px"></asp:TextBox>
            </td>
           <td>
                <asp:Image ID="Image3" runat="server" Width="250px" Height="250px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <center>
                    <asp:Button ID="btnCheckIn3" runat="server" CssClass="Button" Text="Check In" OnClick="AddCheckInContractor"
                        Width="94px" />
                    <asp:Button ID="btnClear3" CssClass="Button" runat="server" Text="Cancel" OnClick="btnClear3_Click"
                        Width="85px" />
                </center>
            </td>
        </tr>
      
        <td valign="top" colspan="4">
            <asp:Label ID="Label2" runat="server" Text="Capture Image" CssClass="Labels" Visible="False"></asp:Label>
            <asp:FileUpload runat="server" CssClass="Labels" ID="FileUpload1" onchange="javascript:showBrowse(this.value,0);"
                accept="gif|jpeg|png|jpg" maxlength="5" Width="206px" Visible="False"></asp:FileUpload>
        </td>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvContractorTable" runat="server" AllowPaging="true" AllowSorting="true"
                    AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" CssClass="GridMain2"
                    OnPageIndexChanging="gvContractorTable_PageIndexChanging" OnRowDataBound="gvContractorTable_RowDataBound"
                    OnSelectedIndexChanged="gvContractorTable_SelectedIndexChanged" Width="100%"
                    PageSize="20">
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
                        <asp:BoundField DataField="checkin_time" HeaderText="In Time" HeaderStyle-ForeColor="White" />
                        <asp:BoundField DataField="checkout_time" HeaderText="Out Time" HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="NRICno" HeaderText="NRIC/FIN No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="user_name" HeaderText="Name" HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="telephone" HeaderText="Phone No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="pass_no" HeaderText="Pass No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="Key_no" HeaderText="Key No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No." HeaderStyle-ForeColor="White"/>
                        <asp:BoundField DataField="to_visit" HeaderText="To Visit" HeaderStyle-ForeColor="White"/>
                        <%-- <asp:BoundField DataField="remarks" HeaderText="Remarks" />--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
