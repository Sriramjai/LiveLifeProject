using LiveLife.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveLife.Controllers
{
    public class ContractController : Controller
    {
        public class ContractModel {
            public string promisor { get; set; }
            public string promisee { get; set; }
        }


        // GET: Contract
        LiveLifeEntities dbObj = new LiveLifeEntities();
        public ActionResult Contract(tblContract obj)
        {
            //var promisor = dbObj.tblContracts.SelectMany(t => t.Promiser);

           List<string> Name = new List<string>();


            var businessName = (from business in dbObj.CarrierMGAs
                          select  business.BusinessName).ToList();

            List<CarrierMGA> BusinessList  = dbObj.CarrierMGAs.ToList();

            var advisorName = (from advisor in dbObj.tblAdvisors
                               select new { Name = advisor.FirstName + " " + advisor.LastName }).ToList();

            foreach(var item in advisorName)
            {
                businessName.Add(item.Name);
            }               

            //ViewBag.BusinessList = new SelectList(BusinessList, "BusinessList");
            ViewBag.BusinessName = businessName;
            //ViewBag.data = businessName.ToString();
            //ViewBag.Advisor = advisorName;

            return View(obj);
        }


        [HttpPost]
        public ActionResult AddContract(tblContract model)
        {
            tblContract obj = new tblContract();


            var contract = (from con in dbObj.tblContracts
                            where con.Promiser == model.Promiser && con.Promisee == model.Promisee
                            select con.ContractID).FirstOrDefault();

            // Checking if the contracting self

            if (model.Promiser == model.Promisee)
            {
                ModelState.Clear();
                ViewBag.ErrorMessage = "Can't contract with Self";
                return View("Contract");

            }

            // Checking if user entered Carrier or MGA exists in our database 

            //else if (dbObj.CarrierMGAs.Any(x => x.BusinessName != model.Promiser) || dbObj.CarrierMGAs.Any(x => x.BusinessName != model.Promisee) ||
            //         dbObj.tblAdvisors.Any(x => x.FirstName != model.Promiser) || dbObj.tblAdvisors.Any(x => x.FirstName != model.Promisee))

            //{
            //    ModelState.Clear();
            //    ViewBag.ErrorMessage = "Carrier or MGA does not exist";
            //    return View("Contract");
            //}

            

            //else if (dbObj.tblContracts.Any(x => x.Promiser == model.Promiser) && dbObj.tblContracts.Any(x => x.Promisee == model.Promisee))
            else if (contract > 0)
            {
                ModelState.Clear();
                ViewBag.ErrorMessage = "Contract already exists between the two entities";
                return View("Contract");
            }

            else
            {

                if (ModelState.IsValid)
                {

                    obj.ContractID = model.ContractID;
                    // obj.PromiserID = model.PromiserID;
                    obj.Promiser = model.Promiser;
                    // obj.PromiseeID = model.PromiseeID;
                    obj.Promisee = model.Promisee;

                    
                    if (model.ContractID == 0)
                    {
                        ViewBag.Message = String.Format("Contract Created");
                        dbObj.tblContracts.Add(obj);
                        dbObj.SaveChanges();
                    }
                    else
                    {
                        dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        dbObj.SaveChanges();
                    }


                }
                ModelState.Clear();
                return View("Contract");
            }
        }


        public ActionResult ContractList()
        {
            var res = dbObj.tblContracts.ToList();
            return View(res);
        }


        public ActionResult FindContract(string promiserName)
        {
            return View();

        }

        [HttpPost]
        public ActionResult GetContractDetails(ContractModel model)
        {

            tblContract res;
            if (dbObj.tblContracts.Any(p => p.Promiser == model.promisor) && dbObj.tblContracts.Any(p => p.Promisee == model.promisee))
            {
                res = dbObj.tblContracts.Where(p => (p.Promiser == model.promisor) && (p.Promisee == model.promisee)).First();

                //var result = (from con in dbObj.tblContracts
                //              where con.Promiser == model.promisor && con.Promisee == model.promisee
                //              select new { con.ContractID, con.Promiser, con.Promisee});


               ViewBag.Message = res;
               

                return View();
            }
            else
            {
                res = null;
                return View("FindContract", res);
            }

            //res = dbObj.tblContracts.Where(p => p.Promiser == model.promisor).First();


            //ViewBag.Message = res;

            //return View();
        }

        //public ActionResult Contract()
        //{
        //    ContractModel cModel = new ContractModel();
        //    return View(cModel);
        //}


        public ActionResult Delete(int id)
        {
            var res = dbObj.tblContracts.Where(x => x.ContractID == id).First();
            dbObj.tblContracts.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tblContracts.ToList();
            return View("ContractList", list);
        }

    }
}