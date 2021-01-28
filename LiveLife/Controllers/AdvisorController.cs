using LiveLife.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveLife.Controllers
{
    public class AdvisorController : Controller
    {
        // GET: Advisor
        LiveLifeEntities dbObj = new LiveLifeEntities();
        public ActionResult Advisor(tblAdvisor obj)
        {
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddAdvisor(tblAdvisor model)
        {
            tblAdvisor obj = new tblAdvisor();
            if (ModelState.IsValid)
            {

                obj.AdvisorID = model.AdvisorID;
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Address = model.Address;
                obj.PhoneNumber = model.PhoneNumber;
                obj.HealthStatus = model.HealthStatus;

                if (model.AdvisorID == 0)
                {
                    dbObj.tblAdvisors.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }


            }
            ModelState.Clear();
            return View("Advisor");
        }


        public ActionResult AdvisorList()
        {
            var res = dbObj.tblAdvisors.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.tblAdvisors.Where(x => x.AdvisorID == id).First();
            dbObj.tblAdvisors.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tblAdvisors.ToList();
            return View("AdvisorList", list);
        }



    }


}