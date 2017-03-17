﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BikeHire.Models;

namespace BikeHire.Controllers                      //Colm: This manages all the Basic CRUD Operations
{
    public class HiresController : ApiController    //Colm: API Controller
    {
        private BikeHireContext db = new BikeHireContext();

        // GET: api/Hires
        public IQueryable<Hire> GetHires()
        {
            return db.Hires;
        }

        // GET: api/Hires/5
        [ResponseType(typeof(Hire))]
        public async Task<IHttpActionResult> GetHire(int id)
        {
            Hire hire = await db.Hires.FindAsync(id);
            if (hire == null)
            {
                return NotFound();
            }

            return Ok(hire);
        }

        // PUT: api/Hires/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHire(int id, Hire hire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hire.HireID)
            {
                return BadRequest();
            }

            db.Entry(hire).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HireExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hires
        [ResponseType(typeof(Hire))]
        public async Task<IHttpActionResult> PostHire(Hire hire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hires.Add(hire);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hire.HireID }, hire);
        }

        // DELETE: api/Hires/5
        [ResponseType(typeof(Hire))]
        public async Task<IHttpActionResult> DeleteHire(int id)
        {
            Hire hire = await db.Hires.FindAsync(id);
            if (hire == null)
            {
                return NotFound();
            }

            db.Hires.Remove(hire);
            await db.SaveChangesAsync();

            return Ok(hire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HireExists(int id)
        {
            return db.Hires.Count(e => e.HireID == id) > 0;
        }
    }
}