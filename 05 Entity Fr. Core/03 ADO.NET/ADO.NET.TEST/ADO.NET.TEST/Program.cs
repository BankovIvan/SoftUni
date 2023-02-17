// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnection connection = new SqlConnection("Server=.;Database=SoftUni;MultipleActiveResultSets=true;Integrated Security=true;TrustServerCertificate=True");

connection.Open();

Console.WriteLine(connection.ServerVersion);

using (connection)
{
    string sSelectCount = "SELECT COUNT(*) FROM Employees";
    SqlCommand command = new SqlCommand(sSelectCount, connection);
    int? nEmployeesCount = (int?) await command.ExecuteScalarAsync();

    Console.WriteLine("Employees Count: {0}", nEmployeesCount);

    string sSelectTop5 = "SELECT TOP(5) * FROM Employees";
    command = new SqlCommand(sSelectTop5, connection);
    SqlDataReader reader = await command.ExecuteReaderAsync();

    using (reader)
    {
        while (reader.Read())
        {
            string? sFirstName = reader["FirstName"].ToString();
            string? sLastName = reader["LastName"].ToString();

            Console.WriteLine("{1}, {0}", sFirstName, sLastName);
        }
    }

    reader.Close();

}

connection.Close();
