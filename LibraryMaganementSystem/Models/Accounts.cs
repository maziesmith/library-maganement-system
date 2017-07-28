using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{

    [Serializable]
   public class Accounts
    {
        public string AccountId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string AccountType { set; get; }
        public string Email { set; get; }
        public int CellNo { set; get; }
        public string Address { set; get; }
        public DateTime ExpDate { set; get; }
    }
}