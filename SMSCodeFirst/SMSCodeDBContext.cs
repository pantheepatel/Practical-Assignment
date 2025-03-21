using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SMSCodeFirst.Models;

namespace SMSCodeFirst
{
    internal class SMSCodeDBContext : DbContext
    {
        public SMSCodeDBContext() : base("name=SMSModelDBContainer")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SMSCodeDBContext>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasMany(s => s.Courses)
                        .WithMany(c => c.Students)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("Students_StudentId");
                            cs.MapRightKey("Course_CourseId");
                            cs.ToTable("StudentCourse");
                        });
            base.OnModelCreating(modelBuilder);
        }
    }
}
