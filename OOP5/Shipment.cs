using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    public abstract partial class Shipment
    {
            public static int TotalShipmentsCreated;
            private string TrackingCode;
            private string Description;
            private decimal Weight;
            private decimal DeliveryFee; 
            public DeliveryAddress Destination { get; set; }

            static Shipment()
            {
                TotalShipmentsCreated = 0;
                Console.WriteLine("Shipment System Initialized");
            }

        public static int GetTotalShipmentsCreated() 
        {
            return TotalShipmentsCreated;
        }
        public string trackingCode
            {
                get { return TrackingCode; }
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        TrackingCode = value;
                }
            }

            public string description
            {
                get { return Description; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        Description = value;
                }
            }

            public decimal weight
            {
                get { return Weight; }
                set
                {
                    if (value > 0)
                        Weight = value;
                }
            }

            public decimal deliveryFee
            {
                get { return DeliveryFee; }
                private set
                {
                    if (value > 0)
                        DeliveryFee = value;
                }
            }
           public abstract decimal EstimatedCost { get; }
            

            public Shipment(string trackingCode)
            {
                this.trackingCode = trackingCode;
                Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                Destination = new DeliveryAddress("Unknown", "Unknown", 0);
                TotalShipmentsCreated++;
            }

            public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            {
                this.trackingCode = trackingCode;
                this.description = description;
                this.weight = weight;
                this.deliveryFee = deliveryFee;
                Destination = destination;
                TotalShipmentsCreated++;

            }
            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                    DeliveryFee = newFee;
            }

            public void UpdateWeight(decimal newWeight)
            {
                if (newWeight > 0)
                    Weight = newWeight;
            }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight > 0 && extraPackingWeight >= 0)
                Weight = newWeight + extraPackingWeight;
        }

        public abstract void PrintShipment();

        public virtual Shipment CopyShipment()
        {
            return new StandardShipment(
               this.trackingCode,
               this.description,
               this.weight,
               this.deliveryFee,
               this.Destination );
        }
        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = this.CopyShipment();

            copy.Destination = new DeliveryAddress(
                this.Destination.city,
                this.Destination.street,
                this.Destination.BuildingNumber
            );

            return copy;
        }
        partial void OnTrackingStatusChanged(string newStatus);
    }
    }

