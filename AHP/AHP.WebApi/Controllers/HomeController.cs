using AHP.Model.Common.Model_Interfaces;
using AHP.Models;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;




namespace AHP.Controllers
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
        public async Task<List<ProjectDto>> AllProjects(int page = 1)
        {                        
            var AllProjects = await ProjectService.GetProjects(page, 10);
            var ProjectView = _mapper.Map<List<ProjectDto>>(AllProjects);
            var count = await ProjectService.CountProjects();

            //ViewBag.current = page;
            //ViewBag.numOfProj = count;
            return ProjectView;
        }

        // POST: Home/CreateProject
        [HttpPost]
        public async Task<ProjectDto> CreateProject(ProjectDto project)
        {

            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<ProjectDto, IProjectModel>(project);
                var projectInDb = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);
                if (!(projectInDb == null))
                {
                    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
                }
                else
                {
                    mapped.ProjectId = Guid.NewGuid();
                    var status = await ProjectService.AddProjectAsync(mapped);

                    return project;
                }                
            }
            else throw new HttpResponseException(System.Net.HttpStatusCode.NotModified);
        }
    }
}