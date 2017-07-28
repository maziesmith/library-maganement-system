using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class BookSearchUI : System.Web.UI.Page
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
            bookGridView.DataSource = aBookBll.GetAllBook();
            bookGridView.DataBind();
        }

       protected void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Book aBook = new Book();
                aBook.Name = bookNameTextBox.Text;
                aBook.Author = authorNameTextBox.Text;
                bookGridView.DataSource = aBookBll.SearchBook(aBook);
                bookGridView.DataBind();
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }

        protected void showallButton_Click(object sender, EventArgs e)
        {
          showall();
        }

        protected void deleteallButton_Click(object sender, EventArgs e)
        {
            try
            {
                aBookBll.DeleteAllBook();
                showall();
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }
       
        protected void bookGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
              int bookid = Convert.ToInt32(bookGridView.DataKeys[e.RowIndex].Value.ToString());
              aBookBll.DeleteRowBook(bookid);
              showall();
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }

        protected void bookGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            bookGridView.EditIndex = e.NewEditIndex;
            showall();
        }
        protected void bookGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            bookGridView.EditIndex = -1;
            showall();
        }

        protected void bookGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(bookGridView.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)bookGridView.Rows[e.RowIndex];
            // Label bookid = (Label)row.FindControl("bookid");
            // Label  bookid = (Label)(row.Cells[0].Controls[0]);
            TextBox bookNameTextBox = (TextBox)row.Cells[1].Controls[0];
            TextBox authorTextBox = (TextBox)row.Cells[2].Controls[0];
            TextBox versionTextBox = (TextBox)row.Cells[3].Controls[0];
            TextBox bookTypeTextBox = (TextBox)row.Cells[4].Controls[0];
            TextBox quantityTextBox = (TextBox)row.Cells[5].Controls[0];
            TextBox priceTextBox = (TextBox)row.Cells[6].Controls[0];

          
            Book aBook = new Book();
            //student.RegNo = department.Code + student.Date.Year + "." + (count + 1).ToString("D4");
            aBook.BookId = id;
            aBook.Name = bookNameTextBox.Text;
            aBook.Author = authorTextBox.Text;
            aBook.Version = Convert.ToInt32(versionTextBox.Text);
            aBook.BookType = bookTypeTextBox.Text;
            aBook.Quantity = Convert.ToInt32(quantityTextBox.Text);
            aBook.Price = Convert.ToInt32(priceTextBox.Text);

            aBookBll.UpdateBookById(aBook);
            bookGridView.EditIndex = -1;
            
            showall();
            
        }

        protected void bookGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          bookGridView.PageIndex = e.NewPageIndex;
          showall();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookUI.aspx");
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