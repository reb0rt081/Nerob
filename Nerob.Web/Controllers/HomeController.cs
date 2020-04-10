using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nerob.Shared;

namespace Nerob.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Picking()
        {
            ViewBag.Message = "Your picking page.";
            
            return View();
        }

        //  With this method we navigate to the view with the information obtained here
        [HttpGet]
        public ActionResult Inventory()
        {
            var viewModel = new InventoryInformation()
            {
                ItemName = "Scan Item",
                ItemDescription = string.Empty,
                ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                QuantityAvailable = 0,
                ItemBarcode = string.Empty
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitInventory(InventoryInformation model)
        {
           return RedirectToAction(nameof(Index));
        }
    }
}