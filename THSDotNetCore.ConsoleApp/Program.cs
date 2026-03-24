// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THSDotNetCore.ConsoleApp;

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
            /*
            string connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
            Console.WriteLine(value: "Connection String " + connectionString);
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine(value: "Connection opening...");
            connection.Open();
            Console.WriteLine(value: "Connection opened.");


            //
/*
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
            FROM[dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(cmdText: query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand: cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dataTable: dt);
            */


            /*foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                //Console.WriteLine(dr["DeleteFlag"]);

            }*/

            /* Console.WriteLine(value: "Connection closing...");
             connection.Close();
             Console.WriteLine(value: "Connection closed...");

             // Data Set
             /*
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
             */


            /*
            // max connection = 100
            string connectionString2 = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
           
            SqlConnection connection2 = new SqlConnection(connectionString2);
            Console.WriteLine(value: "Connection opening...");
            connection2.Open();

            string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
      ,@BlogAuthor
      ,@BlogContent
      ,0)";

            

            SqlCommand cmd2 = new SqlCommand(queryInsert, connection2);
            cmd2.Parameters.AddWithValue("@BlogTitle", title);
            cmd2.Parameters.AddWithValue("@BlogAuthor", author);
            cmd2.Parameters.AddWithValue("@BlogContent", content);
            

            int result = cmd2.ExecuteNonQuery();

           

            connection2.Close(); */
            /*
                        if (result == 1)
                        {
                            Console.WriteLine("Saving Successful.");
                        }
                        else
                        {
                            Console.WriteLine("Saving Failed.");
                        }
            */

            // Console.WriteLine(result== 1 ? "Saving Successful." : "Saving Failed.");


            /* AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

             Console.WriteLine("\n1. Read");
             Console.WriteLine("2. Create");
             Console.WriteLine("3. Edit");
             Console.WriteLine("4. Update");

             Console.Write("Choose option: ");
             string input = Console.ReadLine();

             switch (input)
             {
                 case "1":
                     adoDotNetExample.Read();
                     break;
                 case "2":
                     adoDotNetExample.Create();
                     break;
                 case "3":
                     adoDotNetExample.Edit();
                     break;
                 case "4":
                     adoDotNetExample.Update();
                     break;


             }*/

            //AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

            //Console.WriteLine("\n--- READ SECTION ---");
            //adoDotNetExample.Read();

            //Console.WriteLine("\n--- CREATE SECTION ---");
            //adoDotNetExample.Create();

            //Console.WriteLine("\n--- EDIT SECTION ---");
            //adoDotNetExample.Edit();

            // DapperExample dapperExample = new DapperExample();
            //dapperExample.Read();
            //dapperExample.Create("dptitle", "dpauthor", "dpcontent");
            //dapperExample.Edit(1);
            //dapperExample.Edit(2);

            EFCoreExample eFCoreExample = new EFCoreExample();
            //eFCoreExample.Read();
            eFCoreExample.Create("eftitle", "efauthor", "efcontent");
            Console.ReadKey();
        }
    }
}