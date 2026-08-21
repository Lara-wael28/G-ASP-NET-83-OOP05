namespace OOP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            //a)When you assign one object variable to another, both variables refer to the same object in memory
            //b)No. Assigning one object variable to another does not create a new object. It only copiesthe reference to the existing object
            //c)Copying the object: A new object is created with its own data , Copying the reference: Both variables refer to the same object
            #endregion

            #region question2
            //a)A Shallow Copy creates a new object, but its reference-type members still refer to the same objects as the original
            //b)A Deep Copy creates a new object and also creates new copies of its reference-type members So, the copied object is completely independent from the original
            //c)The reference-type members are not copied into new objects. Both the original and copied objects refer to the same reference-type object
            //d)New objects are created for the reference-type members, so the original and copied objects have different references
            //e)Deep Copy is safer when you want to modify the copied object's reference-type data without affecting the original object

            #endregion

            #region question3
            //a)A static field belongs to the class itself and is shared by all objects of that class , An instance field belongs to each individual object, so every object has its own copy
            //b)A static method belongs to the class rather than a specific object , A static method cannot directly access instance members, because instance members belong to a specific object
            //c)A static constructor is used to initialize static members , It is executed automatically by the runtime before the class is first used It cannot be called manually
            //d)A static class is a class that contains only static members , No, you cannot create an object from a static class

            #endregion

            #region question4
            //a)An Extension Method allows you to add a new method to an existing class without modifying the original class or creating a derived class
            //b)The keyword is this
            //c)An extension method must be declared inside a static class
            //d)An extension method cannot directly access the private members of the class it extends
            #endregion

            #region question5
            //a)A Partial Class allows you to split the definition of one class into multiple files
            //b)To organize the code and make a large class easier to maintain
            //c)A Partial Method is a method that can be declared in one part of a partial class and implemented in another part of the same class
            //d)If a partial method has no implementation, its declaration and calls are removed by the compiler 
            #endregion


            Console.Write("Enter Delivery Center Name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter center = new DeliveryCenter(centerName);
            center.CenterName = centerName;

            Console.WriteLine("\n--- Driver Information ---");

            Console.Write("Driver ID: ");
            int driverId = int.Parse(Console.ReadLine());

            Console.Write("Driver Full Name: ");
            string driverName = Console.ReadLine();

            Console.Write("Driver Phone Number: ");
            string driverPhone = Console.ReadLine();

            Driver driver = new Driver(driverId, driverName, driverPhone);
            center.Driver = driver;

            Console.WriteLine("--- Standard Shipment ---");
            Console.Write("Tracking Code: ");
            string trackingCode1 = Console.ReadLine();
            Console.Write("Description: ");
            string description1 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight1 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal deliveryFee1 = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string city1 = Console.ReadLine();
            Console.Write("Street: ");
            string street1 = Console.ReadLine();
            Console.Write("Building Number: ");
            int buildingNumber1 = int.Parse(Console.ReadLine());
            DeliveryAddress destination1 = new DeliveryAddress(city1, street1, buildingNumber1);

            StandardShipment standard = new StandardShipment(trackingCode1, description1, weight1, deliveryFee1, destination1);

            Console.WriteLine("--- Express Shipment ---");
            Console.Write("Tracking Code: ");
            string trackingCode2 = Console.ReadLine();
            Console.Write("Description: ");
            string description2 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight2 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal deliveryFee2 = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string city2 = Console.ReadLine();
            Console.Write("Street: ");
            string street2 = Console.ReadLine();
            Console.Write("Building Number: ");
            int buildingNumber2 = int.Parse(Console.ReadLine());
            DeliveryAddress destination2 = new DeliveryAddress(city2, street2, buildingNumber2);
            Console.Write("Extra Fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine());

            ExpressShipment express = new ExpressShipment(trackingCode2, description2, weight2, deliveryFee2, destination2, extraFee);

            Console.WriteLine("\n--- International Shipment ---");
            Console.Write("Tracking Code: ");
            string trackingCode3 = Console.ReadLine();
            Console.Write("Description: ");
            string description3 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight3 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal deliveryFee3 = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string city3 = Console.ReadLine();
            Console.Write("Street: ");
            string street3 = Console.ReadLine();
            Console.Write("Building Number: ");
            int buildingNumber3 = int.Parse(Console.ReadLine());
            DeliveryAddress destination3 = new DeliveryAddress(city3, street3, buildingNumber3);
            Console.Write("Destination Country: ");
            string destinationCountry = Console.ReadLine();
            Console.Write("Customs Fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine());

            InternationalShipment international = new InternationalShipment(trackingCode3, description3, weight3, deliveryFee3, destination3, destinationCountry, customsFee);
           
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Static Shipment Counter");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            DeliveryUtilities.PrintSystemTitle();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Object Copying");
            Console.WriteLine("==========================================");

            Shipment shipment1 = standard;
            Shipment shipment2 = shipment1;

            Console.WriteLine($"Original Shipment : {shipment1.trackingCode}");
            Console.WriteLine($"Assigned Shipment : {shipment2.trackingCode}");
            Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, shipment2)}");

            Shipment copiedShipment = shipment1.CopyShipment();

            Console.WriteLine($"Copied Shipment : {copiedShipment.trackingCode}");
            Console.WriteLine($"Same Object After Copy : {ReferenceEquals(shipment1, copiedShipment)}");
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Shallow Copy");
            Console.WriteLine("==========================================");

            Shipment shallowCopy = shipment1.ShallowCopy();

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.city}");
            Console.WriteLine($"Copied Shipment Address : {shallowCopy.Destination.city}");

            Console.WriteLine("Changing copied shipment address...");

            shallowCopy.Destination.city = "Giza";

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.city}");
            Console.WriteLine($"Copied Shipment Address : {shallowCopy.Destination.city}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.Destination, shallowCopy.Destination)}");

            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Deep Copy");
            Console.WriteLine("------------------------------------------");

            Shipment deepCopy = shipment1.DeepCopy();
            shipment1.Destination.city = "Cairo";

            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.city}");
            Console.WriteLine($"Copied Shipment Address : {deepCopy.Destination.city}");
            Console.WriteLine("Changing copied shipment address...");
            deepCopy.Destination.city = "Giza";
            Console.WriteLine($"Original Shipment Address : {shipment1.Destination.city}");
            Console.WriteLine($"Copied Shipment Address : {deepCopy.Destination.city}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(shipment1.Destination, deepCopy.Destination)}");


            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using DeliveryHelper ");
            Console.WriteLine("==========================================");
            DeliveryHelper.PrintShipmentDetails(standard);
            Console.WriteLine();
            DeliveryHelper.PrintShipmentDetails(express);
            Console.WriteLine();
            DeliveryHelper.PrintShipmentDetails(international);
            Console.WriteLine();

            Console.WriteLine("==========================================");
            Console.WriteLine("Updating Weight...");
            Console.WriteLine("==========================================");

            Console.WriteLine($"Original Weight : {standard.weight} KG");
            standard.UpdateWeight(5);

            Console.WriteLine($"Updated Weight : {standard.weight} KG");
            standard.UpdateWeight(5, 0.5m);

            Console.WriteLine($"Updated Weight After Packing : {standard.weight} KG");


            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Printing Using Shipment[]...");
            Console.WriteLine("==========================================");

            Shipment[] shipments = { standard, express, international };

            foreach (Shipment shipment in shipments)
            {
                shipment.PrintShipment();

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Sealed Method Demonstration");
            Console.WriteLine("==========================================");

            PriorityInternationalShipment priority = new PriorityInternationalShipment(
                    "SH005",
                    "Camera",
                    4,
                    150,
                    destination2,
                    "France",
                    120);
            priority.GenerateCustomsReport();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Tracking Statuses");
            Console.WriteLine("==========================================");
            center.PrintTrackingStatuses();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("ITrackable[] Demonstration");
            Console.WriteLine("==========================================");

            ITrackable[] trackableShipments =
            {
                standard,
                express,
                international
            };

            foreach (ITrackable shipment in trackableShipments)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("IInsurable[] Demonstration");
            Console.WriteLine("==========================================");

            IInsurable[] insurableShipments =
            {
                standard,
                express,
                international
            };

            foreach (IInsurable shipment in insurableShipments)
            {
                Console.WriteLine($"Insurance : {shipment.CalculateInsurance():F2} EGP");
            }

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("Delivery Report");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n--- Standard Shipment ---");
            DeliveryReport.PrintShipment(standard);
            DeliveryReport.PrintInsurance(standard);

            Console.WriteLine("\n--- Express Shipment ---");
            DeliveryReport.PrintShipment(express);
            DeliveryReport.PrintInsurance(express);

            Console.WriteLine("\n--- International Shipment ---");
            DeliveryReport.PrintShipment(international);
            DeliveryReport.PrintInsurance(international);

            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(standard.GetSummary());
            Console.WriteLine(express.GetSummary());
            Console.WriteLine(international.GetSummary());

            Console.WriteLine($"SH001 Is Delivered : {standard.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {international.IsDelivered()}");


            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();

            standard.UpdateTrackingStatus("Out For Delivery");
            international.UpdateTrackingStatus("Delivered");


            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");


            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();

            international.UpdateTrackingStatus("Delivered");


            Console.Write("\nEnter tracking code to search: ");
            string searchCode = Console.ReadLine();
            Shipment found = center[searchCode];
            if (found != null)
            {
                Console.WriteLine("\nShipment Found:");
                found.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }


            Console.Write("\nEnter tracking code to remove: ");
            string removeCode = Console.ReadLine();
            bool removed = center.RemoveShipment(removeCode);
            Console.WriteLine(removed ? "Shipment removed successfully." : "Shipment not found for removal.");
            Console.WriteLine("\n--- Remaining Shipments ---");
            center.PrintAllShipments();



        }
    }
}
