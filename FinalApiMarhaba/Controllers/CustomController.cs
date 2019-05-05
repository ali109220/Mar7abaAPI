using FinalApiMarhaba.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FinalApiMarhaba.Controllers
{
    public class CategoryHeader
    {
        public CategoryHeader()
        {
            this.Types = new List<Models.Type>();
        }
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public List<Models.Type> Types { get; set; }

        public Deal Deal { get; set; }
    }

    public class CustomController : ApiController
    {
        private Marhaba db = new Marhaba();

        public IQueryable<CategoryHeader> GetAdrvertismentDeals()
        {

            List<CategoryHeader> categories = new List<CategoryHeader>();
            foreach (var cat in db.Categorys)
            {
                Deal deal;
                List<Models.Type> types = new List<Models.Type>();
                Deal _deal = getAdvertisemnet(cat);
                if (_deal.Id == 0)
                    continue;
                var dealPics = new List<DealPic>();
                if (_deal.DealPics.Count != 0)
                    dealPics.Add(new DealPic()
                    {
                        Id = _deal.DealPics[0].Id,
                        Url = _deal.DealPics[0].Url,
                        ResourceName = _deal.DealPics[0].ResourceName,
                        ResourceDescription = _deal.DealPics[0].ResourceDescription
                    });
                deal = new Deal()
                {
                    Id = _deal.Id,
                    ResourceName = _deal.ResourceName,
                    ResourceDescription = _deal.ResourceDescription,
                    DealPics = dealPics

                };
                foreach (var type in cat.Types)
                {
                    type.Category = null;
                    type.Category_Id = 0;
                    type.Deals = new List<Deal>();
                    types.Add(new Models.Type()
                    {
                        Id = type.Id,
                        ResourceDescription = type.ResourceDescription,
                        ResourceName = type.ResourceName
                    });
                }
                categories.Add(new CategoryHeader()
                {
                    Id = cat.Id,
                    ResourceDescription = cat.ResourceDescription,
                    ResourceName = cat.ResourceName,
                    Types = types,
                    Deal = deal

                });
            }
            return categories.AsQueryable();
        }
        // GET: api/Custom/5
        [ResponseType(typeof(Deal))]
        public IHttpActionResult GetAdrvertismentDealForCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Deal deal = getAdvertisemnet(category);
                if (deal == null)
                {
                    return NotFound();
                }
                return Ok(deal);
            }
        }

        private Deal getAdvertisemnet(Category category)
        {
            try
            {
                foreach (var type in category.Types)
                {
                    foreach (var deal in type.Deals)
                        if (deal.ISForAdvertisement && deal.IsViewedInCategoryArea)
                            return deal;
                }
                return new Deal();
            }
            catch (Exception ex)
            {
                return new Deal();
            }
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