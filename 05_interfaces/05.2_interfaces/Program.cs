namespace _05._2_interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            //2
            int size = 7;
            Console.WriteLine("Enter ID and name for 7 persons");
            for (int i = 0; i < size; i++)
            {
                uint id = uint.Parse(Console.ReadLine());
                if (dictionary.ContainsKey(id))
                {
                    Console.WriteLine("This ID already exists. Enter other ID");
                    i--;
                    continue;
                }
                string name = Console.ReadLine();
                dictionary.Add(id, name);
            }

            foreach(KeyValuePair<uint, string> pair in dictionary)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }

            //3
            Console.Write("\nEnter ID to find a name: ");
            uint searchedId = uint.Parse(Console.ReadLine());
            if (dictionary.ContainsKey(searchedId))
            {
                Console.WriteLine(dictionary[searchedId]);
            }
            else
            {
                Console.WriteLine("Such ID isn't in the list");
            }
        }
    }
}