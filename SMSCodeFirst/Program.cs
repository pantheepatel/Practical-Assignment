using SMSCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SMSCodeDBContext context = new SMSCodeDBContext())
            {
                //making 3 courses objects
                var course1 = new Course
                {
                    CourseName = ".NET",
                    CreditHours = 50
                };
                var course2 = new Course
                {
                    CourseName = "Java",
                    CreditHours = 30
                };
                var course3 = new Course
                {
                    CourseName = "Python",
                    CreditHours = 40
                };
                List<Course> courses = new List<Course> { course1, course2, course3 };
                context.Courses.AddRange(courses); // adding courses to the database

                // making 2 student objects
                var student1 = new Student
                {
                    StudentName = "Panthee Patel",
                    StudentAge = 20,
                    Courses = new List<Course> { course1, course3 },
                };
                var student2 = new Student
                {
                    StudentName = "Himanshi Gandhi",
                    StudentAge = 21,
                    Courses = new List<Course> { course1, course2 },
                };
                List<Student> students = new List<Student> { student1, student2 };

                // CREATE Operation
                context.Students.AddRange(students); // adding students to the database
                context.SaveChanges(); // saving changes to the database
                Console.WriteLine("Added");

                // READ Operation
                //// getting student details from database
                //var studentDetails = context.Students.ToList();
                //Console.WriteLine(studentDetails);
                //foreach (var student in studentDetails)
                //{
                //    Console.WriteLine("Student Name: {0}", student.StudentName);
                //    foreach (var course in student.Courses) // getting navigational property(Courses) of student
                //    {
                //        Console.WriteLine("\tCourse Name: {0}", course.CourseName);
                //    }
                //    Console.WriteLine();
                //}

                // UPDATE Operation
                //// editing details of student
                //var studentToEdit = context.Students.FirstOrDefault(s => s.StudentName == "Panthee Patel");
                //context.Students.Attach(studentToEdit);

                //if (studentToEdit != null)
                //{
                //    studentToEdit.StudentName = "Panthee Sharadbhai Patel";
                //    //context.Entry(studentToEdit).State = System.Data.Entity.EntityState.Modified;
                //    context.Entry(studentToEdit);
                //    context.SaveChanges();
                //    Console.WriteLine("Edited record");
                //}

                // DELETE Operation
                //// deleting student
                //var studentToDelete = context.Students.Include("Courses").FirstOrDefault(s => s.StudentName == "Himanshi Gandhi");
                //if (studentToDelete != null)
                //{
                //    // Remove associated courses (clearing join table entries)
                //    studentToDelete.Courses.Clear();
                //    context.SaveChanges();

                //    context.Students.Remove(studentToDelete);
                //    context.SaveChanges();
                //    Console.WriteLine("Student deleted");
                //}

            }
        }
    }
}
