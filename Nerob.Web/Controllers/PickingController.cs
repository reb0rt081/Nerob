using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nerob.Shared;

namespace Nerob.Web.Controllers
{
    // This is a Web API, it just can handle data and return data to the HTML
    public class PickingController : ApiController
    {
        // GET: api/Picking
        public IEnumerable<InventoryInformation> Get()
        {
            return new List<InventoryInformation>{
                new InventoryInformation()
                {
                    ItemName = "Scan Item",
                    ItemDescription = string.Empty,
                    ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                    QuantityAvailable = 0,
                    ItemBarcode = string.Empty
                }
            };
        }

        // GET: api/Picking/5
        public InventoryInformation Get(int id)
        {
            return new InventoryInformation()
            {
                ItemName = "Scan Item",
                ItemDescription = string.Empty,
                ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                QuantityAvailable = 10,
                ItemBarcode = string.Empty
            };
        }

        // POST: api/Picking
        public void Post([FromBody]InventoryInformation value)
        {
        }

        // PUT: api/Picking/5
        public void Put(int id, [FromBody]InventoryInformation value)
        {
        }

        // DELETE: api/Picking/5
        public void Delete(int id)
        {
        }
    }
}
