<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountAlterUI.aspx.cs" Inherits="UniversityManagementSystem.UI.AccountAlterUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table style="width: 100%">

                <tr>
                    <td style="width: 100%; text-align: center">
                        <strong><span style="font-size: 16pt">Account Search</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center; font-weight: 700;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span style="font-size: 16pt">Search By</span></strong>&nbsp;&nbsp;&nbsp;
                         <asp:DropDownList ID="optionDropDownList" runat="server">
                               <asp:ListItem Selected="True">AccountId</asp:ListItem>
                               <asp:ListItem>FirstName</asp:ListItem>
                               <asp:ListItem>PhoneNo</asp:ListItem>
                          </asp:DropDownList>&nbsp;
                               <asp:TextBox ID="optionTextBox" runat="server"></asp:TextBox>               
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 26px; text-align: center">&nbsp;</td>                                                   
                </tr>
            </table>
        </div>

        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Search" Width="91px" />
            &nbsp;&nbsp;
            <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="logoutButton" runat="server" ForeColor="Red" OnClick="logoutButton_Click" Text="Logout" Width="115px" />
            &nbsp;&nbsp;
        </div>
        <div>
            
            &nbsp;<asp:Label ID="messageLabel" runat="server"></asp:Label>

        </div>
        <div>
            <table>
                <tr>
                <td style="text-align: center; width: 100%; height: 234px;">
                        <br />
                        <asp:GridView ID="accountGridView" runat="server" Width="566px"
                            AutoGenerateColumns="false" Font-Names="Arial"
                            Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                            HeaderStyle-BackColor="green"
                            AllowPaging="true"
                            ShowFooter="true"
                           
                             OnPageIndexChanging="OnPaging"
                            OnRowEditing="EditAccount"
                            OnRowUpdating="UpdateAccount"
                            OnRowCancelingEdit="CancelEdit"
                            PageSize="10">
                            <Columns>

                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Account ID">
                                    <ItemTemplate>
                                        <asp:Label ID="accountIdLabel" runat="server"
                                            Text='<%# Eval("AccountId")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editAccountIdTextBox" runat="server"
                                            Text='<%# Eval("AccountId")%>'></asp:TextBox>
                                    </EditItemTemplate>

                                    <FooterTemplate>
                                        <asp:TextBox ID="accountIdTextBox" Width="100px"
                                            MaxLength="8" runat="server"></asp:TextBox>
                                    </FooterTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="FirstName">
                                    <ItemTemplate>
                                        <asp:Label ID="firstNameLabel" runat="server"
                                            Text='<%# Eval("FirstName")%>'></asp:Label>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <asp:TextBox ID="editFirstNameTextBox" runat="server"
                                            Text='<%# Eval("FirstName")%>'></asp:TextBox>
                                    </EditItemTemplate>

                                    <FooterTemplate>
                                        <asp:TextBox ID="firstNameTextBox" Width="100px"
                                            MaxLength="8" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="30px" HeaderText="LastName">
                                    <ItemTemplate>
                                        <asp:Label ID="lastNameLabel" runat="server"
                                            Text='<%# Eval("LastName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editLastNameTextBox" runat="server"
                                            Text='<%# Eval("LastName")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="lastNameTextBox" Width="40px"
                                            MaxLength="5" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="100px" HeaderText="AccountType">
                                    <ItemTemplate>
                                        <asp:Label ID="accountTypeLabel" runat="server"
                                            Text='<%# Eval("AccountType")%>'></asp:Label>
                                    </ItemTemplate>

                                    <EditItemTemplate>
                                        <asp:TextBox ID="editAccountTypeTextBox" runat="server"
                                            Text='<%# Eval("AccountType")%>'></asp:TextBox>
                                    </EditItemTemplate>

                                    <FooterTemplate>
                                        <asp:TextBox ID="accountTypeTextBox" Width="100px"
                                            MaxLength="8" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="emailLabel" runat="server"
                                            Text='<%# Eval("Email")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editEmailTextBox" runat="server"
                                            Text='<%# Eval("Email")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="CellNo">
                                    <ItemTemplate>
                                        <asp:Label ID="cellNoLabel" runat="server"
                                            Text='<%# Eval("CellNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editCellNoTextBox" runat="server"
                                            Text='<%# Eval("CellNo")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="cellNoTextBox" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="addressLabel" runat="server"
                                            Text='<%# Eval("Address")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="editAddressTextBox" runat="server"
                                            Text='<%# Eval("Address")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="ExpDate">
                                    <ItemTemplate>
                                        <asp:Label ID="expDateLabel" runat="server"
                                            Text='<%# Eval("ExpDate")%>'></asp:Label>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        <asp:TextBox ID="expDateTextBox" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRemove" runat="server"
                                            CommandArgument='<%# Eval("AccountId")%>'
                                            OnClientClick="return confirm('Do you want to delete?')"
                                            Text="Delete"
                                            OnClick="DeleteAccount"></asp:LinkButton>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add"
                                            OnClick="AddNewAccount" />
                                    </FooterTemplate>
                                </asp:TemplateField>


                                <asp:CommandField ShowEditButton="True" />
                            </Columns>
                            <AlternatingRowStyle BackColor="#C2D69B" />
                        </asp:GridView>
                    </td>
                  </tr>
            </table>
        </div>

    </form>
</body>
</html>
