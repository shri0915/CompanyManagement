using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL
{
    public class EnumClass
    {
        public enum EmployeeRoleInProject
        {
            ProjectManager = 1,
            TeamLead = 2,
            UIDeveloper = 3,
            BackendDeveloper = 4,
            SystemManager = 5
        }
        public EmployeeRoleInProject employeeRoleInProject;

        public enum Status
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }
        public Status status;
    }
}
