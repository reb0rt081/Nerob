using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerob.Domain;
using Unity;

namespace Nerob.Client.Modules.Picking
{
    public class PickingModule : IPickingModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
    }
}
