using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.RestApi.DataModels;
using THSDotNetCore.RestApi.ViewModels;

namespace THSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private readonly string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetBlogs()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Tbl_Blog WHERE DeleteFlag = 0";
            var lst = db.Query<BlogDataModel>(query).ToList();

            var response = lst.Select(x => new BlogViewModel
            {
                Id = x.BlogId,
                Title = x.BlogTitle,
                Author = x.BlogAuthor,
                Content = x.BlogContent,
                DeleteFlag = x.DeleteFlag
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId AND DeleteFlag = 0";
            var item = db.Query<BlogDataModel>(query, new { BlogId = id }).FirstOrDefault();

            if (item == null)
            {
                return NotFound("No blog found.");
            }

            var response = new BlogViewModel
            {
                Id = item.BlogId,
                Title = item.BlogTitle,
                Author = item.BlogAuthor,
                Content = item.BlogContent,
                DeleteFlag = item.DeleteFlag
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel blog)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"INSERT INTO [dbo].[Tbl_Blog] ([BlogTitle], [BlogAuthor], [BlogContent], [DeleteFlag])
                             VALUES (@Title, @Author, @Content, 0)";

            int result = db.Execute(query, blog);

            return Ok(result > 0 ? "Saving Successful!" : "Saving Failed.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogViewModel blog)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"UPDATE [dbo].[Tbl_Blog] 
                             SET [BlogTitle] = @Title, [BlogAuthor] = @Author, [BlogContent] = @Content 
                             WHERE BlogId = @Id";

            blog.Id = id;
            int result = db.Execute(query, blog);

            return Ok(result > 0 ? "Updating Successful!" : "Updating Failed.");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogViewModel blog)
        {
            string conditions = "";
            if (!string.IsNullOrEmpty(blog.Title)) conditions += "[BlogTitle] = @Title, ";
            if (!string.IsNullOrEmpty(blog.Author)) conditions += "[BlogAuthor] = @Author, ";
            if (!string.IsNullOrEmpty(blog.Content)) conditions += "[BlogContent] = @Content, ";

            if (string.IsNullOrEmpty(conditions))
            {
                return BadRequest("Invalid Parameters!");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            using IDbConnection db = new SqlConnection(_connectionString);
            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            if (!string.IsNullOrEmpty(blog.Title)) parameters.Add("Title", blog.Title);
            if (!string.IsNullOrEmpty(blog.Author)) parameters.Add("Author", blog.Author);
            if (!string.IsNullOrEmpty(blog.Content)) parameters.Add("Content", blog.Content);

            int result = db.Execute(query, parameters);

            return Ok(result > 0 ? "Updating Successful!" : "Updating Failed.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "UPDATE Tbl_Blog SET DeleteFlag = 1 WHERE BlogId = @BlogId";
            int result = db.Execute(query, new { BlogId = id });

            return Ok(result > 0 ? "Deleting Successful!" : "Deleting Failed.");
        }
    }
}
