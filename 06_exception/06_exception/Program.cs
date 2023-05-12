namespace _06_exception
{
    internal class Program
    {
        //1
        int a, b;
        public void Div()
        {
            Console.WriteLine(a / b);
        }

        //3
        int[] numbers_array = new int[10];
        bool isValid;
        public void ReadNumber(int start, int end)
        {
            Console.WriteLine("\nEnter 10 numbers:");
            for (int i = 0; i < numbers_array.Length; i++)
            {
                do
                {
                    try
                    {
                        numbers_array[i] = int.Parse(Console.ReadLine());
                        isValid = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error! {ex.Message}\nEnter integer number:");
                        i--;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error! {ex.Message}");
                        i--;
                    }
                } while (!isValid);
            }

            Console.WriteLine();
            int previous_number = start - 1;
            for (int i = 0; i < numbers_array.Length; i++)
            {
                try
                {
                    if (numbers_array[i] > start && numbers_array[i] < end && numbers_array[i] > previous_number)
                    {
                        Console.Write(numbers_array[i] + " ");
                        previous_number = numbers_array[i];
                    }
                    else
                    {
                        throw new Exception($"{numbers_array[i]} is out of range ({start}, {end}) or less than {previous_number}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError! {ex.Message}");
                    do
                    {
                        Console.WriteLine($"Enter correct number:");
                        numbers_array[i] = int.Parse(Console.ReadLine());
                    } while (!(numbers_array[i] > start && numbers_array[i] < end && numbers_array[i] > previous_number));
                    Console.Write(numbers_array[i] + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            bool isValid = false;
            do
            {
                try
                {
                    Console.WriteLine("Enter 2 numbers:");
                    Program numbers = new Program() { a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine()) };
                    numbers.Div();
                    isValid = true;
                }
                //2
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error! {ex.Message}\nEnter integer numbers:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                }
            } while (!isValid);

            //3
            Program numbers_array = new Program();
            numbers_array.ReadNumber(1, 100);
        }
    }
}