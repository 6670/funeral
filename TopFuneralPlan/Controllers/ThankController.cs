using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopFuneralPlan.Models;

namespace TopFuneralPlan.Controllers
{
    public class ThankController : Controller
    {
        // GET: Thank
        public ActionResult Index()
        {
            ThankModel model = new ThankModel();
        
            if (TempData.ContainsKey("thank"))
            {
                model = TempData["thank"] as ThankModel;
                return View(model);

            }
            return RedirectToAction("index", "Home");
        }
    }
}