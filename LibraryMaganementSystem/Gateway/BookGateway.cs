using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class BookGateway
    {

    SqlConnection aConnection = new SqlConnection();
    public BookGateway()
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementDBConnectionString"].ConnectionString;
        aConnection.ConnectionString = connectionString;
    }
    public bool Save(Book aBook)
    {
        aConnection.Open();
        string query = string.Format("INSERT INTO Book VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})",
                                      aBook.Name, aBook.Author, aBook.BookType, aBook.Version, aBook.Quantity, aBook.PublisherName,
                                      aBook.PublisherAddress,aBook.PublisherContactNo,aBook.PublishYear,aBook.Price);
        SqlCommand bCommand = new SqlCommand(query, aConnection);
       
        int total1 = bCommand.ExecuteNonQuery();
        aConnection.Close();

        if ((total1) > 0)
            return true;
        return false;
       
    }

    public DataTable GetAllBook()
    {
        aConnection.Open();
        //string selectString = "SELECT * FROM Book";
        string selectString = string.Format("SELECT * FROM Book");
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectString, aConnection);
       
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }

      //public List<Book> GetAllBook()
      //{
      //    aConnection.Open();
      //    string query = string.Format("SELECT * FROM Book");
      //    SqlCommand aCommand = new SqlCommand(query, aConnection);
      //    SqlDataReader aReader = aCommand.ExecuteReader();
      //    List<Book> allBooks = new List<Book>();
      //    if (aReader.HasRows)
      //    {
      //        while (aReader.Read())
      //        {
      //            Book aBook =new Book();
      //            aBook.BookId=aReader[0].ToString();
      //            aBook.Name=aReader[1].ToString();
      //            aBook.Author=aReader[2].ToString();
      //            aBook.BookType=aReader[3].ToString();
      //            aBook.Version=(int)aReader[4];
      //            aBook.Quantity = (int)aReader[5];
      //            aBook.PublisherName=aReader[6].ToString();
                 
      //            aBook.PublisherAddress=aReader[7].ToString();
      //            aBook.PublisherContactNo = (int)aReader[8];
      //            aBook.PublishYear = (int)aReader[9];
      //            allBooks.Add(aBook);
      //            }
      //    }
      //    aConnection.Close();
      //    return allBooks;
      //}
    public DataTable DeleteAllBook()
    {
        aConnection.Open();
        //string selectString = "DELETE FROM Book";
        string selectString = string.Format("DELETE FROM Book");
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectString, aConnection);
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }

    public DataTable DeleteRowBook(int bookid)
    {
        aConnection.Open();
        //string query = "DELETE FROM Book WHERE BookId =" + bookid;
        //string query = string.Format("DELETE FROM Book WHERE BookId='" + bookid + "'");
        string query = string.Format("DELETE FROM Book WHERE BookId={0}", bookid);
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(query, aConnection);
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }

    public DataTable GetaBookByIdUsingDataTable(int bookid)
    {
        aConnection.Open();
        //string query = "SELECT *FROM Boo  WHERE BookId =" + bookid;
        //string query = string.Format("SELECT * FROM Book WHERE BookId='" + bookid + "'");
        string query = string.Format("SELECT * FROM Book WHERE BookId={0}", bookid);
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(query, aConnection);
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }

    public DataTable GetaBookByNameUsingDataTable(string name)
    {
        aConnection.Open();
        //string query = "SELECT *FROM Boo  WHERE Name =" + name;
        // string query = string.Format("SELECT * FROM Book WHERE Name='" + name + "'");
        string query = string.Format("SELECT * FROM Book WHERE Name='{0}'", name);
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(query, aConnection);
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }

    public Book GetBookById(int bookid)
    {
        Book aBook = null;
        aConnection.Open();
        //var query = "SELECT * FROM Book WHERE BookId =" + bookid;
        // string query = string.Format("SELECT * FROM Book WHERE BookId='" + bookid + "'");
        string query = string.Format("SELECT * FROM Book WHERE BookId={0}", bookid);
        SqlCommand command = new SqlCommand(query, aConnection);

        SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            aBook = new Book();
            aBook.BookId = (int)dataReader["BookId"];
            aBook.Name = (string)dataReader["Name"];
            aBook.Author = (string)dataReader["Author"];
            aBook.BookType = (string)dataReader["BookType"];
            aBook.Version = (int)dataReader["Version"];
            aBook.Quantity = (int)dataReader["Quantity"];
            aBook.PublisherName = (string)dataReader["PublisherName"];
            aBook.PublisherAddress = (string)dataReader["PublisherAddress"];
            aBook.PublisherContactNo = (int)dataReader["PublisherContactNo"];
            aBook.PublishYear = (int)dataReader["PublishYear"];
            aBook.Price = (int)dataReader["Price"];

        }
        dataReader.Close();
        aConnection.Close();
        return aBook;
    }

    public DataTable SearchBook(Book aBook)
    {
        aConnection.Open();
        string selectString = String.Format("SELECT * FROM Book WHERE Name LIKE '%{0}' OR Author LIKE '%{1}'", aBook.Name, aBook.Author);

       //string selectString = "SELECT * FROM Book WHERE(Name LIKE '%" + aBook.Name + "%') OR (Author LIKE '%" + aBook.Author + "%')";
        SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(selectString, aConnection);
        DataTable dt = new DataTable();
        sqlDataAdapterObj.Fill(dt);
        aConnection.Close();
        return dt;
    }
   

    public bool UpdateBookById(Book aBook)
    {       
        aConnection.Open();
        string query2= String.Format("Update Book SET Name='{0}', Author='{1}', BookType='{2}', Version={3},Price={4},Quantity={5}  WHERE BookId={6}",
                       aBook.Name, aBook.Author, aBook.BookType, aBook.Version, aBook.Price,aBook.Quantity,aBook.BookId);

        //string query2 = string.Format("UPDATE Book SET Name ='" + aBook.Name+"',Author='" + aBook.Author
        //                              + "',BookType='" + aBook.BookType + "',Version='" + aBook.Version + "',Price='" + aBook.Price
        //                              +"',Quantity='" + aBook.Quantity+ "' Where BookId='" + aBook.BookId + "'");
                                  
        SqlCommand bCommand = new SqlCommand(query2, aConnection);

        int total1 = bCommand.ExecuteNonQuery();//ExecuteNonQuery will retun 1 always but stored procedure retun -1
        aConnection.Close();

        if ((total1) > 0)
            return true;
        return false;   
    }
    public bool DeleteBookById(int bookid)
    {
        aConnection.Open();

        //var query = "DELETE FROM Book WHERE BookId =" + bookid;
        //string query = string.Format("DELETE FROM Book WHERE BookId='" + bookid + "'");
        string query = string.Format("DELETE FROM Book WHERE BookId={0}", bookid);

        SqlCommand bCommand = new SqlCommand(query, aConnection);
        int total1 = bCommand.ExecuteNonQuery();
        aConnection.Close();

        if ((total1) > 0)
            return true;
        return false;
    }
  }
}