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
    public class BikesAPIController : ApiController     //Colm: API Controller
    {
        private BikeHireContext db = new BikeHireContext();

        // GET: api/BikesAPI
        public IList<BikeDetailsDto> GetBikes()     //Colm: Newely created, enabled due to creation of Models.BikeDetailsDto.cs

        {
            var bikeList = db.Bikes.ToList();
            return bikeList.Select(p => new BikeDetailsDto
            {
                BikeID = p.BikeID,
                Make = p.Make,
                Model = p.Model,
                RentalChargePerDay = p.RentalChargePerDay,
                BikeAvailable = p.BikeAvailable,
                Hires = p.hires.Select(s => new HireDetailsDto
                {
                    HireID = s.HireID,
                    BikeID = s.BikeID,
                    FirstName = s.FirstName,
                    Surname = s.Surname,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber,
                    StartDate = s.StartDate,
                    FinishDate = s.FinishDate
                    }).ToList()
            }).ToList();
         }


        /*
        //Original code
        // GET: api/BikesAPI
        public IQueryable<Bike> GetBikes()
        {
            return db.Bikes;
        }*/

        // GET: api/BikesAPI/5
        [ResponseType(typeof(BikeDetailsDto))]
        public async Task<IHttpActionResult> GetBike(int id)
        {
            var bikeList = await db.Bikes.Include(p => p.BikeID).Select(s => new BikeDetailsDto()
            {
                BikeID = s.BikeID,
                Make = s.Make,
                Model = s.Model,
                RentalChargePerDay = s.RentalChargePerDay,
                BikeAvailable = s.BikeAvailable
            }).SingleOrDefaultAsync(p => p.BikeID == id);

                if (bikeList == null)
                {
                    return NotFound();
                }

                return Ok(bikeList);
            }

        //Original code
        /*
                // GET: api/BikesAPI/5
                [ResponseType(typeof(Bike))]
                public async Task<IHttpActionResult> GetBike(int id)
                {
                    Bike bike = await db.Bikes.FindAsync(id);
                    if (bike == null)
                    {
                        return NotFound();
                    }

                    return Ok(bike);
                }
        */

            // PUT: api/BikesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBike(int id, Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bike.BikeID)
            {
                return BadRequest();
            }

            db.Entry(bike).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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


        // POST: api/BikesAPI
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> PostBike(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bikes.Add(bike);
            await db.SaveChangesAsync();

            //db.Entry(bike).Reference(p => p.BikeID).Load();

            //new code
            var dto = new BikeDetailsDto()
            {
                BikeID = bike.BikeID,
                Make = bike.Make,
                Model = bike.Model,
                RentalChargePerDay = bike.RentalChargePerDay,
                BikeAvailable = bike.BikeAvailable
            };

            return CreatedAtRoute("DefaultApi", new { id = bike.BikeID }, dto);
        }

        //Original Code
        /*
        // POST: api/BikesAPI
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> PostBike(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bikes.Add(bike);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bike.BikeID }, bike);
        }
        */

        // DELETE: api/BikesAPI/5
        [ResponseType(typeof(Bike))]
        public async Task<IHttpActionResult> DeleteBike(int id)
        {
            Bike bike = await db.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            db.Bikes.Remove(bike);
            await db.SaveChangesAsync();

            return Ok(bike);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeExists(int id)
        {
            return db.Bikes.Count(e => e.BikeID == id) > 0;
        }
    }
}
 