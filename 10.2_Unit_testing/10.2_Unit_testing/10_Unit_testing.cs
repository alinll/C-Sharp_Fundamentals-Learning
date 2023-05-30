using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2_Unit_testing
{
    internal class _10_Unit_testing
    {
        public struct Point
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
        public class Triangle
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
    }
}
