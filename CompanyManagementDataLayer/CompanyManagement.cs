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
            List<Project> listOfDelayedProjects = (from Project in dc.Projects where Project.ProjectStatus == 4 select Project).ToList();
            return listOfDelayedProjects;
        }

        public List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            List<Project> listOfProjectForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.Project).ToList();
            return listOfProjectForEmployee;
        }

        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            List<Task> listOfTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask.Task).ToList();
            return listOfTasksForEmployee;
        }

        public List<TaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            List<TaskTechnology> listOfTaskTechnologies = (from EmployeeTask in dc.EmployeeTasks join TaskTechnology in dc.TaskTechnologies on EmployeeTask.TaskID equals TaskTechnology.TaskID where TaskTechnology.TechnologyID == technologyID && EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
            return listOfTaskTechnologies;
        }

        public List<ProjectTechnology> GetAllTechnologyProjects(int technologyID)
        {
            List<ProjectTechnology> listOfProjectTechnologies = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technologyID select ProjectTechnology).ToList();
            return listOfProjectTechnologies;
        }

        public List<ProjectTask> GetAllActiveTasksForProject(int projectID)
        {
            List<ProjectTask> listOfActiveTasksForProject = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID && ProjectTask.ProjectTaskStatus == 1 select ProjectTask).ToList();
            return listOfActiveTasksForProject;
        }

        public List<TaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            List<TaskTechnology> listOfTechnologiesForEmployee = (from TaskTechnology in dc.TaskTechnologies join EmployeeTask in dc.EmployeeTasks on TaskTechnology.TaskID equals EmployeeTask.TaskID where EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
            return listOfTechnologiesForEmployee;
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            int projectCountForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.ProjectID).Count();
            return projectCountForEmployee;
        }

        public List<EmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            List <EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == 1 select EmployeeProject).ToList();
            return listOfActiveProjectsManagedByEmployee;
        }

        public List<EmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            List<EmployeeTask> listOfAllDelayedTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID && EmployeeTask.EmployeeTaskStatus == 4 select EmployeeTask).ToList();
            return listOfAllDelayedTasksForEmployee;
        }


    }
}
