<%@ Page Language="C#" MasterPageFile="~/SMSmaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SMS.SMSChat.Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divContainer">
   <div class="divHeader"><span class="pageTitle">User Registration </span></div> 
   <div>
         <table cellSpacing="0" cellPadding="0" style="Width:800px;	padding-top:35px;	height:400px;" align="center" border="0">
				<tr>	
					<td valign="top">
						<table cellspacing="1" cellpadding="5" border="0" style="width: 600px;	background-color: #cccccc" align="center">
							<tr>
								<td valign=top style="padding:4px 5px 4px 15px;	background-color: #eeeeee;	color: #444444;	font-family: Tahoma, Arial, Helvetica;
									font-size: 12px;	font-weight: bold;	height:24px;	background-image:url(images/WindowHeader.gif" height="30">
									 Registration Information  
								</td>
							</tr>
							<tr>
								<td valign=top style="background-color: #f9f9f9; padding:15px;">
									<table width="100%" cellspacing="1" cellpadding="3" border="0" align="center">
										<tr>
											<td>
												<table cellspacing="1" border="0" cellpadding="5">
													<tr>
														<td >
														    <asp:label ID="lblName" runat="server" text="User Name"  class="Labels"></asp:label>
														
                                                         </td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtUsername" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" Display="Dynamic"></asp:RequiredFieldValidator>
															<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please keep Username one word with no spaces or special characters." ValidationExpression="^[a-zA-Z0-9\._-]+$"></asp:RegularExpressionValidator>
														</td>
													</tr>
													<tr>
														<td>
														    <asp:label ID="lblpassword" runat="server" text="Password"  class="Labels"></asp:label>
														
														</td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtPassword" runat="server" Width="200px" TextMode="Password" 
                                                                CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
															<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Passwords do not match"
																ControlToValidate="txtPassword2" Display="Dynamic" ControlToCompare="txtPassword"></asp:CompareValidator>
														</td>
													</tr>
													<tr>
													    <td>
														    <asp:label ID="lblrepassword" runat="server" text="Re-Write Password"  class="Labels"></asp:label>
														
														</td>
														
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtPassword2" runat="server" Width="200px" TextMode="Password" 
                                                                CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword2"
															Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
													      <td>
														    <asp:label ID="lblfname" runat="server" text="First Name"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtFirstName" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtFirstName" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
													     <td>
														    <asp:label ID="lblmname" runat="server" text="Middle Name"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtMiddleName" runat="server" Width="200px" CssClass="Input"></asp:TextBox>															
														</td>
													</tr>
													<tr>
													     <td>
														    <asp:label ID="lblLname" runat="server" text="Last Name"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtLastName" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Last Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
													    <td>
														    <asp:label ID="lblcontry" runat="server" text="Country"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21">
															<asp:TextBox id="txtCountry" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
													<tr>
													     <td>
														    <asp:label ID="lblmpbile" runat="server" text="Mobile"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21" >
															<asp:TextBox id="txtMobile" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
													<tr>
													     <td>
														    <asp:label ID="lblmail" runat="server" text="Email"  class="Labels"></asp:label>
														
														</td>
														
														<td height="21"  style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtEmail" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="Invalid Email"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
                                                    <tr>
                                                        <td>
														    <asp:label ID="lblrole" runat="server" text="Role"  class="Labels"></asp:label>
														
														</td>
                                                        <td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
                                                            <asp:DropDownList ID="ddlRole" runat="server" Width="210px" CssClass="Input" >
                                                            </asp:DropDownList>
                                                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:chatConnectionString %>" 
                                                                SelectCommand="SELECT [RoleName] FROM [RoleMaster] ORDER BY [RoleName]">
                                                            </asp:SqlDataSource>
                                                            <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ErrorMessage="Role is required" ControlToValidate="ddlRole" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
													<tr>
													      <td>
														       <asp:label ID="lblSquestion" runat="server" text="Your Secret Question"  class="Labels"></asp:label>
														</td>  
													
														
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtQuestion" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="Secret Question is required" ControlToValidate="txtQuestion" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>													
													<tr>
													     <td>
														       <asp:label ID="lblSanswer" runat="server" text="Your Secret Answer"  class="Labels"></asp:label>
														</td>
													
														
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtAnswer" runat="server" Width="200px" CssClass="Input"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Secret Answer is required" ControlToValidate="txtQuestion" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td width="130px">&nbsp;</td>
														<td>
															
													</tr>
												</table>											
											</td>
										</tr>
										<tr>
										    
											<td align="center">
											    <asp:Button id="btnReg" runat="server" OnClick="btnReg_Click" Width="80px" 
                                                Text="Register" CssClass="Buttons" ></asp:Button>
												&nbsp;&nbsp;&nbsp;	<asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" 
                                                Width="80px" Text="Cancel" CausesValidation="False" CssClass="Buttons"></asp:Button></td>
											
											</td>
											 
										</tr>
									</table>									
								</td>
							</tr>
						</table>
				</td>					
				</tr>
			</table>
   </div>
</asp:Content>
