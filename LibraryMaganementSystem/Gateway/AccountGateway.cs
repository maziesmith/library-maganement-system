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
    public class AccountGateway
    {
        SqlConnection aConnection = new SqlConnection();
        public AccountGateway()
         {
             string connectionString = WebConfigurationManager.ConnectionStrings["LibraryManagementDBConnectionString"].ConnectionString;
             aConnection.ConnectionString = connectionString;
         }

        public bool Save(Accounts anAccount)
        {
            aConnection.Open();
            SqlCommand cmd = new SqlCommand("_sp_InsertIntoAccount", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", anAccount.AccountId);
            cmd.Parameters.AddWithValue("@FirstName ", anAccount.FirstName);
            cmd.Parameters.AddWithValue("@LastName ", anAccount.LastName);
            cmd.Parameters.AddWithValue("@AccountType ", anAccount.AccountType);

            cmd.Parameters.AddWithValue("@Email ", anAccount.Email);
            cmd.Parameters.AddWithValue("@CellNo ", anAccount.CellNo);
            cmd.Parameters.AddWithValue("@Address ", anAccount.Address);
            cmd.Parameters.AddWithValue("@ExpDate ", anAccount.ExpDate);

            cmd.ExecuteNonQuery();
           
            aConnection.Close();

            return true;  
        }

        public DataTable GetAllAccount()
        {
            aConnection.Open();
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("_sp_GetAccountDetail", aConnection);
            DataTable dt = new DataTable();
            sqlDataAdapterObj.Fill(dt);
            aConnection.Close();
            return dt;           
        }
     
        public DataTable SearchAccount(Accounts anAccount)
        {
            aConnection.Open();
            SqlCommand cmd = new SqlCommand("_sp_SearchAccountDetail", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", anAccount.AccountId);
            cmd.Parameters.AddWithValue("@FirstName ", anAccount.FirstName);
            cmd.Parameters.AddWithValue("@LastName ", anAccount.LastName);
            cmd.Parameters.AddWithValue("@Address ", anAccount.Address);
            cmd.Parameters.AddWithValue("@ExpDate ", anAccount.ExpDate);
         
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            aConnection.Close();
            
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
           
        }


        public Accounts GetAnAccountById(string accountId)
        {
            aConnection.Open();
            SqlCommand cmd = new SqlCommand("_sp_GetAnAccountById", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", accountId);
            SqlDataReader dataReader = cmd.ExecuteReader();

            Accounts anAccount = null;
            
            while (dataReader.Read())
            {
                anAccount=new Accounts();
                anAccount.AccountId = (string)dataReader["AccountId"];
                anAccount.FirstName = (string)dataReader["FirstName"];
                anAccount.LastName = (string)dataReader["LastName"];
                anAccount.AccountType = (string)dataReader["AccountType"];
                anAccount.Email = (string)dataReader["Email"];
                anAccount.CellNo = (int)dataReader["CellNo"];
                anAccount.Address = (string)dataReader["Address"];
                anAccount.ExpDate = (DateTime)dataReader["ExpDate"];
               }
            dataReader.Close();
            aConnection.Close();
            return anAccount;
           
        }

        public DataTable GetAnAccountByIdUsingDataTable(string accId)
        {
            aConnection.Open();
            //string query = "SELECT * FROM Account  WHERE AccountId =" + accId;
            //string query = string.Format("SELECT * FROM Account WHERE AccountId='" + accId + "'");
            string query = string.Format("SELECT * FROM Account WHERE AccountId={0}", accId);

            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(query, aConnection);
            DataTable dt = new DataTable();
            sqlDataAdapterObj.Fill(dt);
            aConnection.Close();
            return dt; 
        }

        public DataTable GetAnAccountByNameUsingDataTable(string name)
        {
            aConnection.Open();
            //string query = "SELECT * FROM Account  WHERE FirstName =" + name;
            //string query = string.Format("SELECT * FROM Account WHERE FirstName='" + name + "'");
            string query = string.Format("SELECT * FROM Account WHERE FirstName={0}", name);
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter(query, aConnection);
            DataTable dt = new DataTable();
            sqlDataAdapterObj.Fill(dt);
            aConnection.Close();
            return dt;
        }
       
        public bool DeleteAllAccount()
        {
            aConnection.Open();

            SqlCommand cmd = new SqlCommand("_sp_DeleteAllAccount", aConnection);
            int total1 = cmd.ExecuteNonQuery();

            aConnection.Close();

            if ((total1) > 0)
                return true;
            return false;

      }

      public DataTable DeleteRowAccountByID(string accountID)
        {
            aConnection.Open();

            SqlCommand cmd = new SqlCommand("_sp_DeleteRowAccountByID", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", accountID);

            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            aConnection.Close();

            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
  
       }
        public bool DeleteAccountByID(string accountID)
        {
            aConnection.Open();

            SqlCommand cmd = new SqlCommand("_sp_DeleteAccountByID", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", accountID);
            int total1 = cmd.ExecuteNonQuery();

            aConnection.Close();

            if ((total1) > 0)
                return true;
            return false;
           }

        public DataTable UpdateRowAccountById(Accounts anAccount)
        {       
        aConnection.Open();

        SqlCommand cmd = new SqlCommand("_sp_UpdateRowAccountById", aConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AccountId ", anAccount.AccountId);
        cmd.Parameters.AddWithValue("@FirstName ", anAccount.FirstName);
        cmd.Parameters.AddWithValue("@LastName ", anAccount.LastName);
        cmd.Parameters.AddWithValue("@AccountType ", anAccount.AccountType);
        cmd.Parameters.AddWithValue("@Email ", anAccount.Email);
        cmd.Parameters.AddWithValue("@CellNo ", anAccount.CellNo);
        cmd.Parameters.AddWithValue("@Address ", anAccount.Address);
        //cmd.Parameters.AddWithValue("@ExpDate ", anAccount.ExpDate);

        SqlDataAdapter adap = new SqlDataAdapter(cmd);

        aConnection.Close();

        DataTable dt = new DataTable();
        adap.Fill(dt);
        return dt;
       }

        public bool UpdateAccountById(Accounts anAccount)
        {
            aConnection.Open();
            SqlCommand cmd = new SqlCommand("_sp_UpdateAccountById", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountId ", anAccount.AccountId);
            cmd.Parameters.AddWithValue("@FirstName ", anAccount.FirstName);
            cmd.Parameters.AddWithValue("@LastName ", anAccount.LastName);
            cmd.Parameters.AddWithValue("@AccountType ", anAccount.AccountType);

            cmd.Parameters.AddWithValue("@Email ", anAccount.Email);
            cmd.Parameters.AddWithValue("@CellNo ", anAccount.CellNo);
            cmd.Parameters.AddWithValue("@Address ", anAccount.Address);
            cmd.Parameters.AddWithValue("@ExpDate ", anAccount.ExpDate);

            int total1 = cmd.ExecuteNonQuery();//will always retun -1

            aConnection.Close();

            if ((total1) < 0)
                return true;
            return false;

        }
     
        public DataTable GetAllExpiredAccountTillToday(DateTime toDay)
        {
            aConnection.Open();
            SqlCommand cmd = new SqlCommand("_sp_GetAllExpiredAccount", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ToDay ", toDay);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            aConnection.Close();

            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;

        }

        public string DeleteExperiedAccountWhomHaveNoBorrowedBook(DateTime toDay)
        {
            string message = string.Empty;
            SqlCommand cmd = new SqlCommand("_sp_DeleteExperiedAccountWhomHaveNoBorrowedBook", aConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ToDay", toDay);
            cmd.Parameters.Add("@ErrorMsg", SqlDbType.Char, 500);
            cmd.Parameters["@ErrorMsg"].Direction = ParameterDirection.Output;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
         
            aConnection.Open();
            cmd.ExecuteNonQuery();

            message = (string)cmd.Parameters["@ErrorMsg"].Value;
            aConnection.Close();
            return message;
        }

      
    }
}