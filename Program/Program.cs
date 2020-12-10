using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyManagement c1 = new CompanyManagement();

            //List all the Projects
            foreach (var project in c1.GetAllProjects())
            {
                Console.WriteLine(project.ProjectID + " " + project.ProjectName + " is assigned to Department : " + project.Department.DepartmentName);
            }

            //List all the Technologies
            foreach (var technology in c1.GetAllTechnologies())
            {
                Console.WriteLine(technology.TechnologyID + " " + technology.TechnologyName);
            }

            //Print the count of Employees in Project
            Console.WriteLine(c1.GetEmployeeCountForProject(2));

            //List all the Employees in the Project
            foreach (var employeeForProject in c1.GetAllEmployeesForProject(2))
            {
                Console.WriteLine(employeeForProject.EmployeeID + " " + employeeForProject.EmployeeName);
            }


            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
