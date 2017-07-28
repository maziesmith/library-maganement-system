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
    public class BorrowerGatewy
    {
        SqlConnection aConnection = new SqlConnection();
        public BorrowerGatewy()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementDBConnectionString"].ConnectionString;
            aConnection.ConnectionString = connectionString;
        }

        public string BorrowBook(Borrower aBorrower)
        {
            string message = string.Empty;
           
            using (SqlCommand cmd = new SqlCommand("_sp_InsertIntoBorrower", aConnection))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId ", aBorrower.BookId);
                cmd.Parameters.AddWithValue("@AccountId ", aBorrower.AccountId);
                cmd.Parameters.AddWithValue("@IssueDate ", aBorrower.IssueDate);
                cmd.Parameters.AddWithValue("@ReturnDate ", aBorrower.ReturnDate);

                cmd.Parameters.Add("@ErrorMsg", SqlDbType.Char, 500);
                cmd.Parameters["@ErrorMsg"].Direction = ParameterDirection.Output;

                aConnection.Open();
                cmd.ExecuteNonQuery();

                message = (string)cmd.Parameters["@ErrorMsg"].Value;
                aConnection.Close();
                return message;
            }

        }

        public string ReturnBook(Borrower aBorrower)
        {
            string message = string.Empty;
            using (SqlCommand cmd = new SqlCommand("_sp_ReturnFromBorrower", aConnection))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId ", aBorrower.BookId);
                cmd.Parameters.AddWithValue("@AccountId ", aBorrower.AccountId);
              
                cmd.Parameters.Add("@ErrorMsg", SqlDbType.Char, 500);
                cmd.Parameters["@ErrorMsg"].Direction = ParameterDirection.Output;

                aConnection.Open();
                cmd.ExecuteNonQuery();

                message = (string)cmd.Parameters["@ErrorMsg"].Value;
                aConnection.Close();
                return message;
            }

        }

        public DataTable GetAllBorrower()
        {
            aConnection.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("_sp_GetAllBorrower", aConnection);
            DataTable dt = new DataTable();
            sqlDataAdapterObj.Fill(dt);
            aConnection.Close();
            return dt;

        }

    }
    }
