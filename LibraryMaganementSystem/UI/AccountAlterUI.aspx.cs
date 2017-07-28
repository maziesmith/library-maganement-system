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
    public partial class AccountAlterUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                showall();
            }
        }

       AccountBLL anAccountBll=new AccountBLL();
        protected void showall()
        {
            accountGridView.DataSource = anAccountBll.GetAllAccount();
            accountGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
              
            if (optionDropDownList.SelectedValue == "AccountId") 
            {
                try
                {
                    string accId = optionTextBox.Text;

                    accountGridView.DataSource = anAccountBll.GetAnAccountByIdUsingDataTable(accId);  
                    accountGridView.DataBind();
                }
                catch (Exception ex)
                {
                    messageLabel.Text = ""+ex;
                }
            }
            
            if (optionDropDownList.SelectedValue =="FirstName")
            {
                try
                {
                    string name = optionTextBox.Text;

                    accountGridView.DataSource = anAccountBll.GetAnAccountByNameUsingDataTable(name);
                    accountGridView.DataBind();
                }
                catch (Exception ex)
                {
                    messageLabel.Text = "" + ex;
                }
            }

        
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            showall();
            accountGridView.PageIndex = e.NewPageIndex;
            accountGridView.DataBind();
        }
        protected void EditAccount(object sender, GridViewEditEventArgs e)
        {
            accountGridView.EditIndex = e.NewEditIndex;
            showall();
        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            accountGridView.EditIndex = -1;

            messageLabel.Text = "";
            showall();

        }
        protected void UpdateAccount(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string accountid = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editAccountIdTextBox")).Text;
                string FirstName = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editFirstNameTextBox")).Text;
                string LastName = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editLastNameTextBox")).Text;
                string AccountType =((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editAccountTypeTextBox")).Text;
                string Email = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editEmailTextBox")).Text;
                string CellNo = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editCellNoTextBox")).Text;
                string Address = ((TextBox) accountGridView.Rows[e.RowIndex].FindControl("editAddressTextBox")).Text;

                Accounts anAccounts = new Accounts();
                anAccounts.AccountId = accountid;
                anAccounts.FirstName = FirstName;
                anAccounts.LastName = LastName;
                anAccounts.Email = Email;
                anAccounts.AccountType = AccountType;
                anAccounts.CellNo = Convert.ToInt32(CellNo);
                anAccounts.Address = Address;

                anAccountBll.UpdateRowAccountById(anAccounts);

                accountGridView.EditIndex = -1;
                showall();
                messageLabel.Text = "";
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }
      
        protected void DeleteAccount(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkRemove = (LinkButton) sender;
                string accountId = Convert.ToString(lnkRemove.CommandArgument);
                anAccountBll.DeleteRowAccountByID(accountId);
                 messageLabel.Text = "";
                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        protected void AddNewAccount(object sender, EventArgs e)
        {
            try
            {
                string accountid = ((TextBox) accountGridView.FooterRow.FindControl("accountIdTextBox")).Text;
                string FirstName = ((TextBox) accountGridView.FooterRow.FindControl("firstNameTextBox")).Text;
                string LastName = ((TextBox) accountGridView.FooterRow.FindControl("lastNameTextBox")).Text;
                string AccountType = ((TextBox) accountGridView.FooterRow.FindControl("accountTypeTextBox")).Text;
                string Email = ((TextBox) accountGridView.FooterRow.FindControl("emailTextBox")).Text;
                string CellNo = ((TextBox) accountGridView.FooterRow.FindControl("cellNoTextBox")).Text;
                string Address = ((TextBox) accountGridView.FooterRow.FindControl("addressTextBox")).Text;
                string ExpDate = ((TextBox) accountGridView.FooterRow.FindControl("expDateTextBox")).Text;

                Accounts anAccounts = new Accounts();
                anAccounts.AccountId = accountid;
                anAccounts.FirstName = FirstName;
                anAccounts.LastName = LastName;
                anAccounts.Email = Email;
                anAccounts.AccountType = AccountType;
                anAccounts.CellNo = Convert.ToInt32(CellNo);
                anAccounts.Address = Address;
                anAccounts.ExpDate = Convert.ToDateTime(ExpDate);

                anAccountBll.Save(anAccounts);
                messageLabel.Text = "";
                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/AccountUI.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }
    }
}