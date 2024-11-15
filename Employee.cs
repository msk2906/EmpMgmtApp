namespace EmpMgmtApp
{
    public class Employee
    {
        //private static int idCounter = 1;  // Static field to track last used ID
        /*public Employee()
        {
            EmpId = idCounter++;
        }*/
        public int EmpId { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string DeptName { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Salary: {Salary}, Dept: {DeptName}";
        }
    }

}
