using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Student : ArtSchoolEntity
    {
        //Primary Key
        public int StudentId { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double TuitionFees { get; set; }
        public Country Country { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public int Age => DateTime.Now.Year - DateOfBirth.Year;


        //Navigation Properties
        public virtual ICollection<Course> Courses { get; set; }


        //Constructors

        public Student()
        {
            Courses = new HashSet<Course>();

        }


        public Student(string firstName, string lastName, DateTime dateOfBirth, double tuitionFees, Country country)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
            Country = country;

        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, double tuitionFees, Course course)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
        }
    }
}
