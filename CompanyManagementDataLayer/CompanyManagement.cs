using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    public class CompanyManagement
    {
        public enum Status
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }

        /* Things remaining:
         * Data validation
         * Validation on operations like update, delete*/


        

        public String CheckCumpulsoryFieldsOfProject(Project project)
        {
            
            if (project.ProjectID.Equals(null))
            {
                return Resource1.ProjectIDMissing;
            }
            else if (project.ProjectID <= 0)
            {
                return Resource1.ProjectIDNegativeOrZero;
            }
            else if (string.IsNullOrEmpty(project.ProjectName))
            {
                return Resource1.ProjectNameMissing;
            }
            else if (project.ClientID.Equals(null))
            {
                return Resource1.ClientIDForProjectMissing;
            }
            else if (project.DepartmentID.Equals(null))
            {
                return Resource1.DepartmentIDForProjectMissing;
            }
            else
            {
                return Resource1.AllCloumnsPresent;
            }
        }

        DataClasses1DataContext dc = new DataClasses1DataContext();

        public List<Project> GetAllProjects()
        {

            List<Project> listOfProjects = (from Project in dc.Projects select Project).ToList();
            return listOfProjects;
        }
        public List<Technology> GetAllTechnologies()
        {
            List<Technology> listOfTechnologies = (from Technology in dc.Technologies select Technology).ToList();
            return listOfTechnologies;
        }

        public int GetEmployeeCountForProject(int projectID)
        {
            int countOfEmployeesOfProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).Count();
            return countOfEmployeesOfProject;
        }

        public List<Employee> GetAllEmployeesForProject(int projectID)
        {
            List<Employee> listOfEmployeeFromProject = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject.Employee).ToList();
            return listOfEmployeeFromProject;
        }

        public List<Project> GetAllDelayedProjects()
        {
            List<Project> listOfDelayedProjects = (from Project in dc.Projects where Project.ProjectStatus == (int)Status.Delayed select Project).ToList();
            return listOfDelayedProjects;
        }

        public List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            List<Project> listOfProjectForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.Project).ToList();
            return listOfProjectForEmployee;
        }

        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            List<Task> listOfTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask.Task).ToList();
            return listOfTasksForEmployee;
        }

        public List<TaskTechnology> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            List<TaskTechnology> listOfTaskTechnologies = (from EmployeeTask in dc.EmployeeTasks join TaskTechnology in dc.TaskTechnologies on EmployeeTask.TaskID equals TaskTechnology.TaskID where TaskTechnology.TechnologyID == technologyID && EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
            return listOfTaskTechnologies;
        }

        public List<ProjectTechnology> GetAllTechnologyProjects(int technologyID)
        {
            List<ProjectTechnology> listOfProjectTechnologies = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.TechnologyID == technologyID select ProjectTechnology).ToList();
            return listOfProjectTechnologies;
        }

        public List<ProjectTask> GetAllActiveTasksForProject(int projectID)
        {
            List<ProjectTask> listOfActiveTasksForProject = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID && ProjectTask.ProjectTaskStatus == (int)Status.Active select ProjectTask).ToList();
            return listOfActiveTasksForProject;
        }

        public List<TaskTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            List<TaskTechnology> listOfTechnologiesForEmployee = (from TaskTechnology in dc.TaskTechnologies join EmployeeTask in dc.EmployeeTasks on TaskTechnology.TaskID equals EmployeeTask.TaskID where EmployeeTask.EmployeeID == employeeID select TaskTechnology).ToList();
            return listOfTechnologiesForEmployee;
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            int projectCountForEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject.ProjectID).Count();
            return projectCountForEmployee;
        }

        public List<EmployeeProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            List <EmployeeProject> listOfActiveProjectsManagedByEmployee = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID && EmployeeProject.Project.ProjectStatus == (int)Status.Active select EmployeeProject).ToList();
            return listOfActiveProjectsManagedByEmployee;
        }

        public List<EmployeeTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            List<EmployeeTask> listOfAllDelayedTasksForEmployee = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID && EmployeeTask.EmployeeTaskStatus == (int)Status.Delayed select EmployeeTask).ToList();
            return listOfAllDelayedTasksForEmployee;
        }

        public void AddProject(Project project)
        {

            try
            {

                Project objProject = new Project();
                // fields to be inserted
                objProject.ProjectID = project.ProjectID;
                objProject.ProjectName = project.ProjectName;
                objProject.ProjectStatus = project.ProjectStatus;
                objProject.ClientID = project.ClientID;
                objProject.DepartmentID = project.DepartmentID;
                // Insert the values to the database
                String checkProjectCumpulsoryFieldsValidation = CheckCumpulsoryFieldsOfProject(objProject);
                if (checkProjectCumpulsoryFieldsValidation != Resource1.AllCloumnsPresent)
                {
                    throw new Exception(checkProjectCumpulsoryFieldsValidation);
                }
                else
                {
                    dc.Projects.InsertOnSubmit(objProject);
                    dc.SubmitChanges();
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
            Technology objTechnology = new Technology();
            objTechnology.TechnologyID = technology.TechnologyID;
            objTechnology.TechnologyName = technology.TechnologyName;
            dc.Technologies.InsertOnSubmit(objTechnology);
            dc.SubmitChanges();

        }

        public void AddEmployee(Employee employee)
        {
            Employee objEmployee = new Employee();
            objEmployee.EmployeeID = employee.EmployeeID;
            objEmployee.EmployeeName = employee.EmployeeName;
            objEmployee.EmployeeDesignation = employee.EmployeeDesignation;
            objEmployee.EmployeeAddress = employee.EmployeeAddress;
            objEmployee.EmployeeContact = employee.EmployeeContact;
            objEmployee.DepartmentID = objEmployee.DepartmentID;
            dc.Employees.InsertOnSubmit(objEmployee);
            dc.SubmitChanges();
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
            EmployeeProject objEmployeeProject = new EmployeeProject();
            objEmployeeProject.EmployeeID = employeeID;
            objEmployeeProject.ProjectID = projectID;
            dc.EmployeeProjects.InsertOnSubmit(objEmployeeProject);
            dc.SubmitChanges();
        }
        public void CreateTaskInProject(Task task, int projectID)
        {
            ProjectTask objProjectTask = new ProjectTask();
            objProjectTask.ProjectID = projectID;
            objProjectTask.TaskID = task.TaskID;
            dc.ProjectTasks.InsertOnSubmit(objProjectTask);
            dc.SubmitChanges();
        }
        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            TaskTechnology objTaskTechnology = new TaskTechnology();
            objTaskTechnology.TaskTechnologyID = technologyID;
            objTaskTechnology.TaskID = taskID;
            dc.TaskTechnologies.InsertOnSubmit(objTaskTechnology);
            dc.SubmitChanges();
        }
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID) //Incomplete. Yet to be written.
        {
            List<TaskTechnology> taskToBeDeletedForUpdation = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
            dc.TaskTechnologies.DeleteAllOnSubmit(taskToBeDeletedForUpdation);
            dc.SubmitChanges();
            foreach (int technology in technologyIDs)
            {

                TaskTechnology taskTechnologyToBeInsertedForUpdation = new TaskTechnology();
                taskTechnologyToBeInsertedForUpdation.TaskID = taskID;
                taskTechnologyToBeInsertedForUpdation.TechnologyID = technology;
                dc.TaskTechnologies.InsertOnSubmit(taskTechnologyToBeInsertedForUpdation);
                dc.SubmitChanges();
                
            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            List<EmployeeProject> employeeProjectToBeRemoved = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.EmployeeID == employeeID select EmployeeProject).ToList();
            dc.EmployeeProjects.DeleteAllOnSubmit(employeeProjectToBeRemoved);
            dc.SubmitChanges();

            List<EmployeeTask> employeeTaskToBeRemoved = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.EmployeeID == employeeID select EmployeeTask).ToList();
            dc.EmployeeTasks.DeleteAllOnSubmit(employeeTaskToBeRemoved);
            dc.SubmitChanges();

            List<Employee> employeeToBeRemoved = (from Employee in dc.Employees where Employee.EmployeeID == employeeID select Employee).ToList();
            dc.Employees.DeleteAllOnSubmit(employeeToBeRemoved);
            dc.SubmitChanges();
        }
        public void DeleteTechnology(int technology)
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
        public void DeleteTask(int taskID)
        {
            List<EmployeeTask> employeeTaskToBeDeleted = (from EmployeeTask in dc.EmployeeTasks where EmployeeTask.TaskID == taskID select EmployeeTask).ToList();
            dc.EmployeeTasks.DeleteAllOnSubmit(employeeTaskToBeDeleted);
            dc.SubmitChanges();

            List<ProjectTask> projectTaskToBeDeleted = (from ProjectTask in dc.ProjectTasks where ProjectTask.TaskID == taskID select ProjectTask).ToList();
            dc.ProjectTasks.DeleteAllOnSubmit(projectTaskToBeDeleted);
            dc.SubmitChanges();

            List<TaskTechnology> taskTechnologyToBeDeleted = (from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology).ToList();
            dc.TaskTechnologies.DeleteAllOnSubmit(taskTechnologyToBeDeleted);
            dc.SubmitChanges();

            List<Task> taskToBeDeleted = (from Task in dc.Tasks where Task.TaskID == taskID select Task).ToList();
            dc.Tasks.DeleteAllOnSubmit(taskToBeDeleted);
            dc.SubmitChanges();
        }
        public void DeleteProject(int projectID)
        {
            List<EmployeeProject> employeeProjectToBeDeleted = (from EmployeeProject in dc.EmployeeProjects where EmployeeProject.ProjectID == projectID select EmployeeProject).ToList();
            dc.EmployeeProjects.DeleteAllOnSubmit(employeeProjectToBeDeleted);
            dc.SubmitChanges();

            List<ProjectTask> projectTaskToBeDeleted = (from ProjectTask in dc.ProjectTasks where ProjectTask.ProjectID == projectID select ProjectTask).ToList();
            dc.ProjectTasks.DeleteAllOnSubmit(projectTaskToBeDeleted);
            dc.SubmitChanges();

            List<ProjectTechnology> projectTechnologyToBeDeleted = (from ProjectTechnology in dc.ProjectTechnologies where ProjectTechnology.ProjectID == projectID select ProjectTechnology).ToList();
            dc.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologyToBeDeleted);
            dc.SubmitChanges();

            List<Project> projectToBeDeleted = (from Project in dc.Projects where Project.ProjectID == projectID select Project).ToList();
            dc.Projects.DeleteAllOnSubmit(projectToBeDeleted);
            dc.SubmitChanges();
        }


    }
}
