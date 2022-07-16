namespace Sample
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class StudentTeamA
    {
        public List<Student> Students { get; private set; }
        public StudentTeamA()
        {
            Students = new List<Student>();
        }
        public StudentTeamA(IEnumerable<Student> studentList) : this()
        {
            Students.AddRange(studentList);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var listStudent = new List<Student>();

            StudentTeamA teamA2 = new StudentTeamA();

            teamA2.Students.Add(new Student() { Name = "Steve", Age = 3 });

            teamA2.Students.AddRange(listStudent);

            Console.WriteLine(teamA2.Students.Count);

            //也可以像下面这样实现

            StudentTeamA teamA3 = new StudentTeamA(listStudent);

            Console.WriteLine(teamA3.Students.Count);
        }
    }
}