using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class BorrowBookUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                issueDateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                returnDateTextBox.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            }
        }

        BorrowerBLL aBorrowerBll=new BorrowerBLL();
        protected void borrowButton_Click(object sender, EventArgs e)
        {
            try
            {
                Borrower aBorrower = new Borrower();
                aBorrower.BookId = Convert.ToInt32(bookIdTextBox.Text);
                aBorrower.AccountId = accountIdTextBox.Text;

                string issueDate = issueDateTextBox.Text;
                DateTime id = DateTime.ParseExact(issueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime id = Convert.ToDateTime(issueDate);
                aBorrower.IssueDate = id;

                string returnDate = returnDateTextBox.Text;
               // DateTime rd = Convert.ToDateTime(returnDate);
                DateTime rd = DateTime.ParseExact(returnDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                aBorrower.ReturnDate = rd;

                string msg = aBorrowerBll.BorrowBook(aBorrower);
                messageLabel.Text = msg;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
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