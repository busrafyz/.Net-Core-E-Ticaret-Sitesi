using CoreFood.Data.Models;
using CoreFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {   
            return View(categoryRepository.TList());
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
        }
    }
}
