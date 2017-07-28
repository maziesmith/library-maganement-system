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
    public partial class AccountSearchUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                expdateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                showall();
            }
        }
    
        AccountBLL anAccountBll=new AccountBLL();
        protected void showall()
        {
            accountGridView.DataSource = anAccountBll.GetAllAccount();
            accountGridView.DataBind();
        }
 
        protected void showallButton_Click(object sender, EventArgs e)
        {
            showall();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Accounts anAccount = new Accounts();
                anAccount.AccountId = aaccidTextBox.Text;
                anAccount.FirstName = nameTextBox.Text;
                anAccount.LastName = nameTextBox.Text;
                anAccount.Address = addressTextBox.Text;


                DateTime dt = DateTime.ParseExact(expdateTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                anAccount.ExpDate = dt;

                //string format = "dd/MM/yyyy";
                //  string strDate = expDateTextBox.Text;
                //  anAccount.ExpDate = DateTime.ParseExact(strDate, format, CultureInfo.InvariantCulture);


                accountGridView.DataSource = anAccountBll.SearchAccount(anAccount);
                // ClearAll();
                accountGridView.DataBind();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "Error" + ex;
            }
        }

        protected void deleteallButton_Click(object sender, EventArgs e)
        {
            try
            {
                anAccountBll.DeleteAllAccount();
                showall();
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }
        protected void accountGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string accountId = accountGridView.DataKeys[e.RowIndex].Value.ToString();
                anAccountBll.DeleteRowAccountByID(accountId);
                showall();
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }

        protected void accountGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            accountGridView.PageIndex = e.NewPageIndex;
            showall();

        }

        protected void accountGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            accountGridView.EditIndex = e.NewEditIndex;
            showall();
        }

        protected void accountGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            accountGridView.EditIndex = -1;
            showall();
        }
        protected void accountGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string accountId = accountGridView.DataKeys[e.RowIndex].Value.ToString();
                GridViewRow row = (GridViewRow) accountGridView.Rows[e.RowIndex];
                // Label bookid = (Label)row.FindControl("bookid");
                // Label  bookid = (Label)(row.Cells[0].Controls[0]);
                TextBox FirstNameTextBox = (TextBox) row.Cells[1].Controls[0];
                TextBox LastNameTextBox = (TextBox) row.Cells[2].Controls[0];
                TextBox AccountTypeTextBox = (TextBox) row.Cells[3].Controls[0];
                TextBox EmailTextBox = (TextBox) row.Cells[4].Controls[0];
                TextBox AddressyTextBox = (TextBox) row.Cells[5].Controls[0];
                TextBox ExpDateTextBox = (TextBox) row.Cells[6].Controls[0];


                Accounts anAccount = new Accounts();
                anAccount.AccountId = accountId;
                anAccount.FirstName = FirstNameTextBox.Text;
                anAccount.LastName = LastNameTextBox.Text;
                anAccount.AccountType = AccountTypeTextBox.Text;
                anAccount.Email = EmailTextBox.Text;
                anAccount.Address = AddressyTextBox.Text;
                anAccount.ExpDate = Convert.ToDateTime(ExpDateTextBox.Text);

                //string date = expdateTextBox.Text;
                anAccountBll.UpdateRowAccountById(anAccount);
                accountGridView.EditIndex = -1;

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