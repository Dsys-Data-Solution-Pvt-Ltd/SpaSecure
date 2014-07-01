<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true"
    CodeBehind="SOPAdmin.aspx.cs" Inherits="SMS.SMSAdmin.SOPAdmin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader">
            <span class="pageTitle">SOP Master</span></div>
        <div id="divAdvSearch" runat="server" visible="true">
            <br />
            <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="880">
            <table width="800" class="table">
            <tr><td height="10"></td></tr>
                <tr>
                    <td style="width: 103px">
                        <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td style="width: 244px">
                        <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels">
                        </asp:DropDownList>
                       <asp:Label ID="Searchid" runat="server" Text="" Visible="false"></asp:Label>
                    </td>  
                    <td>
                        <asp:Label ID="lblSOPtitle" Text="Title" CssClass="Labels" runat="server"></asp:Label>
                    </td>
                    <td style="width: 220px">
                        <%--<asp:TextBox ID="txtSOPtitle" runat="server" CssClass="Input" />--%>
                        <asp:DropDownList ID="txtSOPtitle" runat="server" CssClass="Labels">
                        </asp:DropDownList>
                        
                    </td>              
                </tr>
                
                <tr>
                    
                    <td style="width: 103px">
                        <asp:Label ID="lbldatefrom" CssClass="Labels" runat="server" Text="Date:  From"></asp:Label>
                    </td>
                    <td style="width: 244px">
                        <asp:TextBox ID="txtdatefrom" CssClass="Input" runat="server" OnTextChanged="txtdatefrom_TextChanged"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdatefrom" PopupButtonID="imgBtnFromDate2" />
                        <asp:ImageButton ID="imgBtnFromDate2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate2_Click" class="calender"/>
                    </td>
                    <td>
                        <asp:Label ID="lbldateto" CssClass="Labels" runat="server" Text="To"></asp:Label>
                    </td>
                    <td style="width: 220px">
                        <asp:TextBox ID="txtdateto" CssClass="Input" runat="server" OnTextChanged="txtdateto_TextChanged"></asp:TextBox>
                        <AJAX:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="AjaxCalendar"
                            Format="MM/dd/yyyy" TargetControlID="txtdateto" PopupButtonID="imgBtnFromDate3" />
                        <asp:ImageButton ID="imgBtnFromDate3" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar.bmp"
                            OnClick="imgBtnFromDate3_Click" class="calender"/>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 103px">
                        <asp:Label ID="lblSOPIDSearch" Text="SOP No." CssClass="Labels" runat="server" visible=false></asp:Label>
                    </td>
                    <td style="width: 244px">
                        <asp:TextBox ID="txtSOPID" runat="server" CssClass="Input" visible=false />
                    </td>
                    
                    <td style="width: 70px">
                        <asp:Label ID="lblSOPSubject" Text="Subject" CssClass="Labels" runat="server" visible=false></asp:Label>
                    </td>
                    <td>
                       <%-- <asp:TextBox ID="txtSOPSubjectSearch" runat="server" CssClass="Input" />--%>
                         <asp:DropDownList ID="txtSOPSubjectSearch" runat="server" CssClass="Labels" visible=false>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="20px" style="width: 103px">
                    </td>
                </tr>
                <table  width="100%" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr>
                    <td colspan="4" align="center" style="width: 897px">
                        <asp:Button ID="btnSearchSOPAdd" Text="Search" runat="server" CssClass="Buttons"
                            OnClick="btnsearchSOP_Click" Width="85px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnClearSOPAdd" Text="Clear" runat="server" CssClass="Buttons" OnClick="btnClearSOPAdd_Click"
                            Width="85px" />
                    </td>
                </tr>
                </table>
            </table>
            </asp:panel>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvSOPTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="100%" OnRowDataBound="gvSOP_RowDataBound"
                OnRowCommand="gvSOP_RowCommand" OnPageIndexChanging="gvSOP_PageIndexChanging"
                CssClass="GridMain2" HeaderStyle-HorizontalAlign="Center" 
                ItemStyle-HorizontalAlign="Center" PageSize="100">
                <HeaderStyle CssClass="HeaderRow" />
                <RowStyle CssClass="NormalRow" />
                <AlternatingRowStyle CssClass="AlternateRow" />
                <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px" />
                <SelectedRowStyle CssClass="HighlightedRow" />
                <EmptyDataRowStyle CssClass="NoRecords" />
                <EmptyDataTemplate>
                    <asp:Label ID="lblNoRecords" Text="no record(s) in the system."
                        runat="server">
                    </asp:Label>                
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Date_From" HeaderText="Time"><HeaderStyle Width="100px" /></asp:BoundField>
                    <asp:BoundField DataField="SOP_Title" HeaderText="Title"></asp:BoundField>                 
                    
                    <asp:HyperLinkField DataTextField="ImagePathName" DataNavigateUrlFields="ImagePathName"
                        DataNavigateUrlFormatString="../FileUpload/{0}" HeaderText="File" />
                        
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SOP_ID") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SOP_ID") %>'
                                CommandName="DeleteRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <div class="table">  
              <table  width="102%" style="margin-left:0.1em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
        <tr><td colspan="4" align="center" style="width: 897px">    
              <asp:Button ID="btnNewItem" Text="Add New SOP" runat="server" CssClass="Buttons" OnClick="btnNewSOP_Click" />                 
        </td></tr>
        </table>
        </div>
        <br />
    </div>
</asp:Content>
