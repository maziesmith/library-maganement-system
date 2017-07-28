<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookEditUI.aspx.cs" Inherits="UniversityManagementSystem.UI.BookEditUi2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table style="margin-top: 20px; font-size: 12pt; margin-bottom: 20px; margin-left: 10%; font-family: Verdana">
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         Search By &nbsp;
                        <asp:DropDownList ID="optionDropDownList" runat="server" Width="88px" Height="16px">
                            <asp:ListItem Selected="True">BookId</asp:ListItem>
                                            <asp:ListItem>Book Name</asp:ListItem>
                                            <asp:ListItem>Author</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td style="text-align: left; font-weight: bold; font-size: small; width: 224px; color: #758a85; font-family: Verdana; height: 21px" colspan="3">
                            <asp:TextBox ID="optionTextBox" runat="server" Width="126px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center" colspan="5">&nbsp;<asp:Button ID="searchButton" runat="server" ForeColor="Black" OnClick="searchButton_Click" Text="Search" Width="115px" />
                            &nbsp;&nbsp; 
                         <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
                            &nbsp;&nbsp;
                         <asp:Button ID="logoutButton" runat="server" ForeColor="Red" OnClick="logoutButton_Click" Text="Logout" Width="115px" />
                            &nbsp;&nbsp;
                         <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" colspan="5">

                            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                    <tr style="font-family: Verdana">
                        <td style="text-align: center" colspan="4">&nbsp;&nbsp;
                    <asp:GridView ID="booksGridView" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="BookId"
                        CellPadding="4"
                        ForeColor="#333333"
                        OnPageIndexChanging="booksGridView_PageIndexChanging"
                        OnRowCommand="booksGridView_RowCommand"
                        OnRowDataBound="booksGridView_RowDataBound"
                        OnRowEditing="booksGridView_RowEditing"
                        OnDataBound="booksGridView_DataBound"
                        OnRowDeleting="booksGridView_RowDeleting"
                        Font-Size="Small" PageSize="20" GridLines="Vertical" Style="margin-top: 0px">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="BookId">
                                <ItemTemplate>
                                    <asp:Label ID="bokIdLabel" runat="server"
                                        Text='<%# Bind("BookId") %>' Width="80px"></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Book Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="bookNameTextBox" runat="server"
                                        Text='<%# Bind("Name") %>' Width="80px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Author">
                                <ItemTemplate>
                                    <asp:TextBox ID="authorTextBox" runat="server"
                                        Text='<%# Bind("Author") %>' Width="80px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Version">
                                <ItemTemplate>
                                    <asp:TextBox ID="versionTextBox" runat="server"
                                        Text='<%# Bind("Version") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Book Type">
                                <ItemTemplate>
                                    <asp:TextBox ID="bookTypeTextBox" runat="server"
                                        Text='<%# Bind("BookType") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="quantityTextBox" runat="server"
                                        Text='<%# Bind("Quantity") %>' Width="50px"
                                        AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:TextBox ID="piceTextBox" runat="server"
                                        Text='<%# Bind("Price") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditButton" runat="server"
                                        CommandName="Edit" ForeColor="Black">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteButton" runat="server"
                                        CommandName="Delete" ForeColor="Black">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:ButtonField HeaderText="Details" Text="Details"
                                CommandName="BookInfoDetails" />

                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="LightSlateGray" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="LightSlateGray" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                        </td>
                    </tr>
                </table>
                <div class="" style="margin-top: 20px; font-weight: bold; color: black; font-style: normal; font-family: Verdana; text-align: center; margin-bottom: 20px;">
                    <br />
                    <br />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
