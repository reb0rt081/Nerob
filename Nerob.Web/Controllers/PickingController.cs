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
        public IEnumerable<InventoryInformation> Get(int id)
        {
            return new List<InventoryInformation>
            { new InventoryInformation()
                {
                    ItemName = "Tornillos",
                    ItemDescription = @"D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221,5): warning : CompleteTransportRequest.cs(15,18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportRequest' [D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj] D:\TGW\bin\PDEnvironment\SCOTe.Agent\v2\Projects\BuildSolution.proj(221, 5): warning : CompleteTransportResponse.cs(16, 18): warning CS1591: Missing XML comment for publicly visible type or member 'CompleteTransportResponse'[D:\_B\6837055\B\8\Products\SharedCode\ManualTransports\ManualTransports.Facade.Messages\ManualTransports.Facade.Messages.csproj]",
                    ItemLocation = "Pasillo 1 / Armario 2 / Estanteria 4 / Posición 3",
                    QuantityAvailable = 10,
                    ItemBarcode = id.ToString()
                }
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
