using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class AccountUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void createAccountButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountCreateUI.aspx");
        }

       protected void updateButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/AccountUpdateUI.aspx");
       }

       protected void searchButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/AccountSearchUI.aspx");
       }

     
       protected void logoutButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/LoginUI.aspx");
       }

       protected void backButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/HmeUI.aspx");
       }

       protected void alterButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/accountAlterUI.aspx");

       }

       protected void editButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/AccountEditUI.aspx");
       }

       protected void experiedAccountButton_Click(object sender, EventArgs e)
       {
           Response.Redirect("~/UI/AccountExpeiredListUI.aspx");

       }

      
    }
}