﻿using MySql.Data.MySqlClient;

public class StoredProcedure_1
{
    // Write the connection string here
    public static string connectionString = "host=___;port=___;user=___;password=___;database=___;";

    public static void Main(string[] args)
    {
        // 1. Using the '@' character before a string enables us to write it in multiple lines;
        // 2. We don't need to change the DELIMITER when creating a procedure from C# code;
        string procedureCode =
            @"DROP PROCEDURE IF EXISTS SetupTable;
            DROP TABLE IF EXISTS Employees;

            CREATE PROCEDURE `SetupTable` ()
            BEGIN
	            CREATE TABLE IF NOT EXISTS Employees (
		            EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
		            FirstName VARCHAR(50),
		            LastName VARCHAR(50),
		            Age INT,
		            Gender ENUM('Male', 'Female', 'Other'),
		            Department VARCHAR(50),
		            Position VARCHAR(50),
		            Salary DECIMAL(10, 2)
	            );

	            INSERT INTO Employees (FirstName, LastName, Age, Gender, Department, Position, Salary) VALUES 
		            ('John', 'Doe', 30, 'Male', 'IT', 'Software Engineer', 60000.00),
		            ('Jane', 'Smith', 35, 'Female', 'HR', 'HR Manager', 70000.00),
		            ('Alice', 'Johnson', 40, 'Female', 'Finance', 'Accountant', 55000.00),
		            ('Bob', 'Jones', 45, 'Male', 'Marketing', 'Marketing Manager', 75000.00),
		            ('Emily', 'Brown', 28, 'Female', 'Sales', 'Sales Representative', 50000.00);

				SELECT FirstName, LastName, Position, Salary FROM Employees ORDER BY Salary DESC LIMIT 3;
            END;";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // A stored procedure can be created by executing it like any other SQL command.
            MySqlCommand cmd = new MySqlCommand(procedureCode, connection);
            cmd.ExecuteNonQuery();

            // Write code below this line
            
            // Write code above this line
        }
    }
}