using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
     [Serializable]
    public class Borrower
    {
        public string AccountId { set; get; }
        public int BookId { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ReturnDate { set; get; }
    }
}