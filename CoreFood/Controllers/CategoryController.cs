using CoreFood.Data.Models;
using CoreFood.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult GetCategory(int id) 
        {
            var x = categoryRepository.TGet(id);
            Category category = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryId = x.CategoryId
            };        
            return View(category);       
        }

       [HttpPost]     
        public IActionResult UpdateCategory(Category category)
        {
            var x = categoryRepository.TGet(category.CategoryId);
            x.CategoryName = category.CategoryName;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
