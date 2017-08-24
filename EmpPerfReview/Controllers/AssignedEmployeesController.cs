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
    public class AssignedEmployeesController : ApiController
    {
        private EmpPerfReviewContext db = new EmpPerfReviewContext();

        // GET: api/AssignedEmployees
        public IQueryable<AssignedEmployee> GetAssignedEmployees()
        {
            return db.AssignedEmployees;
        }

        // GET: api/AssignedEmployees/5
        [ResponseType(typeof(AssignedEmployee))]
        public async Task<IHttpActionResult> GetAssignedEmployee(int id)
        {
            AssignedEmployee assignedEmployee = await db.AssignedEmployees.FindAsync(id);
            if (assignedEmployee == null)
            {
                return NotFound();
            }

            return Ok(assignedEmployee);
        }

        // PUT: api/AssignedEmployees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssignedEmployee(int id, AssignedEmployee assignedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignedEmployee.Id)
            {
                return BadRequest();
            }

            db.Entry(assignedEmployee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedEmployeeExists(id))
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

        // POST: api/AssignedEmployees
        [ResponseType(typeof(AssignedEmployee))]
        public async Task<IHttpActionResult> PostAssignedEmployee(AssignedEmployee assignedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssignedEmployees.Add(assignedEmployee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assignedEmployee.Id }, assignedEmployee);
        }

        // DELETE: api/AssignedEmployees/5
        [ResponseType(typeof(AssignedEmployee))]
        public async Task<IHttpActionResult> DeleteAssignedEmployee(int id)
        {
            AssignedEmployee assignedEmployee = await db.AssignedEmployees.FindAsync(id);
            if (assignedEmployee == null)
            {
                return NotFound();
            }

            db.AssignedEmployees.Remove(assignedEmployee);
            await db.SaveChangesAsync();

            return Ok(assignedEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignedEmployeeExists(int id)
        {
            return db.AssignedEmployees.Count(e => e.Id == id) > 0;
        }
    }
}