using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THSDotNetCore.ConsoleApp
{

    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;";
        public void Read()
        {

            Console.WriteLine(value: "Connection String " + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine(value: "Connection opening...");
            connection.Open();
            Console.WriteLine(value: "Connection opened.");




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





            Console.WriteLine(value: "Connection closing...");
            connection.Close();
            Console.WriteLine(value: "Connection closed...");
        }


        public void Create() {

            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();




            // max connection = 100



            // Console.WriteLine(value: "Connection opening...");
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

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



            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);


            int result = cmd.ExecuteNonQuery();



            connection.Close();
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

            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");


        }

        public void Edit() {

            Console.Write("Blog Id: ");
            int id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd =  new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);

        }

        public void Update()
        {
            Console.Write("Enter Blog Id: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Get existing data
                string query = @"SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
                SqlCommand selectCmd = new SqlCommand(query, connection);
                selectCmd.Parameters.AddWithValue("@BlogId", id);

                SqlDataAdapter adapter = new SqlDataAdapter(selectCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No data found.");
                    return;
                }

                DataRow dr = dt.Rows[0];

                Console.WriteLine($"Current Title: {dr["BlogTitle"]}");
                Console.Write("New Title: ");
                string title = Console.ReadLine();

                Console.WriteLine($"Current Author: {dr["BlogAuthor"]}");
                Console.Write("New Author: ");
                string author = Console.ReadLine();

                Console.WriteLine($"Current Content: {dr["BlogContent"]}");
                Console.Write("New Content: ");
                string content = Console.ReadLine();

                // UPDATE QUERY
                string updateQuery = @"UPDATE Tbl_Blog
                              SET BlogTitle = @BlogTitle,
                                  BlogAuthor = @BlogAuthor,
                                  BlogContent = @BlogContent,
                                    DeleteFlag = 0
                              WHERE BlogId = @BlogId";

                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@BlogTitle", title);
                updateCmd.Parameters.AddWithValue("@BlogAuthor", author);
                updateCmd.Parameters.AddWithValue("@BlogContent", content);
                updateCmd.Parameters.AddWithValue("@BlogId", id);

                int result = updateCmd.ExecuteNonQuery();

                Console.WriteLine(result == 1 ? "Update Successful." : "Update Failed.");
            }
        }

    }
}
