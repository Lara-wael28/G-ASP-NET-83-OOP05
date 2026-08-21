using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    public class StandardShipment : Shipment , ITrackable , IInsurable
    {
    public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }

        public override decimal EstimatedCost
        {
            get
            {
                return deliveryFee + (weight * 5);
            }
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }

        public string GetTrackingStatus()
        {
            return ($"Shipment {trackingCode} is Ready.");
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine($"Tracking Code : {trackingCode}");
            Console.WriteLine($"Description : {description}");
            Console.WriteLine($"Weight : {weight} KG");
            Console.WriteLine($"Delivery Fee : {deliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        public override Shipment CopyShipment()
        {
            return new StandardShipment(
                this.trackingCode,
                this.description,
                this.weight,
                this.deliveryFee,
                this.Destination
            );
        }
    }
}
