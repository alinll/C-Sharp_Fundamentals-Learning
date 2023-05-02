namespace _04_task
{
    //1
    class Car
    {
        string name;
        string color;
        decimal price;
        const string companyName = "Land Rover";
        public Car()
        {
            name = "unknown name";
            color = "unknown color";
            price = 0;
        }
        public Car(string name, string color, decimal price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public void Input()
        {
            Console.Write("\nEnter name of the car: ");
            name = Console.ReadLine();

            Console.Write("Enter color of the car: ");
            color = Console.ReadLine();

            Console.Write("Enter price of the car: ");
            price = decimal.Parse(Console.ReadLine());
        }
        public void Print()
        {
            Console.WriteLine($"Name: {name}, color: {color}, price: {price}");
        }
        public void ChangePrice(double x)
        {
            price *= (1 + (decimal)x / 100);
        }
        public void getCompanyName()
        {
            Console.WriteLine(companyName);
        }

        //4
        public void SetNewColor(string newColor)
        {
            if(color == "white")
            {
                color = newColor;
            }
        }

        //5
        public static bool operator ==(Car left, Car right)
        {
            return left.name == right.name && left.price == right.price;
        }
        public static bool operator !=(Car left, Car right)
        {
            return left.name != right.name && left.price != right.price;
        }

        //6
        public override string ToString()
        {
            return $"Name: {name}, color: {color}, price: {price}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car defaultCar = new Car();
            defaultCar.getCompanyName();
            defaultCar.Print();
            defaultCar.Input();
            defaultCar.Print();

            //2
            Console.WriteLine("\nList of cars:");
            Car firstCar = new Car("Range Rover", "gray", 7122693);
            Car secondCar = new Car("Defender", "gray", 5662385);
            Car thirdCar = new Car("Range Rover Velar", "white", 3343056);
            Car fourthCar = new Car("Range Rover", "gray", 7122693);

            firstCar.Print();
            secondCar.Print();
            thirdCar.Print();
            fourthCar.Print();

            //3
            double percentage = -10;
            firstCar.ChangePrice(percentage);
            secondCar.ChangePrice(percentage);
            thirdCar.ChangePrice(percentage);
            fourthCar.ChangePrice(percentage);

            Console.WriteLine($"\nList of cars after {percentage}% prices");
            firstCar.Print();
            secondCar.Print();
            thirdCar.Print();
            fourthCar.Print();

            //4
            Console.Write("\nEnter new color: ");
            thirdCar.SetNewColor(Console.ReadLine());
            thirdCar.Print();

            //5
            if(firstCar == fourthCar)
            {
                Console.WriteLine($"\n{firstCar} is equal {fourthCar}");
            }
            else
            {
                Console.WriteLine($"\n{firstCar} is not equal {fourthCar}");
            }
        }
    }
}