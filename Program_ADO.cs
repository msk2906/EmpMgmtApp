using System;

namespace EmpMgmtApp
{
    class ProgramADO
    {
        static void Main(string[] args)
        {
            EmpManagement manager = new EmpManagement();

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
                try
                {
                    switch (choice)
                    {
                        case "1":
                            var employee = GetEmployeeDetails();
                            manager.AddEmployee(employee);
                            Console.WriteLine("\nEmployee Added Successfully \nPress Enter");
                            break;
                        case "2":
                            UpdateEmployee(manager);
                            break;
                        case "3":
                            DeleteEmployee(manager);
                            break;
                        case "4":
                            manager.ViewEmployees();
                            Console.WriteLine("\nPress Enter");
                            break;
                        case "5":
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option, please Enter Valid Option.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press Enter to Try Again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }
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

        static void DeleteEmployee(EmpManagement manager)
        {
            Console.Write("Enter the EmpId of the employee to delete: ");
            int empId = int.Parse(Console.ReadLine());
            bool empid_check = new EmpManagement().EmployeeExists(empId);

            if (empid_check)
            {
                manager.DeleteEmployee(empId);
                Console.WriteLine("\nEmployee Deleted Successfully \nPress Enter");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Employee with EmpID : {empId} does not exists");
                Console.WriteLine("Press Enter to Try Again");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void UpdateEmployee(EmpManagement manager)
        {
            Console.Write("Enter the EmpId of the employee to update: ");
            int empId = int.Parse(Console.ReadLine());
            bool empid_check = new EmpManagement().EmployeeExists(empId);

            if (empid_check)
            {
                Console.Write("Enter new Name : ");
                string newname = Console.ReadLine();
                string newName = string.IsNullOrEmpty(newname) ? null : newname;

                Console.Write("Enter new Age : ");
                string newAgeInput = Console.ReadLine();
                int? newAge = string.IsNullOrEmpty(newAgeInput) ? (int?)null : int.Parse(newAgeInput);

                Console.Write("Enter new Salary : ");
                string newSalaryInput = Console.ReadLine();
                decimal? newSalary = string.IsNullOrEmpty(newSalaryInput) ? (decimal?)null : decimal.Parse(newSalaryInput);

                Console.Write("Enter new Department : ");
                string newdept = Console.ReadLine();
                string newDept = string.IsNullOrEmpty(newdept) ? null : newdept;

                manager.UpdateEmployee(empId, newName, newAge, newSalary, newDept);
                Console.WriteLine("\nEmployee Updated Successfully \nPress Enter");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Employee with EmpID : {empId} does not exists");
                Console.WriteLine("Press Enter to Try Again");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
