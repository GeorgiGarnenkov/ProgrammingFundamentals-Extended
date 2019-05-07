namespace JsonParse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<int> Grades { get; set; }

    }

    public class JsonParse
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { "},{" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Student> students = new List<Student>();
            
            for (int i = 0; i < input.Length; i++)
            {
                var tempStud = input[i]
                    .Split(new[] { "\"", ":", ",", "}", "{", "]", "[", "grades", "name", "age" },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                Student student = new Student();
                student.Name = tempStud[0];
                student.Age = int.Parse(tempStud[1]);
                student.Grades = new List<int>();
                for (int j = 2; j < tempStud.Length; j++)
                {
                    student.Grades.Add(int.Parse(tempStud[j]));
                }
                students.Add(student);
            }
            foreach (var student in students)
            {
                if (student.Grades.Count == 0)
                {
                    Console.WriteLine($"{student.Name} : {student.Age} -> None");
                }
                else
                {
                    Console.WriteLine($"{student.Name} : {student.Age} -> {string.Join(", ", student.Grades)}");
                }
            }
        }
    }
}
