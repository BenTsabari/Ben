using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        [HttpGet("pull")]
        public List<Supplier> Pull()
        {
            return DB.PullData<Supplier>("SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City FROM Suppliers"
                , (dr) =>
                {
                    return new Supplier
                    {
                        SupplierID = dr.GetInt32(0),
                        CompanyName = dr.GetStringOrNull(1),
                        ContactName = dr.GetStringOrNull(2),
                        ContactTitle = dr.GetStringOrNull(3),
                        Address = dr.GetStringOrNull(4),
                        City = dr.GetStringOrNull(5)
                    };
                });
        }

        [HttpPost("update")]
        public bool Update(Supplier supplier)
        {
            return DB.Modify("UPDATE Suppliers SET CompanyName = @CompanyName, " +
                "ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City " +
                "WHERE SupplierID = @SupplierID",
                (cmd) =>
                {
                    cmd
                    .AddWithValue("@CompanyName", supplier.CompanyName.TrimEnd())
                    .AddWithValue("@ContactName", supplier.ContactName.TrimEnd())
                    .AddWithValue("@ContactTitle", supplier.ContactTitle.TrimEnd())
                    .AddWithValue("@Address", supplier.Address.TrimEnd())
                    .AddWithValue("@City", supplier.City.TrimEnd())
                    .AddWithValue("@SupplierID", supplier.SupplierID);

                }) == 1;
        }

        [HttpPost("insert")]
        public bool Insert(Supplier supplier)
        {
            return DB.Modify("INSERT INTO Suppliers " +
                "(CompanyName, ContactName, ContactTitle, Address, City) " +
                "VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City)",
                (cmd) =>
                {
                    cmd
                    .AddWithValue("@CompanyName", supplier.CompanyName.TrimEnd())
                    .AddWithValue("@ContactName", supplier.ContactName.TrimEnd())
                    .AddWithValue("@ContactTitle", supplier.ContactTitle.TrimEnd())
                    .AddWithValue("@Address", supplier.Address.TrimEnd())
                    .AddWithValue("@City", supplier.City.TrimEnd());

                }) == 1;
        }

        [HttpGet("delete")]
        public bool Delete(int id)
        {
            return DB.Modify("DELETE FROM Suppliers WHERE SupplierID=@SupplierID",
                (cmd) => cmd.AddWithValue("@SupplierID", id)) == 1;
        }
    }

}
