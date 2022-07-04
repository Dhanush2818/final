using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BookHiveService.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BookDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public BookDetailsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select BookName,BookId,Gerner,Author,Language,Description,Price,Photo from
                                dbo.BookDetails
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
        public JsonResult Post(BookDetails bd)
        {
            try
            {
                string query = @"
                            insert dbo.BookDetails values
                               ('" + bd.BookName + @"'
                      ,'" + bd.BookId + @"'
                      ,'" + bd.Gerner + @"'
                        ,'" + bd.Author + @"'
                      ,'" + bd.Language + @"'
                        ,'" + bd.Description + @"'
                      ,'" + bd.Price + @"'
                        ,'" + bd.Photo + @"'
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
                return new JsonResult("New Book Added");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(BookDetails bd)
        {
            try
            {
                string query = @"
                    update dbo.BookDetails set
               BookName='" + bd.BookName + @"'
                    ,Gerner='" + bd.Gerner + @"'
,Author= '" + bd.Author + @"'
                    ,Language='" + bd.Language + @"'
,Description='" + bd.Description + @"'
                    ,Price='" + bd.Price + @"'
                    ,Photo='" + bd.Photo + @"'
                    where BookId='" + bd.BookId + @"'
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
                return new JsonResult("Updated Successfully");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delate(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.BookDetails
                    where BookId=" + id + @"
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
                return new JsonResult("Disabled");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                            select BookName,BookId,Gerner,Author,Language,Description,Price,Photo from
                                dbo.BookDetails where BookId=" + id + @"
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


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using(
                    var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch(Exception)
            {
                return new JsonResult("anomymous.png");
            }
        }
    }
}
