using System;

namespace FutureLogistics
{
    public class BillingMain
    {
        public static void Start()
        {
            Console.WriteLine("Enter the Goods Transport details");
            string input = Console.ReadLine();

            Utility util = new Utility();

            try
            {
                GoodsTransport transport = util.ParseDetails(input);

                if (!util.ValidateTransportId(transport.TransportId))
                    return;

                string type = util.FindObjectType(transport);

                Console.WriteLine($"Transporter id : {transport.TransportId}");
                Console.WriteLine($"Date of transport : {transport.TransportDate}");
                Console.WriteLine($"Rating of the transport : {transport.TransportRating}");

                if (transport is BrickTransport brick)
                {
                    Console.WriteLine($"Quantity of bricks : {brick.BrickQuantity}");
                    Console.WriteLine($"Brick price : {brick.BrickPrice}");
                    Console.WriteLine($"Vehicle for transport : {brick.VehicleSelection()}");
                    Console.WriteLine($"Total charge : {brick.CalculateTotalCharge():0.00}");
                }
                else if (transport is TimberTransport timber)
                {
                    Console.WriteLine($"Type of the timber : {timber.TimberType}");
                    Console.WriteLine($"Timber price per kilo : {timber.TimberPrice}");
                    Console.WriteLine($"Vehicle for transport : {timber.VehicleSelection()}");
                    Console.WriteLine($"Total charge : {timber.CalculateTotalCharge():0.00}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
