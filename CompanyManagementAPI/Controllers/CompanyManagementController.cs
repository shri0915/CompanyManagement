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

        public List<BOProject> GetAllProjects()
        {
            return this.businessLayer.GetAllProjects();
        }
    }
}
