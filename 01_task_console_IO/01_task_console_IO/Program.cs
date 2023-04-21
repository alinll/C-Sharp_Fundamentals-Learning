//1

Console.WriteLine("Enter a number: ");

int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());

Console.WriteLine("Entered numbers: " + a + "; " + b);

Console.Write("a + b = ");
Console.WriteLine(a + b);

Console.Write("a - b = ");
Console.WriteLine(a - b);

Console.Write("a * b = ");
Console.WriteLine(a * b);

Console.Write("a / b = ");
Console.WriteLine(a / b);

//2

Console.WriteLine("How are you?");

string answer = Console.ReadLine();
Console.WriteLine("\nYou are " + answer);

//3

Console.WriteLine("Enter 3 chars: ");
char first = char.Parse(Console.ReadLine());
char second = char.Parse(Console.ReadLine());
char third = char.Parse(Console.ReadLine());
Console.WriteLine("You enter " + first + " " + second + " " + third);

//4

bool check = true;
Console.WriteLine(a > 0 & b > 0 ? "Positive" : "Negative");