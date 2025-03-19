using System;
using System.Collections.Generic;
using System.Linq;

namespace SMSModelFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new SMSModelDBContainer())
            {
                //// making 3 courses objects
                //var course1 = new Course
                //{
                //    CourseName = ".NET",
                //    CreditHours = 50
                //};
                //var course2 = new Course
                //{
                //    CourseName = "Java",
                //    CreditHours = 30
                //};
                //var course3 = new Course
                //{
                //    CourseName = "Python",
                //    CreditHours = 40
                //};
                //List<Course> courses = new List<Course> { course1, course2, course3 };
                //context.Courses.AddRange(courses); // adding courses to the database

                //// making 2 student objects
                //var student1 = new Student
                //{
                //    StudentName = "Panthee Patel",
                //    StudentAge = 20,
                //    Courses = new List<Course> { course1, course3 },
                //};
                //var student2 = new Student
                //{
                //    StudentName = "Himanshi Gandhi",
                //    StudentAge = 21,
                //    Courses = new List<Course> { course1, course2 },
                //};
                //List<Student> students = new List<Student> { student1, student2 };
                //context.Students.AddRange(students); // adding students to the database
                //context.SaveChanges(); // saving changes to the database

                //// getting student details from database
                //var studentDetails = context.Students.ToList();
                //foreach (var student in studentDetails)
                //{
                //    Console.WriteLine("Student Name: {0}", student.StudentName);
                //    foreach (var course in student.Courses) // getting navigational property(Courses) of student
                //    {
                //        Console.WriteLine("\tCourse Name: {0}", course.CourseName);
                //    }
                //    Console.WriteLine();
                //}

                //// editing details of student
                //var studentToEdit = context.Students.FirstOrDefault(s => s.StudentName == "Panthee Patel");
                //context.Students.Attach(studentToEdit);

                //if (studentToEdit != null)
                //{
                //    studentToEdit.StudentName = "Panthee Sharadbhai Patel";
                //    //context.Entry(studentToEdit).State = System.Data.Entity.EntityState.Modified;
                //    context.Entry(studentToEdit);
                //    context.SaveChanges();
                //}

                // deleting student
                var studentToDelete = context.Students.LastOrDefault(s => s.StudentName == "Panthee Sharadbhai Patel");
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
