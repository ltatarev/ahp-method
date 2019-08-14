using AHP.Model.Common.Model_Interfaces;
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



        // GET:api/Home/AllProjects      
        [HttpGet]
        public async Task<List<ProjectDto>> AllProjects(int page = 1)
        {
            var allProjects = await ProjectService.GetProjects(page, 100);
            var projectDto = _mapper.Map<List<ProjectDto>>(allProjects);
            
            return projectDto;
        }
        //GET: api/Home/ChooseProject
        [HttpGet]
        public async Task<ProjectDto> ChooseProject(Guid id)
        {
            var project=  await ProjectService.GetProjectByIdAsync(id);
            return _mapper.Map<ProjectDto>(project);
        }

        //POST: api/Home/CreateProject
        [HttpPost]
        public async Task<ProjectDto> CreateProject(ProjectDto project)
        {
            project.ProjectId = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<IProjectModel>(project);
                var projectInDb = await ProjectService.CompareProjects(mapped.ProjectName, mapped.Username);
                if (!(projectInDb == null))
                {
                    throw new HttpResponseException(HttpStatusCode.Conflict);
                }
                else
                {                   
                    var status = await ProjectService.AddProjectAsync(mapped);

                    return project;
                }
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
        [HttpDelete]
        public async Task<bool> DeleteProject(Guid id)
        {
            return await ProjectService.DeleteProject(id);
        }

    }
}
