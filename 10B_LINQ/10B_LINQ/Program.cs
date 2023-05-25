namespace _10B_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "text.txt";
            string filePath = Path.Combine(path, fileName);
            string[] lines = File.ReadAllLines(filePath);

            for(int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(i + " " + lines[i]);
            }

            //1
            Console.WriteLine("\nCount symbols in lines:");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"{i} line has {lines[i].Count()}");
            }

            //2
            Console.WriteLine($"The longest line is:\n{lines.OrderByDescending(l => l.Length).FirstOrDefault()}");
            Console.WriteLine($"The shortest line is:\n{lines.OrderBy(l => l.Length).FirstOrDefault()}");

            //3
            var linesVar = lines.Where(l => l.Contains("var"));
            Console.WriteLine("\nLines which contains 'var'");

            foreach(var l in linesVar)
            {
                Console.WriteLine(l);
            }
        }
    }
}