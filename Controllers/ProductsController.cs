using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        [HttpGet("pull")]
        public List<Product> Pull(int categoryId)
        {
    
            return DB.PullData<Product>("SELECT BookID, BookName, Products.SupplierID AS 'SupplierID', Suppliers.CompanyName AS 'SupplierName', BookAuthor, BookPrintedYear, BookShelfLoction, BookBinding, Products.CategoryID AS 'CategoryID', Categories.CategoryName AS 'CategoryName' FROM Products INNER JOIN Suppliers ON (Products.SupplierID = Suppliers.SupplierID) INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID) WHERE Products.CategoryID=@CategoryID",
                (dr) => new Product
                {
                    BookID = dr.GetInt32(0),
                    BookName = dr.GetStringOrNull(1),
                    SupplierID = dr.GetInt32(2),
                    SupplierName = dr.GetStringOrNull(3),
                    BookAuthor = dr.GetStringOrNull(4),
                    BookPrintedYear = dr.GetInt32(5),
                    BookShelfLoction = dr.GetInt32(6),
                    BookBinding = dr.GetBoolean(7),
                    CategoryID = dr.GetInt32(8),
                    CategoryName = dr.GetStringOrNull(9)

                }
                , (cmd) => cmd.Parameters.AddWithValue("@CategoryID", categoryId));
        }

        [HttpGet("all")]
        public List<Product> All()
        {
            return DB.PullData<Product>("SELECT BookID, BookName, SupplierID, BookAuthor, " +
                "BookPrintedYear, BookShelfLoction, BookBinding, CategoryID FROM Products"
                , (dr) =>
                {
                    return new Product
                    {
                        BookID = dr.GetInt32(0),
                        BookName = dr.GetStringOrNull(1),
                        SupplierID = dr.GetInt32(2),
                        BookAuthor = dr.GetStringOrNull(3),
                        BookPrintedYear = dr.GetInt32(4),
                        BookShelfLoction = dr.GetInt32(5),
                        BookBinding = dr.GetBoolean(6),
                        CategoryID = dr.GetInt32(7),
                    };
                });
        }

       

        [HttpGet("find")]
        public bool Find(int bookshelfloction)
        {
            List<Product> products = new List<Product>();
            
            products = DB.PullData<Product>("SELECT BookID, BookName, SupplierID, BookAuthor," +
                "BookPrintedYear, BookShelfLoction, BookBinding, CategoryID FROM Products " +
                "WHERE Products.BookShelfLoction=@BookShelfLoction",
                 (dr) => new Product
                 {
                     BookID = dr.GetInt32(0),
                     BookName = dr.GetStringOrNull(1),
                     SupplierID = dr.GetInt32(2),
                     BookAuthor = dr.GetStringOrNull(3),
                     BookPrintedYear = dr.GetInt32(4),
                     BookShelfLoction = dr.GetInt32(5),
                     BookBinding = dr.GetBoolean(6),
                     CategoryID = dr.GetInt32(7),
                 }
                 , (cmd) => cmd.Parameters.AddWithValue("@BookShelfLoction", bookshelfloction));

            if(products.Count > 0)
            {
                return true;
            }
                return false;
        }


        [HttpGet("search")]
        public List<Product> Search(string bookname)
        {
            return DB.PullData<Product>("SELECT BookID, BookName, Products.SupplierID AS 'SupplierID', Suppliers.CompanyName AS 'SupplierName', BookAuthor, BookPrintedYear, BookShelfLoction, BookBinding, Products.CategoryID AS 'CategoryID', Categories.CategoryName AS 'CategoryName' FROM Products INNER JOIN Suppliers ON (Products.SupplierID = Suppliers.SupplierID) INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID) WHERE Products.BookName=@BookName",
                (dr) => new Product
                {
                    BookID = dr.GetInt32(0),
                    BookName = dr.GetStringOrNull(1),
                    SupplierID = dr.GetInt32(2),
                    SupplierName = dr.GetStringOrNull(3),
                    BookAuthor = dr.GetStringOrNull(4),
                    BookPrintedYear = dr.GetInt32(5),
                    BookShelfLoction = dr.GetInt32(6),
                    BookBinding = dr.GetBoolean(7),
                    CategoryID = dr.GetInt32(8),
                    CategoryName = dr.GetStringOrNull(9)

                }
                , (cmd) => cmd.Parameters.AddWithValue("@BookName", bookname));
        }







        [HttpPost("update")]
        public bool Update(Product product)
        {
            List<Product> samePlaceProduct = GetExistBookLocation(product);

            if (samePlaceProduct.Count > 0)
            {
                return false;
            }



            return DB.Modify("UPDATE Products SET BookName = @BookName, SupplierID = @SupplierID, " +
                "BookAuthor = @BookAuthor, BookPrintedYear = @BookPrintedYear, BookShelfLoction = @BookShelfLoction, " +
                "BookBinding = @BookBinding, CategoryID = @CategoryID " +
                "WHERE BookID = @BookID",
                (cmd) =>
                {
                    cmd
                    .AddWithValue("@BookName", product.BookName.TrimEnd())
                    .AddWithValue("@SupplierID", product.SupplierID)
                    .AddWithValue("@BookAuthor", product.BookAuthor.TrimEnd())
                    .AddWithValue("@BookPrintedYear", product.BookPrintedYear)
                    .AddWithValue("@BookShelfLoction", product.BookShelfLoction)
                    .AddWithValue("@BookBinding", product.BookBinding)
                    .AddWithValue("@CategoryID", product.CategoryID)
                    .AddWithValue("@BookID", product.BookID);

                }) == 1;
        }

        private static List<Product> GetExistBookLocation(Product product)
        {
            return DB.PullData<Product>($"SELECT BookID, BookName, Products.SupplierID AS 'SupplierID', Suppliers.CompanyName AS 'SupplierName', BookAuthor, BookPrintedYear, BookShelfLoction, BookBinding, Products.CategoryID AS 'CategoryID', Categories.CategoryName AS 'CategoryName' FROM Products INNER JOIN Suppliers ON(Products.SupplierID = Suppliers.SupplierID) INNER JOIN Categories ON(Products.CategoryID = Categories.CategoryID) WHERE Products.CategoryID = @CategoryID And BookShelfLoction = @BookLocationParam"
             , (dr) =>
             {
                 return new Product
                 {
                     BookID = dr.GetInt32(0),
                     BookName = dr.GetStringOrNull(1),
                     SupplierID = dr.GetInt32(2),
                     SupplierName = dr.GetStringOrNull(3),
                     BookAuthor = dr.GetStringOrNull(4),
                     BookPrintedYear = dr.GetInt32(5),
                     BookShelfLoction = dr.GetInt32(6),
                     BookBinding = dr.GetBoolean(7),
                     CategoryID = dr.GetInt32(8),
                     CategoryName = dr.GetStringOrNull(9)
                 };
             }, (cmd) => cmd.AddWithValue("@BookLocationParam", product.BookShelfLoction).AddWithValue("@CategoryID", product.CategoryID));
        }

        [HttpPost("insert")]
        public bool Insert(Product product)
        {
            List<Product> samePlaceProduct = GetExistBookLocation(product);

            if (samePlaceProduct.Count > 0)
            {
                return false;
            }


            return DB.Modify("INSERT INTO Products " +
                "(BookName, SupplierID, BookAuthor, BookPrintedYear, BookShelfLoction, BookBinding, CategoryID) " +
                "VALUES (@BookName, @SupplierID, @BookAuthor, @BookPrintedYear, @BookShelfLoction, @BookBinding, @CategoryID)",
                (cmd) =>
                {
                    cmd
                    .AddWithValue("@BookName", product.BookName.TrimEnd())
                    .AddWithValue("@SupplierID", product.SupplierID)
                    .AddWithValue("@BookAuthor", product.BookAuthor.TrimEnd())
                    .AddWithValue("@BookPrintedYear", product.BookPrintedYear)
                    .AddWithValue("@BookShelfLoction", product.BookShelfLoction)
                    .AddWithValue("@BookBinding", product.BookBinding)
                    .AddWithValue("@CategoryID", product.CategoryID);


                }) == 1;
        }

        [HttpGet("delete")]
        public bool Delete(int id)
        {
            return DB.Modify("DELETE FROM Products WHERE BookID=@BookID",
                (cmd) => cmd.AddWithValue("@BookID", id)) == 1;
        }
    }





    public static class MyExtensionMethod
    {
        public static SqlCommand AddWithValue(this SqlCommand cmd, string parameterName, object value)
        {
            if (value == null)
                cmd.Parameters.AddWithValue(parameterName, DBNull.Value);
            else
                cmd.Parameters.AddWithValue(parameterName, value);
            return cmd;
        }

        public static string GetStringOrNull(this SqlDataReader dr, int i)
        {
            return dr.IsDBNull(i) ? null : dr.GetString(i);
        }
    }
}