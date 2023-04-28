//1
Console.WriteLine("Enter range from a to b: ");
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int count = 0;
for(int i = a; i <= b; i++)
{
    if(i % 3 == 0)
    {
        Console.WriteLine(i);
        ++count;
    }
}
Console.WriteLine($"Count of numbers: {count}");

//2
Console.Write("Enter string: ");
string line = Console.ReadLine();
for(int i = 0; i < line.Length; i+=2)
{
    if(i != 0)
    {
        Console.Write(line[i] + " ");
    }
}

//3
double coffeePrice = 2.50;
double teaPrice = 1.75;
double juicePrice = 3.00;
double waterPrice = 1.00;

Console.WriteLine("Choose a drink: coffee, tea, juice or water");
string drink = Console.ReadLine();
switch (drink)
{
    case "coffee": Console.WriteLine($"{drink} costs {coffeePrice}UAH"); break;
    case "tea": Console.WriteLine($"{drink} costs {teaPrice}UAH"); break;
    case "juice": Console.WriteLine($"{drink} costs {juicePrice}UAH"); break;
    case "water": Console.WriteLine($"{drink} costs {waterPrice}UAH"); break;
    default: Console.WriteLine("Such drink isn't on the list"); break;
}

//4
Console.WriteLine("Enter sequence of numbers: ");
int sum = 0;
count = 0;
int sequence;

while((sequence = int.Parse(Console.ReadLine())) >= 0)
{
    sum += sequence;
    ++count;
}

if(count > 0)
{
    double average = (double)sum / count;
    Console.WriteLine($"Average: {average}");
}
else
{
    Console.WriteLine("There is no positive number");
}

//5
Console.Write("Enter a year: ");
int year = int.Parse(Console.ReadLine());
if (DateTime.IsLeapYear(year))
{
    Console.WriteLine("Entered year is leap");
}
else
{
    Console.WriteLine("Entered year isn't leap");
}

//6
Console.Write("Enter an integer: ");
int integer = int.Parse(Console.ReadLine());
sum = 0;
while(integer != 0)
{
    sum += integer % 10;
    integer /= 10;
}
Console.WriteLine($"Sum of digits: {sum}");

//7
Console.Write("Enter an integer: ");
int number = int.Parse(Console.ReadLine());
bool oddDigits = true;
foreach(int digit in number.ToString())
{
    int digitValue = int.Parse(digit.ToString());
    if (digitValue % 2 == 0)
    {
        oddDigits = false;
        break;
    }
}

if (oddDigits)
{
    Console.WriteLine("Contains only odd digits");
}
else
{
    Console.WriteLine("Contains not only odd digits");
}