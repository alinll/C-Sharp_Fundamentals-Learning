namespace _10._1_Unit_testing
{
    public class Program
    {
        struct Point
        {
            private int x;
            private int y;

            public int X { get { return x; } set { x = value; } }
            public int Y { get { return y; } set { y = value; } }

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"({x},{y})";
            }
        }
        class Triangle
        {
            private Point vertex1;
            private Point vertex2;
            private Point vertex3;

            public Point Vertex1 { get { return vertex1; } set { vertex1 = value; } }
            public Point Vertex2 { get { return vertex2; } set { vertex2 = value; } }
            public Point Vertex3 { get { return vertex3; } set { vertex3 = value; } }

            public Triangle(Point vertex1, Point vertex2, Point vertex3)
            {
                this.vertex1 = vertex1;
                this.vertex2 = vertex2;
                this.vertex3 = vertex3;
            }

            public double Distance(Point p1, Point p2)
            {
                int dx = p2.X - p1.X;
                int dy = p2.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public double Perimeter()
            {
                double perimeter = Distance(vertex1, vertex2) + Distance(vertex2, vertex3) + Distance(vertex3, vertex1);
                return perimeter;
            }

            public double Square()
            {
                double side1 = Distance(vertex1, vertex2);
                double side2 = Distance(vertex2, vertex3);
                double side3 = Distance(vertex3, vertex1);
                double semiPerimeter = Perimeter() / 2;
                double square = Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
                return square;
            }

            public void Print()
            {
                Console.WriteLine($"Triangle vertices: {vertex1}, {vertex2}, {vertex3}\nPerimeter: {Perimeter()}\nSquare: {Square()}");
            }
        }
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(4, 1);
            Point p3 = new Point(1, 5);
            Point p4 = new Point(2, 2);
            Point p5 = new Point(5, 2);
            Point p6 = new Point(2, 6);
            Point p7 = new Point(4, 4);
            Point p8 = new Point(8, 4);
            Point p9 = new Point(4, 8);

            List<Triangle> triangles = new List<Triangle>();
            Triangle t1 = new Triangle(p4, p5, p6);
            triangles.Add(t1);
            Triangle t2 = new Triangle(p1, p2, p3);
            triangles.Add(t2);
            Triangle t3 = new Triangle(p7, p8, p9);
            triangles.Add(t3);

            foreach(Triangle t in triangles)
            {
                t.Print();
                Console.WriteLine();
            }

            double minDistance = double.MaxValue;
            Triangle closest = null;

            foreach(Triangle t in triangles)
            {
                double distance = t.Distance(new Point(0, 0), t.Vertex1);
                
                if(distance < minDistance)
                {
                    minDistance = distance;
                    closest = t;
                }
            }

            Console.WriteLine($"The closest triangle to the origin (0, 0): ");
            closest.Print();
        }
    }
}