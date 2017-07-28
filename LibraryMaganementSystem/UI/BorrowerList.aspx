<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowerList.aspx.cs" Inherits="UniversityManagementSystem.UI.BorrowerList" %>

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
                        OnClick="searchButton_Click" Text="Search" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="showallButton" runat="server" ForeColor="Red"
                        OnClick="showallButton_Click" Text="Show ALL" Width="115px" />
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="backButton" runat="server" ForeColor="#33CC33"
                        OnClick="backButton_Click" Text="Back" Width="115px" style="height: 26px" />
            &nbsp;&nbsp;
                         <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
                          &nbsp; &nbsp;
        <asp:Button ID="logoutButton" runat="server" ForeColor="#33CC33"
                    OnClick="logoutButton_Click" Text="Logout" Width="115px" />
            <br />
            <br />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            &nbsp;<br />
            <br />
            <asp:GridView ID="borrowerGridView" runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="AccountId">
                <Columns>
                    
                    <asp:BoundField DataField="BookId" HeaderText="Book ID" />
                    <asp:BoundField DataField="AccountId" HeaderText="AccountId" />
                    <asp:BoundField DataField="IssueDate" HeaderText="IssueDate" />
                    <asp:BoundField DataField="ReturnDate" HeaderText="ReturnDate" />
                  
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>

</body>
</html>
