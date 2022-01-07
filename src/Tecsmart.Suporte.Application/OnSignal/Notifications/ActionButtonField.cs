using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecsmart.Suporte.OnSignal.Notifications
{
    /// <summary>
    /// Class used to describe action field.
    /// </summary>
    public class ActionButtonField
    {
        /// <summary>
        /// Action button ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Action button text.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Action button icon.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
