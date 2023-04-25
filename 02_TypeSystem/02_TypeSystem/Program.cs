using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        //1
        Console.WriteLine("Enter 3 numbers: ");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        if (a >= -5.0 && a <= 5.0 || b >= -5.0 && b <= 5.0 || c >= -5.0 && c <= 5.0)
        {
            Console.WriteLine("Entered data is in the range [-5;5]");
        }
        else
        {
            Console.WriteLine("Entered data isn't in the range [-5;5]");
        }

        //2
        if (a > b && a > c)
        {
            Console.WriteLine($"{a} is max");
        }
        else if (b > a && b > c)
        {
            Console.WriteLine($"{b} is max");
        }
        else
        {
            Console.WriteLine($"{c} is max");
        }

        if (a < b && a < c)
        {
            Console.WriteLine($"{a} is min");
        }
        else if (b < a && b < c)
        {
            Console.WriteLine($"{b} is min");
        }
        else
        {
            Console.WriteLine($"{c} is min");
        }

        //3
        Console.Write("Choose error 400-401: ");
        HTTPError error = Enum.Parse<HTTPError>(Console.ReadLine());
        if(error == HTTPError.first)
        {
            Console.WriteLine($"{HTTPError.first} error - 400");
        }
        if (error == HTTPError.second)
        {
            Console.WriteLine($"{HTTPError.second} error - 401");
        }
        else
        {
            Console.WriteLine("Haven't such error");
        }

        //4
        Dog myDog = new Dog()
        {
            name = "Scooby-Doo",
            mark = "great dane",
            age = 17
        };
        Console.WriteLine(myDog);
    }
}

//3
enum HTTPError { first = 400, second = 401 }

//4
struct Dog
{
    public string name { get; set; }
    public string mark { get; set; }
    public int age { get; set; }
    public override string ToString()
    {
        return $"{name}'s mark is {mark}, age - {age}";
    }
}