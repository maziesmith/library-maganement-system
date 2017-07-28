using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class BorrowReturnBookUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     

        protected void borrowBookLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowBookUI.aspx");
        }

        protected void returnBookLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowedBookReturnUI.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }

        protected void borrowerlistLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowerList.aspx");
        }
    }
}