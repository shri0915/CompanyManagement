using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;
using CompanyManagementBL.Entities;

namespace CompanyManagementBL
{
    public class DataConverter
    {
        public static List<BOProject> ConvertProjectListToBOProjectList(List<Project> Projects)
        {
            List<BOProject> businessProjects = new List<BOProject>();
            foreach (Project project in Projects)
            {
                BOProject boProject = ConvertProjectToBOProject(project);

                businessProjects.Add(boProject);
            }
            return businessProjects;
        }
        public static List<BOTechnology> ConvertTechnologyListToBOTechnologyList(List<Technology> technologies)
        {
            List<BOTechnology> businessTechnologies = new List<BOTechnology>();
            foreach (Technology technology in technologies)
            {
                BOTechnology boTechnology = ConvertTechnologyToBOTechnology(technology);

                businessTechnologies.Add(boTechnology);
            }
            return businessTechnologies;
        }
        public static List<BOEmployee> ConvertEmployeeListToBOEmployeeList(List<Employee> employees)
        {
            List<BOEmployee> businessEmployees = new List<BOEmployee>();
            foreach (Employee employee in employees)
            {
                BOEmployee boEmployee = ConvertEmployeeToBOEmployee(employee);

                businessEmployees.Add(boEmployee);
            }

            return businessEmployees;
        }
        public static List<BOTask> ConvertTaskListToBOTaskList(List<CompanyManagementDataLayer.Task> tasks)
        {
            List<BOTask> businessTasks = new List<BOTask>();
            foreach (CompanyManagementDataLayer.Task task in tasks)
            {
                BOTask boTask = ConvertTaskToBOTask(task);

                businessTasks.Add(boTask);
            }

            return businessTasks;
        }

        public static List<BOTaskTechnology> ConvertTaskTechnologyListToBOTaskTechnologyList(List<TaskTechnology> taskTechnologies)
        {
            List<BOTaskTechnology> businessTaskTechnologies = new List<BOTaskTechnology>();
            foreach (TaskTechnology taskTechnology in taskTechnologies)
            {
                BOTaskTechnology boTaskTechnology = ConvertTaskTechnologyToBOTaskTechnology(taskTechnology);
                businessTaskTechnologies.Add(boTaskTechnology);
            }
            return businessTaskTechnologies;
        }

        public static List<BOProjectTechnology> ConertProjectTechnologyListToBOProjectTechnologyList(List<ProjectTechnology> projectTechnologies)
        {
            List<BOProjectTechnology> boProjectTechnologies = new List<BOProjectTechnology>();
            foreach(ProjectTechnology projectTechnology in projectTechnologies)
            {
                BOProjectTechnology boProjectTechnology = ConvertProjectTechnologyToBOProjectTechnology(projectTechnology);
                boProjectTechnologies.Add(boProjectTechnology);
            }
            return boProjectTechnologies;
        }

        public static List<BOProjectTask> ConvertProjectTaskListToBOProjectTaskList(List<ProjectTask> projectTasks)
        {
            List<BOProjectTask> boProjectTasks = new List<BOProjectTask>();
            foreach(ProjectTask projectTask in projectTasks)
            {
                BOProjectTask boProjectTask = ConvertProjectTaskToBOProjectTask(projectTask);
                boProjectTasks.Add(boProjectTask);
            }
            return boProjectTasks;
        }

        public static List<BOEmployeeProject> ConvertEmployeeProjectListToBOEmployeeProjectList(List<EmployeeProject> employeeProjects)
        {
            List<BOEmployeeProject> boEmployeeProjects = new List<BOEmployeeProject>();
            foreach(EmployeeProject employeeProject in employeeProjects)
            {
                BOEmployeeProject boEmployeeProject = ConvertEmployeeProjectToBOEmployeeProject(employeeProject);
                boEmployeeProjects.Add(boEmployeeProject);
            }
            return boEmployeeProjects;
        }

        public static BOEmployeeProject ConvertEmployeeProjectToBOEmployeeProject(EmployeeProject employeeProject)
        {
            BOEmployeeProject boEmployeeProject = new BOEmployeeProject();
            boEmployeeProject.EmployeeProjectID = employeeProject.EmployeeProjectID;
            boEmployeeProject.EmployeeID = employeeProject.EmployeeID;
            boEmployeeProject.ProjectID = employeeProject.ProjectID;
            boEmployeeProject.EmployeeRoleInProject = employeeProject.EmployeeRoleInProject;
            return boEmployeeProject;
        }

