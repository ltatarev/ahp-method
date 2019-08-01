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
            this._criteriaService = criteriaService;
            this._criteriaRankService = criteriaRankService;
        }
        private IMapper _mapper { get; set; }
        private ICriteriaService _criteriaService { get; set; }
        private ICriteriaRankService _criteriaRankService;
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
        public async Task<JsonResult> AddNewCriterion(List<CriterionView> criteria)
        {
            
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaModel>>(criteria);           
                var status = await _criteriaService.AddRange(mapped);
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
            var criteriasInProject = await _criteriaService.GetCriteriasByProjectId(id, 1);
            var criterionView = _mapper.Map<List<CriterionView>>(criteriasInProject);
            ViewBag.id = id;
            return View(criterionView);
        }

        // POST: Criterion/EditCriterionPreference
        [HttpPost]
        public async Task<JsonResult> EditCriterionPreference(List<CriteriaRankView> criteriaRank)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<ICriteriaRankModel>>(criteriaRank);               
                await _criteriaRankService.AddRange(mapped);
                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }
    }
}