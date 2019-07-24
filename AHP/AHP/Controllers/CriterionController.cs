using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHP.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace AHP.Controllers
{
    public class CriterionController : Controller
    {
        public ActionResult AddCriterion()
        {
            return View();
        }

       [HttpPost]
        public JsonResult AddNewCriterion(CriterionView[] Criteria)
        {
            CriterionView NewCriterion = new CriterionView();
            NewCriterion.CriteriaName = Criteria[0].CriteriaName;

            var len = Criteria.Length;

            return Json(len);
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