using System;

namespace FutureLogistics
{
    public class TimberTransport : GoodsTransport
    {
        private float timberLength;
        private float timberRadius;
        private string timberType;
        private float timberPrice;

        public float TimberLength
        {
            get => timberLength;
            set => timberLength = value;
        }
        public float TimberRadius
        {
            get => timberRadius;
            set => timberRadius = value;
        }
        public string TimberType
        {
            get => timberType;
            set => timberType = value;
        }
        public float TimberPrice
        {
            get => timberPrice;
            set => timberPrice = value;
        }

        public TimberTransport(
            string transportId,
            string transportDate,
            int transportRating,
            float timberLength,
            float timberRadius,
            string timberType,
            float timberPrice
        )
            : base(transportId, transportDate, transportRating)
        {
            this.timberLength = timberLength;
            this.timberRadius = timberRadius;
            this.timberType = timberType;
            this.timberPrice = timberPrice;
        }

        public override string VehicleSelection()
        {
            float area = 2 * 3.147f * timberRadius * timberLength;
            if (area < 250)
                return "Truck";
            else if (area <= 400)
                return "Lorry";
            else
                return "MonsterLorry";
        }

        public override float CalculateTotalCharge()
        {
            float volume = 3.147f * timberRadius * timberRadius * timberLength;
            float typeMultiplier = timberType.Equals("Premium", StringComparison.OrdinalIgnoreCase)
                ? 0.25f
                : 0.15f;
            float price = volume * timberPrice * typeMultiplier;
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
