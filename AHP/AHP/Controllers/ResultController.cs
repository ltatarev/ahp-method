using AHP.Model.Common.Model_Interfaces;
using AHP.Service.Common;
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
        public ResultController(IFinalResultCalculator finalResultCalculator, ICriteriaService criteriaService)
        {
            this.FinalResultCalculator = finalResultCalculator;
            this.CriteriaService = criteriaService;
        }
        IFinalResultCalculator FinalResultCalculator;
        ICriteriaService CriteriaService;


        // GET: Result/FinalResult
        public async Task<ActionResult> FinalResult(int id)
        {
            var a = await FinalResultCalculator.Calculate(id);
            
            return View();
        }
    }
}