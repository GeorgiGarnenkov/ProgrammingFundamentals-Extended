namespace JsonStringify
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

    public class JsonStringify
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            string input;
            while ((input = Console.ReadLine()) != "stringify")
            {
                var commandArgs = input
                    .Split(new char[] {' ', ':', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Student student = new Student();

                student.Name = commandArgs[0];
                student.Age = int.Parse(commandArgs[1]);
                student.Grades = new List<int>();
                for (int i = 2; i < commandArgs.Length; i++)
                {
                    student.Grades.Add(int.Parse(commandArgs[i]));
                }
                students.Add(student);
            }
            var counter = 0;
            Console.Write("[");
            foreach (var student in students)
            {
                var name = student.Name;
                var age = student.Age;
                var grades = string.Join(", ", student.Grades);
                Console.Write(string.Join(",", $"{{name:\"{name}\"",$"age:{age}",
                    $"grades:[{grades}]}}"));
                counter++;
                if (counter != students.Count)
                {
                    Console.Write(",");
                }
                else
                {
                    Console.Write("");
                }
            }
            Console.WriteLine("]");     
        }
    }
}
