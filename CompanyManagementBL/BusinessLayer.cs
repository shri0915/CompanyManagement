using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;
using CompanyManagementBL.Entities;

namespace CompanyManagementBL
{
    public class BusinessLayer
    {
        
        DataLayer dataLayer = new DataLayer();
        
        

        public List<BOProject> GetAllProjects()
        {
            try
            {

                List<BOProject> listOfBOProjects = new List<BOProject>();
                listOfBOProjects =  DataConverter.ConvertProjectListToBOProjectList(dataLayer.GetAllProjects());
                return listOfBOProjects;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }

        }
        public List<BOTechnology> GetAllTechnologies()
        {
            try
            {
                List<BOTechnology> listOfBOTechologies = new List<BOTechnology>();
                listOfBOTechologies = DataConverter.ConvertTechnologyListToBOTechnologyList(dataLayer.GetAllTechnologies());
                return listOfBOTechologies;



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public int? GetEmployeeCountForProject(int projectID)
        {
            try
            {
                int? countOfEmployeesForProject = 0;
                countOfEmployeesForProject = dataLayer.GetEmployeeCountForProject(projectID);
                return countOfEmployeesForProject;


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }

        }

        public List<BOEmployee> GetAllEmployeesForProject(int projectID)
        {
            try
            {

                List<BOEmployee> listOfBOEmployee = new List<BOEmployee>();
                listOfBOEmployee = DataConverter.ConvertEmployeeListToBOEmployeeList(dataLayer.GetAllEmployeesForProject(projectID));
                return listOfBOEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOProject> GetAllDelayedProjects()
        {
            try
            {

                List<BOProject> listOfDelayedProjects = new List<BOProject>();
                listOfDelayedProjects = DataConverter.ConvertProjectListToBOProjectList(dataLayer.GetAllDelayedProjects());
                return listOfDelayedProjects;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOProject> GetAllProjectsForEmployee(int employeeID)
        {
            try
            {

                List<BOProject> listOfDelayedProjects = new List<BOProject>();
                return listOfDelayedProjects;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOTask> GetAllTasksForEmployee(int employeeID)
        {
            try
            {
                List<BOTask> listOfTasksForEmployee = new List<BOTask>();
                return listOfTasksForEmployee;


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOTaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            try
            {

                List<BOTaskTechnology> listOfTechnologyTasksForEmployee = new List<BOTaskTechnology>();
                listOfTechnologyTasksForEmployee = DataConverter.ConvertTaskTechnologyListToBOTaskTechnologyList(dataLayer.GetAllTechnologyTasksForEmployee(technologyID, employeeID));
                return listOfTechnologyTasksForEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOProjectTechnology> GetAllTechnologyProjects(int technologyID)
        {
            try
            {
                List<BOProjectTechnology> listOfTechnologiesForProjects = new List<BOProjectTechnology>();
                
                return listOfTechnologiesForProjects;


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOProjectTask> GetAllActiveTasksForProject(int projectID)
        {
            try
            {
                List<BOProjectTask> listOfActiveTasksForProject = new List<BOProjectTask>();
                return listOfActiveTasksForProject;


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOTaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            try
            {

                List<BOTaskTechnology> listOfTechnologiesForEmployee = new List<BOTaskTechnology>();
                return listOfTechnologiesForEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            try
            {

                int projectCountForEmployee = 0;
                return projectCountForEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOEmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            try
            {

                List<BOEmployeeProject> listOfActiveProjectManagedByEmployee = new List<BOEmployeeProject>();
                return listOfActiveProjectManagedByEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOEmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            try
            {
                List<BOEmployeeTask> listOfDelayedTasksForEmployee = new List<BOEmployeeTask>();
                return listOfDelayedTasksForEmployee;


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public void AddProject(Project project)
        {

            try
            {

               

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Project not added because of the issue mentioned above");

            }



        }

        public void AddTechnology(Technology technology)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }

        }

        public void AddEmployee(Employee employee)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void CreateTaskInProject(CompanyManagementDataLayer.Task task, int projectID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void AssignTechnologyToTask(int technologyID, int taskID, int? maximumNumberOfTechnologiesThatCanBeAssignedToATask)
        {
            try
            {
                int? countOfTechnologiesAssignedToATask = dataLayer.GetCountOfTechnologiesAssignedToATask(taskID, technologyID);
                bool? projectUsesTheTechnology = dataLayer.IfProjectUsesTheTechnology(taskID, technologyID);
                if (projectUsesTheTechnology.Equals(null) || countOfTechnologiesAssignedToATask.Equals(null))
                {

                }
                else
                {
                    bool technologyAssignedToProjectBelongingToTask = (bool)dataLayer.IfProjectUsesTheTechnology(taskID, technologyID);
                    if (technologyAssignedToProjectBelongingToTask && countOfTechnologiesAssignedToATask < maximumNumberOfTechnologiesThatCanBeAssignedToATask)
                    {
                        dataLayer.AssignTechnologyToTask(technologyID, taskID);
                    }
                    else if(countOfTechnologiesAssignedToATask >= maximumNumberOfTechnologiesThatCanBeAssignedToATask)
                    {
                        Console.WriteLine(CompanyManagementBLResource.CannotAssignTechnologyToTaskLimitReached);
                    }
                    else
                    {
                        Console.WriteLine(CompanyManagementBLResource.CannotAssignTechnologyToTask);
                    }
                }


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteTechnology(int technologyID, int? maxmimumNumberOfProjectAssociatedWithATechnologyForWhichTechnologyCanBeDeleted)
        {
            try
            {
                int? countOfTechnologyProject = dataLayer.GetAllTechnologyProjects(technologyID).Count();
                if(countOfTechnologyProject.Equals(null))
                {

                }
                else if (countOfTechnologyProject >= maxmimumNumberOfProjectAssociatedWithATechnologyForWhichTechnologyCanBeDeleted)
                {
                    Console.WriteLine(CompanyManagementBLResource.CannotDeleteTechnology);
                }
                else
                {
                    dataLayer.DeleteTechnology(technologyID);
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteTask(int taskID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteProject(int projectID)
        {
            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        }
}
