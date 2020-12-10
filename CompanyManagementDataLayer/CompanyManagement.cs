using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    public class CompanyManagement
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public List<Project> GetAllProjects()
        {

            List<Project> listOfProjects = (from Project in dc.Projects select Project).ToList();
            return listOfProjects;
        }
        public List<Technology> GetAllTechnologies()
        {
            List<Technology> listOfTechnologies = (from Technology in dc.Technologies select Technology).ToList();
            return listOfTechnologies;
        }

        public int GetEmployeeCountForProject(int projectID)
        {
            int countOfEmployeesOfProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).Count();
            return countOfEmployeesOfProject;
        }

        public List<Employee> GetAllEmployeesForProject(int projectID)
        {
            List<Employee> listOfEmployeeFromProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject.Employee).ToList();
            return listOfEmployeeFromProject;
        }

        public List<Project> GetAllDelayedProjects()
        {
            List<Project> ListOfDelayedProjects = (from Project in dc.Projects where Project.ProjectStatus == 4 select Project).ToList();
            return ListOfDelayedProjects;
        }

        public List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            List<Project> ListOfProjectForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.Project).ToList();
            return ListOfProjectForEmployee;
        }

        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            List<Task> ListOfTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask.Task).ToList();
            return ListOfTasksForEmployee;
        }
    }
}
