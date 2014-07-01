<%@ Page Language="C#" MasterPageFile="../SMSmaster.Master" AutoEventWireup="true" CodeBehind="SalesmanReport.aspx.cs" Inherits="SMS.Reports.SalesmanReport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divContainer">
        <div class="divHeader"><span class="pageTitle">Salesman Report</span>
        </div>
        <br />
        <table align="left">
              <tr>
                <td>
                    <asp:Label ID="lblStartDate" CssClass="Labels" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStartDate1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblEndDate1" CssClass="Labels"  runat="server" Text="End Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndDate1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblSalesmanID1" CssClass="Labels"  runat="server" Text="Salesman ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSalesmanID1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label ID="lblName1" CssClass="Labels"  runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblMonth1" CssClass="Labels"  runat="server" Text="Month"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMonth1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblYear1" CssClass="Labels"  runat="server" Text="Year"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYear1" CssClass="Input" runat="server"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td colspan="6" align="left">
                    <asp:Button ID="btnSearch1" CssClass="Buttons" runat="server" Text="Search" />
                </td>
            </tr> 
        </table>
        </div>
        <br />
        <div>
        <asp:GridView ID="GridView1" CssClass="GridMain" runat="server"  AllowPaging="true" AllowSorting="true" 
            AutoGenerateColumns="false" CellPadding="5" CellSpacing="0" Width="100%" > 
            <AlternatingRowStyle CssClass="Alternaterow" />
            <HeaderStyle CssClass="HeaderRow" />
            <RowStyle CssClass="NormalRow" />
            
            
            <AlternatingRowStyle CssClass="AlternateRow"/>
            <PagerStyle CssClass="PagingRow" HorizontalAlign="Right" Height="20px"/>
            <SelectedRowStyle CssClass="HighlightedRow"/>
            <EmptyDataRowStyle CssClass="NoRecords"/>
            <EmptyDataTemplate>
            <asp:Label ID="lblNoRecords" Text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                 <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                <li>To add Billing Table click the Add New Billing Table button.</li>
            </EmptyDataTemplate>
            
           
            
            <Columns>
                <asp:BoundField HeaderText="Salesman ID" />
                <asp:BoundField HeaderText="Name" />
                <asp:BoundField HeaderText="Address" />
                <asp:BoundField HeaderText="Tele No." />
                <asp:BoundField HeaderText="Company From" />
                <asp:BoundField HeaderText="To Visit" />
                <asp:BoundField HeaderText="Remark" />
                <asp:BoundField HeaderText="Vehicle No." />
                <asp:BoundField HeaderText="Key No." />
                <asp:BoundField HeaderText="Pass Type" />
                <asp:TemplateField HeaderText="Edit/View" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.locid") %>' CommandName="EditRow" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField> 
                
                
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <div>
          <table align="left">
            <tr>
                <td>
                    <asp:Label ID="salseman1" CssClass="Labels" runat="server" Text="Total Salesman" 
                        ForeColor="#000099"></asp:Label>
&nbsp;<asp:Label ID="salesman2" CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>&nbsp;&nbsp;
                </td>
                <td>
                    <asp:Label ID="vechicle1" CssClass="Labels" runat="server" Text="Total Vehicle" 
                        ForeColor="#000099"></asp:Label>
&nbsp;<asp:Label ID="vehicle2"  CssClass="Labels" runat="server" ForeColor="#000099"></asp:Label>&nbsp;&nbsp;
                </td>
                
                <td>
                
                <asp:Label ID="exportto" CssClass="Labels" runat="server" Text="Export To" ForeColor="#000099"></asp:Label>
                    
&nbsp;<asp:DropDownList ID="DropDownList1" CssClass="Labels" runat="server" ForeColor="#000099">
                    <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>Pdf</asp:ListItem>
                    
                    </asp:DropDownList>&nbsp;&nbsp;
                
                
                </td>
                <td>
                    <asp:Button ID="btnEmail" CssClass="Buttons" runat="server" Text="E-Mail" Width="100px" />
                </td>
                <td>
                
                
                    <asp:Button ID="btnPrint" CssClass="Buttons" runat="server" Text="Print" Width="100px" />
                
                
                </td>
            </tr>
            
        </table>
        <br /> 
        </div>  
    
</asp:Content>
