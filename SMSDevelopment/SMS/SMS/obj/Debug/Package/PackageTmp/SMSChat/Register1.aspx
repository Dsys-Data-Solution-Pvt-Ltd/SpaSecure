<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register1.aspx.cs" Inherits="SMS.SMSChat.Register1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Registration Page</title>
</head>
<body>
<form id="form1" runat="server">
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
														<td align="right" 
                                                            style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;" 
                                                            width="150" valign="middle">
															User Name </td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtUsername" runat="server" Width="200px"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="txtUsername" Display="Dynamic"></asp:RequiredFieldValidator>
															<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please keep Username one word with no spaces or special characters." ValidationExpression="^[a-zA-Z0-9\._-]+$"></asp:RegularExpressionValidator>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Password</td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
															<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Passwords do not match"
																ControlToValidate="txtPassword2" Display="Dynamic" ControlToCompare="txtPassword"></asp:CompareValidator>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Re-enter Password</td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtPassword2" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required." ControlToValidate="txtPassword2"
															Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">First Name:</td>
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtFirstName" runat="server" Width="200px"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtFirstName" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Middle Name:</td>
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtMiddleName" runat="server" Width="200px"></asp:TextBox>															
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Last Name:</td>
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtLastName" runat="server" Width="200px"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Last Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Country:</td>
														<td height="21">
															<asp:TextBox id="txtCountry" runat="server" Width="200px"></asp:TextBox>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Mobile:</td>
														<td height="21" >
															<asp:TextBox id="txtMobile" runat="server" Width="200px"></asp:TextBox>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Email:</td>
														<td height="21"  style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtEmail" runat="server" Width="200px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regEmail" runat="server" ErrorMessage="Invalid Email"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
															<%--<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>--%>
														</td>
													</tr>
                                                    <tr>
                                                        <td align="right" style="color: #444444; font-family: Tahoma, Arial, Helvetica; font-size: 12px;
                                                            font-weight: bold;">
                                                            Role:
                                                        </td>
                                                        <td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
                                                            <asp:DropDownList ID="ddlRole" runat="server" Width="210px" >
                                                               <%-- DataSourceID="SqlDataSource1" DataTextField="RoleName" 
                                                                DataValueField="RoleName">--%>
                                                            </asp:DropDownList>
                                                            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                ConnectionString="<%$ ConnectionStrings:chatConnectionString %>" 
                                                                SelectCommand="SELECT [RoleName] FROM [RoleMaster] ORDER BY [RoleName]">
                                                            </asp:SqlDataSource>
                                                            <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ErrorMessage="Role is required" ControlToValidate="ddlRole" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
													<tr>
														<td align="right" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Your Secret Question:</td>
														<td height="21" style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtQuestion" runat="server" Width="200px"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="Secret Question is required" ControlToValidate="txtQuestion" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>													
													<tr>
														<td align="right" style="color: #444444;	font-family: Tahoma, Arial, Helvetica;	font-size: 12px;	font-weight: bold;">Your Secret Answer:&nbsp;</td>
														<td style="color: #444444; font-family: Tahoma, Arial, Helvetica;	font-size: 12px;">
															<asp:TextBox id="txtAnswer" runat="server" Width="200px"></asp:TextBox>
															<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Secret Answer is required" ControlToValidate="txtQuestion" Display="Dynamic"></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td>&nbsp;</td>
														<td>
															<asp:Button id="btnReg" runat="server" OnClick="btnReg_Click" Width="80px" Text="Register"></asp:Button>
															<asp:Button id="btnCancel" runat="server" OnClick="btnCancel_Click" Width="80px" Text="Cancel" CausesValidation="False"></asp:Button></td>
													</tr>
												</table>											
											</td>
										</tr>
										<tr>
											<td height="28">&nbsp;</td>
										</tr>
									</table>									
								</td>
							</tr>
						</table>
				</td>					
				</tr>
			</table>
    </form>
</body>
</html>
