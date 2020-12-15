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
            
            Project objProject = new Project();
            // fields to be inserted
            objProject.ProjectID = project.ProjectID;
            objProject.ProjectName = project.ProjectName;
            objProject.ProjectStatus = project.ProjectStatus;
            objProject.ClientID = project.ClientID;
            objProject.DepartmentID = project.DepartmentID;
            // Insert the values to the database
            dc.Projects.InsertOnSubmit(objProject);
            dc.SubmitChanges();
                       
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
            TaskTechnology taskToBeUpdated = new TaskTechnology();
            taskToBeUpdated = (TaskTechnology)(from TaskTechnology in dc.TaskTechnologies where TaskTechnology.TaskID == taskID select TaskTechnology);
            foreach (var technology in technologyIDs)
            {

                taskToBeUpdated.TaskTechnologyID = technology;
                dc.TaskTechnologies.InsertOnSubmit(taskToBeUpdated);
                dc.SubmitChanges();
            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            Employee employeeToBeRemoved = new Employee();
            employeeToBeRemoved = (Employee)(from Employee in dc.Employees where Employee.EmployeeID == employeeID select Employee);
            dc.Employees.DeleteOnSubmit(employeeToBeRemoved);
            dc.SubmitChanges();
        }
        public void DeleteTechnology(int technology)
        {
            Technology technologyToBeDeleted = new Technology();
            technologyToBeDeleted = (Technology)(from Technology in dc.Technologies where Technology.TechnologyID == technology select Technology);
            dc.Technologies.DeleteOnSubmit(technologyToBeDeleted);
            dc.SubmitChanges();
        }
        public void DeleteTask(int taskID)
        {
            Task taskToBeDeleted = new Task();
            taskToBeDeleted = (Task)(from Task in dc.Tasks where Task.TaskID == taskID select Task);
            dc.Tasks.DeleteOnSubmit(taskToBeDeleted);
            dc.SubmitChanges();
        }
        public void DeleteProject(int projectID)
        {
            Project projectToBeDeleted = new Project();
            projectToBeDeleted = (Project)(from Project in dc.Projects where Project.ProjectID == projectID select Project);
            dc.Projects.DeleteOnSubmit(projectToBeDeleted);
            dc.SubmitChanges();
        }


    }
}
