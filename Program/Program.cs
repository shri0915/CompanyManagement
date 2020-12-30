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
            int taskID = 0;
            
            
            //List all the Projects
            Console.WriteLine("Here are all the projects in the database");
            foreach (Project returnedProject in dataLayer.GetAllProjects())
            {
                
                Console.WriteLine(returnedProject.ProjectID + " " + returnedProject.ProjectName);
                
            }
            Console.WriteLine("************************************************");

            //List all the Technologies
            Console.WriteLine("Here are all the technologies in the database");
            foreach (Technology returnedTechnology in dataLayer.GetAllTechnologies())
            {
                
                Console.WriteLine(returnedTechnology.TechnologyID + " " + returnedTechnology.TechnologyName);
                
            }
            Console.WriteLine("************************************************");

            //Print the count of Employees in Project
            Console.WriteLine("The number of employees in the project: ");
            Console.WriteLine(dataLayer.GetEmployeeCountForProject(2));
            Console.WriteLine("************************************************");

            //List all the Employees in the Project
            Console.WriteLine("The employees in the project: ");
            foreach (Employee employeeForProject in dataLayer.GetAllEmployeesForProject(2))
            {                
                Console.WriteLine(employeeForProject.EmployeeID + " " + employeeForProject.EmployeeName);
            }

            Console.WriteLine("************************************************");
            Console.WriteLine("The technology for the employee are: ");
            foreach (TaskTechnology taskTechnology in dataLayer.GetAllTechnologyTasksForEmployee(2, 2))
            {
                Console.WriteLine(taskTechnology.TaskTechnologyID);
            }
            Console.WriteLine("************************************************");
            //List all delayed Projects
            Console.WriteLine("The delayed projects are : ");
            foreach (Project delayedProjects in dataLayer.GetAllDelayedProjects())
            {                
                Console.WriteLine(delayedProjects.ProjectName);
            }
            Console.WriteLine("************************************************");

            //List all projects for an employee
            Console.WriteLine("To know all the projects assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(Project employeeProject in dataLayer.GetAllProjectsForEmployee(employeeID))
            {
                Console.WriteLine(employeeProject.ProjectName);
            }
            Console.WriteLine("************************************************");

            //List all tasks for an employee
            Console.WriteLine("To know all the tasks assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(CompanyManagementDataLayer.Task employeeTask in dataLayer.GetAllTasksForEmployee(employeeID))
            {
                Console.WriteLine(employeeTask.TaskName);
            }

            //List all tasks for an employee of a particular technology
            Console.WriteLine("To know all the tasks using a particular technology assigned to an employee please input the employee's Employee ID");
            employeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("To know all the tasks using a particular technology assigned to an employee please input the Technology ID");
            technologyID = Convert.ToInt32(Console.ReadLine());
            foreach(TaskTechnology taskTechnology in dataLayer.GetAllTechnologyTasksForEmployee(technologyID,employeeID))
            {
                Console.WriteLine(taskTechnology.Task.TaskName);
            }

            //List all the projects using a certain technology
            Console.WriteLine("Please input the technology ID for which you want to list the projects");
            technologyID = Convert.ToInt32(Console.ReadLine());
            foreach(ProjectTechnology projectTechnology in dataLayer.GetAllTechnologyProjects(technologyID))
            {
                Console.WriteLine(projectTechnology.Project.ProjectName);
            }

            //List all the active tasks for a project
            Console.WriteLine("Please input the project for which you want to know all the active tasks");
            projectID = Convert.ToInt32(Console.ReadLine());
            foreach(ProjectTask projectTask in dataLayer.GetAllActiveTasksForProject(projectID))
            {
                 Console.WriteLine(projectTask.Task.TaskName);
            }

            //List all the technologies an employee is working on
            Console.WriteLine("Please input the employee ID for whom you want to list the technologies");
            technologyID = Convert.ToInt32(Console.ReadLine());
            List<String> technologyNames = new List<string>();
            foreach (TaskTechnology taskTechnology in dataLayer.GetAllTechnologiesForEmployee(employeeID))
            {
                technologyNames.Add(taskTechnology.Technology.TechnologyName);
            }
            List<String> distinctTechnologyNames = new List<string>();
            distinctTechnologyNames = technologyNames.Distinct().ToList();
            foreach(string distinctTechnologyName in distinctTechnologyNames)
            {
                Console.WriteLine(distinctTechnologyName);
            }
            

            //List the number of projects an employee is working on
            Console.WriteLine("Please input the employee ID for whom you want to list the number of projects");
            employeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(dataLayer.GetProjectCountForEmployee(employeeID));

            //List all active projects managed by an employee
            Console.WriteLine("Please input the employee ID to know all the projects managed by that employee");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(EmployeeProject activeProjectManagedByEmployee in dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID))
            {
                Console.WriteLine(activeProjectManagedByEmployee.Project.ProjectName);
            }

            //List all delayed tasks for an employee
            Console.WriteLine("Please input the employee id of whom you want to display the delayed tasks");
            employeeID = Convert.ToInt32(Console.ReadLine());
            foreach(EmployeeTask employeeTask in dataLayer.GetAllDelayedTasksForEmployee(employeeID))
            {
                Console.WriteLine(employeeTask.Task.TaskName);
            }

            //


           //Adding new Project
           Project project = new Project();
           Console.WriteLine("Please enter the Project Name");
           project.ProjectName = Console.ReadLine();
           project.ProjectStatus = 1;
           Console.WriteLine("Please enter the Client ID for the Project");
           project.ClientID = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Please enter the Department ID for the Project");
           project.DepartmentID = Convert.ToInt32(Console.ReadLine());
           dataLayer.AddProject(project);

            //Add new Technology
            Technology technology = new Technology();
            Console.WriteLine("Please input the Technology Name");
            technology.TechnologyName = Console.ReadLine();
            dataLayer.AddTechnology(technology);


            //Add new Employee
            Employee employee = new Employee();
            Console.WriteLine("Please enter the Employee Name");
            employee.EmployeeName = Console.ReadLine();
            Console.WriteLine("Please enter the Employee Address");
            employee.EmployeeAddress = Console.ReadLine();
            Console.WriteLine("Please enter the Employee Designation");
            employee.EmployeeDesignation = Console.ReadLine();
            Console.WriteLine("Please enter the Employee Contact");
            employee.EmployeeContact = Console.ReadLine();
            Console.WriteLine("Please enter the Department ID to which the employee belongs");
            employee.DepartmentID = Convert.ToInt32(Console.ReadLine());
            dataLayer.AddEmployee(employee);
            
            //Assign Employee to Project
            Console.WriteLine("Please enter the Employee ID whom you want to assign to the project");
            employeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Project ID to which you want to add the employee");
            projectID = Convert.ToInt32(Console.ReadLine());
            dataLayer.AssignEmployeeToProject(employeeID, projectID);
            
            //Assign Technology To Task
            Console.WriteLine("Please enter the Technology ID you want to assign to the task");
            technologyID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Task ID for which you want to assign the technology");
            taskID = Convert.ToInt32(Console.ReadLine());
            dataLayer.AssignTechnologyToTask(technologyID, taskID);

            //Create Task In Project
            Console.WriteLine("Creating a new task");
            CompanyManagementDataLayer.Task task = new CompanyManagementDataLayer.Task();
            Console.WriteLine("Please enter the Task Name");
            task.TaskName = Console.ReadLine();
            Console.WriteLine("Please enter the Task Description");
            task.TaskDescription = Console.ReadLine();
            Console.WriteLine("Please enter the Project ID to which you want to add this Task");
            projectID = Convert.ToInt32(Console.ReadLine());
            dataLayer.CreateTaskInProject(task, projectID);

            //Update Technologies For Task
            List<int> technologIDs = new List<int>();
            int count = 0;
            Console.WriteLine("Please enter the number of (count) technology IDs to be updated");
            count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Please enter the Technology ID number " + (i+1) + " : ");
                technologIDs.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Please enter the Task ID to which you want to assign the above Technologies");
            taskID = Convert.ToInt32(Console.ReadLine());
            dataLayer.UpdateTechnologiesForTask(technologIDs, taskID);

            //Delete Technology
            Console.WriteLine("Please enter the Technology ID you want to delete");
            dataLayer.DeleteTechnology(Convert.ToInt32(Console.ReadLine()));

            //Delete Task
            Console.WriteLine("Please enter the Task ID you want to delete");
            dataLayer.DeleteTask(Convert.ToInt32(Console.ReadLine()));

            //Delete Project
            Console.WriteLine("Please enter the Project ID you want to delete");
            dataLayer.DeleteProject(Convert.ToInt32(Console.ReadLine()));

            //Delete Employee from system
            Console.WriteLine("Please enter the Employee ID to be deleted");
            dataLayer.DeleteEmployeeFromSystem(Convert.ToInt32(Console.ReadLine()));
            
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
