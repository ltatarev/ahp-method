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
        public async Task<ActionResult> AllProjects(int page = 1)
        {
            // Display view with first 10 projects
            int pageNum = page;
            var AllProjects = await ProjectService.GetProjects(pageNum, 10);
            var ProjectView = _mapper.Map<List<ProjectView>>(AllProjects);
            var count = await ProjectService.CountProjects();
            ViewBag.current = pageNum;
            ViewBag.numOfProj = count;
            return View(ProjectView);
        }

        // POST: Home/ChooseProject
        
        public async Task<ActionResult> ChooseProject(Guid id)
        {
            var project = await ProjectService.GetProjectsByIdWithAandC(id);
            if (project.Criterias.Count == 0)
            {
               return RedirectToAction("AddCriterion", "Criterion", new { @id = project.ProjectId });
            }
            else if (project.Criterias[0].CriteriaRanks.Count() == 0)
            {
              return  RedirectToAction("EditCriteria", "Criterion", new { @id = project.ProjectId });
            }
            else if (project.Alternatives.Count == 0)
            {
              return  RedirectToAction("AddAlternative", "Alternative", new { @id = project.ProjectId });
            }
            else if (project.Criterias[0].AlternativeRanks.Count() == 0)
            {
              return  RedirectToAction("EditAlternative", "Alternative", new { @id = project.ProjectId });
            }
            return RedirectToAction("FinalResult", "Result", new { @id = project.ProjectId });
        }

        // GET: Home/LearnMore
        public ActionResult LearnMore()
        {
            // Display LearnMore view
            return View();
        }

        // POST: Home/CreateProject
        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectView project)
        {
            Guid id = Guid.NewGuid();
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
                    mapped.ProjectId = id;
                    var status = await ProjectService.AddProjectAsync(mapped);


                    return RedirectToAction("AddCriterion", "Criterion", new { id = id });
                }
            }
            return View();
        }
    }
}