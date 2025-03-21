using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSCodeFirst.Models
{
    internal class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public short CreditHours { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
