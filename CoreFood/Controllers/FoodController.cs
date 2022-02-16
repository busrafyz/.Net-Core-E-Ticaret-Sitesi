using CoreFood.Data.Models;
using CoreFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreFood.Controllers
{
    public class FoodController : Controller
    {

        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();

        public IActionResult Index(int page = 1)
        {


            return View(foodRepository.TList("Category").ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
           
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
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

        public IActionResult GetFood(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();
            ViewBag.value = values;
            Food food = new Food()
            {
                FoodId = x.FoodId,
                CategoryId = x.CategoryId,
                FoodName = x.FoodName,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImgUrl = x.ImgUrl
            };
            return View(food);
        }

        [HttpPost]
        public IActionResult UpdateFood(Food food)
        {
            var x = foodRepository.TGet(food.FoodId);
            x.FoodName = food.FoodName;
            x.CategoryId = food.CategoryId;
            x.Price = food.Price;
            x.Stock = food.Stock;
            x.ImgUrl = food.ImgUrl;
            x.Description = food.Description;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        
    }
}
