using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;
using CompanyManagementBL.Entities;

namespace CompanyManagementBL
{
    public class ConvertDataLayerToBusinessLayer
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

            

            return boEmployee;
        }
        public static BOTask ConvertTaskToBOTask(CompanyManagementDataLayer.Task task)
        {
            BOTask boTask = new BOTask();

            


            return boTask;
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
