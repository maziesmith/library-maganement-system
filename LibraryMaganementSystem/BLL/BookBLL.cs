using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class BookBLL
    {
        private BookGateway aBookGateWay;

        public BookBLL()
        {
            aBookGateWay = new BookGateway();
        }

        public string Save(Book aBook)
        {
            if ((aBook.Name == "") || (aBook.Author == ""))
            {
                string info = "";
                if (aBook.Name == "")
                {
                    info += "please filled Book Name\n";
                }
                if (aBook.Author == "")
                {
                    info += "please filled Author Name\n";
                }
                return info;
            }
            else
            {
                bool res = aBookGateWay.Save(aBook);
                if (res)
                {
                    return "Book insert successfully";
                }

                return "problem ";
            }
        }

        //public List<Book> GetAllBook()
        //{
        //    return aBookGateWay.GetAllBook();
        //}

        public DataTable GetAllBook()
        {
            return aBookGateWay.GetAllBook();
        }
        public DataTable DeleteAllBook()
        {
            return aBookGateWay.DeleteAllBook();
        }
         public DataTable DeleteRowBook(int bookid)
        {
            return aBookGateWay.DeleteRowBook(bookid);
        }
     
        public DataTable SearchBook(Book aBook)
        {
            return aBookGateWay.SearchBook(aBook);
        }
        public Book GetBookById(int bookid)
        {
            return aBookGateWay.GetBookById(bookid);
        }

        public DataTable GetaBookByIdUsingDataTable(int bookid)
        {
            return aBookGateWay.GetaBookByIdUsingDataTable(bookid);
        }
        public DataTable GetaBookByNameUsingDataTable(string name)
        {
            return aBookGateWay.GetaBookByNameUsingDataTable(name);
        }
        
        public string UpdateBookById(Book aBook)
        {
           bool res = aBookGateWay.UpdateBookById(aBook);
            if (res)
                return "Updated SuccessFully";
            return "Updated not SuccessFull";
        }

        public string DeleteBookById(int bookid)
        {
            bool res = aBookGateWay.DeleteBookById(bookid);
            if (res)
                return "Delete SuccessFully";
            return "Delete not SuccessFull";
        }
    }
}