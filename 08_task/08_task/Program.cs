using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace _08_task
{
    [Serializable]
    public class Person
        {
            public string Name { get; set; }
            public Person() { }
            public Person(string name)
            {
                this.Name = name;
            }

            public override string ToString()
            {
                return $"Name: {Name}";
            }

            public void Search(string searchName)
            {
                if (searchName == this.Name)
                {
                    ToString();
                }
            }
        }

    [Serializable]
    public class Staff : Person, IComparable<Staff>
        {
            public int Salary { get; set; }
            public Staff() { }
            public Staff(string name, int salary) : base(name)
            {
                this.Salary = salary;
            }

            public override string ToString()
            {
                return $"Person {Name} has salary: ${Salary}";
            }

            int IComparable<Staff>.CompareTo(Staff? other)
            {
                return Salary.CompareTo(other.Salary);
            }
        }

    [Serializable]
    public class Teacher : Staff
        {
            public Teacher() { }
            public string Subject { get; set; }
            public Teacher(string name, int salary, string subject) : base(name, salary)
            {
                this.Subject = subject;
            }

            public override string ToString()
            {
                return $"Teacher {Name} teachs {Subject} and has salary ${Salary}";
            }
        }

    [Serializable]
    public class Developer : Staff
        {
            public string Level { get; set; }
            public Developer() { }
            public Developer(string name, int salary, string level) : base(name, salary)
            {
                this.Level = level;
            }

            public override string ToString()
            {
                return $"Developer {Name} with level {Level} has salary ${Salary}";
            }
        }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Person person1 = new Person("Oleg");
            //person1.Print();

            Staff staff1 = new Staff("Igor", 200);
            //staff1.Print();

            person1 = new Staff("Ira", 300);
            //person1.Print();

            Teacher teacher = new Teacher("Andriy", 460, "OOP");

            List<Person> persons = new List<Person>
            {
                new Person("Nadya"),
                person1,
                staff1,
                teacher,
                new Teacher("Khrystyna", 280, "DB"),
                new Developer("Vlad", 2000, "Middle"),
                new Developer("Serhiy", 1300, "Junior")
                
            };

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher("Andriy", 460, "OOP"),
                new Teacher("Khrystyna", 280, "DB")

            };

            File.WriteAllText("persons.json", JsonSerializer.Serialize(persons));
            File.WriteAllText("teachers.json", JsonSerializer.Serialize(teachers));


            string jsonRead = File.ReadAllText("persons.json");
            List<Person>? personRead = JsonSerializer.Deserialize<List<Person>>(jsonRead);

            Console.WriteLine("Persons from JSON:");
            foreach(Person p in personRead)
            {
                Console.WriteLine(p.ToString());
            }

            jsonRead = File.ReadAllText("teachers.json");
            List<Teacher>? teacherRead = JsonSerializer.Deserialize<List<Teacher>>(jsonRead);

            Console.WriteLine("\nTeachers from JSON:");
            foreach (Teacher t in teacherRead)
            {
                Console.WriteLine(t.ToString());
            }

            XmlSerializer xml = new XmlSerializer(typeof(Teacher));

            using (FileStream fs = File.Create("teacher.xml"))
            {
                xml.Serialize(fs, teacher);
            }

            Teacher? teacherxml = null;

            using (FileStream fs = File.OpenRead("teacher.xml"))
            {
                teacherxml = xml.Deserialize(fs) as Teacher;
            }

            Console.WriteLine("\nTeacher from XML:");
            Console.WriteLine(teacher.ToString());

            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = File.Create("persons.bin"))
            {
                //in net7.0 exception: 'BinaryFormatter serialization is obsolete and should not be used.
                //See https://aka.ms/binaryformatter for more information.'

                //binary.Serialize(fs, persons);
            }

            /*Console.WriteLine("\nList of persons");
            foreach (Person p in persons)
            {
                p.Print();
            }

            Console.Write("\nEnter name for searching information: ");
            string searchName = Console.ReadLine();
            foreach (Person p in persons)
            {
                p.Search(searchName);
            }

            persons = persons.OrderBy(person => person.Name).ToList();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "Persons List.txt";
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter writer = File.CreateText(filePath))
            {
                foreach (Person p in persons)
                {
                    writer.WriteLine(p.Name);
                }
            }

            using (StreamReader reader = File.OpenText(filePath))
            {
                string allContent = reader.ReadToEnd();
                Console.WriteLine($"\nSorted persons:\n{allContent}");
            }

            List<Staff> employees = new List<Staff>();

            foreach (Person p in persons)
            {
                if (p is Teacher || p is Developer)
                {
                    employees.Add((Staff)p);
                }
            }

            employees.Sort();

            Console.WriteLine("List of sorted salaries:");
            foreach (Staff e in employees)
            {
                e.Print();
            }*/
        }
    }
}