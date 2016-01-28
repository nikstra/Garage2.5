using Garage2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class FindCarController : Controller
    {
        // GET: FindCar
        public ActionResult Index(string reg)
        {
            ViewData["reg"] = reg;
            VehiclesDb db = new VehiclesDb();
            var car = from c in db.vehicles  select c;
            if (!string.IsNullOrEmpty(reg))
            {
                car = car.Where(c => c.RegNumber.Contains(reg));
            }
            return View(car);
        }
    }
}