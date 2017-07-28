using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;



namespace UniversityManagementSystem.UI
{
    public partial class AccountEditUI : System.Web.UI.Page
    {
        
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showall();
            }

        }

       AccountBLL anAccountBll = new AccountBLL();
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
                   messageLabel.Text = "" + ex;
               }
           }

           if (optionDropDownList.SelectedValue == "FirstName")
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

           //if (optionDropDownList.SelectedValue == "PhoneNo")
           //{
           //    try
           //    {
           //        string accId = optionTextBox.Text;

           //        accountGridView.DataSource = anAccountBll.GetAnAccountByPhoneNoUsingDataTable(accId);
           //        accountGridView.DataBind();
           //    }
           //    catch (Exception ex)
           //    {
           //        messageLabel.Text = "" + ex;
           //    }
           //}
        

        }

        protected void accountGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //booksGridView.DataSource = aBookBll.GetAllBook();
            //booksGridView.DataBind();
            //booksGridView.PageIndex = e.NewPageIndex;
        }
        protected void accountGridView_DataBound(object sender, EventArgs e)
        {

        }
        protected void accountGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("DeleteButton");
                l.Attributes.Add("onclick", "javascript:if(confirm('Are you sure ? ')== false) return false;");
                LinkButton l2 = (LinkButton)e.Row.FindControl("EditButton");
                l2.Attributes.Add("onclick", "javascript:if(confirm('Are you sure ? ')== false) return false;");

                //string qty = ((TextBox)e.Row.Cells[5].FindControl("tquantity")).Text;
                //sum += Double.Parse(qty);
            }
        }

        protected void accountGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int curIndex = e.RowIndex;
            try
            {
                string accountId = ((Label)accountGridView.Rows[curIndex].FindControl("accountIdLabel")).Text.Trim();
                anAccountBll.DeleteAccountByID(accountId);

                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        protected void accountGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int curIndex = e.NewEditIndex;

            string accountId = ((Label)accountGridView.Rows[curIndex].FindControl("accountIdLabel")).Text.Trim();
            string firstName = ((TextBox)accountGridView.Rows[curIndex].FindControl("firstNameTextBox")).Text.Trim();
            string lastName = ((TextBox)accountGridView.Rows[curIndex].FindControl("lastNameTextBox")).Text;
            string accountType = ((TextBox)accountGridView.Rows[curIndex].FindControl("accountTypeTextBox")).Text;
            string email = ((TextBox)accountGridView.Rows[curIndex].FindControl("emailTextBox")).Text;
            string cellNo = ((TextBox)accountGridView.Rows[curIndex].FindControl("cellNoTextBox")).Text;
            string address = ((TextBox)accountGridView.Rows[curIndex].FindControl("addressTextBox")).Text;
            string expDate = ((TextBox)accountGridView.Rows[curIndex].FindControl("expDateTextBox")).Text;

            Accounts anAccount = new Accounts();
            anAccount.AccountId = accountId;
            anAccount.FirstName = firstName;
            anAccount.LastName = lastName;
            anAccount.AccountType = accountType;
            anAccount.Email = email;
            anAccount.CellNo = Convert.ToInt32(cellNo);
            anAccount.Address = address;
            anAccount.ExpDate = Convert.ToDateTime(expDate);

            anAccountBll.UpdateRowAccountById(anAccount);
           
            showall();
        }
      

        protected void accountGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("BookInfoDetails"))
            {

                int curIndex = Int32.Parse(e.CommandArgument.ToString());
               
                string accountId = ((Label)accountGridView.Rows[curIndex].FindControl("accountIdLabel")).Text.Trim();
                string firstName = ((TextBox)accountGridView.Rows[curIndex].FindControl("firstNameTextBox")).Text.Trim();
                string lastName = ((TextBox)accountGridView.Rows[curIndex].FindControl("lastNameTextBox")).Text;
                string accountType = ((TextBox)accountGridView.Rows[curIndex].FindControl("accountTypeTextBox")).Text;
                string email = ((TextBox)accountGridView.Rows[curIndex].FindControl("emailTextBox")).Text;
                string cellNo = ((TextBox)accountGridView.Rows[curIndex].FindControl("cellNoTextBox")).Text;
                string address = ((TextBox)accountGridView.Rows[curIndex].FindControl("addressTextBox")).Text;
                string expDate = ((TextBox)accountGridView.Rows[curIndex].FindControl("expDateTextBox")).Text;

                Accounts anAccount=new Accounts();
                anAccount.AccountId = accountId;
                anAccount.FirstName = firstName;
                anAccount.LastName = lastName;
                anAccount.AccountType = accountType;
                anAccount.Email = email;
                anAccount.CellNo = Convert.ToInt32(cellNo);
                anAccount.Address = address;
                anAccount.ExpDate = Convert.ToDateTime(expDate);
               
                Session["anAccount"] = anAccount;
                Response.Redirect("~/UI/AccountEditUiDetailsPage.aspx");

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