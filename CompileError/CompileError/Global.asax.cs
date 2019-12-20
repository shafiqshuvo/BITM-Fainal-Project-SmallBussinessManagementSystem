using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CompileError.Models;
using CompileError.Model.Model;
using AutoMapper;

namespace CompileError
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Supplier, SupplierViewModel>();
                cfg.CreateMap<SupplierViewModel, Supplier>();
                cfg.CreateMap<Purchase, PurchaseViewModel>();
                cfg.CreateMap<PurchaseProduct, PurchaseViewModel>();
                cfg.CreateMap<PurchaseViewModel, Purchase>();
                cfg.CreateMap<PurchaseViewModel, PurchaseProduct>();
            });
        }
    }
}
