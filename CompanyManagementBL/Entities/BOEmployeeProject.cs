using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOEmployeeProject
    {
        public int EmployeeProjectID;
        public int EmployeeID;
        public int ProjectID;
        public enum EmployeeRoleInProject
        {
            ProjectManager = 1,
            TeamLead = 2,
            UIDeveloper = 3,
            BackendDeveloper = 4,
            SystemManager = 5
        }
        public EmployeeRoleInProject employeeRoleInProject;
    }
}
