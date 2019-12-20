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
    public class StockController : Controller
    {
        // GET: Stock
        readonly StockManager _stockManager = new StockManager();
        readonly StockViewModel stockViewModel = new StockViewModel();
        public ActionResult 
        {
            return View(stockViewModel);
        }
    }
}