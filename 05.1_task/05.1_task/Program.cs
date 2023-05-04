namespace _05._1_task
{
    //1
    interface IFlyable
    {
        void Fly()
        {
            Console.WriteLine("Object can fly");
        }
    }

    //2
    class Bird : IFlyable
    {
        public string Name { get; set; }
        public bool canFly { get; set; }
        public void Fly()
        {
            if (canFly)
            {
                Console.WriteLine($"{Name} can fly");
            }
            else if(!canFly)
            {
                Console.WriteLine($"{Name} can't fly");
            }
        }
    }

    class Plane : IFlyable
    {
        public string Mark { get; set; }
        public float HighFly { get; set; }
        public void Fly()
        {
            Console.WriteLine($"{Mark} plane can fly up to {HighFly}m");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new()
            {
                Name = "Peregrine falcon",
                canFly = true
            };

            Bird bird2 = new()
            {
                Name = "Penguin",
                canFly = false
            };

            Plane plane = new()
            {
                Mark = "AN-225 Mriya",
                HighFly = 11000
            };

            //3
            IFlyable[] flyingObject = new IFlyable[]
            {
                bird1,
                bird2,
                new Bird() {Name = "Chicken", canFly = true},
                plane,
                new Plane() {Mark = "AN-124 Ruslan", HighFly = 9000}
            };

            foreach(IFlyable flyingObj in flyingObject)
            {
                flyingObj.Fly();
            }
        }
    }
}