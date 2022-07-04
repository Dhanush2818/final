using BookHIveService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookHIveService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select UserName,UserEmail,Contact,Address,Password,UserId from
                                dbo.UserDetails
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
        public JsonResult Post(UserDetails bd)
        {
            try
            {
                string query = @"
                            insert dbo.UserDetails values
                               ('" + bd.UserName + @"'
                      ,'" + bd.UserEmail + @"'
                      ,'" + bd.Contact + @"'
                      ,'" + bd.Address + @"'
                      ,'" + bd.Password + @"'
                        
                       
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
                return new JsonResult("Registration Successfull");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(UserDetails bd)
        {
            try
            {
                string query = @"
                    update dbo.UserDetails set
               UserName='" + bd.UserName + @"'
                    ,Contact='" + bd.Contact + @"'
                    ,Address='" + bd.Address + @"'
                    ,Password='" + bd.Password + @"'
                   
                    where UserEmail='" + bd.UserEmail + @"'
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
                return new JsonResult("Updated Successfull");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpDelete("{name}")]
        public JsonResult Delate(string name)
        {
            try
            {
                string query = @"
                    delete from dbo.UserDetails
                    where UserEmail=" + name + @"
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
                return new JsonResult("Account Deleted");
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
                            select UserName,UserEmail,Contact,Address,Password,UserId from
                                dbo.UserDetails where UserEmail=" + name+ @"
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
