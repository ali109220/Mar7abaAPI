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
    public class DealsController : ApiController
    {
        private Marhaba db = new Marhaba();

        // GET: api/Deals
        public IQueryable<Deal> GetDeals()
        {
            return db.Deals;
        }

        // GET: api/Deals/5
        [ResponseType(typeof(Deal))]
        public IHttpActionResult GetDeal(int id)
        {
            Deal deal = db.Deals.Find(id);
            if (deal == null)
            {
                return NotFound();
            }

            return Ok(deal);
        }

        // PUT: api/Deals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeal(int id, Deal deal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deal.Id)
            {
                return BadRequest();
            }

            db.Entry(deal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(id))
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

        // POST: api/Deals
        [ResponseType(typeof(Deal))]
        public IHttpActionResult PostDeal(Deal deal)
        {
            if (deal != null)
            {
                if (deal.Type != null)
                {
                    //deal.Type_Id = deal.Type.Id;
                    deal.Type = null;
                }
                if (deal.City != null)
                {
                    //deal.City_Id = deal.City.Id;
                    deal.City = null;
                }
                if (deal.Company != null)
                {
                    //deal.Company_Id = deal.Company.Id;
                    deal.Company = null;
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deals.Add(deal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deal.Id }, deal);
        }

        // DELETE: api/Deals/5
        [ResponseType(typeof(Deal))]
        public IHttpActionResult DeleteDeal(int id)
        {
            Deal deal = db.Deals.Find(id);
            if (deal == null)
            {
                return NotFound();
            }

            db.Deals.Remove(deal);
            db.SaveChanges();

            return Ok(deal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DealExists(int id)
        {
            return db.Deals.Count(e => e.Id == id) > 0;
        }
    }
}