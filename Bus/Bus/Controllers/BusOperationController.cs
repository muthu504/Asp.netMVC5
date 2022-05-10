using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Data;
using System.Data;

namespace Bus.Controllers
{
    public class BusOperationController : Controller
    {
            // GET: Bus
            BusCrudEntities dbObj = new BusCrudEntities();
            public ActionResult BusOperation(BusTrack busTracking)
            {

                return View(busTracking);
            }

            [HttpPost]
            public ActionResult AddBus(BusTrack busTracking)
            {
                if (ModelState.IsValid)
                {

                    BusTrack obj = new BusTrack();
                    obj.BusID = busTracking.BusID;
                    obj.BoardingStage = busTracking.BoardingStage;
                    obj.TravelDate = busTracking.TravelDate;
                    obj.Amount = busTracking.Amount;
                    obj.Rating = busTracking.Rating;
                    if (busTracking.BusID == 0)
                    {
                        dbObj.BusTracks.Add(obj);
                        dbObj.SaveChanges();
                    }
                    else
                    {
                        dbObj.Entry(busTracking).State = EntityState.Modified;
                        dbObj.SaveChanges();

                        var list = dbObj.BusTracks.ToList();
                        return View("BusList", list);

                    }
                    ModelState.Clear();
                }



                return View("BusOperation");
            }
            public ActionResult BusList()
            {
                var result = dbObj.BusTracks.ToList();
                return View(result);
            }

            public ActionResult Delete(int id)
            {
                var result = dbObj.BusTracks.Where(x => x.BusID == id).First();
                dbObj.BusTracks.Remove(result);
                dbObj.SaveChanges();

                var list = dbObj.BusTracks.ToList();

                return View("BusList", list);
            }
        }
    }