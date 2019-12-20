using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Manager.Manager;
using CompileError.Models;
using CompileError.Model.Model;
using AutoMapper;

namespace CompileError.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        // GET: Customer


        [HttpGet]
        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Customers = _customerManager.GetAll();


            return View(customerViewModel);
        }



        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            string message = "";
            Customer customer = Mapper.Map<Customer>(customerViewModel);


            if (ModelState.IsValid)
            {

                if (_customerManager.Add(customer))
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
            customerViewModel.Customers = _customerManager.GetAll();


            return View(customerViewModel);
        }




        [HttpGet]
        public ActionResult Search()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);

        }

        [HttpPost]
        public ActionResult Search(CustomerViewModel customerViewModel)
        {
            var customers = _customerManager.GetAll();

            if (customerViewModel.Code != null)
            {
                customers = customers.Where(c => c.Code.Contains(customerViewModel.Code)).ToList();
            }
            if (customerViewModel.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customerViewModel.Name.ToLower())).ToList();
            }

            customerViewModel.Customers = customers;


            return View(customerViewModel);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _customerManager.GetById(id);

            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }




        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {

                Customer customer = Mapper.Map<Customer>(customerViewModel);

                if (_customerManager.Update(customer))
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
            customerViewModel.Customers = _customerManager.GetAll();



            return View(customerViewModel);
        }

        public ActionResult Delete(int id)
        {
            string message = " ";
            Customer customer = _customerManager.GetById(id);

            if (_customerManager.Delete(customer.Id))
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