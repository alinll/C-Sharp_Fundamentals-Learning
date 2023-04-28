//1
Console.Write("Enter some string: ");
string str = Console.ReadLine();
int aCount = 0;
int oCount = 0;
int iCount = 0;
int eCount = 0;

foreach(char counter in str)
{
    switch (counter)
    {
        case 'a': ++aCount; break;
        case 'o': ++oCount; break;
        case 'i': ++iCount; break;
        case 'e': ++eCount; break;
        default: break;
    }
}

Console.WriteLine($"Counts of characters:\n" +
    $"count a: {aCount}\n" +
    $"count o: {oCount}\n" +
    $"count i: {iCount}\n" +
    $"count e: {eCount}");

//2
Console.Write("Enter a month: ");
int month = int.Parse(Console.ReadLine());
int days;

switch (month)
{
    case 01:
    case 03:
    case 05:
    case 07:
    case 08:
    case 10:
    case 12:
        days = 31; 
        Console.WriteLine($"{month} month has {days} days"); 
        break;
    case 02: 
        Console.WriteLine("Enter a year:");
        int year = int.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
        {
            days = 29;
        }
        else
        {
            days = 28;
        }
        Console.WriteLine($"{month} month has {days} days");
        break;
    case 04:
    case 06:
    case 09:
    case 11:
        days = 30;
        Console.WriteLine($"{month} month has {days} days");
        break;
    default: Console.WriteLine("Isn't a month"); break;
}

//3
Console.WriteLine("Enter 10 numbers: ");
int size = 10;
int[] numbers = new int[size];
int sum = 0;
int count = 0;
int product = 1;

for(int i = 0; i < size; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

for(int i = 0; i < 5; i++)
{
    if (numbers[i] > 0)
    {
        sum += numbers[i];
        ++count;
    }
}

if(count == 5)
{
    Console.WriteLine($"Sum of the first 5 positive numbers: {sum}");
}
else
{
    for(int i = 5; i < size; i++)
    {
        product *= numbers[i];
    }
    Console.WriteLine($"Product of last 5 numbers: {product}");
}