using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementBL;
using CompanyManagementDataLayer;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataLayer dataLayer = new DataLayer();

            //List all the Projects
            Console.WriteLine("Here are all the projects in the database");
            foreach (var project in dataLayer.GetAllProjects())
            {
                
                Console.WriteLine(project.ProjectID + " " + project.ProjectName);
                
            }
            Console.WriteLine("************************************************");

            //List all the Technologies
            Console.WriteLine("Here are all the technologies in the database");
            foreach (var technology in dataLayer.GetAllTechnologies())
            {
                
                Console.WriteLine(technology.TechnologyID + " " + technology.TechnologyName);
                
            }
            Console.WriteLine("************************************************");

            //Print the count of Employees in Project
            Console.WriteLine("The number of employees in the project: ");
            Console.WriteLine(dataLayer.GetEmployeeCountForProject(2));
            Console.WriteLine("************************************************");

            //List all the Employees in the Project
            foreach (var employeeForProject in dataLayer.GetAllEmployeesForProject(2))
            {
                Console.WriteLine("The employees in the project: ");
                Console.WriteLine(employeeForProject.EmployeeID + " " + employeeForProject.EmployeeName);
            }

            Console.WriteLine("************************************************");
            Console.WriteLine("The technology for the employee are: ");
            foreach (var taskTechnology in dataLayer.GetAllTechnologyTasksForEmployee(2, 2))
            {
                Console.WriteLine(taskTechnology.TaskTechnologyID);
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
            dataLayer.AddProject(project1);
            
            Console.WriteLine("Please enter the Employee ID to be deleted");
            dataLayer.DeleteEmployeeFromSystem(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
