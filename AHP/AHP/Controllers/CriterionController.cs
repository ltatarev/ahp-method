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
        public CriterionController(ICriteriaService criteriaService, ICriteriaRankService criteriaRankService, IMapper mapper)
        {
            this._mapper = mapper;
            this.CriteriaService = criteriaService;
            this.CriteriaRankService = criteriaRankService;
        }
        public IMapper _mapper { get; set; }
        public ICriteriaService CriteriaService { get; set; }
        public ICriteriaRankService CriteriaRankService;

        // GET: Criterion/AddCriterion
        public ActionResult AddCriterion(int projectId)
        {
            // Display View with form for adding Criteria
            ViewBag.id = projectId;
            return View();
        }

        // GET: Criterion/AddNewCriterion
        [HttpPost]
        public async Task<JsonResult> AddNewCriterion(List<CriterionView> Criteria)
        {
            var mapped = _mapper.Map<List<ICriteriaModel>>(Criteria);
            var order = 1;
            foreach (var crit in mapped)
            {
                crit.DateCreated = DateTime.Now;
                crit.DateUpdated = DateTime.Now;
                crit.Order = order;
                order++;
            }
            
            var status = await CriteriaService.AddRange(mapped);

            return Json("Success");
        }

        // GET: Criterion/EditCriterion
        public async Task<ActionResult> EditCriteria(int id)
        {
            // TO DO: GET all Criteria for certain ProjectId
            // IList<CriterionView> Criteria = new List<CriterionView>();
            // projectId??

            var CriteriasInProject = await CriteriaService.GetCriteriasByProjectId(id, 1);

            return View();
        }

        // POST: Criterion/EditCriterionPreference
        [HttpPost]
        public async Task<JsonResult> EditCriterionPreference(List<CriteriaRankView> CriteriaRank)
        {
            var mapped = _mapper.Map<List<ICriteriaRankModel>>(CriteriaRank);
            foreach(var cr in mapped)
            {
                cr.DateCreated = DateTime.Now;
                cr.DateUpdated = DateTime.Now;                
            }
            await CriteriaRankService.AddRange(mapped);

            return Json("Success");
        }
    }
}