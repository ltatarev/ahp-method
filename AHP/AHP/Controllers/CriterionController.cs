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
        #region ctor and property
        public CriterionController(ICriteriaService criteriaService, ICriteriaRankService criteriaRankService, IMapper mapper)
        {
            this._mapper = mapper;
            this.CriteriaService = criteriaService;
            this.CriteriaRankService = criteriaRankService;
        }
        public IMapper _mapper { get; set; }
        public ICriteriaService CriteriaService { get; set; }
        public ICriteriaRankService CriteriaRankService;
        #endregion

        // GET: Criterion/AddCriterion
        public ActionResult AddCriterion(Guid id)
        {
            // Display View with form for adding Criteria
            ViewBag.id = id;
            return View();
        }

        // POST: Criterion/AddNewCriterion
        [HttpPost]
        public async Task<JsonResult> AddNewCriterion(List<CriterionView> Criteria)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaModel>>(Criteria);           
                var status = await CriteriaService.AddRange(mapped);
                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }

        }

        // GET: Criterion/EditCriterion
        public async Task<ActionResult> EditCriteria(Guid id)
        {
            var CriteriasInProject = await CriteriaService.GetCriteriasByProjectId(id, 1);
            var CriterionView = _mapper.Map<List<CriterionView>>(CriteriasInProject);
            ViewBag.id = id;
            return View(CriterionView);
        }

        // POST: Criterion/EditCriterionPreference
        [HttpPost]
        public async Task<JsonResult> EditCriterionPreference(List<CriteriaRankView> CriteriaRank)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaRankModel>>(CriteriaRank);               
                await CriteriaRankService.AddRange(mapped);
                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }
    }
}