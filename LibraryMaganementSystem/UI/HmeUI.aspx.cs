using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.UI
{
    public partial class HmeUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bookinfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookUI.aspx");
        }

        protected void accountinfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountUI.aspx");
        }

        protected void borrowReturnLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowReturnBookUI.aspx");
        }

        protected void booklistLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookSearchUI.aspx");
        }

      protected void borrowerListLinkButton_Click(object sender, EventArgs e)
      {
          Response.Redirect("~/UI/BorrowerList.aspx");
      }

      protected void accountlistLinkButton_Click(object sender, EventArgs e)
      {
          Response.Redirect("~/UI/AccountSearchUI.aspx");
      }

    protected void experiedAccountLinkButton_Click(object sender, EventArgs e)
      {
          Response.Redirect("~/UI/AccountExpeiredListUI.aspx");
      }

      protected void logoutButton_Click(object sender, EventArgs e)
      {
          Response.Redirect("~/UI/LoginUI.aspx");

      }

      protected void bookCrystalReportButton_Click(object sender, EventArgs e)
      {
          Response.Redirect("~/Reports/bookCrystalReportUi.aspx");
      }
    }
}