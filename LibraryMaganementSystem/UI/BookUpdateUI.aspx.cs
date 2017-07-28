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
    public partial class BookUpdateUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableAll();
        }
        Book aBook=new Book();
        BookBLL aBookBll=new BookBLL();
        public void EnableAll()
        {
            this.bookNameTextBox.Enabled = true;
            this.authorTextBox.Enabled = true;
            this.bookTypeTextBox.Enabled = true;
            this.priceTextBox.Enabled = true;
            this.versionTextBox.Enabled = true;
            this.quantityTextBox.Enabled = true;

        }
        public void ClearAll()
        {
            this.bookNameTextBox.Text = "";
            this.authorTextBox.Text = "";
            this.bookTypeTextBox.Text = "";
            this.priceTextBox.Text = "";
            this.versionTextBox.Text = "";
            this.quantityTextBox.Text = "";
        }
        public void DisableAll()
        {
            this.bookNameTextBox.Enabled = false;
            this.authorTextBox.Enabled = false;
            this.bookTypeTextBox.Enabled = false;
            this.priceTextBox.Enabled = false;
            this.versionTextBox.Enabled = false;
            this.quantityTextBox.Enabled = false;
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (bookidTextBox.Text != null)
                {
                    EnableAll(); 
                }
                int bookid = Convert.ToInt32(bookidTextBox.Text);
                Book aBook = aBookBll.GetBookById(bookid);
                

                bookNameTextBox.Text= aBook.Name;
                authorTextBox.Text = aBook.Author;
                bookTypeTextBox.Text = aBook.BookType;
                versionTextBox.Text = Convert.ToString(aBook.Version);
                priceTextBox.Text = Convert.ToString(aBook.Price);
                quantityTextBox.Text = Convert.ToString(aBook.Quantity);
                
            }
            catch (Exception)
            {
                messageLabel.Text = "ERROR";
            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (bookidTextBox.Text != null)
                {
                    EnableAll();
                }
                Book aBook = new Book();
                //student.RegNo = department.Code + student.Date.Year + "." + (count + 1).ToString("D4");
                aBook.BookId = Convert.ToInt32(bookidTextBox.Text);
                aBook.Name = bookNameTextBox.Text;
                aBook.Author = authorTextBox.Text;
                aBook.Version = Convert.ToInt32(versionTextBox.Text);
                aBook.BookType = bookTypeTextBox.Text;
                aBook.Quantity = Convert.ToInt32(quantityTextBox.Text);
                aBook.Price = Convert.ToInt32(priceTextBox.Text);

                string msg = aBookBll.UpdateBookById(aBook);
                messageLabel.Text = msg;
                ClearAll();
            }
            catch (Exception ex)
            {
                messageLabel.Text = "ERROR"+ex;
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookidTextBox.Text != null)
                {
                    EnableAll();
                }

                int id = Convert.ToInt32(bookidTextBox.Text);
                string msg = aBookBll.DeleteBookById(id);
                messageLabel.Text = "Delated Successfully";
                ClearAll();
            }
            catch (Exception exp)
            {
                messageLabel.Text = "ERROR" + exp;
            }

        }     

      
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
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