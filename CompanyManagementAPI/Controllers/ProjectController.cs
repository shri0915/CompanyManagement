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
    public class ProjectController : ApiController
    {
        

        public List<string> GetAllProjects()
        {
            BusinessLayer businessLayer = new BusinessLayer();
            List<string> projectNames = new List<string>();
            foreach (BOProject project in businessLayer.GetAllProjects())
            {
                projectNames.Add(project.ProjectName);
            }
            return projectNames;
        }
    }
}
