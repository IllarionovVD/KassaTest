using KassaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KassaTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }


        public ActionResult Calculations(CreditInfo creditInfo)
        {
            if (creditInfo.Sum <= 0 || creditInfo.Period <= 0 || creditInfo.Percent <= 0 || creditInfo.TimeStep <= 0)
            {
                TempData["ErrorMessage"] = "Все поля должны быть заполнены положительными числами";
                return RedirectToAction("Index");
            }

            CalculationsResult result = creditInfo.Calculate();
            return View(result);
        }

    }
}