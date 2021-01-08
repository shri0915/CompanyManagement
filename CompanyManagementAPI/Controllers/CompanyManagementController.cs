using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompanyManagementBL;
using CompanyManagementBL.Entities;


namespace CompanyManagementAPI.Controllers
{
    public class CompanyManagementController : ApiController
    {
        private BusinessLayer businessLayer;

        public CompanyManagementController()
        {
            this.businessLayer = new BusinessLayer();
        }

        public List<String> GetAllProjects()
        {
            List<String> projectNames = new List<string>();
            foreach (BOProject project in this.businessLayer.GetAllProjects())
            {
                
                projectNames.Add(project.ProjectName);
            }
            return projectNames;
        }
    }
}
