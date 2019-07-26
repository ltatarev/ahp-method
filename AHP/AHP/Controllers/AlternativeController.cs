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

        public AlternativeController(IAlternativeService alternativeService, IMapper mapper)
        {
            this.AlternativeService = alternativeService;
            this._mapper = mapper;
        }
        IAlternativeService AlternativeService;
        IMapper _mapper;

        // GET: Alterntive/AddAlternative
        public ActionResult AddAlternative(int id)
        {
            // Display View with form for adding Alternatives
            ViewBag.id = id;
            return View();
        }

        // GET: Alterntive/EditAlternative
        public ActionResult EditAlternative(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Alterntive/AddNewAlternative
        [HttpPost]
        public async Task<JsonResult> AddNewAlternative(List<AlternativeView> alternatives, int id)
        {
            var order = 1;
            var mapped = _mapper.Map<List<IAlternativeModel>>(alternatives);
            foreach (var alter in mapped)
            {
                alter.DateCreated = DateTime.Now;
                alter.DateUpdated = DateTime.Now;
                alter.Order = order;
                order++;
                alter.ProjectId = id;
            }

            var status = await AlternativeService.AddRange(mapped);

            return Json("Success");
        }

        // POST: Alternative/EditAlternativePreference
        [HttpPost]
        public JsonResult EditAlternativePreference(List<AlternativeRankView> Alternative)
        {
            return Json("Success");
        }
    }
}