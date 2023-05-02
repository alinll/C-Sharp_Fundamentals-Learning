namespace _04_classes
{
    class Person
    {
        //a
        string name;
        DateTime birthYear;

        //b
        public string Name
        {
            get { return name; }
        }
        public DateTime BirthYear
        {
            get { return birthYear; }
        }

        //c
        public Person()
        {
            name = "No name";
            birthYear = DateTime.MinValue;
        }
        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }

        //d
        int age;
        public void Age()
        {
            DateTime today = DateTime.Today;
            age = today.Year - birthYear.Year;
            if(birthYear > today.AddYears(-age))
            {
                --age;
            }
        }

        public void Input()
        {
            Console.Write("Enter a name: ");
            name = Console.ReadLine();

            Console.Write("Enter birthday date: ");
            birthYear = DateTime.Parse(Console.ReadLine());
        }

        public void ChangeName()
        {
            if (age < 16)
            {
                name = "Very Young";
            }
        }

        public override string ToString()
        {
            return $"{name} is {age} years old. Birthday is {birthYear.ToShortDateString()}";
        }

        public void Output()
        {
            Console.WriteLine(this.ToString());
        }

        public static bool operator == (Person person1, Person person2)
        {
            return person1.name == person2.name;
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return person1.name != person2.name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            int size = 6;
            Person[] persons = new Person[size];
            for(int i = 0; i < size; i++)
            {
                persons[i] = new Person();
                persons[i].Input();
            }

            //2
            Console.WriteLine();
            for(int i = 0; i < size; i++)
            {
                persons[i].Age();
                persons[i].Output();
            }

            //3
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                persons[i].ChangeName();

                //4
                persons[i].Output();
            }

            //5
            Console.WriteLine("\nPersons with the same names:");
            for (int i = 0; i < size; i++)
            {
                for(int j = i + 1; j < size; j++)
                {
                    if (persons[i] == persons[j])
                    {
                        Console.WriteLine($"{persons[i]} has the same name as {persons[j]}");
                    }
                }
            }
        }
    }
}