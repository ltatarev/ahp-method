using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AHP.Model.Common.Model_Interfaces;
using AHP.Models;
using AHP.Service.Common;
using AutoMapper;

namespace AHP.Controllers
{
    public class AlternativeController : Controller
    {
        #region ctor and properties
        public AlternativeController(IAlternativeService alternativeService,
                                    ICriteriaService criteriaService,
                                    IAlternativeRankService alternativeRankService,
                                    IMapper mapper)
        {
            this._alternativeService = alternativeService;
            this._criteriaService = criteriaService;
            this._alternativeRankService = alternativeRankService;
            this._mapper = mapper;
        }
        ICriteriaService _criteriaService;
        IAlternativeService _alternativeService;
        IAlternativeRankService _alternativeRankService;
        IMapper _mapper;
        #endregion

        // GET: Alterntive/AddAlternative
        public ActionResult AddAlternative(Guid id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: Alterntive/EditAlternative
        public async Task<ActionResult> EditAlternative(Guid id)
        {
            ViewBag.id = id;
            var alternatives = await _alternativeService.GetAlternativesByProjectId(id, 1);
            var criterias = await _criteriaService.GetCriteriasByProjectId(id, 1);

            var criteriaAlternativeView = new CriteriaAlternativeView();

            var mappedAlternatives = _mapper.Map<IList<AlternativeView>>(alternatives);
            var mappedCriterias = _mapper.Map<IList<CriterionView>>(criterias);

            criteriaAlternativeView.Alternatives = mappedAlternatives;
            criteriaAlternativeView.Criterias = mappedCriterias;

            return View(criteriaAlternativeView);

        }

        // POST: Alterntive/AddNewAlternative
        [HttpPost]
        public async Task<JsonResult> AddNewAlternative(List<AlternativeView> alternatives)
        {
            if (ModelState.IsValid)
            {                
                var mapped = _mapper.Map<List<IAlternativeModel>>(alternatives);
                
                var status = await _alternativeService.AddRange(mapped);

                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }

        // POST: Alternative/EditAlternativePreference
        [HttpPost]
        public async Task<JsonResult> EditAlternativePreference(List<AlternativeRankView> alternative)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<IAlternativeRankModel>>(alternative);
                
                await _alternativeRankService.AddRange(mapped);
                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }
    }
}