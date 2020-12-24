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





        DataClasses1DataContext dc = new DataClasses1DataContext();
        DataValidationHelper validateTheInput = new DataValidationHelper();

        public List<Project> GetAllProjects()
        {
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

        public List<Employee> GetAllEmployeesForProject(int projectID)
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

        public List<Project> GetAllDelayedProjects()
        {
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

        public List<Task> GetAllTasksForEmployee(int employeeID)
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

        public List<TaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
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

        public List<ProjectTechnology> GetAllTechnologyProjects(int technologyID)
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

        public List<ProjectTask> GetAllActiveTasksForProject(int projectID)
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

        public List<TaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
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

        public int GetProjectCountForEmployee(int employeeID)
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

        public List<EmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            try
            {
                List<EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active && EmployeeProject.EmployeeRoleID == (int)Role.ProjectManager  select EmployeeProject).ToList();
                return listOfActiveProjectsManagedByEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public List<EmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
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

        public void AddProject(Project project)
        {

            try
            {


                // Insert the values to the database
                if (!validateTheInput.IfProjectExists(project.ProjectID))
                {
                    String checkProjectCumpulsoryFieldsValidation = validateTheInput.CheckCumpulsoryFieldsOfProject(project);
                    if (checkProjectCumpulsoryFieldsValidation != Resource1.AllColumnsPresent)
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
                    Console.WriteLine(Resource1.ProjectAlreadyExists);
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
            try
            {
                if (!validateTheInput.IfTechnologyExists(technology.TechnologyID))
                {
                    string checkCumpolsoryFieldsForTechnology = validateTheInput.CheckCompulsoryFieldsOfTechnology(technology);
                    if (checkCumpolsoryFieldsForTechnology != Resource1.AllColumnsPresent)
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
                    Console.WriteLine(Resource1.TechnologyAlreadyExists);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                if (!validateTheInput.IfEmployeeExists(employee.EmployeeID))
                {
                    string checkCumpolsoryFieldsForEmployee = validateTheInput.CheckCompulsoryFieldsOfEmployee(employee);
                    if (checkCumpolsoryFieldsForEmployee != Resource1.AllColumnsPresent)
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
                    Console.WriteLine(Resource1.EmployeeAlreadyExists);
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
            try
            {
                if (!validateTheInput.IfEmployeeExists(employeeID))
                {
                    Console.WriteLine(Resource1.EmployeeMissing);
                }
                else if (!validateTheInput.IfProjectExists(projectID))
                {
                    Console.WriteLine(Resource1.ProjectMissing);
                }
                else
                {
                    EmployeeProject objEmployeeProject = new EmployeeProject();
                    objEmployeeProject.EmployeeID = employeeID;
                    objEmployeeProject.ProjectID = projectID;
                    dc.EmployeeProjects.InsertOnSubmit(objEmployeeProject);
                    dc.SubmitChanges();
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
            try
            {
                if (validateTheInput.IfProjectExists(projectID))
                {
                    Console.WriteLine(Resource1.ProjectMissing);
                }
                else if(validateTheInput.IfTaskExists(task.TaskID))
                {
                    Console.WriteLine(Resource1.TaskMissing);
                }
                else
                {
                    string checkCompulsoryFieldsOfTask = validateTheInput.CheckCompulsoryFieldsOfTask(task);
                    if (checkCompulsoryFieldsOfTask != Resource1.AllColumnsPresent)
                    {
                        Console.WriteLine(checkCompulsoryFieldsOfTask);
                    }
                    else
                    {
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
            try
            {
                if (!validateTheInput.IfTechnologyIsAssignedToTask(technologyID, taskID))
                {
                    TaskTechnology objTaskTechnology = new TaskTechnology();
                    objTaskTechnology.TaskTechnologyID = technologyID;
                    objTaskTechnology.TaskID = taskID;
                    dc.TaskTechnologies.InsertOnSubmit(objTaskTechnology);
                    dc.SubmitChanges();
                }
                else
                {
                    Console.WriteLine(Resource1.TechnologyAssignedToTask);
                }
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
                if (validateTheInput.IfTaskExists(taskID)) {
                    List<TaskTechnology> taskTechnologyToBeDeletedForUpdation = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeletedForUpdation);
                    dc.SubmitChanges();
                    foreach (int technology in technologyIDs)
                    {
                        if (validateTheInput.IfTechnologyExists(technology))
                        {
                            TaskTechnology taskTechnologyToBeInsertedForUpdation = new TaskTechnology();
                            taskTechnologyToBeInsertedForUpdation.TaskID = taskID;
                            taskTechnologyToBeInsertedForUpdation.TechnologyID = technology;
                            dc.TaskTechnologies.InsertOnSubmit(taskTechnologyToBeInsertedForUpdation);
                            dc.SubmitChanges();
                        }
                        else
                        {
                            Console.WriteLine(Resource1.TechnologyMissing);
                        }

                    }
                }
                else
                {
                    Console.WriteLine(Resource1.TaskMissing);
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
            try
            {


                if (validateTheInput.IfEmployeeExists(employeeID))
                {
                    List<Employee> employeeToBeRemoved = (from Employee in dc.Employees where Employee.EmployeeID == employeeID select Employee).ToList();
                    dc.Employees.DeleteAllOnSubmit(employeeToBeRemoved);
                    List<EmployeeProject> employeeProjectToBeRemoved = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject).ToList();
                    dc.EmployeeProjects.DeleteAllOnSubmit(employeeProjectToBeRemoved);
                    List<EmployeeTask> employeeTaskToBeRemoved = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask).ToList();
                    dc.EmployeeTasks.DeleteAllOnSubmit(employeeTaskToBeRemoved);
                    dc.SubmitChanges();
                }
                else 
                {
                    Console.WriteLine(Resource1.EmployeeMissing);
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
            try
            {
                if (validateTheInput.IfTechnologyExists(technology))
                {
                    List<TaskTechnology> taskTechnologyToBeDeleted = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TechnologyID == technology select TaskTechnology).ToList();
                    dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeleted);
                    dc.SubmitChanges();

                    List<ProjectTechnology> projectTechnologyToBeDeleted = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technology select ProjectTechnology).ToList();
                    dc.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologyToBeDeleted);
                    dc.SubmitChanges();

                    List<Technology> technologyToBeDeleted = (from Technology in dc.Technologies where Technology.TechnologyID == technology select Technology).ToList();
                    dc.Technologies.DeleteAllOnSubmit(technologyToBeDeleted);
                    dc.SubmitChanges();
                }
                else 
                {
                    Console.WriteLine(Resource1.TechnologyMissing);
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
                if (validateTheInput.IfTaskExists(taskID))
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
                    Console.WriteLine(Resource1.TaskMissing);
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
                if (validateTheInput.IfProjectExists(projectID))
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
                    Console.WriteLine(Resource1.ProjectMissing);
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
