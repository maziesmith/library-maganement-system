<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountEditUI.aspx.cs" Inherits="UniversityManagementSystem.UI.AccountEditUI" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 411px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin-top: 20px; font-size: 12pt; margin-bottom: 20px; margin-left: 10%; font-family: Verdana">
                <tr>
                    <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         Search By &nbsp;
                        <asp:DropDownList ID="optionDropDownList" runat="server" Width="142px" Height="16px">
                          <asp:ListItem Selected="True">AccountId</asp:ListItem>
                               <asp:ListItem>FirstName</asp:ListItem>
                               <asp:ListItem>PhoneNo</asp:ListItem>
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
                    <asp:GridView ID="accountGridView" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="AccountId"
                        CellPadding="4"
                        ForeColor="#333333"
                      
                        OnPageIndexChanging="accountGridView_PageIndexChanging"
                        OnDataBound="accountGridView_DataBound"
                       
                         OnRowDataBound="accountGridView_RowDataBound"                     
                        OnRowCommand="accountGridView_RowCommand"                   
                        OnRowEditing="accountGridView_RowEditing"                   
                        OnRowDeleting="accountGridView_RowDeleting"
                       
                         Font-Size="Small" PageSize="20" GridLines="Vertical" Style="margin-top: 0px">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="AccountId">
                                <ItemTemplate>
                                    <asp:Label ID="accountIdLabel" runat="server"
                                        Text='<%# Bind("AccountId") %>' Width="80px"></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FirstName">
                                <ItemTemplate>
                                    <asp:TextBox ID="firstNameTextBox" runat="server"
                                        Text='<%# Bind("FirstName") %>' Width="80px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LastName">
                                <ItemTemplate>
                                    <asp:TextBox ID="lastNameTextBox" runat="server"
                                        Text='<%# Bind("LastName") %>' Width="80px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AccountType">
                                <ItemTemplate>
                                    <asp:TextBox ID="accountTypeTextBox" runat="server"
                                        Text='<%# Bind("AccountType") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:TextBox ID="emailTextBox" runat="server"
                                        Text='<%# Bind("Email") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CellNo">
                                <ItemTemplate>
                                    <asp:TextBox ID="cellNoTextBox" runat="server"
                                        Text='<%# Bind("CellNo") %>' Width="50px"
                                        AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:TextBox ID="addressTextBox" runat="server"
                                        Text='<%# Bind("Address") %>' Width="50px"
                                        AutoPostBack="True"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ExpDate">
                                <ItemTemplate>
                                    <asp:TextBox ID="expDateTextBox" runat="server"
                                        Text='<%# Bind("ExpDate") %>' Width="50px"
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
    </form>
</body>
</html>
