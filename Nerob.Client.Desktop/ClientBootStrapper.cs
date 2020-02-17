using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerob.Domain;
using Unity;

namespace Nerob.Client.Desktop
{
    public class ClientBootStrapper : IClientBootStrapper
    {
        private IUnityContainer container; 
        public void Run()
        {
            CheckUniqueInstanceIsRunning();
        }

        public void CheckUniqueInstanceIsRunning()
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (System.Diagnostics.Process.GetProcessesByName(processName).Count() > 1)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        public void LoadModules()
        {
            throw new NotImplementedException();
        }
    }
}
