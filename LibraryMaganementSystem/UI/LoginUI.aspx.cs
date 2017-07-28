using System;
using UniversityManagementSystem.Models;
using Login = UniversityManagementSystem.Models.Login;

namespace UniversityManagementSystem.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void loginButton_Click(object sender, EventArgs e)
        {
           if (nameTextBox.Text.Trim() == Login.UserName && passwordTextBox.Text.Trim() == Login.Password)
           {
               Response.Redirect("~/UI/HmeUI.aspx");
           }
           else
           {
              messageLabel.Visible = true;
            
               messageLabel.Text = "InCorrect password or user name or both";
            }
        }

     
       protected void nameTextBox_TextChanged(object sender, EventArgs e)
       {
           messageLabel.Visible = false;
       }

       protected void passwordTextBox_TextChanged(object sender, EventArgs e)
       {
           messageLabel.Visible = false;
       }

    
     }
}