using AHP.Models.Dto;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AHP.Controllers.api
{
    public class HomeController : ApiController
    {
        public HomeController(IProjectService projectService, IMapper mapper)
        {
            this._mapper = mapper;
            this.ProjectService = projectService;
        }
        protected IMapper _mapper { get; set; }
        protected IProjectService ProjectService { get; set; }



        // GET: Home/AllProjects      
        [HttpGet]
        public async Task<List<ProjectDto>> AllProjects(int page = 1)
        {
            var AllProjects = await ProjectService.GetProjects(page, 100);
            var ProjectView = _mapper.Map<List<ProjectDto>>(AllProjects);
            var count = await ProjectService.CountProjects();

            //ViewBag.current = page;
            //ViewBag.numOfProj = count;
            return ProjectView;
        }

        [HttpGet]
        public ProjectDto Project()
        {
            var pro = new ProjectDto();
            pro.Description = "opisnik";
            pro.ProjectName = "ime proijekta";

            return pro;
        }
    }
}
