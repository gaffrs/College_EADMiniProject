﻿using System;
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
        public async Task<ActionResult> Index()
        {
            var hires = db.Hires.Include(h => h.Bike);
            return View(await hires.ToListAsync());
        }

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

            //ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "BikeID", "Make", "Make", "Model", "Model"); //CG:ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "Make");
            //ViewBag.BikeID = new SelectList(db.Bikes, "Make", "Make");
            //ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "BikeID");
            //ViewBag.BikeIDMake = new SelectList(db.Bikes, "BikeID", "Make");
            //ViewBag.BikeIDModel = new SelectList(db.Bikes, "BikeID", "Model");
            //ViewBag.BikeID.Model = new SelectList;
            //new SelectList(db.Bikes, "Make");
            //new SelectList (db.Bikes, "Model");
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
            ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "Make", hire.BikeID);
            return View(hire);
        }

        // POST: HiresMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BikeID,FirstName,Surname,Address,PhoneNumber,StartDate,FinishDate")] Hire hire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BikeID = new SelectList(db.Bikes, "BikeID", "Make", hire.BikeID);
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
