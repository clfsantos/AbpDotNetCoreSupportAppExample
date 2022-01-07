using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecsmart.Suporte.OnSignal.Devices
{
    public class DeviceAddResult
    {
        /// <summary>
        /// Returns true if operation is successfull.
        /// </summary>
        [DeserializeAs(Name = "success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Returns id of the result operation.
        /// </summary>
        [DeserializeAs(Name = "id")]
        public string Id { get; set; }
    }
}
