using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmpMgmtApp
{
    public class EmpManagement
    {
        private readonly string _connectionString = "data source=.; database=Sql_Learnings; integrated security=SSPI";

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Employees (Name, Age, Salary, DeptName) VALUES (@Name, @Age, @Salary, @DeptName)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Age", employee.Age);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@DeptName", employee.DeptName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateEmployee(int empId, string newName, int? newAge, decimal? newSalary, string newDept)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();
                string query = "UPDATE Employees SET Name = ISNULL(@Name, Name), Age = ISNULL(@Age, Age), Salary = ISNULL(@Salary, Salary)," +
                    " DeptName = ISNULL(@DeptName, DeptName) WHERE EmpId = @EmpId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@Name", (object)newName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Age", (object)newAge ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", (object)newSalary ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DeptName", (object)newDept ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int empId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Employees WHERE EmpId = @EmpId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ViewEmployees()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT EmpId, Name, Age, Salary, DeptName FROM Employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("\n--- Employee List ---");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmpId"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Salary: {reader["Salary"]}, Dept: {reader["DeptName"]}");
                }
            }
        }
        public bool EmployeeExists(int empId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Employees WHERE EmpId = @EmpId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    int count = (int)cmd.ExecuteScalar();

                    return count > 0; 
                }
            }
        }
    }
}