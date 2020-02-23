using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CS.Entities.DataTransferObjects
{
    public abstract class CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Company Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Country is a required field.")]
        public string Country { get; set; }

        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }
    }
}
