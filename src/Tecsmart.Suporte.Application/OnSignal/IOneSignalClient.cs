using Tecsmart.Suporte.OnSignal.Devices;
using Tecsmart.Suporte.OnSignal.Notifications;

namespace Tecsmart.Suporte.OnSignal
{
    public interface IOneSignalClient
    {
        /// <summary>
        /// Device resources.
        /// </summary>
        IDevicesResource Devices { get; }

        /// <summary>
        /// Notification resources.
        /// </summary>
        INotificationsResource Notifications { get; }
    }
}
