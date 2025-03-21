using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSCodeFirst.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Range(1, 100)]
        [Required]
        public short StudentAge { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
