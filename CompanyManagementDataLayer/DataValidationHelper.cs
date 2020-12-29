using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    class DataValidationHelper
    {
        
        public String CheckCumpulsoryFieldsOfProject(Project project)
        {

            if (project.ProjectID.Equals(null))
            {
                return CompanyManagementResource.ProjectIDMissing;
            }
            else if (project.ProjectID <= 0)
            {
                return CompanyManagementResource.ProjectIDNegativeOrZero;
            }
            else if (string.IsNullOrEmpty(project.ProjectName))
            {
                return CompanyManagementResource.ProjectNameMissing;
            }
            else if (project.ClientID.Equals(null))
            {
                return CompanyManagementResource.ClientIDForProjectMissing;
            }
            else if (project.DepartmentID.Equals(null))
            {
                return CompanyManagementResource.DepartmentIDForProjectMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfTask(Task task)
        {
            if (task.TaskID == 0)
            {
                return CompanyManagementResource.TaskIDMissing;
            }
            else if (string.IsNullOrEmpty(task.TaskName))
            {
                return CompanyManagementResource.TaskNameMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfTechnology(Technology technology)
        {
            if (technology.TechnologyID.Equals(null) || technology.TechnologyID <= 0)
            {
                return CompanyManagementResource.TechnologyIDMissing;
            
            }

            else if (string.IsNullOrEmpty(technology.TechnologyName))
            {
                return CompanyManagementResource.TechnologyNameMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfEmployee(Employee employee)
        {
            if (employee.DepartmentID.Equals(null) || employee.DepartmentID <= 0)
            {
                return CompanyManagementResource.DepartmentIDMissing;
            }
            else if (employee.EmployeeID.Equals(null) || employee.EmployeeID <= 0)
            {
                return CompanyManagementResource.EmployeeIDMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                return CompanyManagementResource.EmployeeNameMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeDesignation))
            {
                return CompanyManagementResource.EmployeeDesignationMissing;
            }
            else if (string.IsNullOrEmpty(employee.EmployeeAddress))
            {
                return CompanyManagementResource.EmployeeAddressMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfProjectTask(ProjectTask projectTask)
        {
            if (projectTask.ProjectTaskStatus.Equals(null) || projectTask.ProjectTaskStatus <= 0)
            {
                return CompanyManagementResource.StatusMissing;
            }
            else if (projectTask.TaskID.Equals(null) || projectTask.TaskID <= 0)
            {
                return CompanyManagementResource.TaskIDMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }

        }

        public  string CheckCompulsoryFieldsOfEmployeeProject(EmployeeProject employeeProject)
        {

            if (employeeProject.EmployeeID.Equals(null) || employeeProject.EmployeeID <= 0)
            {
                return CompanyManagementResource.EmployeeIDMissing;
            }
            else if (employeeProject.ProjectID.Equals(null) || employeeProject.ProjectID <= 0)
            {
                return CompanyManagementResource.ProjectIDMissing;
            }
            else if (employeeProject.EmployeeRoleID.Equals(null) || employeeProject.EmployeeRoleID <= 0)
            {
                return CompanyManagementResource.EmployeeRoleIDMIssing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }
        }

        public  string CheckCompulsoryFieldsOfTaskTechnology(TaskTechnology taskTechnology)
        {

            if (taskTechnology.TaskID <= 0 || taskTechnology.TaskID.Equals(null))
            {
                return CompanyManagementResource.TaskIDMissing;
            }
            else if (taskTechnology.TechnologyID <= 0 || taskTechnology.TechnologyID.Equals(null))
            {
                return CompanyManagementResource.TaskIDMissing;
            }
            else
            {
                return CompanyManagementResource.AllColumnsPresent;
            }
        }

        public  bool IfProjectExists(int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool projectExists;
            projectExists = (from Project in dc.Projects where Project.ProjectID == projectID select Project).Any();
            return projectExists;
        }

        public  bool IfEmployeeExists(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool employeeExists;
            employeeExists = (from Employee in dc.Employees where Employee.EmployeeID == employeeID select Employee).Any();
            return employeeExists;
        }

        public bool IfTaskExists(int taskID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool taskExists;
            taskExists = (from Task in dc.Tasks where Task.TaskID == taskID select Task).Any();
            return taskExists;
        }
        public bool IfTechnologyExists(int technologyID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool technologyExists = (from Technology in dc.Technologies where Technology.TechnologyID == technologyID select Technology).Any();
            return technologyExists;
        }

        public bool IfTechnologyIsAssignedToTask(int technologyID, int taskID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool technologyAssignedToTask = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TechnologyID == technologyID &&
                                             TaskTechnology.TaskID == taskID select TaskTechnology).Any();
            return technologyAssignedToTask;
        }
        public bool IfEmployeeIsAssignedToProject(int employeeID, int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            bool employeeAssignedToProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID 
                                              && EmployeeProject.ProjectID == projectID select EmployeeProject).Any();
            return employeeAssignedToProject;
        }
    }
}
