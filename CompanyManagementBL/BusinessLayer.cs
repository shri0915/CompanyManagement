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
        
        
        
        

        public List<BOProject> GetAllProjects()
        {
            try
            {
                DataLayer dataLayer = new DataLayer();

                List<BOProject> listOfProjects = new List<BOProject>();
                listOfProjects =  DataConverter.ConvertProjectListToBOProjectList(dataLayer.GetAllProjects());
                return listOfProjects;

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
                DataLayer dataLayer = new DataLayer();
                List<BOTechnology> listOfTechologies = new List<BOTechnology>();
                listOfTechologies = DataConverter.ConvertTechnologyListToBOTechnologyList(dataLayer.GetAllTechnologies());
                return listOfTechologies;



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
                DataLayer dataLayer = new DataLayer();
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
                DataLayer dataLayer = new DataLayer();

                List<BOEmployee> listOfEmployee = new List<BOEmployee>();
                listOfEmployee = DataConverter.ConvertEmployeeListToBOEmployeeList(dataLayer.GetAllEmployeesForProject(projectID));
                return listOfEmployee;

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
                DataLayer dataLayer = new DataLayer();

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
                DataLayer dataLayer = new DataLayer();

                List<BOProject> listOfProjectsForEmployee = new List<BOProject>();
                listOfProjectsForEmployee = DataConverter.ConvertProjectListToBOProjectList(dataLayer.GetAllProjectsForEmployee(employeeID));
                return listOfProjectsForEmployee;

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
                DataLayer dataLayer = new DataLayer();
                List<BOTask> listOfTasksForEmployee = new List<BOTask>();
                listOfTasksForEmployee = DataConverter.ConvertTaskListToBOTaskList(dataLayer.GetAllTasksForEmployee(employeeID));
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
                DataLayer dataLayer = new DataLayer();

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
                DataLayer dataLayer = new DataLayer();
                List<BOProjectTechnology> listOfProjectsUsingTechnology = new List<BOProjectTechnology>();
                listOfProjectsUsingTechnology = DataConverter.ConertProjectTechnologyListToBOProjectTechnologyList(dataLayer.GetAllTechnologyProjects(technologyID));
                return listOfProjectsUsingTechnology;
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
                DataLayer dataLayer = new DataLayer();
                List<BOProjectTask> listOfActiveTasksForProject = new List<BOProjectTask>();
                listOfActiveTasksForProject = DataConverter.ConvertProjectTaskListToBOProjectTaskList(dataLayer.GetAllActiveTasksForProject(projectID));
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
                DataLayer dataLayer = new DataLayer();
                List<BOTaskTechnology> listOfTechnologiesForEmployee = new List<BOTaskTechnology>();
                listOfTechnologiesForEmployee = DataConverter.ConvertTaskTechnologyListToBOTaskTechnologyList(dataLayer.GetAllTechnologiesForEmployee(employeeID));
                return listOfTechnologiesForEmployee;

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public int? GetProjectCountForEmployee(int employeeID)
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                int? projectCountForEmployee = dataLayer.GetProjectCountForEmployee(employeeID);
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
                DataLayer dataLayer = new DataLayer();
                List<BOEmployeeProject> listOfActiveProjectManagedByEmployee = new List<BOEmployeeProject>();
                listOfActiveProjectManagedByEmployee = DataConverter.ConvertEmployeeProjectListToBOEmployeeProjectList(dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID));
                return listOfActiveProjectManagedByEmployee;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public List<BOEmployeeTask> GetAllDelayedTasksForEmployee(int employeeID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
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
                DataLayer dataLayer = new DataLayer();
                dataLayer.AddProject(project);


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
                DataLayer dataLayer = new DataLayer();
                dataLayer.AddTechnology(technology);


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
                DataLayer dataLayer = new DataLayer();
                dataLayer.AddEmployee(employee);


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        public void AssignEmployeeToProject(int employeeID, int projectID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void CreateTaskInProject(CompanyManagementDataLayer.Task task, int projectID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


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
                BLConstraints blConstraints = new BLConstraints();
                CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
                List<int> projectIDs = (from ProjectTask in dc.ProjectTasks where ProjectTask.TaskID == taskID select ProjectTask.ProjectID).ToList();
                DataLayer dataLayer = new DataLayer();
                int technologiesTaskCount = dataLayer.GetCountOfTechnologiesAssignedToATask(taskID);
                bool projectUsesTheTechnology = dataLayer.IfProjectUsesTheTechnology(technologyID, projectIDs);
                    if (projectUsesTheTechnology && technologiesTaskCount < blConstraints.maxNumberOFTaskTechnology)
                    {
                        dataLayer.AssignTechnologyToTask(technologyID, taskID);
                    }
                    else if(technologiesTaskCount >= blConstraints.maxNumberOFTaskTechnology)
                    {
                        Console.WriteLine(CompanyManagementBLResource.CannotAssignTechnologyToTaskLimitReached);
                    }
                    else
                    {
                        Console.WriteLine(CompanyManagementBLResource.CannotAssignTechnologyToTask);
                    }
                


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteEmployeeFromSystem(int employeeID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteTechnology(int technologyID)
        {
            try
            {
                BLConstraints blConstraints = new BLConstraints();
                DataLayer dataLayer = new DataLayer();
                int? countOfProjectsUsingTechnology = dataLayer.GetAllTechnologyProjects(technologyID).Count();
                if (countOfProjectsUsingTechnology >= blConstraints.minNumberOfProjectsUsingTechnologies)
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
        public void DeleteTask(int taskID) //Yet to be implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void DeleteProject(int projectID) //Yet to be Implemented
        {
            try
            {
                DataLayer dataLayer = new DataLayer();


            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        }
}
