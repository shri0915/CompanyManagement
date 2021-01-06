using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBL
{
    public class BLConstraints
    {
        public int maxNumberOfTaskTechnology = 4;
        public int minNumberOfProjectsUsingTechnologies = 2;
        public int maxNumberOfProjectsForEmployee = 2;
        public int maxNumberOfProjectsManagedByEmployee = 3;
    }
}
