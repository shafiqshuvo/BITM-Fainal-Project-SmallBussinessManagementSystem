using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Model.Model;
using CompileError.Manager.Manager;
using CompileError.Models;
using AutoMapper;

namespace CompileError.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();


        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            Category category = new Category();
            categoryViewModel.Categories = _categoryManager.GetAll();


            return View(categoryViewModel);
        }



        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            string message = "";
            Category category = Mapper.Map<Category>(categoryViewModel);


            if (ModelState.IsValid)
            {

                if (_categoryManager.Add(category))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "Model State failed";
            }

            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }




        [HttpGet]
        public ActionResult Search()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);

        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            var categories = _categoryManager.GetAll();

            if (categoryViewModel.Code != null)
            {
                categories = categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
            }
            if (categoryViewModel.Name != null)
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
            }

            categoryViewModel.Categories = categories;


            return View(categoryViewModel);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            categoryViewModel.Categories = _categoryManager.GetAll();



            return View(categoryViewModel);
        }




        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);

                if (_categoryManager.Update(category))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();



            return View(categoryViewModel);
        }




        public ActionResult Delete(int id)
        {
            string message = " ";
            Category category = _categoryManager.GetById(id);

            if (_categoryManager.Delete(category.Id))
            {
                message = "Deleted";

            }

            else
            {
                message = "Not Deleted";
            }

            ViewBag.Message = message;

            return RedirectToAction("Add");
        }

    }
}