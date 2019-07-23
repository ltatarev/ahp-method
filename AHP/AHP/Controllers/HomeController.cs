using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHP.Models;
using AHP.Service.Common;

namespace AHP.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IProjectService projectService)
        {
            this.ProjectService = ProjectService;
        }
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
        public ActionResult CreateProject(Project project)
        {
            // Adding new project
            //ProjectService.insertProject(project);
            return RedirectToRoute("AddCriterion");
        }
    }
}