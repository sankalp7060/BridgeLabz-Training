namespace TechVille.Core.Models
{
    public class Citizen
    {
        private string _name;
        private int _age;
        private double _income;
        private int _residencyYears;

        public Guid CitizenId { get; private set; }

        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age cannot be negative.");
                _age = value;
            }
        }

        public double Income
        {
            get => _income;
            set => _income = value;
        }

        public int ResidencyYears
        {
            get => _residencyYears;
            set => _residencyYears = value;
        }

        public ServicePackage Package { get; set; }

        public Citizen(string name, int age, double income, int residencyYears)
        {
            CitizenId = Guid.NewGuid();
            Name = name;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;
        }

        public override string ToString()
        {
            return $"ID: {CitizenId}\nName: {Name}\nAge: {Age}\nIncome: {Income}\nResidency: {ResidencyYears} years\nPackage: {Package}";
        }
    }
}
