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
    public class CriterionController : Controller
    {
        public CriterionController(ICriteriaService criteriaService, IMapper mapper)
        {
            this._mapper = mapper;
            this.CriteriaService = criteriaService;
        }
        public IMapper _mapper { get; set; }
        public ICriteriaService CriteriaService { get; set; }

        public ActionResult AddCriterion(int projectId)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddNewCriterion(List<CriterionView> Criteria)
        {
            var mapped = _mapper.Map<List<ICriteriaModel>>(Criteria);            
            foreach (var crit in mapped)
            {
                crit.DateCreated = DateTime.Now;
                crit.DateUpdated = DateTime.Now;                                
            }
            
            var status = await CriteriaService.AddRange(mapped);

            return Json("Success");
        }

        // GET: Criterion/EditCriterion
        public ActionResult EditCriteria()
        {
            // TO DO: GET all Criteria for certain ProjectId
            // IList<CriterionView> Criteria = new List<CriterionView>();

            return View();
        }

        [HttpPost]
        public JsonResult EditCriterionPreference(List<CriteriaRankModel> CriteriaRank)
        {
            return Json("Success");
        }
    }
}