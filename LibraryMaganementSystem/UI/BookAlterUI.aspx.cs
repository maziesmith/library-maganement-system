using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class BookAlterUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showall();
            }
        }
        BookBLL aBookBll=new BookBLL();
        protected void showall()
        {
            booksGridView.DataSource = aBookBll.GetAllBook();
            booksGridView.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (optionDropDownList.SelectedValue == "BookId")
            {
                try
                {
                    int bookId = Convert.ToInt16(optionTextBox.Text);

                    booksGridView.DataSource = aBookBll.GetaBookByIdUsingDataTable(bookId);
                    booksGridView.DataBind();
                }
                catch (Exception ex)
                {
                    messageLabel.Text = "" + ex;
                }
            }

            if (optionDropDownList.SelectedValue == "Book Name")
            {
                try
                {
                    string name = optionTextBox.Text;

                    booksGridView.DataSource = aBookBll.GetaBookByNameUsingDataTable(name);
                    booksGridView.DataBind();
                }
                catch (Exception ex)
                {
                    messageLabel.Text = "" + ex;
                }
            }

            //if (optionDropDownList.SelectedValue == "Author")
            //{
            //    try
            //    {
            //        string author = optionTextBox.Text;

            //        booksGridView.DataSource = aBookBll.GetaBookByAuthorUsingDataTable(author);
            //        booksGridView.DataBind();
            //    }
            //    catch (Exception ex)
            //    {
            //        messageLabel.Text = "" + ex;
            //    }
            //}

        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            showall();
            booksGridView.PageIndex = e.NewPageIndex;
            booksGridView.DataBind();
        }

        protected void EditBook(object sender, GridViewEditEventArgs e)
        {
            booksGridView.EditIndex = e.NewEditIndex;
            showall();
        }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            booksGridView.EditIndex = -1;
            showall();
        }
        protected void UpdateBook(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string bookid = ((Label) booksGridView.Rows[e.RowIndex].FindControl("bookIdLabel")).Text;
                string Name = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editNameTextBox")).Text;
                string Author = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editAuthorTextBox")).Text;
                string BookType = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editBookTypeTextBox")).Text;
                string version = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editVersionTextBox")).Text;
                string Quantity = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editQuantityTextBox")).Text;
                string Price = ((TextBox) booksGridView.Rows[e.RowIndex].FindControl("editPriceTextBox")).Text;

                Book aBook = new Book();
                aBook.BookId = Convert.ToInt32(bookid);
                aBook.Name = Name;
                aBook.Author = Author;
                aBook.Version = Convert.ToInt32(version);
                aBook.BookType = BookType;
                aBook.Quantity = Convert.ToInt32(Quantity);
                aBook.Price = Convert.ToInt32(Price);


                aBookBll.UpdateBookById(aBook);
                booksGridView.EditIndex = -1;
                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }

        }
       
      
        protected void DeleteBook(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkRemove = (LinkButton) sender;
                int bookid = Convert.ToInt32(lnkRemove.CommandArgument);
                aBookBll.DeleteRowBook(bookid);

                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }
  
        protected void AddNewBook(object sender, EventArgs e)
        {
            try
            {
                string Name = ((TextBox) booksGridView.FooterRow.FindControl("nameTextBox")).Text;
                string Author = ((TextBox) booksGridView.FooterRow.FindControl("authorTextBox")).Text;
                string BookType = ((TextBox) booksGridView.FooterRow.FindControl("bookTypeTextBox")).Text;
                string Version = ((TextBox) booksGridView.FooterRow.FindControl("versionTextBox")).Text;
                string Price = ((TextBox) booksGridView.FooterRow.FindControl("quantityTextBox")).Text;
                string Quantity = ((TextBox) booksGridView.FooterRow.FindControl("priceTextBox")).Text;

                Book aBook = new Book();
                aBook.Name = Name;
                aBook.Author = Author;
                aBook.BookType = BookType;
                aBook.Version = Convert.ToInt32(Version);
                aBook.Price = Convert.ToInt32(Price);
                aBook.Quantity = Convert.ToInt32(Quantity);

                aBookBll.Save(aBook);

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

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/LoginUI.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookUI.aspx");
        }
      }
}