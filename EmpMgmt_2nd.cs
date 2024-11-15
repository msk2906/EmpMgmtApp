using EmpMgmtApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class EmpMgmt
{
    private List<Employee> employees = new List<Employee>();
    private const string fileName = "employees.json";


    public EmpMgmt()
    {
        // Load employee data from the file on startup
        LoadEmployees();
    }

    private void LoadEmployees()
    {
        if (File.Exists(fileName))
        {
            try
            {
                var jsonData = File.ReadAllText(fileName);
                employees = JsonSerializer.Deserialize<List<Employee>>(jsonData) ?? new List<Employee>();
                Console.WriteLine("Employee data loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading employee data: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No saved employee data found.");
        }
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        Console.WriteLine("Employee added successfully.");
    }

    public void UpdateEmployee(int empId, string newName, int? newAge, decimal? newSalary, string newDept)
    {
        Employee employee = employees.Find(e => e.EmpId == empId);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        if (!string.IsNullOrEmpty(newName))
            employee.Name = newName;

        if (newAge.HasValue)
            employee.Age = newAge.Value;

        if (newSalary.HasValue)
            employee.Salary = newSalary.Value;

        if (!string.IsNullOrEmpty(newDept))
            employee.DeptName = newDept;

        Console.WriteLine("Employee updated successfully.");
    }

    public void SaveEmployees()
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(employees);
            File.WriteAllText(fileName, jsonData);
            Console.WriteLine("Employee data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving employee data: {ex.Message}");
        }
    }


    public void DeleteEmployee(int empId)
    {
        Employee employee = employees.Find(e => e.EmpId == empId);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        employees.Remove(employee);
        Console.WriteLine($"Employee with ID {empId} deleted successfully.");
    }

    public void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        Console.WriteLine("\n--- Employee List ---");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
