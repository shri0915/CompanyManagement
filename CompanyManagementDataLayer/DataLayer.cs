using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    public class DataLayer
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

        
        public List<Project> GetAllProjects()
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();

            try
            {
                List<Project> listOfProjects = (from Project in dc.Projects select Project).ToList();
                return listOfProjects;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public List<Technology> GetAllTechnologies()
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            try
            {
                List<Technology> listOfTechnologies = (from Technology in dc.Technologies select Technology).ToList();
                return listOfTechnologies;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public int? GetEmployeeCountForProject(int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfProjectExists(projectID))
                {
                try
                {
                    int countOfEmployeesOfProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).Count();
                    return countOfEmployeesOfProject;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.ProjectMissing);
                return null;
            }
        }

        public List<Employee> GetAllEmployeesForProject(int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfProjectExists(projectID))
            {
                try
                {
                    List<Employee> listOfEmployeeFromProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject.Employee).ToList();
                    return listOfEmployeeFromProject;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.ProjectMissing);
                return null;
            }
        }

        public List<Project> GetAllDelayedProjects()
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            try
            {
                List<Project> listOfDelayedProjects = (from Project in dc.Projects where Project.ProjectStatus == (int)Status.Delayed select Project).ToList();
                return listOfDelayedProjects;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<Project> listOfProjectForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.Project).ToList();
                    return listOfProjectForEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;

            }
        }

        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<Task> listOfTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask.Task).ToList();
                    return listOfTasksForEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;
            }
        }

        public List<TaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (!dataValidationHelper.IfEmployeeExists(employeeID))
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;
            }
            else if(!dataValidationHelper.IfTechnologyExists(technologyID))
            {
                Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                return null;
            }
            else
            {


                try
                {
                    List<TaskTechnology> listOfTaskTechnologies = (from EmployeeTask in dc.EmployeeTasks join TaskTechnology in dc.TaskTechnologies on EmployeeTask.TaskID equals TaskTechnology.TaskID where TaskTechnology.TechnologyID == technologyID && EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
                    return listOfTaskTechnologies;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        public List<ProjectTechnology> GetAllTechnologyProjects(int technologyID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfTechnologyExists(technologyID))
            {
                try
                {
                    List<ProjectTechnology> listOfProjectTechnologies = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technologyID select ProjectTechnology).ToList();
                    return listOfProjectTechnologies;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                return null;
            }
        }

        public List<ProjectTask> GetAllActiveTasksForProject(int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfProjectExists(projectID))
            {
                try
                {
                    List<ProjectTask> listOfActiveTasksForProject = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID && ProjectTask.ProjectTaskStatus == (int)Status.Active select ProjectTask).ToList();
                    return listOfActiveTasksForProject;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.ProjectMissing);
                return null;
            }
        }

        public List<TaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<TaskTechnology> listOfTechnologiesForEmployee = (from TaskTechnology in dc.TaskTechnologies join EmployeeTask in dc.EmployeeTasks on TaskTechnology.TaskID equals EmployeeTask.TaskID where EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
                    return listOfTechnologiesForEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;

            }
        }

        public int? GetProjectCountForEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {

                try
                {
                    int projectCountForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active select EmployeeProject.ProjectID).Count();
                    return projectCountForEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;
            }
        }

        public List<EmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active && EmployeeProject.EmployeeRoleInProject == (int)Role.ProjectManager select EmployeeProject).ToList();
                    return listOfActiveProjectsManagedByEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;
            }
        }

        public List<EmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<EmployeeTask> listOfAllDelayedTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID && EmployeeTask.EmployeeTaskStatus == (int)Status.Delayed select EmployeeTask).ToList();
                    return listOfAllDelayedTasksForEmployee;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            else
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                return null;
            }
        }

        public void AddProject(Project project)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();

            try
            {
                String compulsoryFieldsValidationResult = dataValidationHelper.CheckCompulsoryFieldsOfProject(project);
                if (compulsoryFieldsValidationResult != CompanyManagementResource.AllColumnsPresent)
                {
                    throw new Exception(compulsoryFieldsValidationResult);
                }

                else
                {

                    // Insert the values to the database
                    if (!dataValidationHelper.IfDepartmentExists(project.DepartmentID) && !dataValidationHelper.IfClientExists(project.ClientID))
                    {
                        
                            Console.WriteLine(CompanyManagementResource.DepartmentMissing + " and " + CompanyManagementResource.ClientMissing);
                        
                    }
                    else
                    {
                            if (dataValidationHelper.IfClientExists(project.ClientID))
                            {
                                if (dataValidationHelper.IfDepartmentExists(project.DepartmentID))
                                {


                                    dc.Projects.InsertOnSubmit(project);
                                    dc.SubmitChanges();

                                }
                                else
                                {
                                    Console.WriteLine(CompanyManagementResource.DepartmentMissing);
                                }
                            }
                            else
                            {
                                Console.WriteLine(CompanyManagementResource.ClientMissing);
                            }
                    }
                    
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Project not added because of the issue mentioned above");

            }



        }

        public void AddTechnology(Technology technology)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                string compulsoryFieldsValidationResult = dataValidationHelper.CheckCompulsoryFieldsOfTechnology(technology);
                if (compulsoryFieldsValidationResult != CompanyManagementResource.AllColumnsPresent)
                {
                    Console.WriteLine(compulsoryFieldsValidationResult);
                }
                else
                {
                        dc.Technologies.InsertOnSubmit(technology);
                        dc.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void AddEmployee(Employee employee)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                string compulsoryFieldsValidationResult = dataValidationHelper.CheckCompulsoryFieldsOfEmployee(employee);
                if (compulsoryFieldsValidationResult != CompanyManagementResource.AllColumnsPresent)
                {
                    Console.WriteLine(compulsoryFieldsValidationResult);
                }
                else
                {

                    if (dataValidationHelper.IfDepartmentExists(employee.DepartmentID))
                    {


                        dc.Employees.InsertOnSubmit(employee);
                        dc.SubmitChanges();

                    }
                    else
                    {
                        Console.WriteLine(CompanyManagementResource.DepartmentMissing);
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if(!dataValidationHelper.IfEmployeeExists(employeeID) && !dataValidationHelper.IfProjectExists(projectID))
                {
                    Console.WriteLine(CompanyManagementResource.EmployeeMissing + " and " + CompanyManagementResource.ProjectMissing);
                }
                else if (!dataValidationHelper.IfEmployeeExists(employeeID))
                {
                    Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                }
                else if (!dataValidationHelper.IfProjectExists(projectID))
                {
                    Console.WriteLine(CompanyManagementResource.ProjectMissing);
                }
                else
                {
                    if (!dataValidationHelper.IfEmployeeIsAssignedToProject(employeeID, projectID))
                    {

                        EmployeeProject objEmployeeProject = new EmployeeProject();
                        objEmployeeProject.EmployeeID = employeeID;
                        objEmployeeProject.ProjectID = projectID;
                        dc.EmployeeProjects.InsertOnSubmit(objEmployeeProject);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        Console.WriteLine(CompanyManagementResource.EmployeeAssignedToProject);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public void CreateTaskInProject(Task task, int projectID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                string compulsoryFieldsValidationResult = dataValidationHelper.CheckCompulsoryFieldsOfTask(task);
                if (compulsoryFieldsValidationResult != CompanyManagementResource.AllColumnsPresent)
                {
                    Console.WriteLine(compulsoryFieldsValidationResult);
                }
                else
                {
                    dc.Tasks.InsertOnSubmit(task);
                    dc.SubmitChanges();
                    if (!dataValidationHelper.IfProjectExists(projectID))
                    {
                        Console.WriteLine(CompanyManagementResource.ProjectMissing);
                    }

                    else
                    {
                            if (!dataValidationHelper.IfTaskAssignedToProject(task.TaskID,projectID))
                            {
                                ProjectTask objProjectTask = new ProjectTask();
                                objProjectTask.ProjectID = projectID;
                                objProjectTask.TaskID = task.TaskID;
                                dc.ProjectTasks.InsertOnSubmit(objProjectTask);
                                dc.SubmitChanges();
                            }
                            else
                            {
                                Console.WriteLine(CompanyManagementResource.TaskAlreadyAssignedToProject);
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();

            if(!dataValidationHelper.IfTaskExists(taskID) && !dataValidationHelper.IfTechnologyExists(technologyID))
            {
                Console.WriteLine(CompanyManagementResource.TaskMissing + " and " + CompanyManagementResource.TechnologyMissing);
            }
            else if (!dataValidationHelper.IfTaskExists(taskID))
            {
                Console.WriteLine(CompanyManagementResource.TaskMissing);
            }
            else if (!dataValidationHelper.IfTechnologyExists(technologyID))
            {
                Console.WriteLine(CompanyManagementResource.TechnologyMissing);
            }
            else
            {
                try
                {
                    if (!dataValidationHelper.IfTechnologyIsAssignedToTask(technologyID, taskID))
                    {
                        TaskTechnology objTaskTechnology = new TaskTechnology();
                        objTaskTechnology.TechnologyID = technologyID;
                        objTaskTechnology.TaskID = taskID;
                        dc.TaskTechnologies.InsertOnSubmit(objTaskTechnology);
                        dc.SubmitChanges();
                    }
                    else
                    {
                        Console.WriteLine(CompanyManagementResource.TechnologyAssignedToTask);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
        }
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID) 
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfTaskExists(taskID)) {
                    List<TaskTechnology> taskTechnologyToBeDeletedForUpdation = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeletedForUpdation);
                    dc.SubmitChanges();
                    foreach (int technologyID in technologyIDs)
                    {
                        if (dataValidationHelper.IfTechnologyExists(technologyID))
                        {
                            TaskTechnology taskTechnologyToBeInsertedForUpdation = new TaskTechnology();
                            taskTechnologyToBeInsertedForUpdation.TaskID = taskID;
                            taskTechnologyToBeInsertedForUpdation.TechnologyID = technologyID;
                            dc.TaskTechnologies.InsertOnSubmit(taskTechnologyToBeInsertedForUpdation);
                        }
                        else
                        {
                            Console.WriteLine(CompanyManagementResource.TechnologyMissing + " :-> " + technologyID);
                        }

                    }
                    dc.SubmitChanges();
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {


                if (dataValidationHelper.IfEmployeeExists(employeeID))
                {                    
                    List<EmployeeProject> employeeProjectToBeRemoved = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject).ToList();
                    dc.EmployeeProjects.DeleteAllOnSubmit(employeeProjectToBeRemoved);
                    List<EmployeeTask> employeeTaskToBeRemoved = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask).ToList();
                    dc.EmployeeTasks.DeleteAllOnSubmit(employeeTaskToBeRemoved);
                    List<Employee> employeeToBeRemoved = (from Employee in dc.Employees where Employee.EmployeeID == employeeID select Employee).ToList();
                    dc.Employees.DeleteAllOnSubmit(employeeToBeRemoved);
                    dc.SubmitChanges();
                }
                else 
                {
                    Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public void DeleteTechnology(int technology)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfTechnologyExists(technology))
                {
                    List<TaskTechnology> taskTechnologyToBeDeleted = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TechnologyID == technology select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeleted);
                    List<ProjectTechnology> projectTechnologyToBeDeleted = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technology select ProjectTechnology).ToList();
                    dc.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologyToBeDeleted);
                    List<Technology> technologyToBeDeleted = (from Technology in dc.Technologies where Technology.TechnologyID == technology select Technology).ToList();
                    dc.Technologies.DeleteAllOnSubmit(technologyToBeDeleted);
                    
                }
                else 
                {
                    Console.WriteLine(CompanyManagementResource.TechnologyMissing);
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
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfTaskExists(taskID))
                {
                    List<EmployeeTask> employeeTaskToBeDeleted = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.TaskID == taskID select EmployeeTask).ToList();
                    dc.EmployeeTasks.DeleteAllOnSubmit(employeeTaskToBeDeleted);
                    List<ProjectTask> projectTaskToBeDeleted = (from ProjectTask in dc.ProjectTasks where ProjectTask.TaskID == taskID select ProjectTask).ToList();
                    dc.ProjectTasks.DeleteAllOnSubmit(projectTaskToBeDeleted);
                    List<TaskTechnology> taskTechnologyToBeDeleted = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeleted);
                    List<Task> taskToBeDeleted = (from Task in dc.Tasks where Task.TaskID == taskID select Task).ToList();
                    dc.Tasks.DeleteAllOnSubmit(taskToBeDeleted);
                    dc.SubmitChanges();
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing);
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
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfProjectExists(projectID))
                {
                    List<EmployeeProject> employeeProjectToBeDeleted = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).ToList();
                    dc.EmployeeProjects.DeleteAllOnSubmit(employeeProjectToBeDeleted);
                    List<ProjectTask> projectTaskToBeDeleted = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID select ProjectTask).ToList();
                    dc.ProjectTasks.DeleteAllOnSubmit(projectTaskToBeDeleted);
                    List<ProjectTechnology> projectTechnologyToBeDeleted = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.ProjectID == projectID select ProjectTechnology).ToList();
                    dc.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologyToBeDeleted);
                    List<Project> projectToBeDeleted = (from Project in dc.Projects where Project.ProjectID == projectID select Project).ToList();
                    dc.Projects.DeleteAllOnSubmit(projectToBeDeleted);
                    dc.SubmitChanges();
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.ProjectMissing);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public bool? IfProjectUsesTheTechnology(int taskID, int technologyID)
        {
            CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                bool taskExists = dataValidationHelper.IfTaskExists(taskID);
                bool technologyExists = dataValidationHelper.IfTechnologyExists(technologyID);
                if (!taskExists && !technologyExists)
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing + " and " + CompanyManagementResource.TechnologyMissing);
                    return null;
                }
                else if(!taskExists)
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing);
                    return null;
                }
                else if(!technologyExists)
                {
                    Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                    return null;
                }
                else
                {
                    bool projectTaskExists = (from ProjectTask in dc.ProjectTasks
                                             join ProjectTechnology in dc.ProjectTechnologies on
                       ProjectTask.ProjectID equals ProjectTechnology.ProjectID
                                             where ProjectTask.TaskID == taskID && ProjectTechnology.TechnologyID == technologyID
                                             select ProjectTask).Any();
                    return projectTaskExists;

                    
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

       public int? GetCountOfTechnologiesAssignedToATask(int taskID, int technologyID)
        {
            try
            {
                CompanyManagementDataClassesDataContext dc = new CompanyManagementDataClassesDataContext();
                DataValidationHelper dataValidationHelper = new DataValidationHelper();
                bool taskExists = dataValidationHelper.IfTaskExists(taskID);
                bool technologyExists = dataValidationHelper.IfTechnologyExists(technologyID);
                if (!taskExists && !technologyExists)
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing + " and " + CompanyManagementResource.TechnologyMissing);
                    return null;
                }
                else if(!taskExists)
                {
                    Console.WriteLine(CompanyManagementResource.TaskMissing);
                    return null;
                }
                else if(!technologyExists)
                {
                    Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                    return null;
                }
                else
                {
                    int countOfTechnologyAssignedToATask = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID
                                                            && TaskTechnology.TechnologyID == technologyID select TaskTechnology).Count();
                    return countOfTechnologyAssignedToATask;
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
