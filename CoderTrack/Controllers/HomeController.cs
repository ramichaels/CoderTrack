using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoderTrack.Models;

namespace CoderTrack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoderModel coder = new CoderModel();
            coder.FirstName = "Rick";
            coder.LastName = "Michaels";
            coder.EmailAddress = "rmichaels@rjandassociatescoding.com";

            string yourEncodedHtml = "<h1>Boo!</h1>";
            var html = new MvcHtmlString(yourEncodedHtml);
            ViewBag.HTMLMessage = html;
            return View(coder);

        }

        public ActionResult About()
        {
            ViewBag.Message = "RJ and Associates Health Management Solutions";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
    }
}