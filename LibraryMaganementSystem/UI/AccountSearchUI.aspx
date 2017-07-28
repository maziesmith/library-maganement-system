<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSearchUI.aspx.cs" Inherits="UniversityManagementSystem.UI.AccountSearchUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Account Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="aaccidTextBox" runat="server"  Width="170px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="nameTextBox" runat="server"  Width="174px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Address&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="addressTextBox" runat="server"  Width="170px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            Exp Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="expdateTextBox" runat="server"  Width="174px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; &nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator" runat="server"
                ControlToValidate="expDateTextBox" Display="Dynamic"
                ErrorMessage="Not in the format (dd/MM/yyyy)" ForeColor="Red"
                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[ /]([1-9]|0[1-9]|1[012])[ /](19|20)\d\d"
                ValidationGroup="validateAccount"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>



            <br />
        <br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" ForeColor="Red" OnClick="searchButton_Click"   ValidationGroup="validateAccount" Text="Search" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="showallButton" runat="server" ForeColor="Red" OnClick="showallButton_Click" Text="Show ALL" Width="115px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="deleteallButton" runat="server" ForeColor="Red" OnClick="deleteallButton_Click" Text="Delete ALL" Width="115px" />
            &nbsp;&nbsp;
            <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
            &nbsp;
            <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
            &nbsp;
            <asp:Button ID="logoutButton" runat="server" ForeColor="#33CC33" OnClick="logoutButton_Click" Text="Logout" Width="115px" />
        <br />
        <br />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            &nbsp;<br />
        <br />      
        <asp:GridView ID="accountGridView" runat="server" 
            AutoGenerateColumns="false" 
            DataKeyNames="AccountId" 
            OnPageIndexChanging="accountGridView_PageIndexChanging" 
            OnRowCancelingEdit="accountGridView_RowCancelingEdit" 
            OnRowDeleting="accountGridView_RowDeleting" 
            OnRowEditing="accountGridView_RowEditing" 
            OnRowUpdating="accountGridView_RowUpdating">
            <Columns>
                <asp:BoundField DataField="AccountId" HeaderText="Account Id" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Author" />
                <asp:BoundField DataField="AccountType" HeaderText="AccountType" />
                <asp:BoundField DataField="Email" HeaderText=" Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="ExpDate" HeaderText="ExpDate" />
                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true" />
            
            </Columns>
         </asp:GridView>   
        <br />
        </div>

    </div>
    </form>
</body>
</html>
