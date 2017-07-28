using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    [Serializable]
    public class Book
    {
        public int BookId { set; get; }
        public string Name { set; get; }
        public string Author { set; get; }
        public string BookType { set; get; }
        public int Version { set; get; }
        public int Quantity { set; get; }
        public int Price { set; get; }

        public string PublisherName { set; get; }
        public int PublishYear { set; get; }
        public string PublisherAddress { set; get; }
        public int PublisherContactNo { set; get; }

        // public Publisher Publisher { set; get; }
    }
}