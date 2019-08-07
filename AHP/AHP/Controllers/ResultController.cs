using AHP.Models;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AHP.Controllers
{
    public class ResultController : Controller
    {
        public ResultController(IFinalResultCalculator finalResultCalculator,IProjectService projectService, IMapper mapper)
        {
            this._finalResultCalculator = finalResultCalculator;
            this._projectService = projectService;            
            this._mapper = mapper;
        
        }
        private IProjectService _projectService;
        private IFinalResultCalculator _finalResultCalculator;
        private IMapper _mapper;


        // GET: Result/FinalResult
        public async Task<ActionResult> FinalResult(Guid id)
        {            
            var alternatives = await _finalResultCalculator.Calculate(id);
            var mapped = _mapper.Map<List<AlternativeView>>(alternatives);
            return View(mapped);
        }
    }
}