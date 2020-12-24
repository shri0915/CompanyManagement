using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    class DataValidationHelper
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public String CheckCumpulsoryFieldsOfProject(Project project)
        {

            if (project.ProjectID.Equals(null))
            {
                return Resource1.ProjectIDMissing;
            }
            else if (project.ProjectID <= 0)
            {
                return Resource1.ProjectIDNegativeOrZero;
            }
            else if (string.IsNullOrEmpty(project.ProjectName))
            {
                return Resource1.ProjectNameMissing;
            }
            else if (project.ClientID.Equals(null))
            {
                return Resource1.ClientIDForProjectMissing;
            }
            else if (project.DepartmentID.Equals(null))
            {
                return Resource1.DepartmentIDForProjectMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfTask(Task task)
        {
            if (task.TaskID == 0)
            {
                return Resource1.TaskIDMissing;
            }
            else if (string.IsNullOrEmpty(task.TaskName))
            {
                return Resource1.TaskNameMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfTechnology(Technology technology)
        {
            if (technology.TechnologyID.Equals(null) || technology.TechnologyID <= 0)
            {
                return Resource1.TechnologyIDMissing;
            
            }

            else if (string.IsNullOrEmpty(technology.TechnologyName))
            {
                return Resource1.TechnologyNameMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfEmployee(Employee employee)
        {
            if (employee.DepartmentID.Equals(null) || employee.DepartmentID <= 0)
            {
                return Resource1.DepartmentIDMissing;
            }
            else if (employee.EmployeeID.Equals(null) || employee.EmployeeID <= 0)
            {
                return Resource1.EmployeeIDMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                return Resource1.EmployeeNameMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeDesignation))
            {
                return Resource1.EmployeeDesignationMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeAddress))
            {
                return Resource1.EmployeeAddressMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfProjectTask(ProjectTask projectTask)
        {
            if (projectTask.ProjectTaskStatus.Equals(null) || projectTask.ProjectTaskStatus <= 0)
            {
                return Resource1.StatusMissing;
            }
            else if (projectTask.TaskID.Equals(null) || projectTask.TaskID <= 0)
            {
                return Resource1.TaskIDMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfEmployeeProject(EmployeeProject employeeProject)
        {

            if (employeeProject.EmployeeID.Equals(null) || employeeProject.EmployeeID <= 0)
            {
                return Resource1.EmployeeIDMissing;
            }
            else if (employeeProject.ProjectID.Equals(null) || employeeProject.ProjectID <= 0)
            {
                return Resource1.ProjectIDMissing;
            }
            else if (employeeProject.EmployeeRoleID.Equals(null) || employeeProject.EmployeeRoleID <= 0)
            {
                return Resource1.EmployeeRoleIDMIssing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfTaskTechnology(TaskTechnology taskTechnology)
        {

            if (taskTechnology.TaskID <= 0 || taskTechnology.TaskID.Equals(null))
            {
                return Resource1.TaskIDMissing;
            }
            else if (taskTechnology.TechnologyID <= 0 || taskTechnology.TechnologyID.Equals(null))
            {
                return Resource1.TaskIDMissing;
            }
            else
            {
                return Resource1.AllColumnsPresent;
            }
        }

        public  bool IfProjectExists(int projectID)
        {
            List<Project> listOfProjects = new List<Project>();
            listOfProjects = (from Project in dc.Projects select Project).ToList();
            bool projectExists;
            projectExists = false;
            foreach (Project project in listOfProjects)
            {
                if(project.ProjectID == projectID)
                {
                    projectExists = true;
                    break;
                }
            }

            return projectExists;
        }

        public  bool IfEmployeeExists(int employeeID)
        {
            List<Employee> listOfEmployee = new List<Employee>();
            listOfEmployee = (from Employee in dc.Employees select Employee).ToList();
            bool employeeExists;
            employeeExists = false;
            foreach (Employee employee in listOfEmployee)
            {
                if (employee.EmployeeID == employeeID)
                {
                    employeeExists = true;
                    break;
                }
            }

            return employeeExists;
        }

        public bool IfTaskExists(int taskID)
        {
            List<Task> listOfTasks = new List<Task>();
            listOfTasks = (from Task in dc.Tasks select Task).ToList();
            bool taskExists;
            taskExists = false;
            foreach (Task task in listOfTasks)
            {
                if (task.TaskID == taskID)
                {
                    taskExists = true;
                    break;
                }
            }

            return taskExists;
        }
        public bool IfTechnologyExists(int technologyID)
        {
            List<Technology> listOfTechnologies = new List<Technology>();
            listOfTechnologies = (from Technology in dc.Technologies select Technology).ToList();
            bool technologyExists;
            technologyExists = false;

            foreach(Technology technology in listOfTechnologies)
            {
                if (technology.TechnologyID == technologyID)
                {
                    technologyExists = true;
                    break;
                }
            }
            return technologyExists;
        }

        public bool IfTechnologyIsAssignedToTask(int technologyID, int taskID)
        {
            List<TaskTechnology> listOfTaskTechnology = new List<TaskTechnology>();
            listOfTaskTechnology = (from TaskTechnology in dc.TaskTechnologies select TaskTechnology).ToList();
            bool technologyAssignedToTask;
            technologyAssignedToTask = false;

            foreach(TaskTechnology taskTechnology in listOfTaskTechnology)
            {
                if(taskTechnology.TaskID == taskID && taskTechnology.TechnologyID == technologyID)
                {
                    technologyAssignedToTask = true;
                    break;
                }
            }

            return technologyAssignedToTask;
        }
    }
}
