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
    public partial class BookAddUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ClearAll()
        {
            this.bookNameTextBox.Text= "";
            this. authorTextBox.Text= "";
            this.versionTextBox.Text = "";
            this.qualityTextBox.Text= "";
            this.qualityTextBox.Text = "";
            this.priceTextBox.Text = "";
            this.publisherNameTextBox.Text = "";
            this.publishYearTextBox.Text = "";
            this.publisherAddressTextBox.Text = "";
            this.conatactTextBox.Text = "";
        }

        BookBLL aBookBll = new BookBLL();
        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Book aBook = new Book();
                //student.RegNo = department.Code + student.Date.Year + "." + (count + 1).ToString("D4");
                aBook.Name =bookNameTextBox.Text;
                aBook.Author = authorTextBox.Text;
                aBook.Version = Convert.ToInt32(versionTextBox.Text);
                aBook.BookType = bookTypeDropDownList.Text;
                aBook.Quantity = Convert.ToInt32(qualityTextBox.Text);
                aBook.Price = Convert.ToInt32(priceTextBox.Text);
                aBook.PublisherName = publisherNameTextBox.Text;
                aBook.PublishYear = Convert.ToInt32(publishYearTextBox.Text);
                aBook.PublisherAddress = publisherAddressTextBox.Text;

                aBook.PublisherContactNo = Convert.ToInt32(conatactTextBox.Text);

                string msg = aBookBll.Save(aBook);
                // messageLabel.Text = isInserted ? "Saved Successfully!" : "Insertion failed!";
                messageLabel.Text = msg;
                ClearAll();

            }
            catch (Exception ex)
            {
                messageLabel.Text = "" + ex;
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/BookUI.aspx");
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/HmeUI.aspx");
        }

    }
}