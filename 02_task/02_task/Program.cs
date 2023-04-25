using System.ComponentModel;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        //Task 1
        Console.Write("Enter a day: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter a month: ");
        int month = int.Parse(Console.ReadLine());

        if (month < 1 || month > 12)
        {
            Console.WriteLine("Entered data isn't a month");
        }

        else if (day < 1 || day > DateTime.DaysInMonth(DateTime.Now.Year, month))
        {
            Console.WriteLine("Entered data isn't a day");
        }

        else
        {
            Console.WriteLine("Entered data is in the correct format");
        }

        //Task 2
        Console.Write("Enter double number: ");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine($"Entered number is: {number}");
        int digits = (int)(number * 100) % 100;
        Console.WriteLine($"First 2 digits after double point : {digits}");
        Console.WriteLine($"Sum: {digits / 10 + digits % 10}");

        //Task 3
        Console.Write("Enter a hour: ");
        int h = int.Parse(Console.ReadLine());
        if (h < 0 || h > 23)
        {
            Console.WriteLine("Entered data isn't a hour");
        }
        else if (h >= 6 && h < 12)
        {
            Console.WriteLine("Good morning!");
        }
        else if (h >= 12 && h < 18)
        {
            Console.WriteLine("Good afternoon!");
        }
        else if (h >= 18 && h <= 23)
        {
            Console.WriteLine("Good evening!");
        }
        else
        {
            Console.WriteLine("Good night!");
        }

        //Task 4

        TestCaseStatus test1Status = TestCaseStatus.Pass;
        Console.WriteLine($"value: {test1Status}");

        //Task 5
        RGB white = new RGB()
        {
            red = 255,
            green = 255,
            blue = 255
        };
        RGB black = new RGB()
        {
            red = 0,
            green = 0,
            blue = 0
        };
        Console.WriteLine($"White RGB has red:{white.red}, green:{white.green}, blue:{white.blue}");
        Console.WriteLine($"Black RGB has red:{black.red}, green:{black.green}, blue:{black.blue}");
    }
}

//Task 4
enum TestCaseStatus { Pass, Fail, Blocked, WP, Unexecuted }

//Task 5
struct RGB
{
    public byte red, green, blue;
}