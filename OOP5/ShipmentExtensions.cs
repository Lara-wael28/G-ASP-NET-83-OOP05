using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string status = "";

            if (shipment is ITrackable trackable)
            {
                status = trackable.GetTrackingStatus();
            }

            return $"{shipment.trackingCode} | {shipment.GetType().Name.Replace("Shipment", "")} | {shipment.weight} KG | {status}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment is InternationalShipment)
                return true;

            return false;
        }
    }
}
