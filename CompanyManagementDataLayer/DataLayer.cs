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

        /* Things remaining:
         * Data validation
         * Validation on operations like update, delete*/





        
        

        public List<Project> GetAllProjects()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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

        public int GetEmployeeCountForProject(int projectID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                int countOfEmployeesOfProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).Count();
                return countOfEmployeesOfProject;
            }
        }

        public List<Employee> GetAllEmployeesForProject(int projectID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<Employee> listOfEmployeeFromProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject.Employee).ToList();
                return listOfEmployeeFromProject;
            }
        }

        public List<Project> GetAllDelayedProjects()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<Project> listOfProjectForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.Project).ToList();
                return listOfProjectForEmployee;

            }
        }

        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<Task> listOfTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask.Task).ToList();
                return listOfTasksForEmployee;
            }
        }

        public List<TaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (!dataValidationHelper.IfEmployeeExists(employeeID))
            {
                Console.WriteLine(CompanyManagementResource.EmployeeMissing);
                List<TaskTechnology> listOfTaskTechnologies = (from EmployeeTask in dc.EmployeeTasks join TaskTechnology in dc.TaskTechnologies on EmployeeTask.TaskID equals TaskTechnology.TaskID where TaskTechnology.TechnologyID == technologyID && EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
                return listOfTaskTechnologies;
            }
            else if(!dataValidationHelper.IfTechnologyExists(technologyID))
            {
                Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                List<TaskTechnology> listOfTaskTechnologies = (from EmployeeTask in dc.EmployeeTasks join TaskTechnology in dc.TaskTechnologies on EmployeeTask.TaskID equals TaskTechnology.TaskID where TaskTechnology.TechnologyID == technologyID && EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
                return listOfTaskTechnologies;
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<ProjectTechnology> listOfProjectTechnologies = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technologyID select ProjectTechnology).ToList();
                return listOfProjectTechnologies;
            }
        }

        public List<ProjectTask> GetAllActiveTasksForProject(int projectID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<ProjectTask> listOfActiveTasksForProject = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID && ProjectTask.ProjectTaskStatus == (int)Status.Active select ProjectTask).ToList();
                return listOfActiveTasksForProject;
            }
        }

        public List<TaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<TaskTechnology> listOfTechnologiesForEmployee = (from TaskTechnology in dc.TaskTechnologies join EmployeeTask in dc.EmployeeTasks on TaskTechnology.TaskID equals EmployeeTask.TaskID where EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
                return listOfTechnologiesForEmployee;

            }
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {

                try
                {
                    int projectCountForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.ProjectID).Count();
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
                int projectCountForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.ProjectID).Count();
                return projectCountForEmployee;
            }
        }

        public List<EmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            if (dataValidationHelper.IfEmployeeExists(employeeID))
            {
                try
                {
                    List<EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active && EmployeeProject.EmployeeRoleID == (int)Role.ProjectManager select EmployeeProject).ToList();
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
                List<EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active && EmployeeProject.EmployeeRoleID == (int)Role.ProjectManager select EmployeeProject).ToList();
                return listOfActiveProjectsManagedByEmployee;
            }
        }

        public List<EmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
                List<EmployeeTask> listOfAllDelayedTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID && EmployeeTask.EmployeeTaskStatus == (int)Status.Delayed select EmployeeTask).ToList();
                return listOfAllDelayedTasksForEmployee;
            }
        }

        public void AddProject(Project project)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();

            try
            {


                // Insert the values to the database
                if (!dataValidationHelper.IfProjectExists(project.ProjectID))
                {
                    String checkProjectCumpulsoryFieldsValidation = dataValidationHelper.CheckCumpulsoryFieldsOfProject(project);
                    if (checkProjectCumpulsoryFieldsValidation != CompanyManagementResource.AllColumnsPresent)
                    {
                        throw new Exception(checkProjectCumpulsoryFieldsValidation);
                    }
                    else
                    {
                        dc.Projects.InsertOnSubmit(project);
                        dc.SubmitChanges();
                    }
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.ProjectAlreadyExists);
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (!dataValidationHelper.IfTechnologyExists(technology.TechnologyID))
                {
                    string checkCumpolsoryFieldsForTechnology = dataValidationHelper.CheckCompulsoryFieldsOfTechnology(technology);
                    if (checkCumpolsoryFieldsForTechnology != CompanyManagementResource.AllColumnsPresent)
                    {
                        Console.WriteLine(checkCumpolsoryFieldsForTechnology);
                    }
                    else {
                        dc.Technologies.InsertOnSubmit(technology);
                        dc.SubmitChanges();
                    }
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.TechnologyAlreadyExists);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void AddEmployee(Employee employee)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (!dataValidationHelper.IfEmployeeExists(employee.EmployeeID))
                {
                    string checkCumpolsoryFieldsForEmployee = dataValidationHelper.CheckCompulsoryFieldsOfEmployee(employee);
                    if (checkCumpolsoryFieldsForEmployee != CompanyManagementResource.AllColumnsPresent)
                    {
                        Console.WriteLine(checkCumpolsoryFieldsForEmployee);
                    }
                    else
                    {
                        dc.Employees.InsertOnSubmit(employee);
                        dc.SubmitChanges();
                    }
                }
                else
                {
                    Console.WriteLine(CompanyManagementResource.EmployeeAlreadyExists);
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (!dataValidationHelper.IfEmployeeExists(employeeID))
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfProjectExists(projectID))
                {
                    Console.WriteLine(CompanyManagementResource.ProjectMissing);
                }
                
                else
                {
                    string checkCompulsoryFieldsOfTask = dataValidationHelper.CheckCompulsoryFieldsOfTask(task);
                    if (checkCompulsoryFieldsOfTask != CompanyManagementResource.AllColumnsPresent)
                    {
                        Console.WriteLine(checkCompulsoryFieldsOfTask);
                    }
                    else
                    {
                        dc.Tasks.InsertOnSubmit(task);
                        ProjectTask objProjectTask = new ProjectTask();
                        objProjectTask.ProjectID = projectID;
                        objProjectTask.TaskID = task.TaskID;
                        dc.ProjectTasks.InsertOnSubmit(objProjectTask);
                        dc.SubmitChanges();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();

            if (!dataValidationHelper.IfTaskExists(taskID))
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
                        objTaskTechnology.TaskTechnologyID = technologyID;
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
            DataValidationHelper dataValidationHelper = new DataValidationHelper();
            try
            {
                if (dataValidationHelper.IfTaskExists(taskID)) {
                    List<TaskTechnology> taskTechnologyToBeDeletedForUpdation = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeletedForUpdation);
                    dc.SubmitChanges();
                    foreach (int technology in technologyIDs)
                    {
                        if (dataValidationHelper.IfTechnologyExists(technology))
                        {
                            TaskTechnology taskTechnologyToBeInsertedForUpdation = new TaskTechnology();
                            taskTechnologyToBeInsertedForUpdation.TaskID = taskID;
                            taskTechnologyToBeInsertedForUpdation.TechnologyID = technology;
                            dc.TaskTechnologies.InsertOnSubmit(taskTechnologyToBeInsertedForUpdation);
                            dc.SubmitChanges();
                        }
                        else
                        {
                            Console.WriteLine(CompanyManagementResource.TechnologyMissing);
                        }

                    }
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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
            DataClasses1DataContext dc = new DataClasses1DataContext();
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


    }
}
