<%@ Page Language="C#" MasterPageFile="~/master/login.Master" AutoEventWireup="true" CodeBehind="PenaltySecurityPersnnel.aspx.cs" Inherits="SMS.SuperVisor.PenaltySecurityPersnnel"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="divContainer">
             <div class="divHeader">

                <span class="pageTitle">Penalty Clause For Security Personnel</span></div>
             
           
           <div id="divAdvSearch" runat="server" visible="true">  
             <div><asp:Label id="lblerror" runat="server" ForeColor="Red" Font-Bold="True" 
                    CssClass="ValSummary"></asp:Label></div> 
         </div>
   <br/>       
    <asp:Panel ID="printview" runat="server">
       <br /><asp:panel runat="server" ID="Panel1" BackColor="White" 
                            style=" margin-left:1.5em" Font-Bold="True" width="700px">
              <div class="table" align="center" style="height: 22px"><asp:Label id="Label1" runat="server"  
                    Font-Bold="True" CssClass="Labels" 
                    Text="PENALTY CLAUSE FOR ALL SECURITY PERSONNEL" Font-Size="Medium"></asp:Label>
             </div>                  
            <br />
            <br />
        <div style=" margin-left:1.5em; width:750px">
            <asp:gridview id="gvPassTable" runat="server" allowpaging="True" allowsorting="True"
                autogeneratecolumns="False" cellpadding="5" width="670px" onrowdatabound="gvPass_RowDataBound"
                onrowcommand="gvPass_RowCommand" onpageindexchanging="gvPass_PageIndexChanging"
                cssclass="GridMain2" 
                onselectedindexchanged="gvPassTable_SelectedIndexChanged" PageSize="20">
            
            <HeaderStyle cssclass="HeaderRow" HorizontalAlign="Center"/>
            <RowStyle cssclass="NormalRow"/>
            <AlternatingRowStyle cssclass="AlternateRow"/>
            <PagerStyle cssclass="PagingRow" horizontalalign="Right" height="20px"/>
            <SelectedRowStyle cssclass="HighlightedRow"/>
            <EmptyDataRowStyle cssclass="NoRecords"/>
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecords" text="Your search did not match any Key or, there may be no records in the system." runat="server">
                </asp:Label>
                <p>Suggestions:</p>                    
                <li>Try different keywords.</li>
                <li>Try fewer keywords.</li>
                <li>Make sure all words are spelled correctly.</li>
                <li>There may be no records in the system.</li>
                
            </EmptyDataTemplate>
            

            <Columns>           
                                        
                  <%-- <asp:BoundField datafield="Penality_id" headertext="ID" ItemStyle-Width="10px"></asp:BoundField> --%>
                    <asp:BoundField datafield="Heading" headertext="Heading"></asp:BoundField>
                    <%--<asp:BoundField datafield="Clause" headertext="Clause"></asp:BoundField>--%>
                     <asp:BoundField datafield="Fine" headertext="Fine" ItemStyle-Width="100px"></asp:BoundField>                     
                 
                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="../Images/Edit.gif" ID="btnEdit" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Penality_id") %>' CommandName="Edit" runat="server"/>
                    </ItemTemplate>
                     <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField> 
                
                <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Delete.gif" ID="btnDelete" CommandArgument ='<%# DataBinder.Eval(Container, "DataItem.Penality_id") %>' CommandName="DeleteRow" runat="server"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
              
            </Columns>
       </asp:gridview>
  </div>
  
   
  
  <br />
          <div>
               <table  width="670px" style="margin-left:1.4em; margin-bottom:-0.4em;border:1px;border-style:groove; border-color:Black;background: url(../Images/1397d40aa687.jpg)">
                <tr><td colspan="4" align="center" width="670px">
                          <asp:button id="btnNewPass" text="Add New Penalty Clause" runat="server" 
                            cssclass="Buttons" onclick="btnNewPass_Click" Font-Bold="False" />
                       </td>
                      
                   </tr>
                </table>
                       
                        
          </div>
          </asp:panel>
          </asp:Panel>
        <br />
    </div>


</asp:Content>
