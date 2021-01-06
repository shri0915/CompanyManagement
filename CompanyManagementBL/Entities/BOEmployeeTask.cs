using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL.Entities
{
    public class BOEmployeeTask
    {
        public int EmployeeTaskID;
        public int EmployeeID;
        public int TaskID;
        public enum EmployeeTaskStatus
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }
        public EmployeeTaskStatus employeeTaskStatus;
    }
}
