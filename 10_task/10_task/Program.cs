using System.Linq;

namespace _10_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            int size = 10;
            int[] numbers = new int[size];
            Random random = new Random();

            for(int i = 0; i < size; ++i)
            {
                numbers[i] = random.Next(-100, 101);
            }

            Console.WriteLine("Numbers:");
            for (int i = 0; i < size; ++i)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine("\n");

            //2
            var negative = numbers.Where(n => n < 0);

            Console.WriteLine("Negative numbers:");
            foreach (int num in negative)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            //3
            var positive = numbers.Where(n => n >= 0);

            Console.WriteLine("Positive numbers:");
            foreach (int num in positive)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            //4
            var max = numbers.Max();

            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {numbers.Min()}");
            Console.WriteLine($"Sum number: {numbers.Sum()}");

            //5
            var average = numbers.Average();
            Console.WriteLine($"\nAverage number: {average}");
            var maxBeforeAverage = numbers.Where(n => n < average).OrderByDescending(n => n).FirstOrDefault();
            Console.WriteLine($"Max number before average: {maxBeforeAverage}\n");

            //6
            var sort = numbers.OrderBy(n => n);
            Console.WriteLine($"Sorted numbers:");
            foreach (int num in sort)
            {
                Console.Write(num + " ");
            }
        }
    }
}