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
            this.AlternativeService = alternativeService;
            this.CriteriaService = criteriaService;
            this.AlternativeRankService = alternativeRankService;
            this._mapper = mapper;
        }
        ICriteriaService CriteriaService;
        IAlternativeService AlternativeService;
        IAlternativeRankService AlternativeRankService;
        IMapper _mapper;
        #endregion

        // GET: Alterntive/AddAlternative
        public ActionResult AddAlternative(Guid id)
        {
            // Display View with form for adding Alternatives
            ViewBag.id = id;
            return View();
        }

        // GET: Alterntive/EditAlternative
        public async Task<ActionResult> EditAlternative(Guid id)
        {
            ViewBag.id = id;
            var alternatives = await AlternativeService.GetAlternativesByProjectId(id, 1);
            var criterias = await CriteriaService.GetCriteriasByProjectId(id, 1);

            var CriteriaAlternativeView = new CriteriaAlternativeView();

            var MappedAlternatives = _mapper.Map<IList<AlternativeView>>(alternatives);
            var MappedCriterias = _mapper.Map<IList<CriterionView>>(criterias);

            CriteriaAlternativeView.Alternatives = MappedAlternatives;
            CriteriaAlternativeView.Criterias = MappedCriterias;

            return View(CriteriaAlternativeView);

        }

        // POST: Alterntive/AddNewAlternative
        [HttpPost]
        public async Task<JsonResult> AddNewAlternative(List<AlternativeView> alternatives)
        {
            if (ModelState.IsValid)
            {
                
                var mapped = _mapper.Map<List<IAlternativeModel>>(alternatives);
                //var order = 1;
                //foreach (var alter in mapped)
                //{
                //    alter.DateCreated = DateTime.Now;
                //    alter.DateUpdated = DateTime.Now;
                //    alter.Order = order;
                //    order++;
                //    alter.ProjectId = id;
                //}

                var status = await AlternativeService.AddRange(mapped);

                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }

        // POST: Alternative/EditAlternativePreference
        [HttpPost]
        public async Task<JsonResult> EditAlternativePreference(List<AlternativeRankView> Alternative)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<List<IAlternativeRankModel>>(Alternative);
                foreach (var arv in mapped)
                {
                    arv.DateCreated = DateTime.Now;
                    arv.DateUpdated = DateTime.Now;

                }
                await AlternativeRankService.AddRange(mapped);
                return Json("Success");
            }
            else
            {
                return Json("Failure");
            }
        }
    }
}