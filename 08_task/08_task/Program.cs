namespace _08_task
{
    internal class Program
    {
        //1
        public class Person
        {
            private string name;
            public Person(string name)
            {
                this.name = name;
            }
            public string Name { get { return name; } }

            public virtual void Print()
            {
                Console.WriteLine("Name: {0}", this.name);
            }

            //4
            public void Search(string searchName)
            {
                if (searchName == this.Name)
                {
                    Print();
                }
            }
        }

        public class Staff : Person, IComparable<Staff>
        {
            private int salary;
            public int Salary { get { return salary; } }
            public Staff(string name, int salary) : base(name)
            {
                this.salary = salary;
            }

            public override void Print()
            {
                Console.WriteLine("Person {0} has salary: ${1}", Name, this.salary);
            }

            int IComparable<Staff>.CompareTo(Staff? other)
            {
                return Salary.CompareTo(other.Salary);
            }
        }

        //2
        public class Teacher : Staff
        {
            private string subject;
            public string Subject { get { return subject; } }
            public Teacher(string name, int salary, string subject) : base(name, salary)
            {
                this.subject = subject;
            }

            public override void Print()
            {
                Console.WriteLine($"Teacher {Name} teachs {this.subject} and has salary ${Salary}");
            }
        }

        public class Developer : Staff
        {
            private string level;
            public string Level { get { return level; } }
            public Developer(string name, int salary, string level) : base(name, salary)
            {
                this.level = level;
            }

            public override void Print()
            {
                Console.WriteLine($"Developer {Name} with level {this.level} has salary ${Salary}");
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person("Oleg");
            person1.Print();

            Staff staff1 = new Staff("Igor", 200);
            staff1.Print();

            person1 = new Staff("Ira", 300);
            person1.Print();

            //3
            List<Person> persons = new List<Person>
            {
                new Person("Nadya"),
                person1,
                staff1,
                new Teacher("Andriy", 460, "OOP"),
                new Teacher("Khrystyna", 280, "DB"),
                new Developer("Vlad", 2000, "Middle"),
                new Developer("Serhiy", 1300, "Junior")
                
            };

            Console.WriteLine("\nList of persons");
            foreach(Person p in persons)
            {
                p.Print();
            }

            //4
            Console.Write("\nEnter name for searching information: ");
            string searchName = Console.ReadLine();
            foreach (Person p in persons)
            {
                p.Search(searchName);
            }

            //5
            persons = persons.OrderBy(person => person.Name).ToList();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "Persons List.txt";
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using(StreamWriter writer = File.CreateText(filePath))
            {
                foreach (Person p in persons)
                {
                    writer.WriteLine(p.Name);
                }
            }

            using(StreamReader reader = File.OpenText(filePath))
            {
                string allContent = reader.ReadToEnd();
                Console.WriteLine($"\nSorted persons:\n{allContent}");
            }

            //6
            List<Staff> employees = new List<Staff>();

            foreach(Person p in persons)
            {
                if(p is Teacher || p is Developer)
                {
                    employees.Add((Staff)p);
                }
            }

            employees.Sort();

            Console.WriteLine("List of sorted salaries:");
            foreach(Staff e in employees)
            {
                e.Print();
            }
        }
    }
}