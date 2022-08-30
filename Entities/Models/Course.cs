using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Course : ArtSchoolEntity
    {
        //Primary Key
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public CourseType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }

        //Constructors

        public Course()
        {

        }

        public Course(string title, string stream, CourseType type, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }
    }    
}
