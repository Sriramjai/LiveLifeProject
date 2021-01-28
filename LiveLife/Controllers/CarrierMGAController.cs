using LiveLife.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LiveLife.Controllers
{
    public class CarrierMGAController : Controller
    {
        // GET: CarrierMGA
        LiveLifeEntities dbObj = new LiveLifeEntities();
        public ActionResult CarrierMGA(CarrierMGA obj)
        {
            return View(obj);
            
        }

        [HttpPost]
        public ActionResult AddCarrierMGA(CarrierMGA model)
        {
            CarrierMGA obj = new CarrierMGA();
            if (ModelState.IsValid)
            {

                obj.Id = model.Id;               
                obj.BusinessName = model.BusinessName;
                obj.BusinessAddress = model.BusinessAddress;
                obj.BusinessPhoneNumber = model.BusinessPhoneNumber;

                if(model.Id==0)
                {
                    dbObj.CarrierMGAs.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
                

            }
            ModelState.Clear();
            return View("CarrierMGA");
        }

        public ActionResult CarrierMGAList()
        {
            var res = dbObj.CarrierMGAs.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.CarrierMGAs.Where(x => x.Id == id).First();
            dbObj.CarrierMGAs.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.CarrierMGAs.ToList();
            return View("CarrierMGAList",list);
        }

    }
}