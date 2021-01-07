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

        public static List<BOTask> ConvertTaskTechnologyListToBOTaskList(List<TaskTechnology> taskTechnologies)
        {
            List<BOTask> businessTaskTechnologies = new List<BOTask>();
            foreach (TaskTechnology taskTechnology in taskTechnologies)
            {
                BOTask boTask = ConvertTaskTechnologyToBOTask(taskTechnology);
                businessTaskTechnologies.Add(boTask);
            }
            return businessTaskTechnologies;
        }

        public static List<BOProject> ConvertProjectTechnologyListToBOProjectList(List<ProjectTechnology> projectTechnologies)
        {
            List<BOProject> boProjectTechnologies = new List<BOProject>();
            foreach(ProjectTechnology projectTechnology in projectTechnologies)
            {
                BOProject boProjectTechnology = ConvertProjectTechnologyToBOProject(projectTechnology);
                boProjectTechnologies.Add(boProjectTechnology);
            }
            return boProjectTechnologies;
        }

        public static List<BOProject> ConvertProjectTaskListToBOProjectList(List<ProjectTask> projectTasks)
        {
            List<BOProject> boProjectTasks = new List<BOProject>();
            foreach(ProjectTask projectTask in projectTasks)
            {
                BOProject boProjectTask = ConvertProjectTaskToBOProject(projectTask);
                boProjectTasks.Add(boProjectTask);
            }
            return boProjectTasks;
        }

        public static List<BOEmployee> ConvertEmployeeProjectListToBOEmployeeList(List<EmployeeProject> employeeProjects)
        {
            List<BOEmployee> boEmployeeProjects = new List<BOEmployee>();
            foreach(EmployeeProject employeeProject in employeeProjects)
            {
                BOEmployee boEmployeeProject = ConvertEmployeeProjectToBOEmployee(employeeProject);
                boEmployeeProjects.Add(boEmployeeProject);
            }
            return boEmployeeProjects;
        }
        public static List<BOEmployee> ConvertEmployeeTaskListtoBOEmployeeList(List<EmployeeTask> employeeTasks)
        {
            List<BOEmployee> boEmployeeTasks = new List<BOEmployee>();
            foreach(EmployeeTask employeeTask in employeeTasks)
            {
                BOEmployee boEmployeeTask = ConvertEmployeeTaskToBOEmployee(employeeTask);
                boEmployeeTasks.Add(boEmployeeTask);
            }
            return boEmployeeTasks;
        }

        public static BOEmployee ConvertEmployeeTaskToBOEmployee(EmployeeTask employeeTask)
        {
            DataLayer dataLayer = new DataLayer();
            BOEmployee boEmployee = new BOEmployee();
            boEmployee.EmployeeID = employeeTask.EmployeeID;
            boEmployee.EmployeeName = employeeTask.Employee.EmployeeName;
            boEmployee.Task = employeeTask.Task;
            return boEmployee;
        }
        public static BOEmployee ConvertEmployeeProjectToBOEmployee(EmployeeProject employeeProject)
        {
            BOEmployee boEmployee = new BOEmployee();
            boEmployee.EmployeeID = employeeProject.EmployeeID;
            boEmployee.EmployeeName = employeeProject.Employee.EmployeeName;
            boEmployee.Project = employeeProject.Project;
            return boEmployee;
        }

        public static BOProject ConvertProjectTaskToBOProject(ProjectTask projectTask)
        {
            BOProject boProjectTask = new BOProject();
            boProjectTask.ProjectID = projectTask.ProjectID;
            boProjectTask.Task = projectTask.Task;
            boProjectTask.projectStatus = (EnumClass.Status)projectTask.ProjectTaskStatus;
            return boProjectTask;
        }
        public static BOProject ConvertProjectToBOProject(Project project)
        {
            BOProject boProject = new BOProject();
            boProject.ProjectID = project.ProjectID;
            boProject.ProjectName = project.ProjectName;
            boProject.projectStatus = (EnumClass.Status)project.ProjectStatus;
            boProject.Client = project.Client;
            boProject.Department = project.Department;
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
            boEmployee.Department = employee.Department;
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
        public static BOTask ConvertTaskTechnologyToBOTask(TaskTechnology taskTechnology)
        {
            BOTask boTask = new BOTask();
            boTask.Technology = taskTechnology.Technology;
            boTask.TaskID = taskTechnology.TaskID;
            boTask.TaskName = taskTechnology.Task.TaskName;
            return boTask;
        }

        public static BOProject ConvertProjectTechnologyToBOProject(ProjectTechnology projectTechnology)
        {
            BOProject boProjectTechnology = new BOProject();
            boProjectTechnology.ProjectID = projectTechnology.ProjectID;
            boProjectTechnology.ProjectName = projectTechnology.Project.ProjectName;
            boProjectTechnology.Technology = projectTechnology.Technology;
            return boProjectTechnology;
        }
        
       

    }
}
