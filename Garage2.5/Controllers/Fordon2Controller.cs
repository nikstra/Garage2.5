using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;

namespace Garage2.Controllers
{
    public class Fordon2Controller : Controller
    {
        private VehiclesDb db = new VehiclesDb();

        // GET: Fordon2
        public ViewResult Index(string sortOrder, string searchString)
        {
            //var vehicles = db.vehicles.Include(v => v.Member).Include(v => v.VehicleType);
            //return View(vehicles.ToList());

    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
    ViewBag.DateSortParm = sortOrder == "Parkeringstid" ? "date_desc" : "Parkeringstid";
    var vehicles = db.vehicles.Include(v => v.Member).Include(v => v.VehicleType);
                 
    if (!String.IsNullOrEmpty(searchString))
    {
        vehicles = vehicles.Where(s => s.RegNumber.Contains(searchString) || s.Member.Name.Contains(searchString) || s.VehicleType.Type.Contains(searchString));
    }
    switch (sortOrder)
    {
        case "Member":
            vehicles = vehicles.OrderByDescending(s => s.Member.Name);
            break;
        case "Parkeringstid":
            vehicles = vehicles.OrderBy(s => s.ParkedTime);
            break;
        case "date_desc":
            vehicles = vehicles.OrderByDescending(s => s.ParkedTime);
            break;
        case "VehicleType":
            vehicles = vehicles.OrderByDescending(s => s.VehicleType.Type );
            break;
        default:
            vehicles = vehicles.OrderBy(s => s.RegNumber );
            break;
    }

    return View(vehicles.ToList());
}
        

        // GET: Fordon2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Fordon2/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "Type");
            return View();
        }

        // POST: Fordon2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNumber,Colour,VehicleTypeId,MemberId,Model,Wheels,ParkedTime")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.ParkedTime = DateTime.Now;
                db.vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Fordon2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Fordon2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Colour,VehicleTypeId,MemberId,Model,Wheels,ParkedTime")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "VehicleTypeId", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Fordon2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Fordon2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            TempData["Vehicle"] = vehicle;
            TempData["VehicleType"] = vehicle.VehicleType.Type; // Sub query for VehicleType before the vehicle is deleted.
            TempData["MemberName"] = vehicle.Member.Name; // Sub query for Member before the vehicle is deleted.
        
            db.vehicles.Remove(vehicle); // Moved this line to after TempData assignment.
            db.SaveChanges();
            
            return RedirectToAction("../Receipt/Compute");
           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
