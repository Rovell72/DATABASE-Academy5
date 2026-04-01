using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Academy5;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            try
            {
                // Faculties ================================
                ExecuteQuery(connection, "INSERT INTO Faculties (Name) VALUES ('Computer Science')");
                ExecuteQuery(connection, "INSERT INTO Faculties (Name) VALUES ('Economics')");
                ExecuteQuery(connection, "INSERT INTO Faculties (Name) VALUES ('Design')");

                // Departments ==============================
                ExecuteQuery(connection, "INSERT INTO Departments (Name, Financing) VALUES ('Software Development', 100000)");
                ExecuteQuery(connection, "INSERT INTO Departments (Name, Financing) VALUES ('Cybersecurity', 80000)");
                ExecuteQuery(connection, "INSERT INTO Departments (Name, Financing) VALUES ('Marketing', 60000)");

                // Groups ===================================
                ExecuteQuery(connection, "INSERT INTO Groups (Name, Rating, [Year]) VALUES ('CS101', 5, 1)");
                ExecuteQuery(connection, "INSERT INTO Groups (Name, Rating, [Year]) VALUES ('CS102', 4, 1)");
                ExecuteQuery(connection, "INSERT INTO Groups (Name, Rating, [Year]) VALUES ('CS201', 5, 2)");
                ExecuteQuery(connection, "INSERT INTO Groups (Name, Rating, [Year]) VALUES ('CS301', 3, 3)");

                // Teachers =================================
                ExecuteQuery(connection, @"INSERT INTO Teachers (Name, Surname, Salary, Premium, EmploymentDate) 
                              VALUES ('Ivan', 'Ivanov', 1200, 200, '2015-03-01')");

                ExecuteQuery(connection, @"INSERT INTO Teachers (Name, Surname, Salary, Premium, EmploymentDate) 
                              VALUES ('Maria', 'Petrova', 1500, 300, '2010-06-15')");

                ExecuteQuery(connection, @"INSERT INTO Teachers (Name, Surname, Salary, Premium, EmploymentDate) 
                              VALUES ('Alexey', 'Sidorov', 1800, 400, '2008-09-10')");

                ExecuteQuery(connection, @"INSERT INTO Teachers (Name, Surname, Salary, Premium, EmploymentDate) 
                              VALUES ('Olga', 'Kovalenko', 1400, 150, '2018-02-20')");

                Console.WriteLine("Database filled      ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  :  " + ex.Message);
            }
        }

        Console.ReadLine();
    }

    static void ExecuteQuery(SqlConnection connection, string query)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
