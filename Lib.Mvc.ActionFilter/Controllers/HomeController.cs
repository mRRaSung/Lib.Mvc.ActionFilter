using Lib.Mvc.ActionFilter.ActionFilters;
using Lib.Mvc.ActionFilter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lib.Mvc.ActionFilter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.ServerAndClient)]
        //[OutputCache(CacheProfile = "5_SEC")]
        //[AjaxOnly, BlockIFrame, PreventGoBack]
        //[Message]
        //[ETag]

        //[Whitespace]
        [Compress]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            AboutViewModel model = new AboutViewModel
            {
                Subject = "Setting OutputCache 5 secs",
                Description = "OutputCacheLocation.Any",
                CacheTime = DateTime.Now
            };

            return View(model);
        }

        [ActionTimer]
        public ActionResult Timer()
        {
            //Tranditional
            //System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            //timer.Start();
            //System.Threading.Thread.Sleep(3000);
            //timer.Stop();
            //TimeSpan ts = timer.Elapsed;


            //By ActionFilter
            System.Threading.Thread.Sleep(3000);


            return View();
        }

        [ActionTimer]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            System.Threading.Thread.Sleep(1000);

            return View();
        }
    }
}