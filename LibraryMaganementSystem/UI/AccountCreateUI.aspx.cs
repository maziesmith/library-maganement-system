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
    public partial class AccountCreateUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        AccountBLL anAccountBll=new AccountBLL();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Accounts anAccount = new Accounts();
            try
            {
                anAccount.AccountId = accIdTextBox.Text;
                anAccount.FirstName = firstnameTextBox.Text;
                anAccount.LastName = lastnameTextBox.Text;
                anAccount.AccountType = accountTypeDropDownList.Text;
                anAccount.Address = addressTextBox.Text;
                anAccount.Email = emailTextBox.Text;
                anAccount.CellNo = Convert.ToInt32(cellNoTextBox.Text);
                // anAccount.ExpDate = Convert.ToDateTime(expDateTextBox.Text);


                DateTime dt = DateTime.ParseExact(expDateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                anAccount.ExpDate = dt;

                //string format = "dd/MM/yyyy";
                //  string strDate = expDateTextBox.Text;
                //  anAccount.ExpDate = DateTime.ParseExact(strDate, format, CultureInfo.InvariantCulture);

                //string date = expireDateTextBox.Text;
                //DateTime dt = Convert.ToDateTime(date);
                //anAccount.ExpDate = dt;

                string msg = anAccountBll.Save(anAccount);
                messageLabel.Text = msg;
                // ClearAll();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Account not created" + ex;
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountUI.aspx");
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
        }
    }
}