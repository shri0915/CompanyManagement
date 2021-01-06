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
        
       public enum Status
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }

        public enum Role
        {
            ProjectManager = 1,
            TeamLead = 2,
            UIDeveloper = 3,
            BackendDeveloper = 4,
            SystemManager = 5
        }



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

        public int GetEmployeeCountForProject(int projectID)
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
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
                listOfProjectsUsingTechnology = DataConverter.ConvertProjectTechnologyListToBOProjectTechnologyList(dataLayer.GetAllTechnologyProjects(technologyID));
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

        public int GetProjectCountForEmployee(int employeeID)
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                int projectCountForEmployee = dataLayer.GetProjectCountForEmployee(employeeID);
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

        public List<BOEmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                List<BOEmployeeTask> listOfDelayedTasksForEmployee = new List<BOEmployeeTask>();
                listOfDelayedTasksForEmployee = DataConverter.ConvertEmployeeTaskListtoBOEmployeeTaskList(dataLayer.GetAllDelayedTasksForEmployee(employeeID));
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

        public void AssignEmployeeToProject(int employeeID, int projectID, int roleID) 
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                BLConstraints blConstraints = new BLConstraints();
                int projectCountForEmployee = dataLayer.GetProjectCountForEmployee(employeeID);
                int projectManagedCountForEmployee = dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID).Count();
                if (roleID != (int)Role.ProjectManager)
                {
                    if (projectCountForEmployee >= blConstraints.maxNumberOfProjectsForEmployee)
                    {
                        throw new Exception(CompanyManagementBLResource.CannotAssignMoreProjects);
                    }
                    else
                    {
                        dataLayer.AssignEmployeeToProject(employeeID, projectID);
                    }
                }
                else
                {
                    if(projectManagedCountForEmployee < blConstraints.maxNumberOfProjectsManagedByEmployee)
                    {
                        dataLayer.AssignEmployeeToProject(employeeID, projectID, roleID);
                    }
                    else
                    {
                        throw new Exception(CompanyManagementBLResource.CannotAssignMoreProjectsToPM);
                    }
                }

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
                DataLayer dataLayer = new DataLayer();
                int? projectStatus = dataLayer.GetProjectStatus(projectID);
                if(projectStatus == (int)Status.Completed)
                {
                    throw new Exception(CompanyManagementBLResource.CannotCreateTaskInProject);
                }
                else
                {
                    dataLayer.CreateTaskInProject(task, projectID);
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }
        public void AssignTechnologyToTask(int technologyID, int taskID, int projectID)
        {
            try
            {
                BLConstraints blConstraints = new BLConstraints();
                DataLayer dataLayer = new DataLayer();
                int technologiesTaskCount = dataLayer.GetCountOfTechnologiesAssignedToATask(taskID);
                bool projectUsesTheTechnology = dataLayer.DoesProjectUsesTheTechnology(technologyID, projectID);
                    if (projectUsesTheTechnology && technologiesTaskCount < blConstraints.maxNumberOfTaskTechnology)
                    {
                        dataLayer.AssignTechnologyToTask(technologyID, taskID);
                    }
                    else if(technologiesTaskCount >= blConstraints.maxNumberOfTaskTechnology)
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
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID) 
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                dataLayer.UpdateTechnologiesForTask(technologyIDs, taskID);

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
                DataLayer dataLayer = new DataLayer();
                dataLayer.DeleteEmployeeFromSystem(employeeID);

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
                int countOfProjectsUsingTechnology = dataLayer.GetAllTechnologyProjects(technologyID).Count();
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
        public void DeleteTask(int taskID) 
        {
            try
            {
                DataLayer dataLayer = new DataLayer();
                List<int?> listOfTaskStatus = dataLayer.GetTaskStatus(taskID);
                bool canTaskBeDeleted = true;
                foreach(int taskStatus in listOfTaskStatus)
                {
                    if(taskStatus != (int)Status.NotStarted)
                    {
                        canTaskBeDeleted = false;
                        break;
                    }
                }
                if(canTaskBeDeleted)
                {
                    dataLayer.DeleteTask(taskID);
                }
                else
                {
                    throw new Exception(CompanyManagementBLResource.CannotDeleteTask);
                }
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
                DataLayer dataLayer = new DataLayer();
                int? projectSTatus = dataLayer.GetProjectStatus(projectID);
                if(projectSTatus == (int)Status.NotStarted)
                {
                    dataLayer.DeleteProject(projectID);
                }
                else
                {
                    throw new Exception(CompanyManagementBLResource.CannotDeleteProject);
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;

            }
        }

        }
}
