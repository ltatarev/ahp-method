using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHP.Models;

namespace AHP.Controllers
{
    public class CriterionController : Controller
    {
        public ActionResult AddCriterion()
        {
            return View();
        }

       [HttpPost]
        public JsonResult AddNewCriterion(List<CriterionView> Criteria)
        {
            CriterionView NewCriterion = new CriterionView();
            NewCriterion.CriteriaName = Criteria[0].CriteriaName;

            

            return Json(1);
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