using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeHire.Models;

namespace BikeHire.Controllers
{
    public class BikesMVCController : Controller
    {
        private BikeHireContext db = new BikeHireContext();

        // GET: BikesMVC
        public ActionResult Index(string sortOrder, string searchString)
        {
        //Add Filtering
        ViewBag.NameSortParmMake = String.IsNullOrEmpty(sortOrder) ? "make_ascending" : "";
        ViewBag.NameSortParmModel = String.IsNullOrEmpty(sortOrder) ? "model_ascending" : "";

            var bikes = from s in db.Bikes
                    select s;
                    //Add a Search Box to the Hire View  (Search by First or Surname)
            if (!String.IsNullOrEmpty(searchString))
            {
                bikes = bikes.Where(s => s.Make.ToUpper().Contains(searchString.ToUpper())
                                            ||
                                         s.Model.ToUpper().Contains(searchString.ToUpper())); ;
            }switch (sortOrder)
            {
                case "make_ascending":
                    bikes = bikes.OrderBy(s => s.Make);
                    break;
                case "model_ascending":
                    bikes = bikes.OrderBy(s => s.Model);
                    break;
                default:
                    bikes = bikes.OrderBy(s => s.BikeID);
                    break;
            }
            return View(bikes.ToList());
        }


        /*
                 //CG: 07/04/17 Original colde before Filtering
                // GET: BikesMVC
                public async Task<ActionResult> Index()
                {
                    return View(await db.Bikes.ToListAsync());
                }


        */


        // GET: BikesMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: BikesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikesMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Make,Model,RentalChargePerDay,BikeAvailable")] Bike bike) //CG: Removed BikeID from list
        {

            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bike);
        }

        // GET: BikesMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: BikesMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BikeID,Make,Model,RentalChargePerDay,BikeAvailable")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        // GET: BikesMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: BikesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            db.Bikes.Remove(bike);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
