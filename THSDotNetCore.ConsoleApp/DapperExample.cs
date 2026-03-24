using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THSDotNetCore.ConsoleApp.Models;

namespace THSDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";


        public void Read()
        {

            //using (IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where DeleteFlag = 0;";
            //    var lst = db.Query(query).ToList();

            //    //if(item ==  null)
            //    foreach (var item in lst)
            //    {


            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);


            //    }
            //    //DTO => Data Transfer Project
            //}
        }

       


        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
      ,@BlogAuthor
      ,@BlogContent
      ,0)";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,

                    BlogAuthor = author,

                    BlogContent = content,

                });
                Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");

            }


        }

        public void Edit(int id)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0 and BlogId = @BlogId;";
                var item = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id

                }).FirstOrDefault();

                //if(item ==  null)
                if (item is null)
                {
                    Console.WriteLine("No data found.");
                    return;
                }

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);


            }
            //DTO => Data Transfer Project
        }


    }
}
