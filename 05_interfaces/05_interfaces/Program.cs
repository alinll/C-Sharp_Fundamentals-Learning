namespace _05_interfaces
{
    //1
    interface IDeveloper: IComparable<IDeveloper>
    {
        string Tool { get; set; }
        void Create();
        void Destroy();
    }

    //2
    class Programmer : IDeveloper
    {
        public string Language { get; set; }
        public string Tool { get; set; }

        public int CompareTo(IDeveloper? other)
        {
            return string.Compare(Tool, other.Tool);
        }

        public void Create()
        {
            Console.WriteLine($"Programmer writing a code on {Language} using {Tool}");
        }
        public void Destroy()
        {
            Console.WriteLine($"Programmer deleting a code on {Language} using {Tool}\n");
        }

        public override string ToString()
        {
            return $"Programmer create on {Language} with {Tool}";
        }
    }

    class Builder : IDeveloper
    {
        public string DestroingTool { get; set; }
        public string Tool { get; set; }

        public int CompareTo(IDeveloper? other)
        {
            return string.Compare(Tool, other.Tool);
        }

        public void Create()
        {
            Console.WriteLine($"Builder building with {Tool}");
        }
        public void Destroy()
        {
            Console.WriteLine($"Builder demolishing with {DestroingTool}\n");
        }

        public override string ToString()
        {
            return $"Builder build with {Tool} and destroy with {DestroingTool}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //3
            List<IDeveloper> developers = new List<IDeveloper>
            {
                new Programmer() {Language = "C#", Tool = "Visual Studio"},
                new Programmer() {Language = "JavaScript", Tool = "Visual Studio Code"},
                new Programmer() {Language = "C++", Tool = "Visual Studio"},
                new Builder() {Tool = "nails", DestroingTool = "ax"},
                new Builder() {Tool = "hammer", DestroingTool = "sledgehammer"}
            };
            
            foreach(IDeveloper dev in developers)
            {
                dev.Create();
                dev.Destroy();
            }

            //4
            developers.Sort();

            Console.WriteLine("Sorted list of developers:");
            foreach (IDeveloper dev in developers)
            {
                Console.WriteLine(dev);
            }
        }
    }
}