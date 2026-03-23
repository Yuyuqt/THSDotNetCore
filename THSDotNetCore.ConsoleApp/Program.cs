// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine();

            // md => markdown
            // C# <=> Database
            // ADO.Net
            //Dapper
            //EFCore / Entity Framework

            // max connection = 100
            var connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
            Console.WriteLine(value: "Connection String " + connectionString);
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine(value: "Connection opening...");
            connection.Open();
            Console.WriteLine(value: "Connection opened.");


            //

            var query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
            FROM[dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(cmdText: query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dataTable: dt);



            /*foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);

            }*/

            Console.WriteLine(value: "Connection closing...");
            connection.Close();
            Console.WriteLine(value: "Connection closed...");

            // Data Set

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);

            }
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();




            // max connection = 100
            var connectionString2 = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
           
            SqlConnection connection2 = new SqlConnection(connectionString2);
            Console.WriteLine(value: "Connection opening...");
            connection2.Open();

            string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}'
           ,0)";

            SqlCommand cmd2 = new SqlCommand(queryInsert   , connection2);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection2.Close();


            Console.ReadKey();
        }
    }
}