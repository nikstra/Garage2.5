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
            ViewData["reg"] = car.RegNumber;
            ViewData["brand"] = car.VehicleTypeId;

            DateTime startTime = car.ParkedTime;
            DateTime endTime = DateTime.Now;
            TimeSpan diff = endTime - startTime;

            var minutes = diff.TotalMinutes;

            double hours = diff.TotalHours;
            int hour = (int)Math.Round(hours);
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