using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Trainer : ArtSchoolEntity
    {
        //Primary Key
        public int TrainerId { get; set; }
        //Foreign Key
        public int CourseId { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(100), MinLength(5)]
        public string Subject { get; set; }
        public string PhotoUrl { get; set; }
        [Range(0, 50000)]

        public decimal Salary { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        //Navigation Properties
        public Course Course { get; set; }

        //Constructors
        public Trainer()
        {

        }

        public Trainer(string firstName, string lastName, string subject, string photoUrl, decimal salary, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
            PhotoUrl = photoUrl;  
            Salary = salary;
            Phone = phone;
        }
    }
}
