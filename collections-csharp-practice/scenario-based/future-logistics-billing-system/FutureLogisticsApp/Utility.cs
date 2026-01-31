using System;
using System.Text.RegularExpressions;

namespace FutureLogistics
{
    public class Utility
    {
        public GoodsTransport ParseDetails(string input)
        {
            string[] parts = input.Split(':');
            if (parts.Length < 7)
                throw new ArgumentException("Invalid input format.");

            string transportId = parts[0];
            string transportDate = parts[1];
            int transportRating = int.Parse(parts[2]);
            string transportType = parts[3];

            if (transportType.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
            {
                float brickSize = float.Parse(parts[4]);
                int brickQuantity = int.Parse(parts[5]);
                float brickPrice = float.Parse(parts[6]);
                return new BrickTransport(
                    transportId,
                    transportDate,
                    transportRating,
                    brickSize,
                    brickQuantity,
                    brickPrice
                );
            }
            else if (transportType.Equals("TimberTransport", StringComparison.OrdinalIgnoreCase))
            {
                float timberLength = float.Parse(parts[4]);
                float timberRadius = float.Parse(parts[5]);
                string timberType = parts[6];
                float timberPrice = float.Parse(parts[7]);
                return new TimberTransport(
                    transportId,
                    transportDate,
                    transportRating,
                    timberLength,
                    timberRadius,
                    timberType,
                    timberPrice
                );
            }
            else
            {
                throw new ArgumentException("Invalid transport type.");
            }
        }

        public bool ValidateTransportId(string transportId)
        {
            Regex regex = new Regex(@"^RTS\d{3}[A-Z]$");
            if (!regex.IsMatch(transportId))
            {
                Console.WriteLine($"Transport id {transportId} is invalid");
                Console.WriteLine("Please provide a valid record");
                return false;
            }
            return true;
        }

        public string FindObjectType(GoodsTransport transport)
        {
            if (transport is BrickTransport)
                return "BrickTransport";
            if (transport is TimberTransport)
                return "TimberTransport";
            return "Unknown";
        }
    }
}
