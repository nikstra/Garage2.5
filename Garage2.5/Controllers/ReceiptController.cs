using Garage2.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage2.Controllers
{
    public class ReceiptController : Controller
    {

        // GET: Receipt
        public ActionResult Compute()
        {

            vehicle car = (vehicle)TempData["Vehicle"];
            //string membername = new Garage2.Models.VehiclesDb().Members.Where(m => m.MemberId == car.MemberId).FirstOrDefault().Name;
            ViewData["reg"] = car.RegNumber;
            ViewData["VehicleType"] = TempData["VehicleType"]; // Use a separate TempData for VehicleType.
            ViewData["Member"] = TempData["MemberName"]; // Use a separate TempData for MemberName.

            //ViewData["VehicleType"] = car.VehicleType;// here we have a problem to get this value
            //ViewData["Member"] = car.Member.Name;// here we have a problem to get this value

            DateTime startTime = car.ParkedTime;
            DateTime endTime = DateTime.Now;
            TimeSpan diff = endTime - startTime;

            var minutes = diff.TotalMinutes;

           // double hours = diff.TotalHours;
           // int hour = (int)Math.Round(hours);
            ViewData["hour"] = diff.ToString(@"dd\.hh\:mm");
            int pricePerMinute = 1;


            int cost = (int)(pricePerMinute * minutes);
            ViewData["cost"] = cost;
            if (car == null)
            {
                return HttpNotFound();
            }

            return View();
        }
    }
}