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
using EmpPerfReview.Models;

namespace EmpPerfReview.Controllers
{
    public class ReviewsController : ApiController
    {
        private EmpPerfReviewContext db = new EmpPerfReviewContext();

        // GET: api/Reviews
        public IQueryable<Review> GetReviews()
        {
            return db.Reviews;
        }

        //public IQueryable<EmployeeReviewDTO> GetReviews()
        //{
        //    return db.Reviews;
        //}

        // GET: api/Reviews/5
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> GetReview(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReview(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.Id)
            {
                return BadRequest();
            }

            db.Entry(review).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> PostReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviews.Add(review);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public async Task<IHttpActionResult> DeleteReview(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            await db.SaveChangesAsync();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.Id == id) > 0;
        }
    }
}