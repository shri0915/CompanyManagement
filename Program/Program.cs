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
            int employeeID = 0;
            int technologyID = 0;
            int projectID = 0;

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
            Console.WriteLine("The employees in the project: ");
            foreach (var employeeForProject in dataLayer.GetAllEmployeesForProject(2))
            {                
                Console.WriteLine(employeeForProject.EmployeeID + " " + employeeForProject.EmployeeName);
            }

            Console.WriteLine("************************************************");
            Console.WriteLine("The technology for the employee are: ");
            foreach (var taskTechnology in dataLayer.GetAllTechnologyTasksForEmployee(2, 2))
            {
                Console.WriteLine(taskTechnology.TaskTechnologyID);
            }
            Console.WriteLine("************************************************");
            //List all delayed Projects
            Console.WriteLine("The delayed projects are : ");
            foreach (var delayedProjects in dataLayer.GetAllDelayedProjects())
            {                
                Console.WriteLine(delayedProjects.ProjectName);
            }
            Console.WriteLine("************************************************");

            //List all projects for an employee
            Console.WriteLine("To know all the projects assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(var employeeProject in dataLayer.GetAllProjectsForEmployee(employeeID))
            {
                Console.WriteLine(employeeProject.ProjectName);
            }
            Console.WriteLine("************************************************");

            //List all tasks for an employee
            Console.WriteLine("To know all the tasks assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(var employeeTask in dataLayer.GetAllTasksForEmployee(employeeID))
            {
                Console.WriteLine(employeeTask.TaskName);
            }

            //List all tasks for an employee of a particular technology
            Console.WriteLine("To know all the tasks using a particular technology assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To know all the tasks using a particular technology assigned to an employee please input the Technology ID");
            technologyID = Convert.ToInt32(Console.ReadLine());
            foreach(var taskTechnology in dataLayer.GetAllTechnologyTasksForEmployee(technologyID,employeeID))
            {
                Console.WriteLine(taskTechnology.Task.TaskName);
            }

            //List all the projects using a certain technology
            Console.WriteLine("Please input the technology ID for which you want to list the projects");
            technologyID = Convert.ToInt32(Console.ReadLine());
            foreach(var projectTechnology in dataLayer.GetAllTechnologyProjects(technologyID))
            {
                Console.WriteLine(projectTechnology.Project.ProjectName);
            }

            //List all the active tasks for a project
            Console.WriteLine("Please input the project for which you want to know all the active tasks");
            projectID = Convert.ToInt32(Console.ReadLine());
            foreach(var projectTask in dataLayer.GetAllActiveTasksForProject(projectID))
            {
                 Console.WriteLine(projectTask.Task.TaskName);
            }

            //List all the technologies an employee is working on
            Console.WriteLine("Please input the employee ID for whom you want to list the technologies");
            technologyID = Convert.ToInt32(Console.ReadLine());
            List<String> technologyNames = new List<string>();
            foreach (var taskTechnology in dataLayer.GetAllTechnologiesForEmployee(employeeID))
            {
                technologyNames.Add(taskTechnology.Technology.TechnologyName);
            }
            List<String> distinctTechnologyNames = new List<string>();
            distinctTechnologyNames = technologyNames.Distinct().ToList();
            foreach(var distinctTechnologyName in distinctTechnologyNames)
            {
                Console.WriteLine(distinctTechnologyName);
            }
            

            //List the number of projects an employee is working on
            Console.WriteLine("Please input the employee ID for whom you want to list the projects");
            employeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(dataLayer.GetProjectCountForEmployee(employeeID));

            //List all active projects managed by an employee
            Console.WriteLine("Please input the employee ID to know all the projects managed by that employee");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(var activeProjectManagedByEmployee in dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID))
            {
                Console.WriteLine(activeProjectManagedByEmployee.Project.ProjectName);
            }




           //Adding new Project
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
