using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Product
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string SupplierName { get; set; }
        public int SupplierID { get; set; }
        public string BookAuthor { get; set; }
        public int BookPrintedYear { get; set; }
        public int BookShelfLoction { get; set; }
        public bool BookBinding { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
