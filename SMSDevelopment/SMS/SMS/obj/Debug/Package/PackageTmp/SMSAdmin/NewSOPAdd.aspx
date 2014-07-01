<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="NewSOPAdd.aspx.cs" Inherits="SMS.SMSAdmin.NewSOPAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
        <div class="divHeader">
         <span class="pageTitle">Add New SOP</span></div>
        <div>
            <asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                CssClass="ValSummary"></asp:Label>
        </div> 
       <br />
             <div id="divAdvSearch" runat="server" visible="true">
                        <asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="750px">
            <table width="750px" class="table">
            <tr><td height="10"></td></tr>
                                             <tr>
                                                 <td>
                                                    <asp:Label ID="lbllocation" CssClass="Labels" runat="server" Text="Location"></asp:Label>
                                                </td>
                                                <td>
                                                <asp:UpdatePanel runat="server" ID="Updatepanel">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddllocation" runat="server" CssClass="Labels" 
                                                        onselectedindexchanged="ddllocation_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="searchid" runat="server" Text="" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                </td>
                                           
                                                <td>
                                                    <asp:Label ID="lblSOPIDSearch" Text="SOP No." CssClass="Labels" runat="server" visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSOPID" runat="server" CssClass="Input" visible="false" />
                                                     <asp:Label ID="lblerr1" CssClass="ValSummary" runat="server" Text="*" 
                                                      Font-Size="Smaller" ForeColor="Red"></asp:Label>
                                                </td>
                                          </tr>                            
                                          <tr>     
                                                <td>
                                                    <asp:Label ID="lblSOPtitle" Text="Title" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSOPtitle" runat="server" CssClass="Input" />
                                                </td> 
                                         
                                               <td>
                                                   <asp:Label ID="lblSOPsubject" Text="Subject" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtSOPsubject" runat="server" CssClass="Input" />                                                    
                                                </td>
                                          </tr>                                           
                                            <tr>
                                                <td>
                                                   <asp:Label ID="lblgenerate" Text="SOP Created By [NRIC/FIN No.]" CssClass="Labels" runat="server" visible="false"></asp:Label>
                                                </td>                                                
                                                <td>
                                                    <asp:TextBox ID="txtgenerate" runat="server" CssClass="Input" visible="false"/>  
                                                    <asp:Label ID="lblerr2" CssClass="ValSummary" runat="server" Text="*" 
                                                      Font-Size="Smaller" ForeColor="Red"></asp:Label>                                                  
                                                </td>                                            
                                            </tr> 
                                            <tr>                                                
                                                <td>
                                                    <asp:Label ID="lblimage" Text="Attach File" CssClass="Labels" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:fileupload ID="txtImagePath" runat="server" CssClass="Labels"></asp:fileupload>
                                                </td>
                                            </tr>                                                                                   
                                            <tr>
                                                
                                                <td height="50px">
                                                    &nbsp;</td>
                                                
                                            </tr>
                                            </table>
                                            
                        <table  width="750px" style="margin-left:0.005em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                                            <tr>
                                                <td colspan="4" align="center" style="width:750px">
                                                    <asp:Button ID="btnAddSOPAdd" runat="server" CssClass="Buttons" 
                                                        onclick="btnAddSOP_Click" Text="Add" Width="85px" />
                                                    &nbsp;&nbsp;&nbsp; &nbsp;
                                                    <asp:Button ID="btnClearSOPAdd" runat="server" CssClass="Buttons" 
                                                        onclick="btnClearSOPAdd_Click" Text="Cancel" Width="85px" />
                                                </td>
                                            </tr>
                                            
                                        </table>
                                        </asp:panel>
                   </div>  
        <br /> 
        <br />
         <div style=" margin-left:1.5em; width:750px">
            <asp:GridView ID="gvSOPTable" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" CellPadding="5" Width="750px" OnRowDataBound="gvSOP_RowDataBound"
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
                    <asp:Label ID="lblNoRecords" Text="No Record of This Location"
                        runat="server">
                    </asp:Label>
                   
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="Date_From" HeaderText="Time"><HeaderStyle Width="100px" /></asp:BoundField>
                    <asp:BoundField DataField="SOP_Title" HeaderText="Title"></asp:BoundField>                 
                    
                    <asp:HyperLinkField DataTextField="ImagePathName" DataNavigateUrlFields="ImagePathName"
                        DataNavigateUrlFormatString="../Images/{0}" HeaderText="File" />
                        
                 <%--   <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SOP_ID") %>'
                                CommandName="EditRow" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>--%>
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
    </div>

</asp:Content>
