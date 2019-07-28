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

        // GET: Home/Index
        public ActionResult Index()
        {
            // Display Index view
            return View();
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            // Display view for adding new project
            return View();
        }

        // GET: Home/AllProjects
        // public async Task<ActionResult> AllProjects()
        public ActionResult AllProjects()
        {
            // Display view with first 10 projects
           // int pageNum = 1;
           // var AllProjects = await ProjectService.GetProjects(pageNum, 10);
           // var ProjectView = _mapper.Map<List<CriterionView>>(AllProjects);
            return View();
        }

        // GET: Home/LearnMore
        public ActionResult LearnMore()
        {
            // Display LearnMore view
            return View();
        }

        // POST: Home/CreateProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProject(ProjectView project)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<ProjectView, IProjectModel>(project);
                var projectInDb = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);
                if (!(projectInDb == null))
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Project already exists!');window.location.href='/Home/Login';</script>");
                }
                else
                {
                    mapped.DateCreated = DateTime.Now;
                    mapped.DateUpdated = DateTime.Now;
                    var status = await ProjectService.AddProjectAsync(mapped);
                    var pro = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);

                    return RedirectToAction("AddCriterion", "Criterion", new { id = pro.ProjectId });
                }
            }
            return View();
        }
    }
}