        public static BOProjectTask ConvertProjectTaskToBOProjectTask(ProjectTask projectTask)
        {
            BOProjectTask boProjectTask = new BOProjectTask();
            boProjectTask.ProjectID = projectTask.ProjectID;
            boProjectTask.TaskID = projectTask.TaskID;
            boProjectTask.ProjectTaskID = projectTask.ProjectTaskID;
            boProjectTask.ProjectTaskStatus = projectTask.ProjectTaskStatus;
            return boProjectTask;
        }
        public static BOProject ConvertProjectToBOProject(Project project)
        {
            BOProject boProject = new BOProject();
            boProject.ProjectID = project.ProjectID;
            boProject.ProjectName = project.ProjectName;
            boProject.ProjectStatus = project.ProjectStatus;
            boProject.ClientID = project.ClientID;
            boProject.DepartmentID = project.DepartmentID;
            return boProject;
        }
        public static BOTechnology ConvertTechnologyToBOTechnology(Technology technology)
        {
            BOTechnology boTechnology = new BOTechnology();
            boTechnology.TechnologyID = technology.TechnologyID;
            boTechnology.TechnologyName = technology.TechnologyName;
            return boTechnology;
        }
        public static BOEmployee ConvertEmployeeToBOEmployee(Employee employee)
        {
            BOEmployee boEmployee = new BOEmployee();
            boEmployee.EmployeeID = employee.EmployeeID;
            boEmployee.EmployeeName = employee.EmployeeName;
            boEmployee.EmployeeDesignation = employee.EmployeeDesignation;
            boEmployee.EmployeeAddress = employee.EmployeeAddress;
            boEmployee.EmployeeContact = employee.EmployeeContact;
            boEmployee.DepartmentID = employee.DepartmentID;
            return boEmployee;
        }
        public static BOTask ConvertTaskToBOTask(CompanyManagementDataLayer.Task task)
        {
            BOTask boTask = new BOTask();
            boTask.TaskID = task.TaskID;
            boTask.TaskName = task.TaskName;
            boTask.TaskDescription = task.TaskDescription;
            return boTask;
        }
        public static BOTaskTechnology ConvertTaskTechnologyToBOTaskTechnology(TaskTechnology taskTechnology)
        {
            BOTaskTechnology boTaskTechnology = new BOTaskTechnology();
            boTaskTechnology.TaskTechnologyID = taskTechnology.TaskTechnologyID;
            boTaskTechnology.TechnologyID = taskTechnology.TechnologyID;
            boTaskTechnology.TaskID = taskTechnology.TaskID;
            return boTaskTechnology;
        }

        public static BOProjectTechnology ConvertProjectTechnologyToBOProjectTechnology(ProjectTechnology projectTechnology)
        {
            BOProjectTechnology boProjectTechnology = new BOProjectTechnology();
            boProjectTechnology.ProjectTechnologyID = projectTechnology.ProjectTechnologyID;
            boProjectTechnology.ProjectID = projectTechnology.ProjectID;
            boProjectTechnology.TechnologyID = projectTechnology.TechnologyID;
            boProjectTechnology.ProjectTechnologyVersionNumber = projectTechnology.TechnologyVersion;
            return boProjectTechnology;
        }
        public static Project ConvertBOProjectToProject(BOProject boProject)
        {
            Project project = new Project();

           
            return project;
        }
        public static Technology ConvertBOTechnologyToTechnology(BOTechnology boTechnology)
        {
            Technology technology = new Technology();

           

            return technology;
        }

        public static Employee ConvertBOEmployeeToEmployee(BOEmployee boEmployee)
        {
            Employee employee = new Employee();

           

            return employee;
        }
        public static CompanyManagementDataLayer.Task ConvertBOTaskToTask(BOTask boTask)
        {
            CompanyManagementDataLayer.Task task = new CompanyManagementDataLayer.Task();

            
            return task;
        }

       

    }
}
