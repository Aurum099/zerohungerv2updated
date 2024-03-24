using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohungerv2.EF;
using zerohungerv2.DTO;

namespace zerohungerv2.Controllers
{
    public class restaurantController : Controller
    {
        zerohungerv2Entities db = new zerohungerv2Entities();

        [HttpGet]
        public ActionResult RestaurantDash()
        {
            ViewBag.Title = "Dashboard";
            ViewBag.CollectionRequests = db.COLLECT_RQST.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SubmitRequest(collectRqstDTO request, int res_id)
        {
            if (ModelState.IsValid)
            {
                var collectRequest = new COLLECT_RQST
                {
                    FOOD_NAME = request.FOOD_NAME,
                    MAX_PRESERVE_TIME = request.MAX_PRESERVE_TIME,
                    R_ID = res_id,
                    STATUS = "Pending"
                };

                db.COLLECT_RQST.Add(collectRequest);
                db.SaveChanges();

                int cId = collectRequest.C_ID;

                Session["C_ID"] = cId;
                var foodItemEntry = new FOOD_ITEM
                {
                    C_ID = cId, 
                };

                db.FOOD_ITEM.Add(foodItemEntry);
                db.SaveChanges();
                return RedirectToAction("FoodItem", "foodItem");
            }

            ViewBag.Title = "Dashboard";
            ViewBag.CollectionRequests = db.COLLECT_RQST.ToList();
            return RedirectToAction("Index", "restaurant");
        }
    }
}