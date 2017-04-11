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

//System.Web.UI.WebControls.DropDownList 
using System.Data.Entity.Infrastructure; 

namespace BikeHire.Controllers
{
    public class HiresMVCController : Controller
    {
        private BikeHireContext db = new BikeHireContext();

        // GET: HiresMVC
        public ActionResult Index(string sortOrder, string searchString)
        {
//Add Filtering
            ViewBag.NameSortParmFirstName = String.IsNullOrEmpty(sortOrder) ? "firstname_ascending" : "";
            ViewBag.NameSortParmLastName = String.IsNullOrEmpty(sortOrder) ? "lastname_ascending" : "";
            ViewBag.DateSortParmStartDate = sortOrder == "Date" ? "startdate_desc" : "";

            var hires = from s in db.Hires
                        select s;
//Add a Search Box to the Hire View  (Search by First or Surname)
            if (!String.IsNullOrEmpty(searchString))
            {
                hires = hires.Where(s => s.Surname.ToUpper().Contains(searchString.ToUpper())
                                            ||
                                         s.FirstName.ToUpper().Contains(searchString.ToUpper()));                    ;
            }

            switch (sortOrder)
            {
                case "firstname_ascending":
                    hires = hires.OrderBy(s => s.FirstName);
                    break;
                case "lastname_ascending":
                    hires = hires.OrderBy(s => s.Surname);
                    break;
                case "startdate_desc":
                    hires = hires.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    hires = hires.OrderBy(s => s.HireID);
                    break;
            }


                     //Original code before doing Rental Calculation
                     return View(hires.ToList());
        }

/*
         //CG: 07/04/17 Original colde before Filtering

        // GET: HiresMVC
        public async Task<ActionResult> Index()
        {
            var hires = db.Hires.Include(h => h.Bike);
            return View(await hires.ToListAsync());
        }
*/

        // GET: HiresMVC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hire hire = await db.Hires.FindAsync(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        // GET: HiresMVC/Create
        public ActionResult Create()
        {
            ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "BikeID");   
            //CG:ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "Make");
            return View();
        }

        // POST: HiresMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BikeID,FirstName,Surname,Address,PhoneNumber,StartDate,FinishDate")] Hire hire) //CG: Removed HireID from list
        {
            if (ModelState.IsValid)
            {
                db.Hires.Add(hire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BikeID = new SelectList(db.Bikes, "Make", "Model", hire.BikeID); //CG:(db.Bikes, "BikeID", "Make", hire.BikeID); //CG: (db.Bikes, "Make", "Model", hire.BikeID)
            return View(hire);
        }

        // GET: HiresMVC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hire hire = await db.Hires.FindAsync(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "BikeID", hire.BikeID);
            return View(hire);
        }
//Removed to try and post edits to the same page
        // POST: HiresMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HireID,BikeID,FirstName,Surname,Address,PhoneNumber,StartDate,FinishDate")] Hire hire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "BikeID", hire.BikeID);
            return View(hire);
        }

        // GET: HiresMVC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hire hire = await db.Hires.FindAsync(id);
            if (hire == null)
            {
                return HttpNotFound();
            }
            return View(hire);
        }

        // POST: HiresMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hire hire = await db.Hires.FindAsync(id);
            db.Hires.Remove(hire);
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
