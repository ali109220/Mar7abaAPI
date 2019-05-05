using FinalApiMarhaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalApiMarhaba.Controllers
{
    public class AdvertisingController : ApiController
    {
        private Marhaba db = new Marhaba();

        public IQueryable<Deal> GetAdrvertismentDeals()
        {
            List<Deal> _deals = new List<Deal>();
            var deals = db.Deals;
            foreach (var del in deals)
            {
                var dealPics = new List<DealPic>();
                if (del.ISForAdvertisement)
                {
                    if(del.DealPics.Count!=0)
                    dealPics.Add(new DealPic()
                    {
                        Id=del.DealPics[0].Id,
                        Url=del.DealPics[0].Url,
                        ResourceName= del.DealPics[0].ResourceName,
                        ResourceDescription = del.DealPics[0].ResourceDescription
                    });
                    _deals.Add(new Deal()
                    {
                        Id = del.Id,
                        ResourceName = del.ResourceName,
                        ResourceDescription = del.ResourceDescription,
                        DealPics = dealPics

                    });
                }
                  
            }
            if (_deals.Count > 4)
            {
                _deals.RemoveRange(0, _deals.Count - 4);
            }
            return _deals.AsQueryable();
        }
    }
}