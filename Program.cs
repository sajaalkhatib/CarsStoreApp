namespace CarsStoreApp
{

    class CarsStore
    {
        public string StoreName { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }

        public CarsStore(string storeName, string location, string owner)
        {
            StoreName = storeName;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Store Name: {StoreName}\nLocation: {Location}\nOwner: {Owner}";
        }
    }


    class Car
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }

        public Car(string carName, decimal price)
        {
            CarName = carName;
            Price = price;
        }

        public override string ToString()
        {
            return $"Car Name: {CarName}\nPrice: {Price:C}";
        }
    }
    class CarOnSale : Car
    {
        public double DiscountPercent { get; set; }
        public decimal FinalPrice { get; private set; }

        public CarOnSale(string carName, decimal price, double discountPercent)
            : base(carName, price)
        {
            DiscountPercent = discountPercent;
            FinalPrice = CalculateFinalPrice();
        }

        private decimal CalculateFinalPrice()
        {
            return Price - (Price * (decimal)(DiscountPercent / 100));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nDiscount: {DiscountPercent}%\nFinal Price: {FinalPrice:C}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Store Name:");
            string storeName = Console.ReadLine();

            Console.WriteLine("Enter Store Location:");
            string location = Console.ReadLine();

            Console.WriteLine("Enter Store Owner:");
            string owner = Console.ReadLine();

            CarsStore store = new CarsStore(storeName, location, owner);
            Console.WriteLine("\nStore Details:");
            Console.WriteLine(store);

            Console.WriteLine("\nEnter Car Name:");
            string carName = Console.ReadLine();

            Console.WriteLine("Enter Car Price:");
            decimal carPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Discount Percent:");
            double discountPercent = Convert.ToDouble(Console.ReadLine());

            CarOnSale carOnSale = new CarOnSale(carName, carPrice, discountPercent);
            Console.WriteLine("\nCar on Sale Details:");
            Console.WriteLine(carOnSale);



            Console.WriteLine("Enter the first number (leave empty for null):");
            string input1 = Console.ReadLine();
            double? num1 = string.IsNullOrWhiteSpace(input1) ? (double?)null : double.Parse(input1);

            Console.WriteLine("Enter the second number (leave empty for null):");
            string input2 = Console.ReadLine();
            double? num2 = string.IsNullOrWhiteSpace(input2) ? (double?)null : double.Parse(input2);

            Console.WriteLine("Choose an operation (+, -, *, /, ^, sqrt):");
            string operation = Console.ReadLine();

            double result = PerformOperation(num1, num2, operation);
            Console.WriteLine($"Result: {result}");
        }

        static double PerformOperation(double? num1, double? num2, string operation)
        {
            double a = num1 ?? 0; // Use 0 if num1 is null
            double b = num2 ?? 0; // Use 0 if num2 is null

            try
            {
                return operation switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => b == 0 ? 0 : a / b, // Handle division by zero
                    "^" => Math.Pow(a, b),
                    "sqrt" => a < 0 ? 0 : Math.Sqrt(a), // Handle square root of negative number
                    _ => 0 // Default case for unsupported operations
                };
            }
            catch
            {
                return 0; // Return 0 in case of any unexpected exceptions
            }












        }
    }
}
