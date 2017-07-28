using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.UI
{
    public partial class BorrowerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showall();
            }
        }

        BorrowerBLL aBorrowerBll=new BorrowerBLL();
        protected void showall()
        {
            borrowerGridView.DataSource = aBorrowerBll.GetAllBorrower();
            borrowerGridView.DataBind();
        }
       

        protected void searchButton_Click(object sender, EventArgs e)
        {

        }

        protected void showallButton_Click(object sender, EventArgs e)
        {
            showall();
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BorrowReturnBookUI.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }

        
    }
}