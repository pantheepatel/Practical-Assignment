namespace LINQ
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal IncrementPotential { get; set; } // Potential salary increment
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Generate Employee List
            List<Employee> employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, Name = "Aarav Sharma", Department = "IT", Salary = 90000, JoiningDate = new DateTime(2015, 5, 23), IncrementPotential = 20000 },
                new Employee { EmployeeId = 2, Name = "Neha Verma", Department = "HR", Salary = 65000, JoiningDate = new DateTime(2017, 3, 18), IncrementPotential = 15000 },
                new Employee { EmployeeId = 3, Name = "Rohan Iyer", Department = "Finance", Salary = 72000, JoiningDate = new DateTime(2018, 7, 12), IncrementPotential = 18000 },
                new Employee { EmployeeId = 4, Name = "Priya Menon", Department = "IT", Salary = 88000, JoiningDate = new DateTime(2016, 8, 30), IncrementPotential = 25000 },
                new Employee { EmployeeId = 5, Name = "Kabir Malhotra", Department = "Sales", Salary = 56000, JoiningDate = new DateTime(2020, 1, 22), IncrementPotential = 12000 },
                new Employee { EmployeeId = 6, Name = "Ananya Reddy", Department = "Marketing", Salary = 74000, JoiningDate = new DateTime(2014, 2, 15), IncrementPotential = 22000 },
                new Employee { EmployeeId = 7, Name = "Vikram Joshi", Department = "HR", Salary = 68000, JoiningDate = new DateTime(2013, 6, 9), IncrementPotential = 17000 },
                new Employee { EmployeeId = 8, Name = "Ishita Rao", Department = "IT", Salary = 95000, JoiningDate = new DateTime(2021, 11, 5), IncrementPotential = 30000 },
                new Employee { EmployeeId = 9, Name = "Arjun Singh", Department = "Sales", Salary = 59000, JoiningDate = new DateTime(2019, 4, 8), IncrementPotential = 14000 },
                new Employee { EmployeeId = 10, Name = "Tanvi Desai", Department = "Finance", Salary = 81000, JoiningDate = new DateTime(2012, 12, 3), IncrementPotential = 26000 },
                new Employee { EmployeeId = 11, Name = "Manav Kapoor", Department = "Marketing", Salary = 71000, JoiningDate = new DateTime(2016, 9, 12), IncrementPotential = 19000 },
                new Employee { EmployeeId = 12, Name = "Divya Nair", Department = "HR", Salary = 70000, JoiningDate = new DateTime(2018, 10, 25), IncrementPotential = 16000 },
                new Employee { EmployeeId = 13, Name = "Amit Patil", Department = "Finance", Salary = 89000, JoiningDate = new DateTime(2015, 5, 19), IncrementPotential = 23000 },
                new Employee { EmployeeId = 14, Name = "Sneha Mehta", Department = "IT", Salary = 93000, JoiningDate = new DateTime(2022, 2, 14), IncrementPotential = 27000 },
                new Employee { EmployeeId = 15, Name = "Rajat Kumar", Department = "Sales", Salary = 64000, JoiningDate = new DateTime(2020, 7, 7), IncrementPotential = 13000 },
            };

            //1. Find the Highest Salary in Each Department.
            var Query1 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, HighestSalary = g.Max(e => e.Salary) });
            foreach (var item in Query1)
            {
                Console.WriteLine($"Department: {item.Department}, Highest Salary: {item.HighestSalary}");
            }

            //2.Find the Employee with the Highest Salary in Each Department
            var Query2 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, Employee = g.OrderByDescending(e => e.Salary).First() });
            foreach (var item in Query2)
            {
                Console.WriteLine($"Department: {item.Department}, Employee: {item.Employee.Name}, Salary: {item.Employee.Salary}");
            }

            //3.Find the Department with the Highest Average Salary
            var Query3 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, AverageSalary = g.Average(e => e.Salary) }).OrderByDescending(e => e.AverageSalary).First();
            Console.WriteLine($"Department: {Query3.Department}, Average Salary: {Query3.AverageSalary}");

            //4.Find the Employee Who Has Worked for the Longest Time
            var Query4 = employees.OrderByDescending(e => DateTime.Now - e.JoiningDate).First();
            Console.WriteLine($"Employee: {Query4.Name}, Joining Date: {Query4.JoiningDate}");

            //5.Find the Employee with the Maximum Salary Increment Potential
            var Query5 = employees.OrderByDescending(e => e.IncrementPotential).First();
            Console.WriteLine($"Employee: {Query5.Name}, Increment Potential: {Query5.IncrementPotential}");

            //6.Find the Department with the Highest Number of Employees
            var Query6 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, EmployeeCount = g.Count() }).OrderByDescending(e => e.EmployeeCount).First();
            Console.WriteLine($"Department: {Query6.Department}, Employee Count: {Query6.EmployeeCount}");

            //7.Find the Most Recent Joining Employee
            var Query7 = employees.OrderByDescending(e => e.JoiningDate).First();
            Console.WriteLine($"Employee: {Query7.Name}, Joining Date: {Query7.JoiningDate}");

            //8.Find the Highest Total Salary in a Department
            var Query8 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, TotalSalary = g.Sum(e => e.Salary) }).OrderByDescending(e => e.TotalSalary).First();
            Console.WriteLine($"Department: {Query8.Department}, Total Salary: {Query8.TotalSalary}");

            //9.Find the Employee with the Maximum Name Length
            var Query9 = employees.OrderByDescending(e => e.Name.Length).First();
            Console.WriteLine($"Employee: {Query9.Name}, Name Length: {Query9.Name.Length}");

            //10.Find the Department with the Maximum Combined Experience
            var Query10 = employees.GroupBy(e => e.Department).Select(g => new { Department = g.Key, CombinedExperience = g.Sum(e => (DateTime.Now - e.JoiningDate).Days) }).OrderByDescending(e => e.CombinedExperience).First();
            Console.WriteLine($"Department: {Query10.Department}, Combined Experience: {Query10.CombinedExperience}");

        }
    }
}