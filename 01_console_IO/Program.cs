//1

using System.Numerics;

Console.WriteLine("Enter side of the square");
int a = int.Parse(Console.ReadLine());

Console.Write("Area of a square: ");
Console.WriteLine(Math.Pow(a, 2));

Console.Write("Perimeter of a square: ");
Console.WriteLine(a + a + a + a);

//2

Console.WriteLine("What is your name?");
string name = Console.ReadLine();
Console.WriteLine($"How old are you, {name}?");
int age = int.Parse(Console.ReadLine());
Console.WriteLine($"{name} is {age} years old");

//3

Console.Write("Enter a radius of a circle: ");
double r = double.Parse(Console.ReadLine());
Console.WriteLine(r);
double l = 2 * Math.PI * r;
double S = Math.PI * r * r;
double volume = 4 / 3 * Math.PI * r * r * r;
Console.WriteLine($"Length of a circle: {l}; area: {S}; volume: {volume}");