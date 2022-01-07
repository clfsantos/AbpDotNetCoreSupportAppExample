using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecsmart.Suporte.OnSignal.Devices
{
    /// <summary>
    /// Test type enumeration.
    /// </summary>
    public enum TestTypeEnum
    {
        /// <summary>
        /// Used during development phase.
        /// </summary>
        Development = 1,
        /// <summary>
        /// Used in production, when trying to track down undelivered messages for example.
        /// </summary>
        AdHoc = 2
    }
}
