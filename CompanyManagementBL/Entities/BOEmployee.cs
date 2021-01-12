using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;

namespace CompanyManagementBL.Entities
{
    public class BOEmployee
    {
        public int EmployeeID;
        public string EmployeeName;
        public string EmployeeDesignation;
        public string EmployeeAddress;
        public string EmployeeContact;
        public Department Department;
        public Project Project;
        public CompanyManagementDataLayer.Task Task;
        public EnumClass employeeRoleInProject;
        public EnumClass employeeTaskStatus;

    }
}
