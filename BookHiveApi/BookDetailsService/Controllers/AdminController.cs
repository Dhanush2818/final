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
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select AdminEmail,Password from
                                dbo.AdminDetails
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
        public JsonResult Post(Admin bd)
        {
            try
            {
                string query = @"
                            insert dbo.AdminDetails values
                               ('" + bd.AdminEmail + @"'
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
                return new JsonResult("New Admin Added Sucessfully");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(Admin bd)
        {
            try
            {
                string query = @"
                    update dbo.AdminDetails set
               Password='" + bd.Password + @"'
                    
                    
                    
                    where AdminEmail='" + bd.AdminEmail + @"'
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
                return new JsonResult("Details Updated");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpDelete("{name}")]
        public JsonResult Delete(string name)
        {
            try
            {
                string query = @"
                    delete from dbo.AdminDetails
                    where AdminEmail=" + name + @"
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
                            select AdminEmail,Password from
                                dbo.AdminDetails where AdminEmail=" + name + @"
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
