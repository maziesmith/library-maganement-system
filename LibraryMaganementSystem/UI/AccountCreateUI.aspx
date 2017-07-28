<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountCreateUI.aspx.cs" Inherits="UniversityManagementSystem.UI.AccountCreateUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div style="color: #0066CC">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Account No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="accIdTextBox" runat="server" Width="170px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="accIdTextBox"
               ValidationGroup="validateAccount"
                Text="Account No is Required!"
                Font-Size="Small">
             </asp:RequiredFieldValidator>

            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            First Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="firstnameTextBox" runat="server" Width="170px"></asp:TextBox>
            &nbsp;&nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                 ControlToValidate="firstnameTextBox"
                  Text="First Name is Required"
                  ValidationGroup="validateAccount"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

            <br />

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lastnameTextBox" runat="server" Width="170px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="emailTextBox" runat="server" Width="182px"></asp:TextBox>
            <br />

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
            Cell No&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="cellNoTextBox" runat="server" Width="179px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                 ControlToValidate="cellNoTextBox"
                 Text="Cell No is Required"
                  ValidationGroup="validateAccount"
                 Font-Size="Small">
             </asp:RequiredFieldValidator>

            &nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator1" runat="server"
                ControlToValidate="cellNoTextBox" Display="Dynamic"
                ErrorMessage="Please enter a 11 or 10 digit number!" ForeColor="Red"
                ValidationExpression="^\d{10,11}$"
                 ValidationGroup="validateAccount"
               
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>

            <br />

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Address&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="addressTextBox" runat="server" Width="180px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ControlToValidate="addressTextBox"
                Text="Address is Required"
                 ValidationGroup="validateAccount"
                Font-Size="Small">
             </asp:RequiredFieldValidator>

            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             Account Type&nbsp; &nbsp;<asp:DropDownList ID="accountTypeDropDownList" runat="server" Height="16px" Style="margin-left: 0px" Width="138px">
                 <asp:ListItem>Teacher</asp:ListItem>
                 <asp:ListItem>Student</asp:ListItem>
                 <asp:ListItem>Employee</asp:ListItem>
             </asp:DropDownList>

            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
            Exp Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="expDateTextBox" runat="server" Width="180px"></asp:TextBox>
            &nbsp;
   
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                 ControlToValidate="expDateTextBox"
                 Text="Exp date is Required"
                 ValidationGroup="validateAccount"
                 Font-Size="Small">
              </asp:RequiredFieldValidator>

            &nbsp;&nbsp;
         
            <asp:RegularExpressionValidator ID="dateRegularExpressionValidator" runat="server"
                ControlToValidate="expDateTextBox" Display="Dynamic"
                ErrorMessage="Not in the format (dd/MM/yyyy)" ForeColor="Red"
                 ValidationGroup="validateAccount"
                ValidationExpression="([1-9]|0[1-9]|[12][0-9]|3[01])[ /]([1-9]|0[1-9]|1[012])[ /](19|20)\d\d"
                Style="font-size: x-small">
            </asp:RegularExpressionValidator>



            <br />

            <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="backButton" runat="server" ForeColor="#33CC33" OnClick="backButton_Click" Text="Back" Width="115px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="homeButton" runat="server" ForeColor="#3366FF" OnClick="homeButton_Click" Text="Home" Width="115px" Style="height: 26px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" ForeColor="Red"
            OnClick="saveButton_Click"  ValidationGroup="validateAccount" Text="Save" Width="115px" />

            <br />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>

            <br />

            <br />

        </div>

    </form>
</body>
</html>
