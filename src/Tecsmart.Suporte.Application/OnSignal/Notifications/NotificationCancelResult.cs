using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace Tecsmart.Suporte.OnSignal.Notifications
{
    /// <summary>
    /// Result of notification cancel operation.
    /// </summary>
    public class NotificationCancelResult
    {
        /// <summary>
        /// Returns whether the message was canceled or not
        /// {'success': "true"}
        /// </summary>
        [DeserializeAs(Name = "success")]
        public string Success { get; set; }
    }
}
