namespace _08_abstract
{
    abstract public class Shape : IComparable<Shape>
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Shape(string name)
        {
            this.name = name;
        }

        abstract public double Area();
        abstract public double Perimeter();
        abstract public void Show();

        public int CompareTo(Shape? other)
        {
            return Area().CompareTo(other.Area());
        }
    }

    public class Circle : Shape
    {
        private double radius;
        private double area;
        private double perimeter;
        public double Radius { get { return radius; } set { radius = value; } }
        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        public override double Perimeter()
        {
            perimeter = 2 * Math.PI * radius;
            return perimeter;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} with radius {radius}cm has area {area}cm and perimeter {perimeter}cm");
        }
    }

    public class Square : Shape
    {
        private double side;
        private double area;
        private double perimeter;
        public double Side { get { return side; } set { side = value; } }
        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            area = Math.Pow(side, 2);
            return area;
        }

        public override double Perimeter()
        {
            perimeter = side * 4;
            return perimeter;
        }

        public override void Show()
        {
            Console.WriteLine($"{Name} with side {side}cm has area {area}cm and perimeter {perimeter}cm");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            List<Shape> shapes = new List<Shape>();
            int size = 6;

            for (int i = 0; i < size; i++)
            {
                try
                {
                    Console.Write("Enter a name of the shape: ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "circle")
                    {
                        try
                        {
                            Console.Write($"Enter {name}'s radius: ");
                            double radius = double.Parse(Console.ReadLine());

                            shapes.Add(new Circle(name, radius));
                        }
                        catch (Exception ex)
                        {
                            i--;
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (name.ToLower() == "square")
                    {
                        try
                        {
                            Console.Write($"Enter {name}'s side: ");
                            double side = double.Parse(Console.ReadLine());

                            shapes.Add(new Square(name, side));
                        }
                        catch(Exception ex)
                        {
                            i--;
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        i--;
                        throw new Exception($"I don't know how calculate {name}'s parameters. Please, enter circle or square");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nList of shapes:\n");
            foreach(Shape s in shapes)
            {
                s.Area();
                s.Perimeter();
                s.Show();
                Console.WriteLine();
            }

            //2
            var rangeArea = shapes.Where(s => (s.Area() >= 10 && s.Area() <= 100));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "shapes.txt";
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine($"Shapes with area from range 10 to 100:");
                foreach(Shape s in rangeArea)
                {
                    writer.WriteLine($"{s.Name} with area {s.Area()}cm");
                }
            }

            //3
            var shapesWithA = shapes.Where(s => s.Name.Contains('a'));

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"\nShapes with letter 'a':");
                foreach (Shape s in shapesWithA)
                {
                    writer.WriteLine($"{s.Name} with area {s.Area()}cm and perimeter {s.Perimeter()}");
                }
            }

            using (StreamReader reader = File.OpenText(filePath))
            {
                string fileShapes = reader.ReadToEnd();
                Console.WriteLine(fileShapes);
            }

            //4
            shapes.RemoveAll(s => s.Perimeter() < 5);

            Console.WriteLine("Shapes with perimeter more than 5cm:");
            foreach(Shape s in shapes)
            {
                Console.WriteLine($"{s.Name} with perimeter {s.Perimeter()}cm");
            }

            /*Shape shapeWithLargestPerimeter = GetShapeWithLargestPerimeter(shapes);

            static Shape GetShapeWithLargestPerimeter(List<Shape> shapes)
            {
                Shape largestPerimeterShape = null;
                double largestPerimeter = 0;

                foreach (Shape s in shapes)
                {
                    double perimeter = s.Perimeter();
                    if (perimeter > largestPerimeter)
                    {
                        largestPerimeter = perimeter;
                        largestPerimeterShape = s;
                    }
                }
                Console.WriteLine($"{largestPerimeterShape.Name} has the largest perimeter {largestPerimeter}cm");
                return largestPerimeterShape;
            }

            shapes.Sort();
            Console.WriteLine("\nSorted list:");
            foreach (Shape s in shapes)
            {
                s.Show();
            }*/
        }
    }
}