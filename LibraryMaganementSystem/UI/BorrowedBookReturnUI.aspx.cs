using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class BorrowedBookReturnUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        BorrowerBLL aBorrowerBll = new BorrowerBLL();
        protected void borrowButton_Click(object sender, EventArgs e)
        {
            Borrower aBorrower = new Borrower();
            aBorrower.BookId = Convert.ToInt32(bookIdTextBox.Text);
            aBorrower.AccountId = accountIdTextBox.Text;

            string msg = aBorrowerBll.ReturnBook(aBorrower);
            messageLabel.Text = msg;
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowReturnBookUI.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
        }

      
    }
}