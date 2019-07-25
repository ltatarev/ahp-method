using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using AHP.Model.Common.Model_Interfaces;
using AHP.Model.Models;
using AHP.Models;
using AHP.Service.Common;
using AutoMapper;

namespace AHP.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IProjectService projectService, IMapper mapper)
        {
            this._mapper = mapper;
            this.ProjectService = projectService;
        }
        public IMapper _mapper { get; set; }
        public IProjectService ProjectService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AllProjects()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectView project)
        {
            
            var mapped = _mapper.Map<ProjectView,IProjectModel>(project);
            var projectInDb = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);
            if (!(projectInDb == null))
            {
                return Json("Ima vec takav project");
            }
            else
            {
                mapped.DateCreated = DateTime.Now;
                mapped.DateUpdated = DateTime.Now;
                var status = await ProjectService.AddProjectAsync(mapped);
                var pro = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);
                
                return RedirectToAction("AddCriterion", "Criterion", new {projectId = pro.ProjectId });
            }
        }
    }
}