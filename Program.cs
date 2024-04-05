namespace Working_with_LINQ_Method_Syntax
{
    internal class Program
    {
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
            public string Major { get; set; }
            public double Tuition { get; set; }
        }
        public class StudentClubs
        {
            public int StudentID { get; set; }
            public string ClubName { get; set; }
        }
        public class StudentGPA
        {
            public int StudentID { get; set; }
            public double GPA { get; set; }
        }
        static void Main(string[] args)
        {
            // Student collection
            IList < Student > studentList = new List < Student >() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };
            // Student GPA Collection
            IList < StudentGPA > studentGPAList = new List < StudentGPA >() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList < StudentClubs > studentClubList = new List < StudentClubs >() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };

            //Part A
            var a = studentGPAList.GroupBy(g => g.GPA);

            foreach(var group in a )
            {
                Console.WriteLine($"GPA {group.Key}:");
                foreach(var student in group)
                {
                    Console.WriteLine($"{student.StudentID}");
                }
                Console.WriteLine();
            }

            //Part B
            var b = studentClubList.OrderBy(c => c.ClubName).GroupBy(c => c.ClubName);

            foreach (var group in b)
            {
                Console.WriteLine($"Club Name {group.Key}:");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.StudentID}");
                }
                Console.WriteLine();
            }

            //Part C
            var c = studentGPAList.Count(g => g.GPA >= 2.5 && g.GPA <= 4.0);
            Console.WriteLine($"Number of Students with GPA's between 2.5 and 4.0: {c}");
            Console.WriteLine();

            //Part D
            var d = studentList.Average(a => a.Tuition);
            Console.WriteLine($"Average students tuition {d}");
            Console.WriteLine();

            //Part E
            var e = studentList.Max(a => a.Tuition);
            Student studentHigh = null;
            foreach (var student in studentList)
            {
                if (student.Tuition == e)
                {
                    studentHigh = student;
                }
            }
            if (studentHigh != null)
            {
                Console.WriteLine($"Name: {studentHigh.StudentName}, Major: {studentHigh.Major}, Tuition: {studentHigh.Tuition}");
                Console.WriteLine();
            }

            //Part F
            var f = studentList.Join(studentGPAList,
                                       s => s.StudentID,
                                       g => g.StudentID,
                                       (s, g) => new
                                       {
                                           s.StudentName,
                                           s.Major,
                                           g.GPA
                                       });

            foreach (var student in f)
            {
                Console.WriteLine($"Name: {student.StudentName}, Major: {student.Major}, GPA: {student.GPA}");
            }
            Console.WriteLine();

            //Part G
            var g = studentList.Join(studentClubList.Where(sc => sc.ClubName == "Game"),
                                          s => s.StudentID,
                                          sc => sc.StudentID,
                                          (s, sc) => s.StudentName);

            foreach (var studentName in g)
            {
                Console.WriteLine($"Student in Game Club: {studentName}");
            }


        }
    }
}
