using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class AccountBLL
    {

        private AccountGateway anAccountGatway = new AccountGateway();

        public String Save(Accounts anAccount)
        {
            anAccountGatway.Save(anAccount);
           
           return "Account Create Successfully";
            
           
        }

        public DataTable GetAllAccount()
        {
            return anAccountGatway.GetAllAccount();
        }

       
        public DataTable SearchAccount(Accounts anAccount)
        {
            return anAccountGatway.SearchAccount(anAccount);
        }

        public string DeleteAllAccount()
        {
            bool msg = anAccountGatway.DeleteAllAccount();
            if (msg)
            {
                return "Delete Successful";
            }
            return "Errror";
        }

        public DataTable DeleteRowAccountByID(string accountId)
        {
            return anAccountGatway.DeleteRowAccountByID(accountId);
        }

        public string DeleteAccountByID(string accountId)
        {
            bool res = anAccountGatway.DeleteAccountByID(accountId);
            if (res==false)
            {
                return "Delete not SuccessFull";
            }
            return "Deleted SuccessFully";

            


        }
        public Accounts GetAnAccountById(string id)
        {
            return anAccountGatway.GetAnAccountById(id);
        }

        public DataTable GetAnAccountByIdUsingDataTable(string accId)
        {
            return anAccountGatway.GetAnAccountByIdUsingDataTable(accId);
        }
         public DataTable GetAnAccountByNameUsingDataTable(string name)
        {
            return anAccountGatway.GetAnAccountByNameUsingDataTable(name);
        }

        public void UpdateRowAccountById(Accounts anAccount)
        {
            anAccountGatway.UpdateRowAccountById(anAccount);
           
        }

        public string UpdateAccountById(Accounts anAccount)
        {
           bool res= anAccountGatway.UpdateAccountById(anAccount);
            if (res==false)
            {
                return "Updated not SuccessFull";
               
            }
            return "Updated SuccessFully";
               
             
           
        }

        public DataTable GetAllExpiredAccountTillToday(DateTime toDay)
        {
            return anAccountGatway.GetAllExpiredAccountTillToday(toDay);
        }

        public string DeleteExperiedAccountWhomHaveNoBorrowedBook(DateTime date)
        {
            return anAccountGatway.DeleteExperiedAccountWhomHaveNoBorrowedBook(date);
        }
        
    }
}