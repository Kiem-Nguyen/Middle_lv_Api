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
using FoodFunday;

namespace FoodFunday.Controllers
{
    public class AboutUsController : ApiController
    {
        private FoodFundayEntities db = new FoodFundayEntities();

        // GET: api/AboutUs
        public AboutUs GetAboutUs()
        {
            return db.AboutUs1.FirstOrDefault();
        }

        // PUT: api/AboutUs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAboutUs(string id, AboutUs aboutUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aboutUs.title)
            {
                return BadRequest();
            }

            db.Entry(aboutUs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutUsExists(id))
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

        // POST: api/AboutUs
        [ResponseType(typeof(AboutUs))]
        public async Task<IHttpActionResult> PostAboutUs(AboutUs aboutUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AboutUs1.Add(aboutUs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AboutUsExists(aboutUs.title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aboutUs.title }, aboutUs);
        }

        // DELETE: api/AboutUs/5
        [ResponseType(typeof(AboutUs))]
        public async Task<IHttpActionResult> DeleteAboutUs(string id)
        {
            AboutUs aboutUs = await db.AboutUs1.FindAsync(id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            db.AboutUs1.Remove(aboutUs);
            await db.SaveChangesAsync();

            return Ok(aboutUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AboutUsExists(string id)
        {
            return db.AboutUs1.Count(e => e.title == id) > 0;
        }
    }
}