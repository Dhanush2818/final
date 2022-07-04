using BookHiveService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookHiveService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CartController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select UserEmail,UserId,BookName,Price,Quantity,TotalBill,Address from
                                dbo.Cart
";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookDetailsCon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Cart bd)
        {
            try
            {
                string query = @"
                            insert dbo.Cart values
                               ('" + bd.UserEmail + @"'
                      ,'" + bd.UserId + @"'
                      ,'" + bd.BookName + @"'
                      ,'" + bd.Price + @"'
                      ,'" + bd.Quantity + @"'
                      ,'" + (bd.Price* bd.Quantity) + @"'
                         ,'" + bd.Address + @"'
                      
)
";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("BookDetailsCon");
                SqlDataReader myReader;
                using (SqlConnection mycon = new SqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                }
                return new JsonResult("Item Added In Cart");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(Cart bd)
        {
            try
            {
                string query = @"
                    update dbo.Cart set
               Quantity='" + bd.Quantity + @"'
                    
                    
                    
                    where UserId='" + bd.UserId + @"'
         ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("BookDetailsCon");
                SqlDataReader myReader;
                using (SqlConnection mycon = new SqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                }
                return new JsonResult("Cart Details Updated");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Cart
                    where UserId=" + id + @"
         ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("BookDetailsCon");
                SqlDataReader myReader;
                using (SqlConnection mycon = new SqlConnection(sqlDataSource))
                {
                    mycon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, mycon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        mycon.Close();
                    }
                }
                return new JsonResult("Item Removed From Cart");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            string query = @"
                            select BookName,Price,Quantity,TotalBill,Address from
                                dbo.Cart where UserEmail=" + name + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookDetailsCon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
    }

}
