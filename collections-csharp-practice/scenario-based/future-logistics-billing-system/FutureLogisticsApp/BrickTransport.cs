using System;

namespace FutureLogistics
{
    public class BrickTransport : GoodsTransport
    {
        private float brickSize;
        private int brickQuantity;
        private float brickPrice;

        public float BrickSize
        {
            get => brickSize;
            set => brickSize = value;
        }
        public int BrickQuantity
        {
            get => brickQuantity;
            set => brickQuantity = value;
        }
        public float BrickPrice
        {
            get => brickPrice;
            set => brickPrice = value;
        }

        public BrickTransport(
            string transportId,
            string transportDate,
            int transportRating,
            float brickSize,
            int brickQuantity,
            float brickPrice
        )
            : base(transportId, transportDate, transportRating)
        {
            this.brickSize = brickSize;
            this.brickQuantity = brickQuantity;
            this.brickPrice = brickPrice;
        }

        public override string VehicleSelection()
        {
            if (brickQuantity < 300)
                return "Truck";
            else if (brickQuantity <= 500)
                return "Lorry";
            else
                return "MonsterLorry";
        }

        public override float CalculateTotalCharge()
        {
            float price = brickPrice * brickQuantity;
            float tax = price * 0.3f;
            float vehiclePrice = VehicleSelection().ToLower() switch
            {
                "truck" => 1000f,
                "lorry" => 1700f,
                "monsterlorry" => 3000f,
                _ => 0f,
            };

            float discountPercent = transportRating switch
            {
                5 => 0.2f,
                3 or 4 => 0.1f,
                _ => 0f,
            };

            float discount = price * discountPercent;
            return price + tax + vehiclePrice - discount;
        }
    }
}
