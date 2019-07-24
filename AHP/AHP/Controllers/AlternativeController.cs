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
<<<<<<< Updated upstream
            var alternative = new AlternativeView()
=======
<<<<<<< Updated upstream
            var alternative = new Alternative()
>>>>>>> Stashed changes
            {
                AlternativeName = "alternativa 1"
            };

            return View(alternative);
=======
            return View();
>>>>>>> Stashed changes
        }

        // GET: Alterntive/EditAlternative
        public ActionResult EditAlternative()
        {
<<<<<<< Updated upstream
            var alternative = new AlternativeView()
=======
<<<<<<< Updated upstream
            var alternative = new Alternative()
>>>>>>> Stashed changes
            {
                AlternativeName = "alternativa 2"
            };

            return View(alternative);
=======
            return View();
>>>>>>> Stashed changes
        }
    }
}