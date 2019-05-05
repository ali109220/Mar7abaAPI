using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinalApiMarhaba.Models;

namespace FinalApiMarhaba.Controllers
{
    public class TypesController : ApiController
    {
        private Marhaba db = new Marhaba();

        // GET: api/Types
        public IQueryable<Models.Type> GetTypes()
        {
            List<Models.Type> types = new List<Models.Type>();
            foreach(var type in db.Types)
            {
                type.Category.Types = new List<Models.Type>();
                types.Add(new Models.Type()
                {
                   Category=type.Category,
                   Id=type.Id,
                   Category_Id=type.Category_Id,
                   ResourceName=type.ResourceName,
                   ResourceDescription=type.ResourceDescription,
                   Deals=new List<Deal>()
                });
            }
            return types.AsQueryable();
        }

        // GET: api/Types/5
        [ResponseType(typeof(Models.Type))]
        public IHttpActionResult GetType(int id)
        {
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        // PUT: api/Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutType(int id, Models.Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != type.Id)
            {
                return BadRequest();
            }

            db.Entry(type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Types
        [ResponseType(typeof(Models.Type))]
        public IHttpActionResult PostType(Models.Type type)
        {
            if(type!=null && type.Category != null)
            {
                type.Category_Id = type.Category.Id;
                type.Category = null;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Types.Add(type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = type.Id }, type);
        }

        // DELETE: api/Types/5
        [ResponseType(typeof(Models.Type))]
        public IHttpActionResult DeleteType(int id)
        {
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            db.Types.Remove(type);
            db.SaveChanges();

            return Ok(type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeExists(int id)
        {
            return db.Types.Count(e => e.Id == id) > 0;
        }
    }
}