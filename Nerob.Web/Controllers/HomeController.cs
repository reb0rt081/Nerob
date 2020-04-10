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

        [HttpGet]
        public ActionResult InventoryDetail(string barcodeId)
        {
            var viewModel = new InventoryInformation()
            {
                ItemName = "Tornillos",
                ItemDescription = @"D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221,5): warning : CompleteTransportRequest.cs(15,18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportRequest' [D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj] D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221, 5): warning : CompleteTransportResponse.cs(16, 18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportResponse'[D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj]",
                ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                QuantityAvailable = 10,
                ItemBarcode = barcodeId 
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitInventory(InventoryInformation model)
        { 
            // Do stuff

            // When done please navigate back to this view
            return RedirectToAction(nameof(Index));
        }
    }
}