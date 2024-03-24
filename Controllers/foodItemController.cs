using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohungerv2.DTO;
using zerohungerv2.EF;

namespace zerohungerv2.Controllers
{
    public class foodItemController : Controller
    {
        zerohungerv2Entities db = new zerohungerv2Entities();
        
        public ActionResult FoodItem()
        {
            return View();
        }

        
        [HttpPost]
   
        public ActionResult SubmitFoodItem(foodItemDTO foodItem, int c_Id)
        {
            if (ModelState.IsValid)
            {
                

                // Find F_ID based on C_ID
                var existingFoodItem = db.FOOD_ITEM.FirstOrDefault(f => f.C_ID == c_Id);

                if (existingFoodItem != null)
                {
                    // Update the existing food item with the new values from the view inputs
                    existingFoodItem.DESCRIPTION = foodItem.DESCRIPTION;
                    existingFoodItem.QUANTITY = foodItem.QUANTITY;
                    existingFoodItem.EXPIRY = foodItem.EXPIRY;

                    // Save changes to the database
                    db.SaveChanges();

                    // Optionally, you can perform additional logic or redirect to another action
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle the case where no existing food item is found for the given C_ID
                    ModelState.AddModelError("", "No existing food item found for the given C_ID.");
                }
            }


            return View("FoodItem", foodItem);
        }

       

    }
}