using CoreFood.Data.Models;
using CoreFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFood.Controllers
{
    public class FoodController : Controller
    {

        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index()
        {


            return View(foodRepository.TList("Category"));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food food)
        {

            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodId = id});
            return RedirectToAction("Index");
        }
    }
}
