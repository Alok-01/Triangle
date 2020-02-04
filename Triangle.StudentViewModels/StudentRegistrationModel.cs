using System.ComponentModel.DataAnnotations;

namespace Triangle.StudentViewModels
{
    /// <summary>
    /// Student Registration View Model
    /// </summary>
    public class StudentRegistrationModel
    {
        /// <summary>
        /// Student Id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        [Required]
        public string StudentName { get; set; }

        /// <summary>
        /// Student Roll Number
        /// </summary>
        [Required]
        public string StudentRollNumber { get; set; }

        /// <summary>
        /// Student Father Name
        /// </summary>
        [Required]
        public string StudentFatherName { get; set; }

        /// <summary>
        /// Student Mother Name
        /// </summary>
        [Required]
        public string StudentMotherName { get; set; } = string.Empty;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
