using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.Database.Models;
using THSDotNetCore.RestApi.ViewModels;

namespace THSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {

        private readonly string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";


        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            List<BlogViewModel> lst = new List<BlogViewModel>();    

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
           




            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
            FROM[dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                //lst.Add(new BlogViewModel
                //{
                //    Id = Convert.ToInt32(reader["BlogId"]),
                //    Title = Convert.ToString(reader["BlogTitle"]),
                //    Author = Convert.ToString(reader["BlogAuthor"]),
                //    Content = Convert.ToString(reader["BlogContent"]),
                //    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])

                //});
                var item = new BlogViewModel
                {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])

                };

                lst.Add(item);

            }


            connection.Close();

            return Ok(lst);
        }




        //[HttpPost]
        //public IActionResult CreateBlog(TblBlog blog)
        //{

        //}


        //[HttpPut("{id}")]
        //public IActionResult UpdateBlog(int id, TblBlog blog)
        //{

        //}



        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogViewModel blog)
        {
            string conditions = "";

            if (!string.IsNullOrEmpty(blog.Title))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }

            if (!string.IsNullOrEmpty(blog.Author))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }

            if (!string.IsNullOrEmpty(blog.Content))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }

            if (conditions.Length == 0)
            {

                return BadRequest("Invalid Parameters!");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string Query = @"UPDATE [dbo].[Tbl_Blog] SET{conditions} WHERE BlogId = @BlogId";

            SqlCommand Cmd = new SqlCommand(Query, connection);
            Cmd.Parameters.AddWithValue("@BlogId", id);
            if (!string.IsNullOrEmpty(blog.Title))
            {
                Cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                Cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                Cmd.Parameters.AddWithValue("@BlogContent", blog.Content);
            }

            int result = Cmd.ExecuteNonQuery();

             
            connection.Close();


            //[HttpDelete("{id}")]
            //public IActionResult DeleteBlog(int id, TblBlog blog)
            //{


            //}
            return Ok(result > 0? "Updating Successful!" : "Updating Failed.");    
        }
        }
}
