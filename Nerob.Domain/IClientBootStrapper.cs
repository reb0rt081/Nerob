using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Domain
{
    public interface IClientBootStrapper
    {
        /// <summary>
        /// Starts the Client Bootstrapper.
        /// </summary>
        void Run();

        /// <summary>
        /// Checks that only one instance of the client is running.
        /// Kills this instance otherwise.
        /// </summary>
        void CheckUniqueInstanceIsRunning();

        /// <summary>
        /// Loads all the modules registered.
        /// </summary>
        void LoadModules();
    }
}
