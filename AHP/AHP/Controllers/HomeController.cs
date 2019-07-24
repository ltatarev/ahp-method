using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AHP.Model.Common.Model_Interfaces;
using AHP.Model.Models;
using AHP.Models;
using AHP.Service.Common;
using AutoMapper;

namespace AHP.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
        public HomeController(IProjectService ProjectService)
=======
        public HomeController(IProjectService projectService, IMapper mapper)
>>>>>>> d4f461b96a13e0c0e18feaa201f3f9f307120666
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
        public async Task<ActionResult> CreateProject(Project project)
<<<<<<< HEAD
        {
            // Adding new project
            await ProjectService.AddProjectAsync(project);
=======
        {            
            var mapped = _mapper.Map<Project,IProjectModel>(project);
            mapped.DateCreated = DateTime.Now;
            mapped.DateUpdated = DateTime.Now;
            mapped.Description = "default";            

            var status = await ProjectService.AddProjectAsync(mapped);            
>>>>>>> d4f461b96a13e0c0e18feaa201f3f9f307120666
            return RedirectToRoute("AddCriterion");
        }
    }
}