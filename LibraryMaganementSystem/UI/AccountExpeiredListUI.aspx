<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountExpeiredListUI.aspx.cs" Inherits="UniversityManagementSystem.UI.ExpiredAccountListUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EXPERIRED ACCOUNT LIST
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current DATE&nbsp;&nbsp;&nbsp;&nbsp;
          
            <asp:TextBox ID="dateTextBox" runat="server" Width="170px"></asp:TextBox>

            &nbsp;&nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator1" runat="server"
                ControlToValidate="dateTextBox" Display="Dynamic"
                ErrorMessage="Not in the format (dd/MM/yyyy)" ForeColor="Red"
                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[ /]([1-9]|0[1-9]|1[012])[ /](19|20)\d\d"
                ValidationGroup="validateAccount"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>



            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Book ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="bookNameTextBox" runat="server" Width="170px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Account ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="authorNameTextBox" runat="server" Width="174px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" ForeColor="Red"
                OnClick="searchButton_Click" ValidationGroup="validateAccount" Text="Search" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="showallButton" runat="server" ForeColor="Red"
                OnClick="showallButton_Click" Text="Show ALL" Width="115px" />
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="backButton" runat="server" ForeColor="#33CC33"
                OnClick="backButton_Click" Text="Back" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
            &nbsp;
        <asp:Button ID="logoutButton" runat="server" ForeColor="#33CC33"
            OnClick="logoutButton_Click" Text="Logout" Width="115px" />
            <br />
            <br />
            Delete Experied Accounts Whom have not Borrowed book:&nbsp;
            <asp:Button ID="deleteButton" runat="server" ForeColor="Red"
                OnClick="deleteButton_Click" Text="Delete" Width="115px" />
            <br />
            &nbsp;<br />
            &nbsp;
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="experiedAccountGridView" runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="AccountId">
                <Columns>
                    <asp:BoundField DataField="AccountId" HeaderText="Account Id" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Author" />
                    <asp:BoundField DataField="AccountType" HeaderText="AccountType" />
                    <asp:BoundField DataField="Email" HeaderText=" Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="ExpDate" HeaderText="ExpDate" />

                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>

</body>
</html>
