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
                listOfBOProjects =  ConvertDataLayerToBusinessLayer.ConvertProjectListToBOProjectList(dataLayer.GetAllProjects());
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
                listOfBOTechologies = ConvertDataLayerToBusinessLayer.ConvertTechnologyListToBOTechnologyList(dataLayer.GetAllTechnologies());
                return listOfBOTechologies;



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public int GetEmployeeCountForProject(int projectID)
        {
            try
            {
                int countOfEmployeesForProject = 0;
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
        public void AssignTechnologyToTask(int technologyID, int taskID)
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
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID) //Incomplete. Yet to be written.
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
        public void DeleteTechnology(int technology)
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
