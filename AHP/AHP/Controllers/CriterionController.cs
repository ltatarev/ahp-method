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

        public ActionResult AddCriterion()
        {
            return View();
        }

       [HttpPost]
        public async Task<JsonResult> AddNewCriterion(List<CriterionView> Criteria)
        {
            var mapped = _mapper.Map<CriterionView, ICriteriaModel>(Criteria[0]);
            mapped.DateCreated = DateTime.Now;
            mapped.DateUpdated = DateTime.Now;

            var status = await CriteriaService.AddCriteriaAsync(mapped);

            return Json("Success");
        }

        // GET: Criterion/EditCriterion
        public ActionResult EditCriteria()
        {
            var criterion = new CriterionView()
            {
                CriteriaName = "Kriterij1"
            };

            return View(criterion);
        }
    }
}