<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="Check_Out_Contractor.aspx.cs" Inherits="SMS.SMSUsers.Check_Out_Contractor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Check Out Contractor</span></div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <br />
        <div id="checkinContractor" runat="server" visible="true">
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="lblContractorID3" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNricID3" CssClass="Input" runat="server" AutoPostBack="true"
                            OnTextChanged="txtNricID3_TextChanged" Style="margin-left: .3em"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPassType3" CssClass="Labels" runat="server" Text="Pass No."></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassno" CssClass="Input" runat="server" AutoPostBack="true" OnTextChanged="txtPassno_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtrole" Text="Contractor" runat="server" Visible="False" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" Visible="false" runat="server" Style="width: 100%">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName3" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtName3" CssClass="Input" runat="server" ReadOnly="True" Width="480px"></asp:TextBox>
                                    </td>
                                    <td align="right" rowspan="3">
                                        <asp:Panel ID="Panel2" runat="server" Style="width: 100px; height: 100px;">
                                            <asp:Image runat="server" ID="Image3" Width="90px" Height="90px" ImageUrl="~/ImageUpload/BlankFace.jpg">
                                            </asp:Image>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTeleNo3" CssClass="Labels" runat="server" Text="Phone No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTeleNo3" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPassType" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassType" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAddress3" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtAddress3" CssClass="Input" runat="server" ReadOnly="True" Height="50px"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblKeyNo3" CssClass="Labels" runat="server" Text="Key No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKeyNo3" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblVehicleNo3" CssClass="Labels" runat="server" Text="Vehicle No."></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVehicleNo3" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyfrom3" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtCompanyfrom3" CssClass="Input" runat="server" ReadOnly="True"
                                            Height="17px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblpurpose" CssClass="Labels" runat="server" Text="Purpose"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtpurpose" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblServingAt1" CssClass="Labels" runat="server" Text="Serving At/Workstation"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtServingAt1" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblItemDeclear3" CssClass="Labels" runat="server" Text="Item Declaration"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtItemDeclear3" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblcheckinTime" CssClass="Labels" runat="server" Text="Check In Time"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcheckinTime" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRemarks3" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtRemarks3" CssClass="Input" runat="server" TextMode="MultiLine"
                                            Height="80px" ReadOnly="True" OnTextChanged="txtRemarks3_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <center>
                                            <asp:Button ID="btnCheckOut3" runat="server" CssClass="Button" Text="Check Out" OnClick="AddCheckOutSaleman"
                                                Width="100px" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnClear3" CssClass="Button" runat="server" Text="Cancel" OnClick="btnClear3_Click"
                                                Width="85px" />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div id="Div1" runat="server" visible="true">
            <asp:GridView ID="gvContractorTable" runat="server" AllowPaging="true" AllowSorting="true"
                AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" CssClass="GridMain2"
                OnPageIndexChanging="gvContractorTable_PageIndexChanging" OnRowDataBound="gvContractorTable_RowDataBound"
                OnSelectedIndexChanged="gvContractorTable_SelectedIndexChanged" Width="750px"
                PageSize="20">
                <HeaderStyle CssClass="HeaderRow" HorizontalAlign="Center" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" Height="20px" HorizontalAlign="Right" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" runat="server" Text="Your search did not match any Key or, there may be no records in the system."> </asp:Label>
                    <p>
                        Suggestions:</p>
                    <li>Try different keywords.</li>
                    <li>Try fewer keywords.</li>
                    <li>Make sure all words are spelled correctly.</li>
                    <li>There may be no records in the system.</li>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="checkin_time" HeaderText="Last In Time" />
                    <asp:BoundField DataField="checkout_time" HeaderText="Last Out Time " />
                    <asp:BoundField DataField="user_id" HeaderText="NRIC/FIN No." />
                    <asp:BoundField DataField="user_name" HeaderText="Name" />
                    <%-- <asp:BoundField DataField="user_address" HeaderText="Address" />--%>
                    <asp:BoundField DataField="telephone" HeaderText="Phone No." />
                    <asp:BoundField DataField="pass_no" HeaderText="Pass No." />
                    <asp:BoundField DataField="key_no" HeaderText="Key No." />
                    <%--<asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No."/>--%>
                    <asp:BoundField DataField="to_visit" HeaderText="To Visit" />
                    <asp:BoundField DataField="company_from" HeaderText="Company From" />
                    <asp:BoundField DataField="purpose" HeaderText="Purpose" />
                    <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
