namespace _05_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> myColl = new List<int>() { };
            Console.WriteLine("Enter 10 numbers:");
            int size = 10;

            for (int i = 0; i < size; i++)
            {
                myColl.Add(int.Parse(Console.ReadLine()));
            }

            //1
            Console.Write("\nIndexes of -10: ");
            for (int i = 0; i < size; i++)
            {
                if(myColl[i] == -10)
                {
                    Console.Write($"{i} ");
                }
                else
                {
                    
                }
            }

            //2
            Console.WriteLine("\n\nRemoved elements greater than 20");
            for(int i = 0; i < size; i++)
            {
                myColl.RemoveAll(myColl => myColl > 20);
                --size;
            }

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }

            //3
            Console.WriteLine("\n\nAdded new elements");
            myColl.Insert(Math.Min(2, size), 1);
            ++size;

            myColl.Insert(Math.Min(8, size), -3);
            ++size;

            myColl.Insert(Math.Min(5, size), -4);
            ++size;

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }

            //4
            Console.WriteLine("\n\nSorted collection: ");
            myColl.Sort();

            foreach (int number in myColl)
            {
                Console.Write(number + " ");
            }
        }
    }
}