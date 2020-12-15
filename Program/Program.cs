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

            foreach (var taskTechnology in c1.GetAllTechnologyTasksForEmployee(2, 2))
            {
                Console.WriteLine(taskTechnology.TaskTechnologyID + " " + taskTechnology.Technology.TechnologyName);
            }
            Project project1 = new Project();
            Console.WriteLine("Please enter the Project ID");
            project1.ProjectID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Project Name");
            project1.ProjectName = Console.ReadLine();
            project1.ProjectStatus = 1;
            Console.WriteLine("Please enter the Client ID for the Project");
            project1.ClientID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Department ID for the Project");
            project1.DepartmentID = Convert.ToInt32(Console.ReadLine());
            c1.AddProject(project1);

            Console.WriteLine("Please enter the Employee ID to be deleted");
            c1.DeleteEmployeeFromSystem(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
