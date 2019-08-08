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
    public class ResultController : ApiController
    {
        public ResultController(IFinalResultCalculator finalResultCalculator, IProjectService projectService, IMapper mapper)
        {
            this._finalResultCalculator = finalResultCalculator;
            this._projectService = projectService;
            this._mapper = mapper;

        }
        private IProjectService _projectService;
        private IFinalResultCalculator _finalResultCalculator;
        private IMapper _mapper;


        // GET: api/Result/FinalResult
        public async Task<List<AlternativeDto>> FinalResult(Guid id)
        {
            var alternatives = await _finalResultCalculator.Calculate(id);
            var mapped = _mapper.Map<List<AlternativeDto>>(alternatives);
            return mapped;
        }
    }
}
