using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHP.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result/FinalResult
        public ActionResult FinalResult(int id)
        {
              // id = projectId
            return View();
        }
    }
}