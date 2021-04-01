using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("pull")]
        public List<Category> Pull()
        {
            return DB.PullData<Category>("SELECT CategoryID, CategoryName FROM Categories"
                , (dr) =>
                {
                    return new Category
                    {
                        CategoryID = dr.GetInt32(0),
                        CategoryName = dr.GetString(1)
                    };
                });
        }

        [HttpPost("update")]
        public bool Update(Category category)
        {
            return DB.Modify("UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID",
                (cmd) => {
                    cmd
                    .AddWithValue("@CategoryName", category.CategoryName.TrimEnd())
                    .AddWithValue("@CategoryID", category.CategoryID);

                }) == 1;
        }

        [HttpPost("insert")]
        public bool Insert(Category category)
        {
            return DB.Modify("INSERT INTO Categories " +
                "(CategoryName) " +
                "VALUES (@CategoryName)",
                (cmd) => {
                    cmd
                    .AddWithValue("@CategoryName", category.CategoryName.TrimEnd());

                }) == 1;
        }

        [HttpGet("delete")]
        public bool Delete(int id)
        {
            return DB.Modify("DELETE FROM Categories WHERE CategoryID=@CategoryID",
                (cmd) => cmd.AddWithValue("@CategoryID", id)) == 1;
        }
    }
}
