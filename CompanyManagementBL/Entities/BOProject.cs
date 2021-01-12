using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagementDataLayer;

namespace CompanyManagementBL.Entities
{
    public class BOProject
    {
        public int ProjectID;
        public string ProjectName;
        public EnumClass.Status projectStatus;
        public CompanyManagementDataLayer.Task Task;
        public Client Client;
        public Department Department;
        public Technology Technology;
    }
}
