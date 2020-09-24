using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _00._Code_first_demo.Data.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(3)]
        public int Age { get; set; }

        public DateTime RegistrationDate { get; set; }

        public StudentType Type { get; set; }


    }
}
