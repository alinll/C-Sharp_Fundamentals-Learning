namespace _09_delegates_event
{
    //1
    public delegate void MyDel(int m);

    //2
    class Student
    {
        private string name;
        private List<int> marks;

        public string Name { get { return name; } set { name = value; } }
        public List<int> Marks { get { return marks; } set { marks = value; } }

        public Student(string name)
        {
            this.name = name;
        }

        public event MyDel MarkChange;
        public void AddMark(int m)
        {
            marks?.Add(m);

            if(MarkChange != null)
            {
                Console.WriteLine("Somebody see your mark");
            }
            else
            {
                Console.WriteLine("Nobody see your mark");
            }

            MarkChange?.Invoke(m);
        }
    }

    //5
    class Accountancy
    {
        public void PayingFellowship(int m)
        {
            if(m >= 90)
            {
                Console.WriteLine("Student will have a scholarship\n");
            }
            else
            {
                Console.WriteLine("Student woun't have a scholarship\n");
            }
        }
    }

    //3
    class Parent
    {
        public void OnMarkChange(int m)
        {
            Console.WriteLine(m);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //4
            Student student = new Student("Alina");
            Parent parent = new Parent();
            Accountancy accountancy = new Accountancy();

            student.MarkChange += parent.OnMarkChange;
            //5
            student.MarkChange += accountancy.PayingFellowship;

            student.AddMark(89);
            student.AddMark(100);

        }
    }
}