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
using ClaroVideoWebAPIs.Models;

namespace ClaroVideoWebAPIs.Controllers
{
    public class RatingCodesController : ApiController
    {
        private ClaroVideoWebAPIsContext db = new ClaroVideoWebAPIsContext();

        // GET: api/RatingCodes
        public IQueryable<RatingCode> GetRatingCodes()
        {
            return db.RatingCodes;
        }

        // GET: api/RatingCodes/5
        [ResponseType(typeof(RatingCode))]
        public async Task<IHttpActionResult> GetRatingCode(int id)
        {
            RatingCode ratingCode = await db.RatingCodes.FindAsync(id);
            if (ratingCode == null)
            {
                return NotFound();
            }

            return Ok(ratingCode);
        }

        // PUT: api/RatingCodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRatingCode(int id, RatingCode ratingCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ratingCode.Id)
            {
                return BadRequest();
            }

            db.Entry(ratingCode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingCodeExists(id))
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

        // POST: api/RatingCodes
        [ResponseType(typeof(RatingCode))]
        public async Task<IHttpActionResult> PostRatingCode(RatingCode ratingCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RatingCodes.Add(ratingCode);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ratingCode.Id }, ratingCode);
        }

        // DELETE: api/RatingCodes/5
        [ResponseType(typeof(RatingCode))]
        public async Task<IHttpActionResult> DeleteRatingCode(int id)
        {
            RatingCode ratingCode = await db.RatingCodes.FindAsync(id);
            if (ratingCode == null)
            {
                return NotFound();
            }

            db.RatingCodes.Remove(ratingCode);
            await db.SaveChangesAsync();

            return Ok(ratingCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingCodeExists(int id)
        {
            return db.RatingCodes.Count(e => e.Id == id) > 0;
        }
    }
}