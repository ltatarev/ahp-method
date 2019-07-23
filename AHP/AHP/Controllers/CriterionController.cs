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
        // GET: Criterion/AddCriterion
        public ActionResult AddCriterion()
        {
            var criterion = new CriterionView()
            {
                CriteriaName = "Kriterij1"
            };

            return View();
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