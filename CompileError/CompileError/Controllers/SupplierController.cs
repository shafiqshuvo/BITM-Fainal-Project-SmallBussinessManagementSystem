using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Model.Model;
using CompileError.Models;
using CompileError.Manager.Manager;
using AutoMapper;


namespace CompileError.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        // GET: Customer


        [HttpGet]
        public ActionResult Add()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();

            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);
        }



        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            string message = "";
            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);


            List<Supplier> suppliers = _supplierManager.GetAll();
            suppliers = suppliers.Where(c => c.Code.Contains(supplierViewModel.Code)).ToList();
            string isExist = "";
            string codeExitsMessage = "";
            foreach (var aSupplier in suppliers)
            {
                isExist = aSupplier.Code;
            }

            if (ModelState.IsValid)
            {

                if (isExist == supplierViewModel.Code)
                {

                    codeExitsMessage = "Code Already Exist";
                    ViewBag.Message = "Code Already Exist";
                    ViewBag.CodeExist = codeExitsMessage;

                }
                else
                {
                    if (_supplierManager.Add(supplier))
                    {
                        message = "Saved";
                    }
                    else
                    {
                        message = "Not Saved";
                    }
                }
            }
            else
            {
                message = "Model State failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();


            return View(supplierViewModel);
        }






        [HttpGet]
        public ActionResult Search()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();

            supplierViewModel.Suppliers = _supplierManager.GetAll();


            return View(supplierViewModel);

        }

        [HttpPost]
        public ActionResult Search(SupplierViewModel supplierViewModel)
        {
            var suppliers = _supplierManager.GetAll();

            if (supplierViewModel.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.Contains(supplierViewModel.Code)).ToList();
            }
            if (supplierViewModel.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(supplierViewModel.Name.ToLower())).ToList();
            }

            supplierViewModel.Suppliers = suppliers;


            return View(supplierViewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.GetById(id);


            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            supplierViewModel.Suppliers = _supplierManager.GetAll();



            return View(supplierViewModel);
        }




        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);


                if (_supplierManager.Update(supplier))
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
            supplierViewModel.Suppliers = _supplierManager.GetAll();



            return View(supplierViewModel);
        }

        public ActionResult Delete(int id)
        {
            string message = " ";
            Supplier supplier = _supplierManager.GetById(id);

            if (_supplierManager.Delete(supplier.Id))
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