using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtApp
{   class Program
    {
        static void Main(string[] args)
        {
            EmpMgmt manager = new EmpMgmt();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Employee Management ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var employee = GetEmployeeDetails();
                        manager.AddEmployee(employee);
                        break;
                    case "2":
                        UpdateEmployee(manager);
                        break;
                    case "3":
                        DeleteEmployee(manager);
                        break;
                    case "4":
                        manager.ViewEmployees();
                        break;
                    case "5":
                        manager.SaveEmployees();
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.ReadLine();

            }
        }

        static Employee GetEmployeeDetails()
        {
            Employee employee = new Employee();

            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            employee.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Salary: ");
            employee.Salary = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Department: ");
            employee.DeptName = Console.ReadLine();

            return employee;
        }

        static void DeleteEmployee(EmpMgmt manager)
        {
            Console.Write("Enter the EmpId of the employee to delete: ");
            int empId = int.Parse(Console.ReadLine());

            manager.DeleteEmployee(empId);
        }

        static void UpdateEmployee(EmpMgmt manager)
        {
            Console.Write("Enter the EmpId of the employee to update: ");
            int empId = int.Parse(Console.ReadLine());

            Console.Write("Enter new Name (leave blank to keep unchanged): ");
            string newName = Console.ReadLine();

            Console.Write("Enter new Age (leave blank to keep unchanged): ");
            string newAgeInput = Console.ReadLine();
            int? newAge = string.IsNullOrEmpty(newAgeInput) ? (int?)null : int.Parse(newAgeInput);

            Console.Write("Enter new Salary (leave blank to keep unchanged): ");
            string newSalaryInput = Console.ReadLine();
            decimal? newSalary = string.IsNullOrEmpty(newSalaryInput) ? (decimal?)null : decimal.Parse(newSalaryInput);

            Console.Write("Enter new Department (leave blank to keep unchanged): ");
            string newDept = Console.ReadLine();

            manager.UpdateEmployee(empId, newName, newAge, newSalary, newDept);
        }
    }

}
