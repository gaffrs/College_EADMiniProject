using System;
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
    public class HiresAPIController : ApiController //Colm: API Controller
    {
        private BikeHireContext db = new BikeHireContext();



        // GET: api/HiresAPI
        public List<HireDetailsDto> GetHires()
        {
            var hireList = db.Hires.ToList();
            return hireList.Select(s => new HireDetailsDto
            {
                HireID = s.HireID,
                BikeID = s.BikeID,
                FirstName = s.FirstName,
                Surname = s.Surname,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                StartDate = s.StartDate,
                FinishDate = s.FinishDate
            }).ToList();
        }

        /*
                // GET: api/HiresAPI
                public IQueryable<Hire> GetHires()
                {
                    return db.Hires;
                }
        */

        // GET: api/HiresAPI/5
        [ResponseType(typeof(HireDetailsDto))]
        public async Task<IHttpActionResult> GetHire(int id)
        {
            var hireList = await db.Hires.Include(p => p.HireID).Select(s => new HireDetailsDto()
            {
                HireID = s.HireID,
                BikeID = s.BikeID,
                FirstName = s.FirstName,
                Surname = s.Surname,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                StartDate = s.StartDate,
                FinishDate = s.FinishDate
            }).SingleOrDefaultAsync(p => p.HireID == id);

            if (hireList == null)
            {
                return NotFound();
            }

            return Ok(hireList);
        }

        //Original code
        /*
                // GET: api/HiresAPI/5
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
        */


        // PUT: api/HiresAPI/5
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

        // POST: api/HiresAPI
        [ResponseType(typeof(Hire))]
        public async Task<IHttpActionResult> PostHire(Hire hire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Entry(hire).Reference(p => p.HireID).Load();

            db.Hires.Add(hire);
            await db.SaveChangesAsync();

            //new code
            var dto = new HireDetailsDto()
            {
                HireID = hire.HireID,
                FirstName = hire.FirstName,
                Surname = hire.Surname,
                Address = hire.Address,
                PhoneNumber = hire.PhoneNumber,
                StartDate = hire.StartDate,
                FinishDate = hire.FinishDate

            };
            return CreatedAtRoute("DefaultApi", new { id = hire.HireID }, hire);

        }

        //Original Code
        /*
                // POST: api/HiresAPI
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
        */

        // DELETE: api/HiresAPI/5
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