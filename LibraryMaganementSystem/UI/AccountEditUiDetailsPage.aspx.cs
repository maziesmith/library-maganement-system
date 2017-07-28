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
    public partial class AccountEditUiDetailsPage : System.Web.UI.Page
    {
        private Accounts anAccounts;
        protected void Page_Load(object sender, EventArgs e)
        {
            anAccounts = (Accounts)Session["anAccount"];

            messageLabel.Text = "";

            if (!IsPostBack)
            {
                if (anAccounts.AccountId != "")
                {
                    //accountIdTextBox.Text = anAccounts.AccountId;
                    //firstNameTextBox.Text = anAccounts.FirstName;
                    //lastNameTextBox.Text = anAccounts.LastName;
                    //accountTypeTextBox.Text = anAccounts.AccountType;
                    //emailTextBox.Text = anAccounts.Email;
                    //cellNoTextBox.Text = Convert.ToString(anAccounts.CellNo);
                    //addressTextBox.Text = anAccounts.Address;
                    string accountId = anAccounts.AccountId;
                    LoadAccountInForm(accountId);
                }
            }

        }
        AccountBLL anAccountBll = new AccountBLL();

        private void LoadAccountInForm(string accountId)
        {
            try
            {
                Accounts anAccount = anAccountBll.GetAnAccountById(accountId);

                accountIdTextBox.Text = anAccount.AccountId;
                firstNameTextBox.Text = anAccount.FirstName;
                lastNameTextBox.Text = anAccount.LastName;
                accountTypeTextBox.Text = anAccount.AccountType;
                emailTextBox.Text = anAccount.Email;
                cellNoTextBox.Text = Convert.ToString(anAccount.CellNo);
                addressTextBox.Text = anAccount.Address;
                expdateTextBox.Text = Convert.ToDateTime(anAccount.ExpDate).ToString("dd/MM/yyyy");
                //DateTime dt = anAccount.ExpDate;
                //expdateTextBox.Text = dt.ToString("dd/MM/yyyy");
                // expdateTextBox.Text = Convert.ToString(anAccount.ExpDate);
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }
        public void EnableAll()
        {
            this.firstNameTextBox.Enabled = true;
            this.lastNameTextBox.Enabled = true;
            this.accountTypeTextBox.Enabled = true;
            this.emailTextBox.Enabled = true;
            this.cellNoTextBox.Enabled = true;
            this.addressTextBox.Enabled = true;
            this.expdateTextBox.Enabled = true;
        }
        public void ClearAll()
        {
            this.accountIdTextBox.Text = "";
            this.accountIdTextBox.Text = "";
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.accountTypeTextBox.Text = "";
            this.emailTextBox.Text = "";
            this.cellNoTextBox.Text = "";
            this.addressTextBox.Text = "";
            this.expdateTextBox.Text = "";
        }
        public void DisableAll()
        {
            this.firstNameTextBox.Enabled = false;
            this.lastNameTextBox.Enabled = false;
            this.accountTypeTextBox.Enabled = false;
            this.emailTextBox.Enabled = false;
            this.cellNoTextBox.Enabled = false;
            this.addressTextBox.Enabled = false;
            this.expdateTextBox.Enabled = false;
        }
        
        protected void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                Accounts anAccount = new Accounts();
                anAccount.AccountId = accountIdTextBox.Text;
                anAccount.FirstName = firstNameTextBox.Text;
                anAccount.LastName = lastNameTextBox.Text;
                anAccount.AccountType = accountTypeTextBox.Text;
                anAccount.Email = emailTextBox.Text;
                anAccount.CellNo = Convert.ToInt32(cellNoTextBox.Text);
                anAccount.Address = addressTextBox.Text;
                anAccount.ExpDate = Convert.ToDateTime(expdateTextBox.Text);

                string msg = anAccountBll.UpdateAccountById(anAccount);

                ClearAll();
                messageLabel.Text = msg;
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = accountIdTextBox.Text;
                string msg = anAccountBll.DeleteAccountByID(id);
                ClearAll();
                messageLabel.Text = msg;
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