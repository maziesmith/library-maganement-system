using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.UI
{
    public partial class BookEditUi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showall();
            }
           
        }
       
        BookBLL aBookBll = new BookBLL();
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

      
        
        protected void booksGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //booksGridView.DataSource = aBookBll.GetAllBook();
            //booksGridView.DataBind();
            //booksGridView.PageIndex = e.NewPageIndex;
        }

        protected void booksGridView_DataBound(object sender, EventArgs e)
        {

        }


        protected void booksGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void booksGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int curIndex = e.RowIndex;
            try
            {
                string bookid = ((Label)booksGridView.Rows[curIndex].FindControl("bokIdLabel")).Text.Trim();
                int bookId = Convert.ToInt32(bookid);

                aBookBll.DeleteRowBook(bookId);

                showall();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR" + ex;
            }
        }

        //protected void booksGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //LinkButton l = (LinkButton)e.Row.FindControl("DeleteButton");
        //        //l.Attributes.Add("onclick", "javascript:if(confirm('Are you sure ? ')== false) return false;");
        //        //LinkButton l2 = (LinkButton)e.Row.FindControl("EditButton");
        //        //l2.Attributes.Add("onclick", "javascript:if(confirm('Are you sure ? ')== false) return false;");
        //    }
        //}

        protected void booksGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int curIndex = e.NewEditIndex;

            // curIndex += this.booksGridView.PageIndex * this.booksGridView.PageSize;

            string bookid = ((Label)booksGridView.Rows[curIndex].FindControl("bokIdLabel")).Text.Trim();
            string Name = ((TextBox)booksGridView.Rows[curIndex].FindControl("bookNameTextBox")).Text.Trim();
            string Author = ((TextBox)booksGridView.Rows[curIndex].FindControl("authorTextBox")).Text;
            string Version = ((TextBox)booksGridView.Rows[curIndex].FindControl("versionTextBox")).Text;
            string BookType = ((TextBox)booksGridView.Rows[curIndex].FindControl("bookTypeTextBox")).Text;
            string Quantity = ((TextBox)booksGridView.Rows[curIndex].FindControl("quantityTextBox")).Text;
            string Price = ((TextBox)booksGridView.Rows[curIndex].FindControl("piceTextBox")).Text;

            //string Price = ((TextBox)this.booksGridView.Rows[e.NewEditIndex].Cells[0].FindControl("bokIdLabel")).Text;
            //string bookid = ((Label)this.booksGridView.Rows[curIndex].Cells[0].FindControl("bokIdLabel")).Text.Trim();
            //string Name = ((TextBox)this.booksGridView.Rows[curIndex].Cells[1].FindControl("bookNameTextBox")).Text.Trim();
            //string Author = ((TextBox)this.booksGridView.Rows[curIndex].Cells[2].FindControl("authorTextBox")).Text;
            //string Version = ((TextBox)this.booksGridView.Rows[curIndex].Cells[3].FindControl("versionTextBox")).Text;
            //string BookType = ((TextBox)this.booksGridView.Rows[curIndex].Cells[4].FindControl("bookTypeTextBox")).Text;
            //string Quantity = ((TextBox)this.booksGridView.Rows[curIndex].Cells[5].FindControl("quantityTextBox")).Text;
            // string Price = ((TextBox)this.booksGridView.Rows[e.NewEditIndex].Cells[6].FindControl("piceTextBox")).Text;

            Book aBook = new Book();
            aBook.BookId = Convert.ToInt32(bookid);
            aBook.Name = Name;
            aBook.Author = Author;
            aBook.Version = Convert.ToInt32(Version);
            aBook.BookType = BookType;
            aBook.Quantity = Convert.ToInt32(Quantity);
            aBook.Price = Convert.ToInt32(Price);

            aBookBll.UpdateBookById(aBook);
            showall();
        }

        protected void booksGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("BookInfoDetails"))
            {
               
                int curIndex = Int32.Parse(e.CommandArgument.ToString());
                // curIndex += this.booksGridView.PageIndex * this.booksGridView.PageSize;

                string bookid = ((Label)booksGridView.Rows[curIndex].FindControl("bokIdLabel")).Text.Trim();
                string Name = ((TextBox)booksGridView.Rows[curIndex].FindControl("bookNameTextBox")).Text.Trim();
                string Author = ((TextBox)booksGridView.Rows[curIndex].FindControl("authorTextBox")).Text;
                string Version = ((TextBox)booksGridView.Rows[curIndex].FindControl("versionTextBox")).Text;
                string BookType = ((TextBox)booksGridView.Rows[curIndex].FindControl("bookTypeTextBox")).Text;
                string Quantity = ((TextBox)booksGridView.Rows[curIndex].FindControl("quantityTextBox")).Text;
                string Price = ((TextBox)booksGridView.Rows[curIndex].FindControl("piceTextBox")).Text;

                // string Price = ((TextBox)this.booksGridView.Rows[e.NewEditIndex].Cells[0].FindControl("bokIdLabel")).Text;
                //  string bookid = ((Label)this.booksGridView.Rows[curIndex].Cells[0].FindControl("bokIdLabel")).Text.Trim();
                //string Name = ((TextBox)this.booksGridView.Rows[curIndex].Cells[1].FindControl("bookNameTextBox")).Text.Trim();
                //string Author = ((TextBox)this.booksGridView.Rows[curIndex].Cells[2].FindControl("authorTextBox")).Text;
                //string Version = ((TextBox)this.booksGridView.Rows[curIndex].Cells[3].FindControl("versionTextBox")).Text;
                //string BookType = ((TextBox)this.booksGridView.Rows[curIndex].Cells[4].FindControl("bookTypeTextBox")).Text;
                //string Quantity = ((TextBox)this.booksGridView.Rows[curIndex].Cells[5].FindControl("quantityTextBox")).Text;
                // string Price = ((TextBox)this.booksGridView.Rows[e.NewEditIndex].Cells[6].FindControl("piceTextBox")).Text;

                Book aBook = new Book();
                aBook.BookId = Convert.ToInt32(bookid);
                aBook.Name = Name;
                aBook.Author = Author;
                aBook.Version = Convert.ToInt32(Version);
                aBook.BookType = BookType;
                aBook.Quantity = Convert.ToInt32(Quantity);
                aBook.Price = Convert.ToInt32(Price);

                Session["aBook"]= aBook;
                Response.Redirect("~/UI/BookEditUiDetailsPage.aspx");
               
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