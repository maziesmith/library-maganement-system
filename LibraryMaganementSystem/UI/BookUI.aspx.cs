using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class BookUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addnewbookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookAddUI.aspx");
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookUpdateUI.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookSearchUI.aspx");
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
            Response.Redirect("~/UI/BookAlterUI.aspx");
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookEditUI.aspx");
        }
    }
}