using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOne.Models
{
    public class StudentRegistrationModel
    {
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentRollNumber { get; set; }

        [Required]
        public string StudentFatherName { get; set; }

        [Required]
        public string StudentMotherName { get; set; }
    }
}
