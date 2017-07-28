using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class BorrowerBLL
    {

        BorrowerGatewy aBorrowerGateway = new BorrowerGatewy();

        public string BorrowBook(Borrower aBorrower)
        {
            string msg = aBorrowerGateway.BorrowBook(aBorrower);
            return msg;
        }

        public string ReturnBook(Borrower aBorrower)
        {
            string msg = aBorrowerGateway.ReturnBook(aBorrower);
            return msg;
        }

        public DataTable GetAllBorrower()
        {
            return aBorrowerGateway.GetAllBorrower();
        }
    }
}