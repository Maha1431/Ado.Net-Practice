using System;

namespace ADO.NET_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Employee_repos repos = new Employee_repos();
            Employee_Model Model = new Employee_Model();
            Model.name = "Appu";
            Model.salary = 40000;
            Model.start_date = "2021-08-15";
           // repos.GetAllEmployee();
            repos.AddEmployee(Model);
        }
    }
}
