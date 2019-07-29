using AHP.Model.Common.Model_Interfaces;
using AHP.Models;
using AHP.Service.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AHP.Controllers
{
    public class ResultController : Controller
    {
        public ResultController(IFinalResultCalculator finalResultCalculator, ICriteriaService criteriaService, IMapper mapper)
        {
            this.FinalResultCalculator = finalResultCalculator;
            this.CriteriaService = criteriaService;
            this.Mapper = mapper;
        
        }
        IFinalResultCalculator FinalResultCalculator;
        ICriteriaService CriteriaService;
        IMapper Mapper;


        // GET: Result/FinalResult
        public async Task<ActionResult> FinalResult(int id)
        {
            var alternatives = await FinalResultCalculator.Calculate(id);
            var mapped = Mapper.Map<List<AlternativeView>>(alternatives);
            return View(mapped);
        }
    }
}