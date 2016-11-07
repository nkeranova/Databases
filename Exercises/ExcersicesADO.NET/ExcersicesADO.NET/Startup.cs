using System;
using System.Data.SqlClient;

namespace ExcersicesADO.NET
{
    class Startup
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=TelerikAcademy;Trusted_Connection=True;");
            connection.Open();
            //Console.WriteLine("OPEN");
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT TOP 10 * FROM Employees", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var firstName = reader["FirstName"];
                        //Console.WriteLine(firstName);

                        Console.WriteLine("-------------------");
                        for (int i = 0; i < reader.VisibleFieldCount; i++)
                        {
                            Console.WriteLine("{0}", reader[i]);
                        }
                    }
                }

                SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);

                var count = (int)countCommand.ExecuteScalar();
                Console.WriteLine(count);
            }


            using (connection)
            {
                SqlCommand commandParameters = new SqlCommand("insert into Towns(Name) values(@townName)", connection);

                commandParameters.Parameters.Add(new SqlParameter("@townName", "Carevo"));

                commandParameters.Parameters.AddWithValue("@townName", "Sinemorec");

                //Identity
                commandParameters.CommandText = "select @@Identity";
                var id = commandParameters.ExecuteScalar();
                Console.WriteLine(id);
            }
            connection.Close();
           //Console.WriteLine("Close");
        }

        /*
        //Password check
        bool IsPasswordValid(string username, string password)
        {
            string sql =
              "SELECT COUNT(*) FROM Users " +
              "WHERE UserName = '" + username + "' and " +
              "PasswordHash = '" + CalcSHA1(password) + "'";
            SqlCommand cmd = new SqlCommand(sql, dbConnection);
            int matchedUsersCount = (int)cmd.ExecuteScalar();
            return matchedUsersCount > 0;
        }

        bool normalLogin =
          IsPasswordValid("peter", "qwerty123"); // true
        bool sqlInjectedLogin =
          IsPasswordValid(" ' or 1=1 --", "qwerty123");
        */
    }
}
