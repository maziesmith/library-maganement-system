using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.UI
{
    public partial class ExpiredAccountListUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //     if (!IsPostBack)
        //    {              
                showall();
                dateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");              
            //}                  
        }

        AccountBLL anAccountBll = new AccountBLL();
        protected void showall()
        {
            dateTextBox.Text = DateTime.Now.ToString("yyyy MMMM dd");
            string date = dateTextBox.Text;
            DateTime toDay = Convert.ToDateTime(date);
            experiedAccountGridView.DataSource = anAccountBll.GetAllExpiredAccountTillToday(toDay);
            experiedAccountGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
        }

        protected void showallButton_Click(object sender, EventArgs e)
        {
            showall();
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTextBox.Text;
                DateTime toDay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                // DateTime toDay = Convert.ToDateTime(date); 
                string msg = anAccountBll.DeleteExperiedAccountWhomHaveNoBorrowedBook(toDay);
                messageLabel.Text = msg;
                
                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountUI.aspx");
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