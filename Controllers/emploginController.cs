using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohungerv2.EF;
using zerohungerv2.DTO;

namespace zerohungerv2.Controllers
{
    public class emploginController : Controller
    {
        zerohungerv2Entities db = new zerohungerv2Entities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(emploginDTO l)
        {
            if (ModelState.IsValid)
            {
                var authenticatedEmployee = (from e in db.NGO_EMP
                                             where e.E_NAME == l.E_NAME && e.E_PASS == l.E_PASS
                                             select e).SingleOrDefault();

                if (authenticatedEmployee != null)
                {
                    
                    Session["e_Id"] = authenticatedEmployee.E_ID;
                    return RedirectToAction("dash", "empDash");
                }
                else
                {
                    
                    ModelState.AddModelError("", "Invalid employee name or password.");
                }
            }

            
            return View();
        }
    }
}