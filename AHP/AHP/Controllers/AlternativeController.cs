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
        public ActionResult AddAlternative()
        {
            // Display View with form for adding Alternatives
            return View();

        }

        // GET: Alterntive/EditAlternative
        public ActionResult EditAlternative()
        {
            // TO DO: GET all Alternatives for projectId
            return View();
        }

        // POST: Alterntive/AddNewAlternative
        [HttpPost]
        public async Task<JsonResult> AddNewAlternative(List<AlternativeView> alternatives)
        {
            var order = 1;
            var mapped = _mapper.Map<List<IAlternativeModel>>(alternatives);
            foreach (var alter in mapped)
            {
                alter.DateCreated = DateTime.Now;
                alter.DateUpdated = DateTime.Now;
                alter.Order = order;
                order++;
                // 2 ??
                alter.ProjectId = 2;
            }

            var status = await AlternativeService.AddRange(mapped);

            return Json("Success");
        }
    }
}