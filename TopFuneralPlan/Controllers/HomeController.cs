using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopFuneralPlan.Models;
using WebSeearchMediaService;

namespace TopFuneralPlan.Controllers
{
    public class HomeController : Controller
    {
        private readonly CaptureService _captureService = new CaptureService();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FilterModel model)
        {
            if (ModelState.IsValid)
            {
               
                var Dob = DateTime.Parse(SqlDateTime.MinValue.ToString());
                if (model.Day != 0 && model.Month != 0 && model.Year != 0)
                {
                    var daysOfMonth = DateTime.DaysInMonth(model.Year, model.Month);
                    if (daysOfMonth < model.Day)
                    {
                        model.Day = daysOfMonth;
                    }
                    Dob = new DateTime(model.Year, model.Month, model.Day);
                }
                FuneralLead lead = new FuneralLead()
                {
                    Address = model.Address,
                    City = string.Empty,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    GeneratedDateTime = DateTime.Now,
                    HomePhone = model.HomePhone,
                    Source = Session["Source"] as string ?? null,
                    Keyword = Session["Keyword"] as string ?? null,
                    MatchType = Session["Match"] as string ?? null,
                    IpAddress = Session["RemoteIPAddress"] as string ?? null,
                    LastName = model.LastName,
                    PostCode = model.PostCode,
                    ProductName = "Funeral",
                    SiteId = 2,
                    Status = "New",
                    Title = model.Title,
                    WorkPhone = model.HomePhone ?? model.WorkPhone,
                   
                   
                    DOB = Dob,
                    Age = CalculateAge(Dob)

                };

               // var id = _captureService.NewAdminLeadCapture(lead, "http://localhost:3431/dataConverstion/capture");

                var id = _captureService.NewAdminLeadCapture(lead, "https://api.websearchmedia.co.uk/dataConverstion/capture");
                //  var id = _captureService.NewAdminLeadCapture(lead, "");
                if (id > 0)
                {
                    TempData["LeadId"] = id;

                }
                else
                {

                }
                ThankModel tmodel = new ThankModel()
                {
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName

                };
                TempData["thank"] = tmodel;

                return RedirectToAction("Index", "Thank");
            }
            return View();
        }
        public static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;
            int age = DateTime.Now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
            return age;
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult BurialPlan()
        {
            return View();
        }
        public ActionResult FuneralCosts()
        {
            return View();
        }
        public ActionResult Over50sFuneralPlan()
        {
            return View();
        }
        public ActionResult FuneralInsurance()
        {
            return View();
        }
        public ActionResult FuneralCover()
        {
            return View();

        }
        public ActionResult FuneralPlan()
        {
            return View();
        }
    }
}