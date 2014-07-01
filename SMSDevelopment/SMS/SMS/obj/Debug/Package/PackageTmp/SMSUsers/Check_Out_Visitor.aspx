<%@ Page Language="C#" MasterPageFile="~/master/SpaMaster.Master" AutoEventWireup="true"
    CodeBehind="Check_Out_Visitor.aspx.cs" Inherits="SMS.SMSUsers.Check_Out_Visitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">Check Out Visitor</span>
        </div>
        <div>
            <asp:Label ID="lblerror" runat="server" ForeColor="Red" Font-Bold="True" CssClass="ValSummary"></asp:Label></div>
        <br />
        <div id="divAdvSearch" runat="server" visible="true">
            <div id="checkinContractor" runat="server" visible="true">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblVisitorID2" CssClass="Labels" runat="server" Text="NRIC/FIN No."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNricID2" CssClass="Input" runat="server" OnTextChanged="txtaddNumberofStaff_Changed"
                                AutoPostBack="true" Style="margin-left: 1em"></asp:TextBox>
                            <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" Font-Size="Smaller"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPassNo2" runat="server" CssClass="Labels" Text="Pass No."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassNo2" runat="server" CssClass="Input" OnTextChanged="txtPassNo2_TextChanged"
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtrole" Text="Visitor" runat="server" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Panel ID="Panel1" runat="server" Visible="false" Width="100%">
                                <table align="left" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblName2" CssClass="Labels" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtName2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td align="right" rowspan="3">
                                            <asp:Panel ID="imagepanel" runat="server" Style="width: 100px; height: 100px; border: 2px solid Black;
                                                margin-left: 5.5em">
                                                <asp:Image ID="image3" runat="server" Height="100px" Width="100px" ImageUrl="../ImageUpload/im.jpg">
                                                </asp:Image>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTeleNo2" runat="server" CssClass="Labels" Text="Phone No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTeleNo2" runat="server" CssClass="Input" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPassType2" CssClass="Labels" runat="server" Text="Pass Type"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpasstype" runat="server" CssClass="Input" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAddress2" CssClass="Labels" runat="server" Text="Address"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtAddress2" CssClass="Input" runat="server" ReadOnly="True" Height="50px"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblKeyNo2" runat="server" CssClass="Labels" Text="Key No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeyNo2" runat="server" CssClass="Input" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVehicleNo2" CssClass="Labels" runat="server" Text="Vehicle No."></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVehicleNo2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblToVisit2" CssClass="Labels" runat="server" Text="To Visit"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtToVisit2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVisitorPurpose2" CssClass="Labels" runat="server" Text="Purpose"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVisitorPurpose2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCompanyFrom2" CssClass="Labels" runat="server" Text="Company From"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtCompanyFrom2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblItemDeclear" CssClass="Labels" runat="server" Text="Item Declaration"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtItemDeclear2" CssClass="Input" runat="server" ReadOnly="True"></asp:TextBox>
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
                                            <asp:Label ID="lblRemarks2" CssClass="Labels" runat="server" Text="Remarks"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtRemarks2" CssClass="Input" runat="server" TextMode="MultiLine"
                                                Height="80px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <center>
                                                <asp:Button ID="btnCheckOut2" CssClass="Button" runat="server" Text="Check Out" OnClick="AddCheckOutVisitor"
                                                    Width="100px" />
                                                <asp:Button ID="btnClear2" CssClass="Button" runat="server" Text="Cancel" OnClick="btnClear2_Click"
                                                    Width="100px" />
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
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
                                    <asp:Label ID="lblNoRecords" runat="server" Text="Your search did not match any Key or, there may be no records in the system.">
                                    </asp:Label>
                                    <p>
                                        Suggestions:</p>
                                    <li>Try different keywords.</li>
                                    <li>Try fewer keywords.</li>
                                    <li>Make sure all words are spelled correctly.</li>
                                    <li>There may be no records in the system.</li>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="checkin_time" HeaderText="Last In Time" HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="checkout_time" HeaderText="Last Out Time " HeaderStyle-ForeColor="White" />
                                    <asp:BoundField DataField="user_id" HeaderText="NRIC/FIN No." HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="user_name" HeaderText="Name" />
                                    <%-- <asp:BoundField DataField="user_address" HeaderText="Address" />--%>
                                    <asp:BoundField DataField="telephone" HeaderText="Phone No." HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="pass_no" HeaderText="Pass No." HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="key_no" HeaderText="Key No." HeaderStyle-ForeColor="White"/>
                                    <%--<asp:BoundField DataField="vehicle_no" HeaderText="Vehicle No."/>--%>
                                    <asp:BoundField DataField="to_visit" HeaderText="To Visit" HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="company_from" HeaderText="Company From" HeaderStyle-ForeColor="White"/>
                                    <asp:BoundField DataField="purpose" HeaderText="Purpose" HeaderStyle-ForeColor="White"/>
                                    <%--<asp:BoundField DataField="remarks" HeaderText="Remarks"/>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
