using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohungerv2.EF;
using zerohungerv2.DTO;

namespace zerohungerv2.Controllers
{
    public class adminController : Controller
    {
        zerohungerv2Entities db = new zerohungerv2Entities();
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult AdminLogin(string username, string password)
        {
            
            if (username == "Admin" && password == "Admin123")
            {
                
                return RedirectToAction("adminDash");
            }
            else
            {
                
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
        public ActionResult adminDash()
        {
            
            var collectionRequests = db.COLLECT_RQST.ToList();
            var distributions = db.DISTRIBUTION_RCRD.ToList();
            var employees = db.NGO_EMP.ToList();

            ViewBag.CollectionRequests = collectionRequests;
            ViewBag.Distributions = distributions;
            ViewBag.Employees = employees;

            return View();
        }
        public ActionResult AssignEmployee(int cId, int employeeId)
        {
            var collectionRequest = db.COLLECT_RQST.FirstOrDefault(c => c.C_ID == cId);
            if (collectionRequest != null)
            {
                collectionRequest.E_ID = employeeId;
                collectionRequest.STATUS = "Assigned"; // Update the status to "Assigned"
                db.SaveChanges();
            }

            return RedirectToAction("adminDash");
        }
    }
}