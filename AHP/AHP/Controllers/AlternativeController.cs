using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AHP.Models;

namespace AHP.Controllers
{
    public class AlternativeController : Controller
    {
        // GET: Alterntive/AddAlternative
        public ActionResult AddAlternative()
        {
            var alternative = new AlternativeView()
            {
                AlternativeName = "alternativa 1"
            };

            return View(alternative);
        }

        // GET: Alterntive/EditAlternative
        public ActionResult EditAlternative()
        {
            var alternative = new AlternativeView()
            {
                AlternativeName = "alternativa 2"
            };

            return View(alternative);
        }
    }
}