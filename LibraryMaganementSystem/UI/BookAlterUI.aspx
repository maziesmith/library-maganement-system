<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookAlterUI.aspx.cs" Inherits="UniversityManagementSystem.UI.BookAlterUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 132px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: center; " class="auto-style1">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <strong><span style="font-size: 16pt">Book Search</span></strong></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">Search Option&nbsp;
                                        <asp:DropDownList ID="optionDropDownList" runat="server">
                                            <asp:ListItem Selected="True">BookId</asp:ListItem>
                                            <asp:ListItem>Book Name</asp:ListItem>
                                            <asp:ListItem>Author</asp:ListItem>
                                        </asp:DropDownList>&nbsp;
                                      <asp:TextBox ID="optionTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: left">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; 
                                       <asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Search" Width="80px" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                        <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="logoutButton" runat="server" ForeColor="Red" OnClick="logoutButton_Click" Text="Logout" Width="115px" />
                                        &nbsp; &nbsp; &nbsp;
                                       <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
                                     </td>                     
                                </tr>
                                
                                 <tr>
                                    <td style="width: 100%; text-align: left">
                                       
                                        &nbsp;&nbsp;
                                       
                                        <asp:Label ID="messageLabel" runat="server"></asp:Label>

                                        &nbsp;</td>
                                </tr>

                                </table>
                          
                        </td>
                        <td style="text-align: center" class="auto-style1"></td>
                    </tr>
                    <tr>
                      
                        <td style="text-align: center; width: 100%; height: 234px;">
                            <br />
                            <asp:GridView ID="booksGridView" runat="server" Width="566px"
                                AutoGenerateColumns="false" Font-Names="Arial"
                                Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                                HeaderStyle-BackColor="green" 
                                AllowPaging="true" 
                                ShowFooter="true"
                                OnPageIndexChanging="OnPaging" 
                                OnRowEditing="EditBook"
                                OnRowUpdating="UpdateBook"

                                OnRowCancelingEdit="CancelEdit"
                                PageSize="10">
                                <Columns>
                                    
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Book ID">
                                        <ItemTemplate>
                                            <asp:Label ID="bookIdLabel" runat="server"
                                                Text='<%# Eval("BookId")%>'></asp:Label>
                                        </ItemTemplate>  
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="nameLabel" runat="server"
                                                Text='<%# Eval("Name")%>'></asp:Label>
                                        </ItemTemplate>

                                         <EditItemTemplate>
                                            <asp:TextBox ID="editNameTextBox" runat="server"
                                                Text='<%# Eval("Name")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                       
                                        <FooterTemplate>
                                                <asp:TextBox ID="nameTextBox" Width="100px"
                                                MaxLength="8" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField ItemStyle-Width="30px" HeaderText="Author">
                                        <ItemTemplate>
                                            <asp:Label ID="authorLabel" runat="server"
                                                Text='<%# Eval("Author")%>'></asp:Label>
                                        </ItemTemplate>
                                         <EditItemTemplate>
                                            <asp:TextBox ID="editAuthorTextBox" runat="server"
                                                Text='<%# Eval("Author")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="authorTextBox" Width="40px"
                                                MaxLength="5" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderText="BookType">
                                        <ItemTemplate>
                                            <asp:Label ID="bookTypeLabel" runat="server"
                                                Text='<%# Eval("BookType")%>'></asp:Label>
                                        </ItemTemplate>

                                         <EditItemTemplate>
                                            <asp:TextBox ID="editBookTypeTextBox" runat="server"
                                                Text='<%# Eval("BookType")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                       
                                        <FooterTemplate>
                                                <asp:TextBox ID="bookTypeTextBox" Width="100px"
                                                MaxLength="8" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="150px" HeaderText="Version">
                                        <ItemTemplate>
                                            <asp:Label ID="versionLabel" runat="server"
                                                Text='<%# Eval("Version")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editVersionTextBox" runat="server"
                                                Text='<%# Eval("Version")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="versionTextBox" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField ItemStyle-Width="150px" HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="QuantityLabel" runat="server"
                                                Text='<%# Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editQuantityTextBox" runat="server"
                                                Text='<%# Eval("Quantity")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField ItemStyle-Width="150px" HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="PriceLabel" runat="server"
                                                Text='<%# Eval("Price")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="editPriceTextBox" runat="server"
                                                Text='<%# Eval("Price")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="priceTextBox" runat="server"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server"
                                                CommandArgument='<%# Eval("BookId")%>'
                                                OnClientClick="return confirm('Do you want to delete?')"
                                                Text="Delete" 
                                                OnClick="DeleteBook"></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnAdd" runat="server" Text="Add"
                                                OnClick="AddNewBook" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                                <AlternatingRowStyle BackColor="#C2D69B" />
                            </asp:GridView>
                        </td>
                        <td style="width: 100%; height: 234px; text-align: center"></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
