using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik

        Context context = new Context();
        public ActionResult Index()
        {
            var value = context.Categories.Count();
            var value2 = context.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            var value3 = context.Writers.Count(x => x.WriterName.Contains("a"));
            var value4 = context.Headings.Max(x => x.Category.CategoryName);
            var value5 = context.Categories.Count(x => x.CategoryStatus == true);
            var value6 = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.CategoryCount = value;
            ViewBag.Heading = value2;
            ViewBag.Writer = value3;
            ViewBag.HeadingMax = value4;
            ViewBag.StatusFark = (value5 - value6);

            return View();
        }
    }
}