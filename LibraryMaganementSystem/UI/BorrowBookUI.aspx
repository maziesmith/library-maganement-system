<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrowBookUI.aspx.cs" Inherits="UniversityManagementSystem.UI.BorrowBookUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            Book Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            &nbsp;<asp:TextBox ID="bookIdTextBox" runat="server" Width="170px"></asp:TextBox>
           &nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                 ControlToValidate="bookIdTextBox"
                  Text="book Id is Required"
                  ValidationGroup="validateBorrower"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

           &nbsp;
         
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="bookIdTextBox" Display="Dynamic"
                ErrorMessage="Please enter digit number!" ForeColor="Red"
                ValidationExpression="^\d+$"
                ValidationGroup="validateBorrower"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>

           <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Account Id &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="accountIdTextBox" runat="server" Width="170px"></asp:TextBox>
            
            &nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                 ControlToValidate="accountIdTextBox"
                  Text="Account Id is Required"
                   ValidationGroup="validateBorrower"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

            <br />
            <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            Issue Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="issueDateTextBox" runat="server" Width="170px"></asp:TextBox>
          
            &nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                 ControlToValidate="issueDateTextBox"
                  Text="Issue Date is Required"
                   ValidationGroup="validateBorrower"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

            &nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator1" runat="server"
                ControlToValidate="issueDateTextBox" Display="Dynamic"
                ErrorMessage="Not in the format (dd/MM/yyyy)" ForeColor="Red"
                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[ /]([1-9]|0[1-9]|1[012])[ /](19|20)\d\d"
                 ValidationGroup="validateBorrower"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>

            <br />
            <br />
          
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Return Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="returnDateTextBox" runat="server" Width="170px" ></asp:TextBox>
         
              &nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                 ControlToValidate="returnDateTextBox"
                  Text="Return Date is Required"
                  ValidationGroup="validateBorrower"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

            &nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator2" runat="server"
                ControlToValidate="returnDateTextBox" Display="Dynamic"
                ErrorMessage="Not in the format (dd/MM/yyyy)" ForeColor="Red"
                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[ /]([1-9]|0[1-9]|1[012])[ /](19|20)\d\d"
               ValidationGroup="validateBorrower"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>



              <br />
              <br />
         
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="borrowButton" runat="server" ForeColor="Red" OnClick="borrowButton_Click"   ValidationGroup="validateBorrower" Text="Borrow" Width="115px" />
            
            &nbsp;&nbsp;&nbsp;
                         <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" />
                          &nbsp;
            <asp:Button ID="logoutButton" runat="server" ForeColor="Red" OnClick="logoutButton_Click" Text="Logout" Width="115px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="messageLabel" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
